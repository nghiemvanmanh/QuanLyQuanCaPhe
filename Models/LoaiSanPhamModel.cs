using System;
using System.ComponentModel.DataAnnotations;
namespace QuanLyQuanCaPhe.Models
{
    public class LoaiSanPhamModel
    {
        [Key]
        public string PK_sMaLSP { get; set; }
        [Required]
        public string sTenLoaiSanPham { get; set; }
    }
}