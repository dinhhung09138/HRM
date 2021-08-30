using HRM.Domain.Assets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HRM.Database.Assets
{
    public class AssetFixingConfiguration : IEntityTypeConfiguration<AssetFixing>
    {
        public void Configure(EntityTypeBuilder<AssetFixing> builder)
        {
            builder.ToTable(nameof(AssetFixing), MessageConstant.SchemaName);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.AssetId).IsRequired();
            builder.HasOne(m => m.Asset)
                   .WithMany(e => e.AssetFixings)
                   .HasForeignKey(m => m.AssetId)
                   .HasConstraintName("FK_AssetFixing_AssetId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.FixingDate).IsRequired();

            builder.Property(m => m.VendorId).IsRequired();
            builder.HasOne(m => m.Vendor)
                   .WithMany(e => e.AssetFixings)
                   .HasForeignKey(m => m.VendorId)
                   .HasConstraintName("FK_AssetFixing_VendorId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Cost).IsRequired();

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
