using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSPro.Models
{
    public class PhieuNhapKho
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string SoPhieu { get; set; } = "";

        public DateTime NgayChungTu { get; set; } = DateTime.Now;

        [MaxLength(20)]
        public string MaHang { get; set; } = "";

        [MaxLength(200)]
        public string TenHang { get; set; } = "";

        [MaxLength(50)]
        public string MaLo { get; set; } = "";

        public int SlThucTe { get; set; }
        public long DonGia { get; set; }

        [NotMapped]
        public long ThanhTien => SlThucTe * DonGia;

        [MaxLength(200)]
        public string NhaCungCap { get; set; } = "";

        [MaxLength(20)]
        public string MaNhaCungCap { get; set; } = "";

        [MaxLength(50)]
        public string TrangThai { get; set; } = "Chờ duyệt";

        [MaxLength(500)]
        public string GhiChu { get; set; } = "";

        [MaxLength(20)]
        public string MaViTriGoiY { get; set; } = "";

        // Người tạo phiếu (từ Identity)
        [MaxLength(450)]
        public string? NguoiTaoId { get; set; }

        [MaxLength(200)]
        public string? NguoiTaoHoTen { get; set; }
    }
}
