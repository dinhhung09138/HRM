using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Database.HR
{
    public sealed class EmployeeContactConfiguration : IEntityTypeConfiguration<EmployeeContact>
    {
        public void Configure(EntityTypeBuilder<EmployeeContact> builder)
        {
            builder.ToTable(nameof(EmployeeContact), MessageConstant.SchemaName);

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.EmployeeId).IsRequired();
            builder.HasOne(m => m.Employee)
                   .WithMany(e => e.EmployeeContacts)
                   .HasForeignKey(m => m.EmployeeId)
                   .HasConstraintName("FK_EmployeeContact_EmployeeId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Phone)
                   .HasColumnType("varchar")
                   .HasMaxLength(15);

            builder.Property(m => m.Mobile)
                   .HasColumnType("varchar")
                   .HasMaxLength(15);

            builder.Property(m => m.Email)
                   .HasColumnType("varchar")
                   .HasMaxLength(100);

            builder.Property(m => m.Skyper)
                   .HasColumnType("varchar")
                   .HasMaxLength(50);

            builder.Property(m => m.Zalo)
                   .HasColumnType("varchar")
                   .HasMaxLength(20);

            builder.Property(m => m.Facebook)
                   .HasColumnType("varchar")
                   .HasMaxLength(200);

            builder.Property(m => m.LinkedIn)
                   .HasColumnType("varchar")
                   .HasMaxLength(200);

            builder.Property(m => m.Twitter)
                   .HasColumnType("varchar")
                   .HasMaxLength(200);

            builder.Property(m => m.Github)
                   .HasColumnType("varchar")
                   .HasMaxLength(200);

            builder.Property(m => m.Whatsapp)
                   .HasColumnType("varchar")
                   .HasMaxLength(200);

            builder.Property(m => m.TemporaryAddress)
                   .HasMaxLength(200);

            builder.Property(m => m.TemporaryWardId);

            builder.Property(m => m.TemporaryDistrictId);

            builder.Property(m => m.TemporaryProvinceId);

            builder.Property(m => m.PermanentAddress)
                   .HasMaxLength(200);

            builder.Property(m => m.PermanentWardId);

            builder.Property(m => m.PermanentDistrictId);

            builder.Property(m => m.PermanentProvinceId);

            builder.Property(m => m.EmergencyName).HasMaxLength(70);

            builder.Property(m => m.EmergencyPhone).HasMaxLength(20);

            builder.Property(m => m.EmergencyEmail).HasMaxLength(50);

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
