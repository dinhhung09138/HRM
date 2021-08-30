using HRM.Domain.Assets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HRM.Database.Assets
{
    public class AssetHandoverInvoiceConfiguration : IEntityTypeConfiguration<AssetHandoverInvoice>
    {
        public void Configure(EntityTypeBuilder<AssetHandoverInvoice> builder)
        {
            builder.ToTable(nameof(AssetHandoverInvoice), MessageConstant.SchemaName);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.Code).HasColumnType("varchar").HasMaxLength(20).IsRequired();

            builder.Property(m => m.HandoverBy).IsRequired();
            builder.HasOne(m => m.Handover)
                   .WithMany(e => e.AssetHandoverInvoiceHandovers)
                   .HasForeignKey(m => m.HandoverBy)
                   .HasConstraintName("FK_AssetHandoverInvoice_HandoverBy")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.HandoverDate).IsRequired();

            builder.Property(m => m.ReceiveBy).IsRequired();
            builder.HasOne(m => m.Receiver)
                   .WithMany(e => e.AssetHandoverInvoiceReceivers)
                   .HasForeignKey(m => m.ReceiveBy)
                   .HasConstraintName("FK_AssetHandoverInvoice_ReceiveBy")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.ReceiveDate);

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
