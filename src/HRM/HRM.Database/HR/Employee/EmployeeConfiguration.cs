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

            builder.Property(m => m.BadgeCardNumber).HasMaxLength(10);

            builder.Property(m => m.DateApplyBadge);

            builder.Property(m => m.FingerSignNumber).HasMaxLength(10);

            builder.Property(m => m.DateApplyFingerSign);

            builder.Property(m => m.WorkingEmail).HasMaxLength(50);

            builder.Property(m => m.WorkingPhone).HasMaxLength(20);

            builder.Property(m => m.EmployeeWorkingStatusId);
            builder.HasOne(m => m.EmployeeWorkingStatus)
                   .WithMany(w => w.Employees)
                   .HasForeignKey(m => m.EmployeeWorkingStatusId)
                   .HasConstraintName("FK_Employee_EmployeeWorkingStatusId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.CurrentPositionId);
            builder.HasOne(m => m.Position)
                   .WithMany(p => p.Employees)
                   .HasForeignKey(m => m.CurrentPositionId)
                   .HasConstraintName("FK_Employee_CurrentPositionId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.CurrentDepartmentId);
            builder.HasOne(m => m.Department)
                   .WithMany(d => d.Employees)
                   .HasForeignKey(m => m.CurrentDepartmentId)
                   .HasConstraintName("FK_Employee_CurrentDepartmentId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.BasicSalary);

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
