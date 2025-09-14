namespace Demo.DataAccess.Data.Configurations
{
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(D => D.Id).UseIdentityColumn(10, 10);
            builder.Property(D => D.Name).HasColumnType("varchar(20)");
            builder.Property(D => D.Code).HasColumnType("varchar(20)");
            builder.Property(D => D.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(D => D.ModifiedAt).HasComputedColumnSql("GETDATE()");
        }
    }
}
