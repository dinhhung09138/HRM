using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Database.HR
{
    public sealed class EmployeeDependencyConfiguration : IEntityTypeConfiguration<EmployeeDependency>
    {
        public void Configure(EntityTypeBuilder<EmployeeDependency> builder)
        {
            builder.ToTable(nameof(EmployeeDependency), MessageConstant.SchemaName);

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.EmployeeId).IsRequired();
            builder.HasOne(m => m.Employee)
                   .WithMany(e => e.EmployeeDependencies)
                   .HasForeignKey(m => m.EmployeeId)
                   .HasConstraintName("FK_EmployeeDependency_EmployeeId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.FullName).HasMaxLength(100).IsRequired();

            builder.Property(m => m.RelationshipTypeId).IsRequired();
            builder.HasOne(m => m.RelationshipType)
                   .WithMany(r => r.EmployeeDependencies)
                   .HasForeignKey(m => m.RelationshipTypeId)
                   .HasConstraintName("FK_EmployeeDependency_RelationshipTypeId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.DateOfBirth).IsRequired();

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
