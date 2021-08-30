using HRM.Domain.Assets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HRM.Database.Assets
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.ToTable(nameof(Asset), MessageConstant.SchemaName);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.Code).HasColumnType("varchar").HasMaxLength(50).IsRequired();

            builder.Property(m => m.Name).HasMaxLength(150).IsRequired();

            builder.Property(m => m.SerialNumber).HasMaxLength(50);

            builder.Property(m => m.AssetTypeId).IsRequired();
            builder.HasOne(m => m.AssetType)
                   .WithMany(e => e.Assets)
                   .HasForeignKey(m => m.AssetTypeId)
                   .HasConstraintName("FK_Asset_AssetTypeId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.VendorId).IsRequired();
            builder.HasOne(m => m.Vendor)
                   .WithMany(e => e.Assets)
                   .HasForeignKey(m => m.VendorId)
                   .HasConstraintName("FK_Asset_VendorId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Cost).IsRequired();

            builder.Property(m => m.FixingCost).IsRequired();

            builder.Property(m => m.MantenanceCost).IsRequired();

            builder.Property(m => m.BuyingDate);

            builder.Property(m => m.WarrantyExpiryDate);

            builder.Property(m => m.LiquidationDate);

            builder.Property(m => m.Notes).HasMaxLength(500);

            builder.Property(m => m.AssetStatus).IsRequired();

            builder.Property(m => m.IsAllowBorrow).IsRequired();

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
