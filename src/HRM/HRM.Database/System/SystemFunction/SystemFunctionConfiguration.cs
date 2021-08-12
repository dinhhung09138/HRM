using HRM.Domain.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HRM.Database.System
{
    public class SystemFunctionConfiguration : IEntityTypeConfiguration<SystemFunction>
    {
        public void Configure(EntityTypeBuilder<SystemFunction> builder)
        {
            builder.ToTable(nameof(SystemFunction), MessageConstant.SchemaName);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.Name).HasMaxLength(70).IsRequired();

            builder.Property(m => m.Url).HasMaxLength(100);

            builder.Property(m => m.PageId).IsRequired();
            builder.HasOne(m => m.SystemPage)
                   .WithMany(e => e.SystemFunctions)
                   .HasForeignKey(m => m.PageId)
                   .HasConstraintName("FK_SystemFunction_PageId")
                   .OnDelete(DeleteBehavior.Cascade);

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
