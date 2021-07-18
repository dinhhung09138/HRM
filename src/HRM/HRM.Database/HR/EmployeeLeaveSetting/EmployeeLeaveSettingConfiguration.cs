using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Database.HR
{
    public sealed class EmployeeLeaveSettingConfiguration : IEntityTypeConfiguration<EmployeeLeaveSetting>
    {
        public void Configure(EntityTypeBuilder<EmployeeLeaveSetting> builder)
        {
            builder.ToTable(nameof(EmployeeLeaveSetting), MessageConstant.SchemaName);

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.EmployeeId).IsRequired();
            builder.HasOne(m => m.Employee)
                   .WithMany(e => e.EmployeeLeaveSettings)
                   .HasForeignKey(m => m.EmployeeId)
                   .HasConstraintName("FK_EmployeeLeaveSetting_EmployeeId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Year).IsRequired();

            builder.Property(m => m.NumOfDay).IsRequired();

            builder.Property(m => m.DayUsed).IsRequired();

            builder.Property(m => m.CreateBy).IsRequired();

            builder.Property(m => m.CreateDate).IsRequired();

            builder.Property(m => m.UpdateBy);

            builder.Property(m => m.UpdateDate);

            builder.Property(m => m.Deleted).IsRequired();

            builder.Property(m => m.RowVersion).IsRowVersion();

        }
    }
}
