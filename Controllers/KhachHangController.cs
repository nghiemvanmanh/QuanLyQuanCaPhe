using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QuanLyQuanCaPhe.Data;
using QuanLyQuanCaPhe.Models;
using System;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KhachHangController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var models = await _context.tbl_KhachHang.ToListAsync();
            //Console.WriteLine("Check models", models);
            return View(models);
        }
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            // Regular expression to match valid phone numbers
            var regex = new Regex(@"^\d{10}$");
            return regex.IsMatch(phoneNumber);
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create([FromForm] IFormCollection form)
        {
            // Lấy product JSON từ FormData
            var khachHangJson = form["khachHang"];
            //Console.WriteLine("Check productJson" + productJson);
            // Kiểm tra productJson có null không
            if (string.IsNullOrEmpty(khachHangJson))
            {
                return Json(new { success = false, message = "Data is missing." });
            }
            // Deserialize product JSON thành object
            var khachHang = JsonConvert.DeserializeObject<KhachHangModel>(khachHangJson);

            // Kiểm tra nếu có file ảnh
            khachHang.PK_sMaKH = "KH" + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (ValidatePhoneNumber(khachHang.sSDT) == false)
            {
                return Json(new { success = false, message = "Số điện thoại sai định dạng." });
            }
            //Console.WriteLine("Deserialized model: " + JsonConvert.SerializeObject(product));
            _context.tbl_KhachHang.Add(khachHang);
            await _context.SaveChangesAsync();
            return Json(new { success = true, khachHang = khachHang, message = "Create new success" });
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Delete([FromBody] JsonElement data)
        {

            string id = data.GetProperty("id").GetString();
            Console.WriteLine("Check id: " + id);
            var kh = await _context.tbl_KhachHang.FirstOrDefaultAsync(sp => sp.PK_sMaKH == id);
            if (kh == null)
            {
                return Json(new { success = false, message = "Error deleting product" });
            }
            _context.tbl_KhachHang.Remove(kh);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Deleted successfully" });
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Edit([FromForm] IFormCollection form)
        {
            var khachHangJson = form["khachHang"];
            var model = JsonConvert.DeserializeObject<KhachHangModel>(khachHangJson);
            //Console.WriteLine("Deserialized model: " + JsonConvert.SerializeObject(model));
            if (model == null || !ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid data" });
            }

            var khachHang = await _context.tbl_KhachHang.FirstOrDefaultAsync(p => p.PK_sMaKH == model.PK_sMaKH);
            if (khachHang == null)
            {
                return Json(new { success = false, message = "Not found" });
            }

            khachHang.sTenKH = model.sTenKH;
            khachHang.sSDT = model.sSDT;
            khachHang.sDiaChi = model.sDiaChi;
            _context.tbl_KhachHang.Update(khachHang);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "updated successfully" });
        }
    }
}