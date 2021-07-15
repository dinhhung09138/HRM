using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Database.HR
{
    public sealed class EmployeeIdentificationConfiguration : IEntityTypeConfiguration<EmployeeIdentification>
    {
        public void Configure(EntityTypeBuilder<EmployeeIdentification> builder)
        {
            builder.ToTable(nameof(EmployeeIdentification), MessageConstant.SchemaName);

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.EmployeeId).IsRequired();
            builder.HasOne(m => m.Employee).WithMany()
                   .HasForeignKey(m => m.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Code).HasMaxLength(20).IsRequired();

            builder.Property(m => m.PlaceId).IsRequired();
            builder.HasOne(m => m.Place).WithMany()
                   .HasForeignKey(m => m.PlaceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.ApplyDate);

            builder.Property(m => m.IdentificationTypeId).IsRequired();
            builder.HasOne(m => m.IdentificationType).WithMany()
                   .HasForeignKey(m => m.IdentificationTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Notes).HasMaxLength(255);

            builder.Property(m => m.ExpirationDate);

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
