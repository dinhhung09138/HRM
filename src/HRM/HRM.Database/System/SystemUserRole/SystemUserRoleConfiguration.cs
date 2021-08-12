using HRM.Domain.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HRM.Database.System
{
    public class SystemUserRoleConfiguration : IEntityTypeConfiguration<SystemUserRole>
    {
        public void Configure(EntityTypeBuilder<SystemUserRole> builder)
        {
            builder.ToTable(nameof(SystemUserRole), MessageConstant.SchemaName);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.RoleId).IsRequired();
            builder.HasOne(m => m.SystemRole)
                   .WithMany(e => e.SystemUserRoles)
                   .HasForeignKey(m => m.RoleId)
                   .HasConstraintName("FK_SystemUserRole_RoleId")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(m => m.UserId).IsRequired();
            builder.HasOne(m => m.SystemUser)
                   .WithMany(e => e.SystemUserRoless)
                   .HasForeignKey(m => m.UserId)
                   .HasConstraintName("FK_SystemUserRole_UserId")
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
