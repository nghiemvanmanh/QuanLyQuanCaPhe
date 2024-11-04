using System;
using System.ComponentModel.DataAnnotations;
namespace QuanLyQuanCaPhe.Models
{
    public class SanPhamModel
    {
        [Key]
        public string PK_sMaSP { get; set; }
        [Required]
        public string sTenSP { get; set; }
        [Required]
        public string FK_sMaNCC { get; set; }
        [Required]
        public string FK_sMaLSP { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        public int iSoLuong { get; set; }
        public string sIMG { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
        public double fGiaSP { get; set; }
    }
}