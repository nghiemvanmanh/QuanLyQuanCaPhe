using Microsoft.EntityFrameworkCore;
using QuanLyQuanCaPhe.Models;

namespace QuanLyQuanCaPhe.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SanPhamModel>()
                .HasKey(p => p.PK_sMaSP);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<NhaCungCapModel>()
                .HasKey(p => p.PK_sMaNCC);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LoaiSanPhamModel>()
                .HasKey(p => p.PK_sMaLSP);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<NguyenLieuModel>()
                .HasKey(p => p.PK_sMaNL);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CongThucModel>()
                .HasKey(p => p.PK_sMaCT);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HoaDonModel>()
                .HasKey(p => p.PK_sMaHD);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HoaDonSanPhamModel>()
                .HasKey(p => p.PK_sMaHDSP);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<KhachHangModel>()
                .HasKey(p => p.PK_sMaKH);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<SanPhamModel> tbl_SanPham { get; set; }
        public DbSet<NhaCungCapModel> tbl_NhaCungCap { get; set; }
        public DbSet<LoaiSanPhamModel> tbl_LoaiSanPham { get; set; }
        public DbSet<NguyenLieuModel> tbl_NguyenLieu { get; set; }
        public DbSet<CongThucModel> tbl_CongThuc { get; set; }
        public DbSet<KhachHangModel> tbl_KhachHang { get; set; }
        public DbSet<HoaDonModel> tbl_HoaDonBanHang { get; set; }
        public DbSet<HoaDonSanPhamModel> tbl_HoaDon_SanPham { get; set; }
        public DbSet<NhanVienModel> tbl_NhanVien { get; set; }
    }
}
