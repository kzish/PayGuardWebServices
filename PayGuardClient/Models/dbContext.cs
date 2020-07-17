using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PayGuardClient.Models
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<MBank> MBank { get; set; }
        public virtual DbSet<MClient> MClient { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=localhost;database=payguard;User Id=sa;Password=123abc;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<MBank>(entity =>
            {
                entity.ToTable("m_bank");

                entity.HasIndex(e => e.Id)
                    .HasName("unique_swift_code")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasColumnName("bank_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndPoint)
                    .HasColumnName("end_point")
                    .HasColumnType("text");

                entity.Property(e => e.SwiftCode)
                    .IsRequired()
                    .HasColumnName("swift_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MClient>(entity =>
            {
                entity.HasKey(e => e.AspNetUserId);

                entity.ToTable("m_client");

                entity.HasIndex(e => e.ClientOrganizationName)
                    .HasName("unique_organization_name")
                    .IsUnique();

                entity.Property(e => e.AspNetUserId)
                    .HasColumnName("asp_net_user_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BankAccountName)
                    .HasColumnName("bank_account_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BankAccountNumber)
                    .HasColumnName("bank_account_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BankBranchCode)
                    .HasColumnName("bank_branch_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientOrganizationName)
                    .IsRequired()
                    .HasColumnName("client_organization_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactEmail)
                    .IsRequired()
                    .HasColumnName("contact_email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactMobile)
                    .IsRequired()
                    .HasColumnName("contact_mobile")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .IsRequired()
                    .HasColumnName("contact_person")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EBankCode).HasColumnName("e_bank_code");

                entity.HasOne(d => d.EBankCodeNavigation)
                    .WithMany(p => p.MClient)
                    .HasForeignKey(d => d.EBankCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_m_client_m_bank");
            });
        }
    }
}
