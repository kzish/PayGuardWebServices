using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PayGuardRbzInterface.Models
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

        public virtual DbSet<MAccountCreditInstructions> MAccountCreditInstructions { get; set; }
        public virtual DbSet<MBank> MBank { get; set; }
        public virtual DbSet<MErrors> MErrors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=localhost;database=PayGuardrbzINterface;User Id=sa;Password=123abc;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<MAccountCreditInstructions>(entity =>
            {
                entity.ToTable("m_account_credit_instructions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecipientAccountNumber)
                    .HasColumnName("recipient_account_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecipientBankCode)
                    .HasColumnName("recipient_bank_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasColumnName("reference")
                    .IsUnicode(false);

                entity.Property(e => e.SenderAccountNumber)
                    .IsRequired()
                    .HasColumnName("sender_account_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SenderBankCode)
                    .IsRequired()
                    .HasColumnName("sender_bank_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MBank>(entity =>
            {
                entity.ToTable("m_bank");

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

            modelBuilder.Entity<MErrors>(entity =>
            {
                entity.ToTable("m_errors");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data1)
                    .HasColumnName("data1")
                    .IsUnicode(false);

                entity.Property(e => e.Data2)
                    .HasColumnName("data2")
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");
            });
        }
    }
}
