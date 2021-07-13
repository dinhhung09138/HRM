using HRM.Domain.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Database.HR
{
    public sealed class EmployeeCommendationConfiguration : IEntityTypeConfiguration<EmployeeCommendation>
    {
        public void Configure(EntityTypeBuilder<EmployeeCommendation> builder)
        {
            builder.ToTable(nameof(EmployeeCommendation), MessageConstant.SchemaName);

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.EmployeeId).IsRequired();
            builder.HasOne(m => m.Employee).WithMany().HasForeignKey(m => m.EmployeeId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.CommendationId).IsRequired();
            builder.HasOne(m => m.Commendation).WithMany().HasForeignKey(m => m.CommendationId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.Date).IsRequired();

            builder.Property(m => m.Comment).HasMaxLength(250).IsRequired();

            builder.Property(m => m.ProposerId).IsRequired();
            builder.HasOne(m => m.Proposer).WithMany().HasForeignKey(m => m.ProposerId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.ProposeDate).IsRequired();

            builder.Property(m => m.ApprovedStatus).IsRequired();

            builder.Property(m => m.ApprovedBy);
            builder.HasOne(m => m.Approve).WithMany().HasForeignKey(m => m.ApprovedBy).OnDelete(DeleteBehavior.Restrict);

            builder.Property(m => m.ApprovedDate);

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
