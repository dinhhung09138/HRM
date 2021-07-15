using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Database.HR
{
    public sealed class EmployeeEducationConfiguration : IEntityTypeConfiguration<EmployeeEducation>
    {
        public void Configure(EntityTypeBuilder<EmployeeEducation> builder)
        {
            builder.ToTable(nameof(EmployeeEducation), MessageConstant.SchemaName);

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.EmployeeId).IsRequired();
            builder.HasOne(m => m.Employee).WithMany()
                   .HasForeignKey(m => m.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.EducationId).IsRequired();
            builder.HasOne(m => m.Education).WithMany()
                   .HasForeignKey(m => m.EducationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.SchoolId).IsRequired();
            builder.HasOne(m => m.School).WithMany()
                   .HasForeignKey(m => m.SchoolId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.MajorId).IsRequired();
            builder.HasOne(m => m.Major).WithMany()
                   .HasForeignKey(m => m.MajorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Year).IsRequired();

            builder.Property(m => m.RankingId).IsRequired();
            builder.HasOne(m => m.Ranking).WithMany()
                   .HasForeignKey(m => m.RankingId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.ModelOfStudyId).IsRequired();
            builder.HasOne(m => m.ModelOfStudy).WithMany()
                   .HasForeignKey(m => m.ModelOfStudyId)
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
