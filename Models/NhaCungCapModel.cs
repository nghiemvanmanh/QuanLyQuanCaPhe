using System;
using System.ComponentModel.DataAnnotations;
namespace QuanLyQuanCaPhe.Models
{
    public class NhaCungCapModel
    {
        [Key]
        public string PK_sMaNCC { get; set; }
        [Required]
        public string sTenNCC { get; set; }
        [Required]
        public string sDiaChi { get; set; }
    }
}