using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Database.HR
{
    public sealed class EmployeeRelationshipConfiguration : IEntityTypeConfiguration<EmployeeRelationship>
    {
        public void Configure(EntityTypeBuilder<EmployeeRelationship> builder)
        {
            builder.ToTable(nameof(EmployeeRelationship), MessageConstant.SchemaName);

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.EmployeeId).IsRequired();
            builder.HasOne(m => m.Employee)
                   .WithMany(e => e.EmployeeRelationships)
                   .HasForeignKey(m => m.EmployeeId)
                   .HasConstraintName("FK_EmployeeRelationship_EmployeeId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.FullName).HasMaxLength(100).IsRequired();

            builder.Property(m => m.RelationshipTypeId).IsRequired();
            builder.HasOne(m => m.RelationshipType)
                   .WithMany(r => r.EmployeeRelationships)
                   .HasForeignKey(m => m.RelationshipTypeId)
                   .HasConstraintName("FK_EmployeeRelationship_RelationshipTypeId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Address).HasMaxLength(255).IsRequired();

            builder.Property(m => m.Mobile).HasMaxLength(15).IsRequired();

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
