using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Database.HR
{
    public sealed class EmployeeLeaveConfiguration : IEntityTypeConfiguration<EmployeeLeave>
    {
        public void Configure(EntityTypeBuilder<EmployeeLeave> builder)
        {
            builder.ToTable(nameof(EmployeeLeave), MessageConstant.SchemaName);

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.EmployeeId).IsRequired();
            builder.HasOne(m => m.Employee)
                   .WithMany(e => e.EmployeeLeaves)
                   .HasForeignKey(m => m.EmployeeId)
                   .HasConstraintName("FK_EmployeeLeave_EmployeeId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.LeaveTypeId).IsRequired();
            builder.HasOne(m => m.LeaveType)
                   .WithMany(l =>l.EmployeeLeaves)
                   .HasForeignKey(m => m.LeaveTypeId)
                   .HasConstraintName("FK_EmployeeLeave_LeaveTypeId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.LeaveStatus).IsRequired();

            builder.Property(m => m.StartTime).IsRequired();

            builder.Property(m => m.EndTime).IsRequired();

            builder.Property(m => m.LineManagerId).IsRequired();
            builder.HasOne(m => m.LineManager)
                   .WithMany(e => e.EmployeeLeaveLineManagers)
                   .HasForeignKey(m => m.LineManagerId)
                   .HasConstraintName("FK_EmployeeLeave_LineManagerId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.CarbonCopy).HasMaxLength(500).IsRequired();

            builder.Property(m => m.ApproverId);
            builder.HasOne(m => m.Approver)
                   .WithMany(e => e.EmployeeLeaveApprovers)
                   .HasForeignKey(m => m.ApproverId)
                   .HasConstraintName("FK_EmployeeLeave_ApproverId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Reason).HasMaxLength(250).IsRequired();

            builder.Property(m => m.CreateBy).IsRequired();

            builder.Property(m => m.CreateDate).IsRequired();

            builder.Property(m => m.UpdateBy);

            builder.Property(m => m.UpdateDate);

            builder.Property(m => m.Deleted).IsRequired();

            builder.Property(m => m.RowVersion).IsRowVersion();
        }
    }
}
