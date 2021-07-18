using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Database.HR
{
    public sealed class EmployeeCertificateConfiguration : IEntityTypeConfiguration<EmployeeCertificate>
    {
        public void Configure(EntityTypeBuilder<EmployeeCertificate> builder)
        {
            builder.ToTable(nameof(EmployeeCertificate), MessageConstant.SchemaName);

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.EmployeeId).IsRequired();
            builder.HasOne(m => m.Employee)
                   .WithMany(e => e.EmployeeCertificates)
                   .HasForeignKey(m => m.EmployeeId)
                   .HasConstraintName("FK_EmployeeCertificate_EmployeeId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.CertificatedId).IsRequired();
            builder.HasOne(m => m.Certificated)
                   .WithMany(s => s.EmployeeCertificates)
                   .HasForeignKey(m => m.CertificatedId)
                   .HasConstraintName("FK_EmployeeCertificate_CertificatedId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.SchoolId).IsRequired();
            builder.HasOne(m => m.School)
                   .WithMany(s => s.EmployeeCertificates)
                   .HasForeignKey(m => m.SchoolId)
                   .HasConstraintName("FK_EmployeeCertificate_SchoolId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Year).IsRequired();

            builder.Property(m => m.IsActive).IsRequired();

            builder.Property(m => m.CreateBy).IsRequired();

            builder.Property(m => m.CreateDate).IsRequired();

            builder.Property(m => m.UpdateBy);

            builder.Property(m => m.UpdateDate);

            builder.Property(m => m.Deleted).IsRequired();

            builder.Property(m => m.RowVersion).IsRowVersion();

        }
    }
}
