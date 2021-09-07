using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HRM.Database.HR
{
    public class CustomerContactConfiguration : IEntityTypeConfiguration<CustomerContact>
    {
        public void Configure(EntityTypeBuilder<CustomerContact> builder)
        {
            builder.ToTable(nameof(CustomerContact), MessageConstant.SchemaName);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.CustomerId).IsRequired();
            builder.HasOne(m => m.Customer)
                   .WithMany(e => e.CustomerContacts)
                   .HasForeignKey(m => m.CustomerId)
                   .HasConstraintName("FK_CustomerContact_CustomerId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Name).HasMaxLength(100).IsRequired();

            builder.Property(m => m.Phone).HasMaxLength(20);

            builder.Property(m => m.Email).HasMaxLength(50);

            builder.Property(m => m.Position).HasMaxLength(100);

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
