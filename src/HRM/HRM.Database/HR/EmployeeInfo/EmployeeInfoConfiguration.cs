using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Database.HR
{
    public sealed class EmployeeInfoConfiguration : IEntityTypeConfiguration<EmployeeInfo>
    {
        public void Configure(EntityTypeBuilder<EmployeeInfo> builder)
        {
            builder.ToTable(nameof(EmployeeInfo), MessageConstant.SchemaName);

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.EmployeeId).IsRequired();
            builder.HasOne(m => m.Employee);

            builder.Property(m => m.FullName).HasMaxLength(70).IsRequired();

            builder.Property(m => m.Gender).IsRequired();

            builder.Property(m => m.DateOfBirth);

            builder.Property(m => m.MaritalStatusId);
            builder.HasOne(m => m.MaritalStatus)
                   .WithMany(ms => ms.EmployeeInfos)
                   .HasForeignKey(m => m.MaritalStatusId)
                   .HasConstraintName("FK_EmployeeInfo_MaritalStatusId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.ReligionId);
            builder.HasOne(m => m.Religion)
                   .WithMany(ms => ms.EmployeeInfos)
                   .HasForeignKey(m => m.ReligionId)
                   .HasConstraintName("FK_EmployeeInfo_ReligionId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.EthnicityId);
            builder.HasOne(m => m.Ethnicity)
                   .WithMany(ms => ms.EmployeeInfos)
                   .HasForeignKey(m => m.EthnicityId)
                   .HasConstraintName("FK_EmployeeInfo_EthnicityId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.NationalityId);
            builder.HasOne(m => m.Nationality)
                   .WithMany(ms => ms.EmployeeInfos)
                   .HasForeignKey(m => m.NationalityId)
                   .HasConstraintName("FK_EmployeeInfo_NationalityId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.AcademicLevelId);

            builder.Property(m => m.ProfessionalQualificationId);
            builder.HasOne(m => m.ProfessionalQualification)
                   .WithMany(ms => ms.EmployeeInfos)
                   .HasForeignKey(m => m.ProfessionalQualificationId)
                   .HasConstraintName("FK_EmployeeInfo_ProfessionalQualificationId")
                   .OnDelete(DeleteBehavior.Restrict);

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
