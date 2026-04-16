using Microsoft.AspNetCore.Identity;

namespace WMSPro.Models
{
    /// <summary>
    /// Người dùng hệ thống WMS - mở rộng từ IdentityUser
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public string HoTen { get; set; } = "";
        public string TrangThai { get; set; } = "Hoạt động";
        public DateTime NgayTao { get; set; } = DateTime.Now;
    }

    // ─────────────────────────────────────────────────────────────
    // Vai trò (Role) - dùng constants để tránh typo
    // ─────────────────────────────────────────────────────────────
    public static class VaiTroConst
    {
        public const string Admin = "Admin";           // Quản trị viên IT (toàn quyền)
        public const string QuanLy = "QuanLy";         // Quản lý kho
        public const string NhanVien = "NhanVien";     // Nhân viên

        // ── Helper strings cho Authorize attributes ──
        public const string QuanLyVaAdmin = $"{QuanLy},{Admin}";
        public const string NhanVienVaAdmin = $"{NhanVien},{Admin}";
        public const string TatCa = $"{NhanVien},{QuanLy},{Admin}";
    }
}
