using System.ComponentModel.DataAnnotations;

namespace WMSPro.Models
{
    public class Kho
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string MaKho { get; set; } = "";

        [Required, MaxLength(200)]
        public string TenKho { get; set; } = "";

        [MaxLength(300)]
        public string DiaDiem { get; set; } = "";

        [MaxLength(200)]
        public string NguoiPhuTrach { get; set; } = "";

        [MaxLength(500)]
        public string GhiChu { get; set; } = "";
    }
}
