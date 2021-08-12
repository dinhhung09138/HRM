using HRM.Domain.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HRM.Database.System
{
    public class SystemUserConfiguration : IEntityTypeConfiguration<SystemUser>
    {
        public void Configure(EntityTypeBuilder<SystemUser> builder)
        {
            builder.ToTable(nameof(SystemUser), MessageConstant.SchemaName);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.UserName).HasMaxLength(50).IsRequired();

            builder.Property(m => m.Password).HasMaxLength(1000).IsRequired();

            builder.Property(m => m.Salt).HasMaxLength(50).IsRequired();

            builder.Property(m => m.EmployeeId).IsRequired();
            builder.HasOne(m => m.Employee).WithOne(e => e.SystemUser)
                .HasForeignKey<SystemUser>(m => m.EmployeeId)
                .HasConstraintName("FK_SystemUser_EmployeeId")
                .OnDelete(DeleteBehavior.Cascade);

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
