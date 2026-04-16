using System.ComponentModel.DataAnnotations;

namespace WMSPro.Models
{
    public class NhaCungCap
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string MaNhaCungCap { get; set; } = "";

        [Required, MaxLength(200)]
        public string TenNhaCungCap { get; set; } = "";

        [MaxLength(300)]
        public string DiaChi { get; set; } = "";

        [MaxLength(20)]
        public string SoDienThoai { get; set; } = "";

        [MaxLength(100)]
        public string Email { get; set; } = "";
    }
}
