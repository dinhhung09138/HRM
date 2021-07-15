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
            builder.HasOne(m => m.MaritalStatus).WithMany()
                   .HasForeignKey(m => m.MaritalStatusId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.ReligionId);
            builder.HasOne(m => m.Religion).WithMany()
                   .HasForeignKey(m => m.ReligionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.EthnicityId);
            builder.HasOne(m => m.Ethnicity).WithMany()
                   .HasForeignKey(m => m.EthnicityId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.NationalityId);
            builder.HasOne(m => m.Nationality).WithMany()
                   .HasForeignKey(m => m.NationalityId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.AcademicLevelId);

            builder.Property(m => m.ProfessionalQualificationId);
            builder.HasOne(m => m.ProfessionalQualification).WithMany()
                   .HasForeignKey(m => m.ProfessionalQualificationId)
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
