using Microsoft.AspNetCore.Mvc;
using QuanLyQuanCaPhe.Data;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using QuanLyQuanCaPhe.Models;

namespace QuanLyQuanCaPhe.Controllers
{
    public class BaoCaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BaoCaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult DoanhThu()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DoanhThu(DateTime startDate, DateTime endDate)
        {
            var doanhThu = await (from hd in _context.tbl_HoaDon_SanPham
                                  join hdb in _context.tbl_HoaDonBanHang on hd.FK_sMaHD equals hdb.PK_sMaHD
                                  join sp in _context.tbl_SanPham on hd.FK_sMaSP equals sp.PK_sMaSP
                                  where hdb.dNgayXuatHD >= startDate && hdb.dNgayXuatHD <= endDate
                                  group new { hd, hdb, sp } by new { hd.FK_sMaSP, sp.sTenSP } into g
                                  select new BaoCaoDoanhThuViewModel
                                  {
                                      MaSP = g.Key.FK_sMaSP,
                                      TenSP = g.Key.sTenSP,
                                      SoLuongBan = g.Sum(x => x.hd.iSoLuong),
                                      TongDoanhThu = g.Sum(x => x.hd.fThanhTien)
                                  }).ToListAsync();

            return View(doanhThu);
        }
    }
}
