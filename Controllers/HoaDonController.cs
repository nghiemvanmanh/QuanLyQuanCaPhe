using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QuanLyQuanCaPhe.Data;
using QuanLyQuanCaPhe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe.Controllers
{
    public class HoaDonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HoaDonController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var models = await _context.tbl_HoaDonBanHang.ToListAsync();
            //Console.WriteLine("Check models", models);
            ViewBag.KhachHang = await _context.tbl_KhachHang.ToListAsync();
            return View(models);
        }
        public async Task<IActionResult> Detail(string id)
        {
            // Retrieve the invoice details
            var hoaDon = await _context.tbl_HoaDonBanHang
                .FirstOrDefaultAsync(hd => hd.PK_sMaHD == id);

            if (hoaDon == null)
            {
                return NotFound();
            }

            // Retrieve the customer details
            var customer = await _context.tbl_KhachHang
                .FirstOrDefaultAsync(c => c.PK_sMaKH == hoaDon.FK_sMaKH);

            // Retrieve product details for this invoice
            var hoaDonSP = await _context.tbl_HoaDon_SanPham
                .Where(hdsp => hdsp.FK_sMaHD == hoaDon.PK_sMaHD)
                .ToListAsync();

            // Store data in ViewData
            ViewData["HoaDon"] = hoaDon;
            ViewData["Customer"] = customer;
            ViewData["HoaDonSP"] = hoaDonSP;
            ViewBag.SanPham = await _context.tbl_SanPham.ToListAsync();
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            var khachHangList = _context.tbl_KhachHang.ToList(); // Lấy danh sách khách hàng từ cơ sở dữ liệu
            ViewData["KhachHangList"] = khachHangList;
            ViewData["SanPhamList"] = _context.tbl_SanPham.ToList(); // Đổ danh sách sản phẩm ra view
            return View();
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create([FromForm] IFormCollection form)
        {
            try
            {
                var hoaDon = new HoaDonModel();
                var khachHangJson = form["customer"];
                var ProductsJson = form["products"];
                var khachhang = JsonConvert.DeserializeObject<KhachHangModel>(khachHangJson);
                var chiTietHoaDons = JsonConvert.DeserializeObject<List<HoaDonSanPhamModel>>(ProductsJson);
                Console.WriteLine("Check khach hang: " + khachhang);
                Console.WriteLine("Check chiTietHoaDons: " + chiTietHoaDons);
                if (!string.IsNullOrEmpty(khachhang.PK_sMaKH))
                {
                    hoaDon.FK_sMaKH = khachhang.PK_sMaKH;
                }
                else
                {
                    // Create new customer if they don’t exist
                    var newCustomer = new KhachHangModel
                    {
                        PK_sMaKH = "KH" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                        sTenKH = khachhang.sTenKH,
                        sSDT = khachhang.sSDT,
                        sDiaChi = khachhang.sDiaChi
                    };

                    await _context.tbl_KhachHang.AddAsync(newCustomer);
                    await _context.SaveChangesAsync();

                    // Assign new customer ID to invoice
                    hoaDon.FK_sMaKH = newCustomer.PK_sMaKH;
                }

                if (ModelState.IsValid)
                {
                    hoaDon.PK_sMaHD = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    hoaDon.dNgayXuatHD = DateTime.Now;
                    hoaDon.fTongTien = 0;

                    // Process invoice details
                    foreach (var chiTiet in chiTietHoaDons)
                    {
                        var sanPham = await _context.tbl_SanPham.FindAsync(chiTiet.FK_sMaSP);
                        if (sanPham != null)
                        {
                            chiTiet.PK_sMaHDSP = hoaDon.PK_sMaHD + sanPham.PK_sMaSP;
                            chiTiet.FK_sMaSP = sanPham.PK_sMaSP;
                            chiTiet.FK_sMaHD = hoaDon.PK_sMaHD;
                            chiTiet.fDonGia = sanPham.fGiaSP;
                            chiTiet.fThanhTien = chiTiet.iSoLuong * chiTiet.fDonGia;
                            hoaDon.fTongTien += chiTiet.fThanhTien;
                        }

                        await _context.tbl_HoaDon_SanPham.AddAsync(chiTiet);
                    }
                    hoaDon.iDiemTichLuy = Convert.ToInt32(hoaDon.fTongTien * 0.01);
                    await _context.tbl_HoaDonBanHang.AddAsync(hoaDon);
                    await _context.SaveChangesAsync();

                    // Return success response
                    return Json(new { success = true, message = "Invoice created successfully." });
                }

                return Json(new { success = false, message = "Invalid model state." });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e.Message });
            }

        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Delete([FromBody] JsonElement data)
        {

            string id = data.GetProperty("id").GetString();
            Console.WriteLine("Check id: " + id);
            var hd = await _context.tbl_HoaDonBanHang.FirstOrDefaultAsync(sp => sp.PK_sMaHD == id);
            if (hd == null)
            {
                return Json(new { success = false, message = "Error deleting product" });
            }
            _context.tbl_HoaDonBanHang.Remove(hd);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Deleted successfully" });
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Edit([FromForm] IFormCollection form)
        {
            var khachHangJson = form["hoaDon"];
            var model = JsonConvert.DeserializeObject<KhachHangModel>(khachHangJson);
            //Console.WriteLine("Deserialized model: " + JsonConvert.SerializeObject(model));
            if (model == null || !ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid data" });
            }

            var hoaDon = await _context.tbl_KhachHang.FirstOrDefaultAsync(p => p.PK_sMaKH == model.PK_sMaKH);
            if (hoaDon == null)
            {
                return Json(new { success = false, message = "Not found" });
            }

            hoaDon.sTenKH = model.sTenKH;
            hoaDon.sSDT = model.sSDT;
            hoaDon.sDiaChi = model.sDiaChi;
            _context.tbl_KhachHang.Update(hoaDon);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "updated successfully" });
        }
    }
}