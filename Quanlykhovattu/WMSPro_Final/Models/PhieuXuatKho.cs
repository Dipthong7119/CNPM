using System.ComponentModel.DataAnnotations;

namespace WMSPro.Models
{
    public class PhieuXuatKho
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string SoPhieu { get; set; } = "";

        public DateTime Ngay { get; set; } = DateTime.Now;

        [MaxLength(20)]
        public string MaHang { get; set; } = "";

        [MaxLength(200)]
        public string TenHang { get; set; } = "";

        [MaxLength(50)]
        public string MaLo { get; set; } = "";

        public int SlXuat { get; set; }
        public int TonSauXuat { get; set; }

        [MaxLength(200)]
        public string DoiTac { get; set; } = "";

        [MaxLength(200)]
        public string BoPhanNhan { get; set; } = "";

        [MaxLength(300)]
        public string LyDoXuat { get; set; } = "";

        [MaxLength(50)]
        public string TrangThai { get; set; } = "Chờ duyệt";

        [MaxLength(500)]
        public string GhiChu { get; set; } = "";

        // Người tạo phiếu (từ Identity)
        [MaxLength(450)]
        public string? NguoiTaoId { get; set; }

        [MaxLength(200)]
        public string? NguoiTaoHoTen { get; set; }
    }
}
