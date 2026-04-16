using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WMSPro.Models;

namespace WMSPro.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // ── Các bảng dữ liệu nghiệp vụ ──
        public DbSet<VatTu> VatTus { get; set; }
        public DbSet<Kho> Khos { get; set; }
        public DbSet<ViTri> ViTris { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<PhieuNhapKho> PhieuNhapKhos { get; set; }
        public DbSet<PhieuXuatKho> PhieuXuatKhos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Index cho các cột tìm kiếm thường xuyên
            builder.Entity<VatTu>().HasIndex(v => v.MaVatTu).IsUnique();
            builder.Entity<Kho>().HasIndex(k => k.MaKho).IsUnique();
            builder.Entity<ViTri>().HasIndex(v => v.MaViTri).IsUnique();
            builder.Entity<NhaCungCap>().HasIndex(n => n.MaNhaCungCap).IsUnique();
            builder.Entity<PhieuNhapKho>().HasIndex(p => p.SoPhieu).IsUnique();
            builder.Entity<PhieuXuatKho>().HasIndex(p => p.SoPhieu).IsUnique();
        }
    }
}
