using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe.Models
{
    public class NhanVienModel
    {
        [Key]
        public string PK_sMaNV { get; set; }
        public string sTenNV { get; set; }
        public DateTime dNgaySinh { get; set; }
        public string sGioiTinh { get; set; }
        public string sCCCD { get; set; }
        public string sDiaChi { get; set; }
        public string sSDT { get; set; }
        public string sEmail { get; set; }
        public DateTime dNgayVaoLam { get; set; }
        public double fLuongcb { get; set; }
        public string sTinhTrang { get; set; }
    }
}
