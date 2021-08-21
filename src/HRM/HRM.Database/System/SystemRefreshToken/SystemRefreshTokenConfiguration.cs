using HRM.Domain.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Database.System
{
    public class SystemRefreshTokenConfiguration : IEntityTypeConfiguration<SystemRefreshToken>
    {
        public void Configure(EntityTypeBuilder<SystemRefreshToken> builder)
        {
            builder.ToTable(nameof(SystemRefreshToken), MessageConstant.SchemaName);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.UserId).IsRequired();
            builder.HasOne(m => m.User)
                   .WithMany(e => e.SystemRefreshTokens)
                   .HasForeignKey(m => m.UserId)
                   .HasConstraintName("FK_SystemRefreshToken_UserId")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(m => m.Token).HasMaxLength(1000).IsRequired();

            builder.Property(m => m.Expires).IsRequired();

            builder.Property(m => m.CreateDate).IsRequired();

            builder.Property(m => m.CreatedByIp).HasMaxLength(50).IsRequired();

            builder.Property(m => m.Revoked);

            builder.Property(m => m.RevokedByIp);

            builder.Property(m => m.ReplacedByToken);
        }
    }
}
