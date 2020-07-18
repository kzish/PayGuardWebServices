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
        public virtual DbSet<MBulkPayments> MBulkPayments { get; set; }
        public virtual DbSet<MBulkPaymentsRecipients> MBulkPaymentsRecipients { get; set; }
        public virtual DbSet<MCompany> MCompany { get; set; }
        public virtual DbSet<MErrors> MErrors { get; set; }
        public virtual DbSet<MUsers> MUsers { get; set; }

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
                    .IsRequired()
                    .HasColumnName("end_point")
                    .HasColumnType("text");

                entity.Property(e => e.Online).HasColumnName("online");

                entity.Property(e => e.SwiftCode)
                    .IsRequired()
                    .HasColumnName("swift_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MBulkPayments>(entity =>
            {
                entity.ToTable("m_bulk_payments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AspNetUserId)
                    .IsRequired()
                    .HasColumnName("asp_net_user_id")
                    .HasMaxLength(450);

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateLastSubmitted)
                    .HasColumnName("date_last_submitted")
                    .HasColumnType("datetime");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasColumnName("reference")
                    .HasColumnType("text");

                entity.HasOne(d => d.AspNetUser)
                    .WithMany(p => p.MBulkPayments)
                    .HasForeignKey(d => d.AspNetUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_m_bulk_payments_AspNetUsers");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.MBulkPayments)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_m_bulk_payments_m_company");
            });

            modelBuilder.Entity<MBulkPaymentsRecipients>(entity =>
            {
                entity.ToTable("m_bulk_payments_recipients");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BulkPaymentId).HasColumnName("bulk_payment_id");

                entity.Property(e => e.ERecipientBankId).HasColumnName("e_recipient_bank_id");

                entity.Property(e => e.RecipientAccountNumber)
                    .IsRequired()
                    .HasColumnName("recipient_account_number")
                    .HasMaxLength(10);

                entity.Property(e => e.RecipientAmount)
                    .HasColumnName("recipient_amount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RecipientName)
                    .IsRequired()
                    .HasColumnName("recipient_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ERecipientBank)
                    .WithMany(p => p.MBulkPaymentsRecipients)
                    .HasForeignKey(d => d.ERecipientBankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_m_bulk_payments_recipients_m_bank");
            });

            modelBuilder.Entity<MCompany>(entity =>
            {
                entity.ToTable("m_company");

                entity.HasIndex(e => e.CompanyName)
                    .HasName("unique_organization_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BankAccountName)
                    .IsRequired()
                    .HasColumnName("bank_account_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BankAccountNumber)
                    .IsRequired()
                    .HasColumnName("bank_account_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BankBranchCode)
                    .IsRequired()
                    .HasColumnName("bank_branch_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("company_name")
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
                    .WithMany(p => p.MCompany)
                    .HasForeignKey(d => d.EBankCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_m_company_m_bank");
            });

            modelBuilder.Entity<MErrors>(entity =>
            {
                entity.ToTable("m_errors");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data1)
                    .HasColumnName("data1")
                    .HasColumnType("text");

                entity.Property(e => e.Data2)
                    .HasColumnName("data2")
                    .HasColumnType("text");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MUsers>(entity =>
            {
                entity.HasKey(e => e.AspNetUserId);

                entity.ToTable("m_users");

                entity.Property(e => e.AspNetUserId)
                    .HasColumnName("asp_net_user_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AspNetUser)
                    .WithOne(p => p.MUsers)
                    .HasForeignKey<MUsers>(d => d.AspNetUserId)
                    .HasConstraintName("FK_m_users_AspNetUsers");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.MUsers)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_m_users_m_company");
            });
        }
    }
}
