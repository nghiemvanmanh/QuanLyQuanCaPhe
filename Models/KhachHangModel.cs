using System;
using System.ComponentModel.DataAnnotations;

namespace QuanLyQuanCaPhe.Models
{
    public class KhachHangModel
    {
        [Key]
        public string PK_sMaKH { get; set; }
        public string sTenKH { get; set; }
        public string sDiaChi { get; set; }
        public string sSDT { get; set; }
        public int iDiem { get; set; }
    }
}