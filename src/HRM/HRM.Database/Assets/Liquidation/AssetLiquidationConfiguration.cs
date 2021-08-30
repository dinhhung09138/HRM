using HRM.Domain.Assets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HRM.Database.Assets
{
    public class AssetAssetLiquidationConfiguration : IEntityTypeConfiguration<AssetLiquidation>
    {
        public void Configure(EntityTypeBuilder<AssetLiquidation> builder)
        {
            builder.ToTable(nameof(AssetLiquidation), MessageConstant.SchemaName);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.Code).HasColumnType("varchar").HasMaxLength(20).IsRequired();

            builder.Property(m => m.VendorId).IsRequired();
            builder.HasOne(m => m.Vendor)
                   .WithMany(e => e.AssetLiquidations)
                   .HasForeignKey(m => m.VendorId)
                   .HasConstraintName("FK_AssetLiquidation_VendorId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.LiquidationDate).IsRequired();

            builder.Property(m => m.TotalCost).IsRequired();

            builder.Property(m => m.TotalDivices).IsRequired();

            builder.Property(m => m.Notes).HasMaxLength(500);

            builder.Property(m => m.CreateBy).IsRequired();

            builder.Property(m => m.CreateDate).IsRequired();

            builder.Property(m => m.UpdateBy);

            builder.Property(m => m.UpdateDate);

            builder.Property(m => m.Deleted).IsRequired();

            builder.Property(m => m.RowVersion).IsRowVersion();
        }
    }
}
