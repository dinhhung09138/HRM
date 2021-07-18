using HRM.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HRM.Database.Common
{
    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.ToTable(nameof(District), MessageConstant.SchemaName);

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.Name).HasMaxLength(100).IsRequired();

            builder.Property(m => m.ProvinceId).IsRequired();
            builder.HasOne(m => m.Province)
                   .WithMany(p => p.Districts)
                   .HasForeignKey(m => m.ProvinceId)
                   .HasConstraintName("FK_District_ProvinceId")
                   .OnDelete(DeleteBehavior.Restrict);

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
