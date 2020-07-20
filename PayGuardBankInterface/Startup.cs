using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PayGuardBankInterface.Services;

namespace PayGuardBankInterface
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //point to the authetication server
            services.AddAuthentication("Bearer")
           .AddIdentityServerAuthentication(x =>
           {
               x.Authority = Globals.auth_end_point;
               x.ApiName = "api";
               x.RequireHttpsMetadata = false;
               x.Validate();
           });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "PayGuardBankInterface",
                    Description = "PayGuard Bank Interface",
                    TermsOfService = new Uri("https://softrite.co.zw"),
                    Contact = new OpenApiContact() { Name = "Mike Garden", Email = "support@softrite.co.zw", Url = new Uri("https://softrite.co.zw/") },
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                });
            });


            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
                c.AddPolicy("AllowMethod", options => options.AllowAnyMethod());
                c.AddPolicy("AllowHeader", options => options.AllowAnyHeader());
            });


            services.AddSingleton<ITimerBulkPaymentsForwardingToRbz, sTimerBulkPaymentsForwardingToRbz>();//add the timer service scheduler as a singleton

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();//show errors
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "PayGuard V1");
                c.OAuthClientId("api");
                c.OAuthAppName("api");
            });
            app.UseStaticFiles();
            app.UseCors(x => x
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());
            app.UseAuthentication();
            app.UseMvc();
            var app_name = env.ApplicationName;
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(app_name);
            });
        }
    }
}
