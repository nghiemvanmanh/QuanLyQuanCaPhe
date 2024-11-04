using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace QuanLyQuanCaPhe.Models
{
    public class SanPhamCongThucModel
    {
        public SanPhamModel SanPham { get; set; }

        public CongThucModel CongThuc { get; set; }
    }
}