using System;
using System.ComponentModel.DataAnnotations;

namespace QuanLyQuanCaPhe.Models
{
    public class HoaDonModel
    {
        [Key]
        public string PK_sMaHD { get; set; }
        public string FK_sMaKH { get; set; }
        public DateTime dNgayXuatHD { get; set; }
        public double fChiPhiKhac { get; set; }
        public double fGiamGia { get; set; }
        public double fTongTien { get; set; }
        public int iDiemTichLuy { get; set; }
    }
}