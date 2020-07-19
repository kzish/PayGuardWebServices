using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PayGuardBankInterface.Models
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

        public virtual DbSet<MBank> MBank { get; set; }
        public virtual DbSet<MBulkPaymentsIncoming> MBulkPaymentsIncoming { get; set; }
        public virtual DbSet<MBulkPaymentsIncomingRecipients> MBulkPaymentsIncomingRecipients { get; set; }
        public virtual DbSet<MErrors> MErrors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=localhost;database=PayGuardBankInterface;User Id=sa;Password=123abc;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

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

            modelBuilder.Entity<MBulkPaymentsIncoming>(entity =>
            {
                entity.ToTable("m_bulk_payments_incoming");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountNumber).HasColumnName("account_number");

                entity.Property(e => e.AspNetUserId)
                    .IsRequired()
                    .HasColumnName("asp_net_user_id")
                    .HasMaxLength(450);

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.DateCreatedAtClient)
                    .HasColumnName("date_created_at_client")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatePosted)
                    .HasColumnName("date_posted")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateProcessed)
                    .HasColumnName("date_processed")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdAtClient).HasColumnName("id_at_client");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasColumnName("reference")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<MBulkPaymentsIncomingRecipients>(entity =>
            {
                entity.ToTable("m_bulk_payments_incoming_recipients");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BulkPaymentId).HasColumnName("bulk_payment_id");

                entity.Property(e => e.IdAtClient).HasColumnName("id_at_client");

                entity.Property(e => e.MBulkPaymentsIncomingId).HasColumnName("m_bulk_payments_incoming_id");

                entity.Property(e => e.RecipientAccountNumber)
                    .IsRequired()
                    .HasColumnName("recipient_account_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecipientAmount)
                    .HasColumnName("recipient_amount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RecipientBankSwiftCode)
                    .IsRequired()
                    .HasColumnName("recipient_bank_swift_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecipientName)
                    .IsRequired()
                    .HasColumnName("recipient_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.MBulkPaymentsIncoming)
                    .WithMany(p => p.MBulkPaymentsIncomingRecipients)
                    .HasForeignKey(d => d.MBulkPaymentsIncomingId)
                    .HasConstraintName("FK_m_bulk_payment_incoming_recipients_m_bulk_payment_incoming");
            });

            modelBuilder.Entity<MErrors>(entity =>
            {
                entity.ToTable("m_errors");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

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
