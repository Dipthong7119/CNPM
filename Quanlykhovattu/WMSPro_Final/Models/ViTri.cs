using System.ComponentModel.DataAnnotations;

namespace WMSPro.Models
{
    public class ViTri
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string MaViTri { get; set; } = "";

        [MaxLength(100)]
        public string Loai { get; set; } = "";

        [MaxLength(50)]
        public string SucChua { get; set; } = "";

        [MaxLength(50)]
        public string TinhTrang { get; set; } = "";

        [MaxLength(200)]
        public string MatHang { get; set; } = "";

        [MaxLength(20)]
        public string MaKho { get; set; } = "KHO-A";
    }
}
