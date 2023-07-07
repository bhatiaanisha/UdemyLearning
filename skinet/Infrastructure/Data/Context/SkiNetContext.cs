using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context;

public partial class SkiNetContext : DbContext
{
    public SkiNetContext()
    {
    }

    public SkiNetContext(DbContextOptions<SkiNetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductBrand> ProductBrands { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=PC0771\\MSSQL2019;Database=SkiNet;Trusted_Connection=True;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CDFDE94102");

            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PictureUrl)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductName)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.HasOne(d => d.ProductBrand).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductBrandId)
                .HasConstraintName("FK__Products__Produc__5FB337D6");

            entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductTypeId)
                .HasConstraintName("FK__Products__Produc__5EBF139D");
        });

        modelBuilder.Entity<ProductBrand>(entity =>
        {
            entity.HasKey(e => e.ProductBrandId).HasName("PK__ProductB__B19594096D6A0978");

            entity.ToTable("ProductBrand");

            entity.Property(e => e.ProductBrandName)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.ProductTypeId).HasName("PK__ProductT__A1312F6EEB68BAC5");

            entity.ToTable("ProductType");

            entity.Property(e => e.ProductTypeName)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
