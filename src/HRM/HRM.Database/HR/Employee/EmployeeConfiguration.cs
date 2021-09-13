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

            builder.Property(m => m.FullName).HasMaxLength(70).IsRequired();

            builder.Property(m => m.BranchId).IsRequired();

            builder.Property(m => m.DepartmentId);
            builder.HasOne(m => m.Department)
                   .WithMany(d => d.Employees)
                   .HasForeignKey(m => m.DepartmentId)
                   .HasConstraintName("FK_Employee_DepartmentId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.PositionId);
            builder.HasOne(m => m.Position)
                   .WithMany(p => p.Employees)
                   .HasForeignKey(m => m.PositionId)
                   .HasConstraintName("FK_Employee_PositionId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.JobPositionId);

            builder.Property(m => m.ManagerId);
            builder.HasOne(m => m.Manager)
                   .WithMany(p => p.Employees)
                   .HasForeignKey(m => m.ManagerId)
                   .HasConstraintName("FK_Employee_ManagerId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Email).HasMaxLength(50);

            builder.Property(m => m.Phone).HasMaxLength(20);

            builder.Property(m => m.PhoneExt).HasMaxLength(10);

            builder.Property(m => m.Fax).HasMaxLength(20);

            builder.Property(m => m.EmployeeWorkingStatusId);
            builder.HasOne(m => m.EmployeeWorkingStatus)
                   .WithMany(w => w.Employees)
                   .HasForeignKey(m => m.EmployeeWorkingStatusId)
                   .HasConstraintName("FK_Employee_EmployeeWorkingStatusId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.ProbationDate);

            builder.Property(m => m.StartWorkingDate);

            builder.Property(m => m.ResignDate);

            builder.Property(m => m.BadgeCardNumber).HasMaxLength(10);

            builder.Property(m => m.DateApplyBadge);

            builder.Property(m => m.FingerSignNumber).HasMaxLength(10);

            builder.Property(m => m.DateApplyFingerSign);

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
