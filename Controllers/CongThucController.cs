using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuanLyQuanCaPhe.Data;
using QuanLyQuanCaPhe.Models;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe.Controllers
{
    public class CongThucController : Controller
    {
        // private readonly ILogger<SanPhamController> _logger;

        // public SanPhamController(ILogger<SanPhamController> logger)
        // {
        //     _logger = logger;
        // }
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CongThucController> _logger;

        public CongThucController(ApplicationDbContext context, ILogger<CongThucController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IActionResult> Create(string maSP)
        {
            var ncc = await _context.tbl_NhaCungCap.ToListAsync();
            //Console.WriteLine("Check: ");
            ViewBag.NguyenLieu = await _context.tbl_NguyenLieu.ToListAsync();
            ViewBag.SanPham = await _context.tbl_SanPham.ToListAsync();
            ViewBag.NhaCungCap = await _context.tbl_NhaCungCap.ToListAsync();
            if (!string.IsNullOrEmpty(maSP))
            {
                ViewBag.CongThuc = await _context.tbl_CongThuc.Where(p => p.FK_sMaSP == maSP).ToListAsync();
                ViewBag.maSP = maSP;
            }
            else
            {
                ViewBag.CongThuc = "";
                ViewBag.maSP = "";
            }
            return View();
        }

        // Phương thức POST để xử lý dữ liệu từ form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CongThucModel model)
        {
            if (ModelState.IsValid)
            {
                var CongThuc = new CongThucModel
                {
                    PK_sMaCT = "CT" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                    FK_sMaNL = model.FK_sMaNL,
                    FK_sMaSP = model.FK_sMaSP,
                    fKhoiLuong = model.fKhoiLuong,
                };

                _context.tbl_CongThuc.Add(CongThuc);
                _context.SaveChanges();
                return RedirectToAction(nameof(Create), new { maSP = model.FK_sMaSP });
            }
            return View();
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Delete([FromBody] JsonElement data)
        {

            string id = data.GetProperty("id").GetString();
            Console.WriteLine("Check id: " + id);
            var ct = await _context.tbl_CongThuc.FirstOrDefaultAsync(ct => ct.PK_sMaCT == id);
            Console.WriteLine("Check ct: " + ct);
            if (ct == null)
            {
                return Json(new { success = false, message = "Error deleting" });
            }
            _context.tbl_CongThuc.Remove(ct);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Product deleted successfully" });
        }

        public async Task<IActionResult> Index(string maSP)
        {

            var ncc = await _context.tbl_NhaCungCap.ToListAsync();
            var sp = await _context.tbl_SanPham.ToListAsync();
            var nl = await _context.tbl_NguyenLieu.ToListAsync();
            ViewBag.NhaCungCap = ncc;
            ViewBag.SanPham = sp;
            ViewBag.NguyenLieu = nl;
            if (string.IsNullOrEmpty(maSP) == true)
            {
                Console.WriteLine("check");
                foreach (var item in sp)
                {
                    maSP = item.PK_sMaSP;
                    break;
                }
            }
            // var models = await _context.tbl_CongThuc.Where(p => p.FK_sMaSP == maSP).ToListAsync();
            var models = string.IsNullOrEmpty(maSP) ?
                   await _context.tbl_CongThuc.ToListAsync() :
                   await _context.tbl_CongThuc.Where(p => p.FK_sMaSP == maSP).ToListAsync();
            return View(models);
        }
    }
}
