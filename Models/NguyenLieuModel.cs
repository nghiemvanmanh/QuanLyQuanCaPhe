using System;
using System.ComponentModel.DataAnnotations;
namespace QuanLyQuanCaPhe.Models
{
    public class NguyenLieuModel
    {
        [Key]
        public string PK_sMaNL { get; set; }
        [Required]
        public string sTenNL { get; set; }
        [Required]
        public string sDonVi { get; set; }
        [Required]
        public double fConLai { get; set; }
        [Required]
        public string FK_sMaNCC { get; set; }
    }
}