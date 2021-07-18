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
            builder.HasOne(m => m.Employee)
                   .WithMany(e => e.EmployeeEducations)
                   .HasForeignKey(m => m.EmployeeId)
                   .HasConstraintName("FK_EmployeeEducation_EmployeeId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.EducationId).IsRequired();
            builder.HasOne(m => m.Education)
                   .WithMany(e => e.EmployeeEducations)
                   .HasForeignKey(m => m.EducationId)
                   .HasConstraintName("FK_EmployeeEducation_EducationId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.SchoolId).IsRequired();
            builder.HasOne(m => m.School)
                   .WithMany(s => s.EmployeeEducations)
                   .HasForeignKey(m => m.SchoolId)
                   .HasConstraintName("FK_EmployeeEducation_SchoolId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.MajorId).IsRequired();
            builder.HasOne(m => m.Major)
                   .WithMany(mj => mj.EmployeeEducations)
                   .HasForeignKey(m => m.MajorId)
                   .HasConstraintName("FK_EmployeeEducation_MajorId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Year).IsRequired();

            builder.Property(m => m.RankingId).IsRequired();
            builder.HasOne(m => m.Ranking)
                   .WithMany(r => r.EmployeeEducations)
                   .HasForeignKey(m => m.RankingId)
                   .HasConstraintName("FK_EmployeeEducation_RankingId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.ModelOfStudyId).IsRequired();
            builder.HasOne(m => m.ModelOfStudy)
                   .WithMany(s => s.EmployeeEducations)
                   .HasForeignKey(m => m.ModelOfStudyId)
                   .HasConstraintName("FK_EmployeeEducation_ModelOfStudyId")
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
