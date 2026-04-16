using Microsoft.AspNetCore.Identity;
using WMSPro.Models;

namespace WMSPro.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider sp)
        {
            var roleMgr = sp.GetRequiredService<RoleManager<IdentityRole>>();
            var userMgr = sp.GetRequiredService<UserManager<ApplicationUser>>();
            var db = sp.GetRequiredService<AppDbContext>();

            // ── 1. Tạo các vai trò ──
            string[] roles = { VaiTroConst.Admin, VaiTroConst.QuanLy, VaiTroConst.NhanVien };
            foreach (var role in roles)
                if (!await roleMgr.RoleExistsAsync(role))
                    await roleMgr.CreateAsync(new IdentityRole(role));

            // ── 2. Tạo tài khoản mặc định nếu chưa có ──
            await TaoTaiKhoan(userMgr, "admin", "Admin@123", "Quản Trị Viên", VaiTroConst.Admin, "admin@wms.vn");
            await TaoTaiKhoan(userMgr, "thukho", "Thukho@123", "Nguyễn Văn A", VaiTroConst.QuanLy, "thukho@wms.vn");
            await TaoTaiKhoan(userMgr, "nhanvien", "Nhanvien@123", "Trần Thị B", VaiTroConst.NhanVien, "nhanvien@wms.vn");

            // ── 3. Seed dữ liệu mẫu nếu DB trống ──
            if (!db.NhaCungCaps.Any())
            {
                db.NhaCungCaps.AddRange(
                    new NhaCungCap { MaNhaCungCap = "NCC-001", TenNhaCungCap = "Công ty ABC", DiaChi = "123 Đường Lê Lợi, Hà Nội", SoDienThoai = "024-1234-5678", Email = "abc@company.vn" },
                    new NhaCungCap { MaNhaCungCap = "NCC-002", TenNhaCungCap = "Công ty XYZ", DiaChi = "456 Nguyễn Huệ, TP.HCM", SoDienThoai = "028-8765-4321", Email = "xyz@company.vn" },
                    new NhaCungCap { MaNhaCungCap = "NCC-003", TenNhaCungCap = "Tech Supply Co.", DiaChi = "789 Trần Phú, Đà Nẵng", SoDienThoai = "0236-999-888", Email = "techsupply@vn.com" }
                );
                await db.SaveChangesAsync();
            }

            if (!db.Khos.Any())
            {
                db.Khos.AddRange(
                    new Kho { MaKho = "KHO-A", TenKho = "Kho A - Điện tử", DiaDiem = "Tầng 1, Tòa nhà A", NguoiPhuTrach = "Nguyễn Văn A", GhiChu = "Kho chứa thiết bị điện tử" },
                    new Kho { MaKho = "KHO-B", TenKho = "Kho B - Phụ kiện", DiaDiem = "Tầng 2, Tòa nhà A", NguoiPhuTrach = "Trần Thị B", GhiChu = "Kho chứa phụ kiện" }
                );
                await db.SaveChangesAsync();
            }

            if (!db.ViTris.Any())
            {
                db.ViTris.AddRange(
                    new ViTri { MaViTri = "A1-01", Loai = "Kệ đứng", SucChua = "100 kg", TinhTrang = "Đầy", MatHang = "Điện thoại A12", MaKho = "KHO-A" },
                    new ViTri { MaViTri = "A1-02", Loai = "Kệ đứng", SucChua = "100 kg", TinhTrang = "Một phần", MatHang = "Chuột không dây", MaKho = "KHO-A" },
                    new ViTri { MaViTri = "A1-03", Loai = "Kệ đứng", SucChua = "100 kg", TinhTrang = "Trống", MatHang = "—", MaKho = "KHO-A" },
                    new ViTri { MaViTri = "B2-01", Loai = "Kệ nặng", SucChua = "500 kg", TinhTrang = "Đầy", MatHang = "Laptop Core i5", MaKho = "KHO-A" },
                    new ViTri { MaViTri = "B2-02", Loai = "Kệ nặng", SucChua = "500 kg", TinhTrang = "Một phần", MatHang = "Màn hình 27\"", MaKho = "KHO-A" },
                    new ViTri { MaViTri = "C3-04", Loai = "Kệ nhỏ", SucChua = "50 kg", TinhTrang = "Đầy", MatHang = "Tai nghe BT", MaKho = "KHO-A" },
                    new ViTri { MaViTri = "D1-02", Loai = "Kệ nhỏ", SucChua = "50 kg", TinhTrang = "Một phần", MatHang = "Bàn phím K300", MaKho = "KHO-B" },
                    new ViTri { MaViTri = "D1-03", Loai = "Kệ nhỏ", SucChua = "50 kg", TinhTrang = "Một phần", MatHang = "Màn hình 27\"", MaKho = "KHO-B" }
                );
                await db.SaveChangesAsync();
            }

            if (!db.VatTus.Any())
            {
                db.VatTus.AddRange(
                    new VatTu { MaVatTu = "DT-A12", TenVatTu = "Điện thoại A12", DonViTinh = "cái", LoaiVatTu = "Điện tử", SoLuongTon = 245, MucTonToiThieu = 50, MaNhaCungCap = "NCC-001", TenNhaCungCap = "Công ty ABC", MaKho = "KHO-A", MaViTri = "A1-01", MaLo = "LOT-045" },
                    new VatTu { MaVatTu = "LT-I5", TenVatTu = "Laptop Core i5", DonViTinh = "cái", LoaiVatTu = "Điện tử", SoLuongTon = 78, MucTonToiThieu = 20, MaNhaCungCap = "NCC-003", TenNhaCungCap = "Tech Supply Co.", MaKho = "KHO-A", MaViTri = "B2-01", MaLo = "SN-LT-*" },
                    new VatTu { MaVatTu = "CN-A200", TenVatTu = "Chuột không dây A200", DonViTinh = "cái", LoaiVatTu = "Phụ kiện", SoLuongTon = 8, MucTonToiThieu = 20, MaNhaCungCap = "NCC-001", TenNhaCungCap = "Công ty ABC", MaKho = "KHO-B", MaViTri = "A1-02", MaLo = "LOT-M-088" },
                    new VatTu { MaVatTu = "TN-BT", TenVatTu = "Tai nghe Bluetooth", DonViTinh = "cái", LoaiVatTu = "Phụ kiện", SoLuongTon = 32, MucTonToiThieu = 15, MaNhaCungCap = "NCC-002", TenNhaCungCap = "Công ty XYZ", MaKho = "KHO-A", MaViTri = "C3-04", MaLo = "LOT-044" },
                    new VatTu { MaVatTu = "BF-K300", TenVatTu = "Bàn phím cơ K300", DonViTinh = "cái", LoaiVatTu = "Phụ kiện", SoLuongTon = 15, MucTonToiThieu = 25, MaNhaCungCap = "NCC-003", TenNhaCungCap = "Tech Supply Co.", MaKho = "KHO-B", MaViTri = "D1-02", MaLo = "SN-K300-001" },
                    new VatTu { MaVatTu = "MH-27", TenVatTu = "Màn hình 27 inch", DonViTinh = "cái", LoaiVatTu = "Điện tử", SoLuongTon = 42, MucTonToiThieu = 10, MaNhaCungCap = "NCC-002", TenNhaCungCap = "Công ty XYZ", MaKho = "KHO-A", MaViTri = "D1-03", MaLo = "LOT-038" }
                );
                await db.SaveChangesAsync();
            }

            if (!db.PhieuNhapKhos.Any())
            {
                db.PhieuNhapKhos.AddRange(
                    new PhieuNhapKho { SoPhieu = "PN-2024-889", NgayChungTu = new DateTime(2024, 4, 2), MaHang = "DT-A12", TenHang = "Điện thoại A12", MaLo = "LOT-2024-045", SlThucTe = 50, DonGia = 3500000, NhaCungCap = "Công ty ABC", MaNhaCungCap = "NCC-001", TrangThai = "Hoàn thành", MaViTriGoiY = "A1-01" },
                    new PhieuNhapKho { SoPhieu = "PN-2024-888", NgayChungTu = new DateTime(2024, 4, 1), MaHang = "TN-BT", TenHang = "Tai nghe Bluetooth", MaLo = "LOT-2024-044", SlThucTe = 100, DonGia = 850000, NhaCungCap = "Công ty XYZ", MaNhaCungCap = "NCC-002", TrangThai = "Đang xử lý", MaViTriGoiY = "C3-04" },
                    new PhieuNhapKho { SoPhieu = "PN-2024-887", NgayChungTu = new DateTime(2024, 3, 30), MaHang = "BF-K300", TenHang = "Bàn phím cơ K300", MaLo = "SN-K300-001", SlThucTe = 60, DonGia = 1200000, NhaCungCap = "Tech Supply Co.", MaNhaCungCap = "NCC-003", TrangThai = "Chờ duyệt", MaViTriGoiY = "D1-02" }
                );
                await db.SaveChangesAsync();
            }

            if (!db.PhieuXuatKhos.Any())
            {
                db.PhieuXuatKhos.AddRange(
                    new PhieuXuatKho { SoPhieu = "PX-2024-845", Ngay = new DateTime(2024, 4, 2), MaHang = "LT-I5", TenHang = "Laptop Core i5", MaLo = "SN-LT-812", SlXuat = 12, TonSauXuat = 78, DoiTac = "Siêu thị A", BoPhanNhan = "Bộ phận Kinh doanh", LyDoXuat = "Bán hàng", TrangThai = "Hoàn thành" },
                    new PhieuXuatKho { SoPhieu = "PX-2024-844", Ngay = new DateTime(2024, 4, 1), MaHang = "CN-A200", TenHang = "Chuột không dây A200", MaLo = "LOT-M-888", SlXuat = 30, TonSauXuat = 8, DoiTac = "Đại lý B", BoPhanNhan = "Bộ phận Kinh doanh", LyDoXuat = "Bán hàng", TrangThai = "Hoàn thành" },
                    new PhieuXuatKho { SoPhieu = "PX-2024-843", Ngay = new DateTime(2024, 3, 30), MaHang = "DT-A12", TenHang = "Điện thoại A12", MaLo = "LOT-2024-042", SlXuat = 25, TonSauXuat = 245, DoiTac = "Siêu thị C", BoPhanNhan = "Bộ phận Kinh doanh", LyDoXuat = "Bán hàng", TrangThai = "Đang soạn" }
                );
                await db.SaveChangesAsync();
            }
        }

        private static async Task TaoTaiKhoan(UserManager<ApplicationUser> userMgr,
            string username, string password, string hoTen, string vaiTro, string email)
        {
            if (await userMgr.FindByNameAsync(username) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = username,
                    Email = email,
                    HoTen = hoTen,
                    TrangThai = "Hoạt động",
                    NgayTao = DateTime.Now
                };
                var result = await userMgr.CreateAsync(user, password);
                if (result.Succeeded)
                    await userMgr.AddToRoleAsync(user, vaiTro);
            }
        }
    }
}
