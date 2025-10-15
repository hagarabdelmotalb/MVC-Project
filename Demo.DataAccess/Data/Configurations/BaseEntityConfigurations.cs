using Demo.DataAccess.Models.Shared;

namespace Demo.DataAccess.Data.Configurations
{
    public class BaseEntityConfigurations<T> : IEntityTypeConfiguration<T> where T : BaseEntity

    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(D => D.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(D => D.ModifiedAt).HasComputedColumnSql("GETDATE()");
        }
    }
}
