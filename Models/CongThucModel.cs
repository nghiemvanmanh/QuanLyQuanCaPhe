using System.ComponentModel.DataAnnotations;

namespace QuanLyQuanCaPhe.Models
{
    public class CongThucModel
    {
        [Key]
        public string PK_sMaCT { get; set; }
        public string FK_sMaSP { get; set; }
        public string FK_sMaNL { get; set; }
        public double fKhoiLuong { get; set; }
    }
}