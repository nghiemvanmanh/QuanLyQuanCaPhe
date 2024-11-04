using System;
using System.ComponentModel.DataAnnotations;

namespace QuanLyQuanCaPhe.Models
{
    public class HoaDonSanPhamModel
    {
        [Key]
        public string PK_sMaHDSP { get; set; }
        public string FK_sMaSP { get; set; }
        public string FK_sMaHD { get; set; }
        public int iSoLuong { get; set; }
        public double fDonGia { get; set; }
        public double fThanhTien { get; set; }
    }
}