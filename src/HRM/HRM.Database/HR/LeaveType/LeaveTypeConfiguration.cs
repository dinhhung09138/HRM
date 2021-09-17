using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Database.HR
{
    public sealed class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.ToTable(nameof(LeaveType), MessageConstant.SchemaName);

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.Code).HasMaxLength(10)
                                         .HasColumnType("varchar")
                                         .IsRequired();

            builder.Property(m => m.Name).HasMaxLength(100).IsRequired();

            builder.Property(m => m.NumOfDay).IsRequired();

            builder.Property(m => m.IsDeductible).IsRequired();

            builder.Property(m => m.Description).HasMaxLength(255);

            builder.Property(m => m.Precedence).IsRequired();

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
