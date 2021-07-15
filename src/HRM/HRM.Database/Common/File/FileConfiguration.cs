using HRM.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HRM.Database.Common
{
    public class FileConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.ToTable(nameof(File), MessageConstant.SchemaName);

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.FileName).HasMaxLength(250).IsRequired();

            builder.Property(m => m.Size).IsRequired();

            builder.Property(m => m.MineType).HasColumnType("varchar").HasMaxLength(20).IsRequired();

            builder.Property(m => m.Extension).HasColumnType("varchar").HasMaxLength(10).IsRequired();

            builder.Property(m => m.SystemFileName).HasMaxLength(100).IsRequired();

            builder.Property(m => m.FilePath).HasMaxLength(300).IsRequired();

            builder.Property(m => m.FilePath32).HasMaxLength(300).IsRequired();

            builder.Property(m => m.FilePath64).HasMaxLength(300).IsRequired();

            builder.Property(m => m.FilePath128).HasMaxLength(300).IsRequired();

            builder.Property(m => m.CreateBy).IsRequired();

            builder.Property(m => m.CreateDate).IsRequired();

            builder.Property(m => m.UpdateBy);

            builder.Property(m => m.UpdateDate);

            builder.Property(m => m.Deleted).IsRequired();

            builder.Property(m => m.RowVersion).IsRowVersion();

        }
    }
}
