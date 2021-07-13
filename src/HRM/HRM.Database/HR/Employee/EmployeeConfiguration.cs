using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Database.HR
{
    public sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(nameof(Employee), MessageConstant.SchemaName);

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.EmployeeCode)
                   .HasMaxLength(15)
                   .HasColumnType("varchar")
                   .IsRequired();

            builder.Property(m => m.ProbationDate);

            builder.Property(m => m.StartWorkingDate);

            builder.Property(m => m.BadgeCardNumber).HasMaxLength(10).IsRequired();

            builder.Property(m => m.DateApplyBadge);

            builder.Property(m => m.FingerSignNumber).HasMaxLength(10).IsRequired();

            builder.Property(m => m.DateApplyFingerSign);

            builder.Property(m => m.WorkingEmail).HasMaxLength(50).IsRequired();

            builder.Property(m => m.WorkingPhone).HasMaxLength(20).IsRequired();

            builder.Property(m => m.EmployeeWorkingStatusId).IsRequired();
            builder.HasOne(m => m.EmployeeWorkingStatus).WithMany()
                   .HasForeignKey(m => m.EmployeeWorkingStatusId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.CurrentPositionId);
            builder.HasOne(m => m.Position).WithMany()
                   .HasForeignKey(m => m.CurrentDepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.CurrentDepartmentId);
            builder.HasOne(m => m.Department).WithMany()
                   .HasForeignKey(m => m.CurrentDepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.BasicSalary).IsRequired();

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
