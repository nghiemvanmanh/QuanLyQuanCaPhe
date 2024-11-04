using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QuanLyQuanCaPhe.Data;
using QuanLyQuanCaPhe.Models;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe.Controllers
{
    public class SanPhamController : Controller
    {
        // private readonly ILogger<SanPhamController> _logger;

        // public SanPhamController(ILogger<SanPhamController> logger)
        // {
        //     _logger = logger;
        // }
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SanPhamController> _logger;

        public SanPhamController(ApplicationDbContext context, ILogger<SanPhamController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Phương thức POST để xử lý dữ liệu từ form
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create([FromForm] IFormCollection form, IFormFile imageFile)
        {
            // Lấy product JSON từ FormData
            var productJson = form["product"];
            //Console.WriteLine("Check productJson" + productJson);
            // Kiểm tra productJson có null không
            if (string.IsNullOrEmpty(productJson))
            {
                return Json(new { success = false, message = "Product data is missing." });
            }
            // Deserialize product JSON thành object
            var product = JsonConvert.DeserializeObject<SanPhamModel>(productJson);
            //Console.WriteLine("Check product " + product);

            //Console.WriteLine("Check tenSp: " + product.sTenSP);
            // Kiểm tra nếu có file ảnh
            product.PK_sMaSP = "SP" + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (imageFile != null && imageFile.Length > 0)
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", imageFile.FileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                product.sIMG = Path.Combine("uploads", imageFile.FileName); // Lưu đường dẫn ảnh
            }
            //Console.WriteLine("Deserialized model: " + JsonConvert.SerializeObject(product));
            _context.tbl_SanPham.Add(product);
            await _context.SaveChangesAsync();
            return Json(new { success = true, product = product, message = "Create new success" });
        }

        // Phương thức POST để xử lý yêu cầu xóa sản phẩm
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Delete([FromBody] JsonElement data)
        {

            string id = data.GetProperty("id").GetString();
            Console.WriteLine("Check id: " + id);
            var sp = await _context.tbl_SanPham.FirstOrDefaultAsync(sp => sp.PK_sMaSP == id);
            Console.WriteLine("Check sp: " + sp);
            var relatedCongThucs = _context.tbl_CongThuc.Where(ct => ct.FK_sMaSP == id);
            Console.WriteLine("Check relatedCongThucs: " + relatedCongThucs);
            _context.tbl_CongThuc.RemoveRange(relatedCongThucs);
            if (sp == null)
            {
                return Json(new { success = false, message = "Error deleting product" });
            }

            _context.tbl_SanPham.Remove(sp);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Product deleted successfully" });
        }
        public async Task<IActionResult> Index(string maNCC)
        {
            // var models = await _context.tbl_SanPham.ToListAsync();
            // maNCC = "NCC01";
            //Console.WriteLine("check: " + maNCC);
            var ncc = await _context.tbl_NhaCungCap.ToListAsync();
            ViewBag.NhaCungCap = ncc;
            ViewBag.LoaiSanPham = new SelectList(await _context.tbl_LoaiSanPham.ToListAsync(), "PK_sMaLSP", "sTenLoaiSanPham");
            var models = string.IsNullOrEmpty(maNCC) ?
                   await _context.tbl_SanPham.ToListAsync() :
                   await _context.tbl_SanPham.Where(p => p.FK_sMaNCC == maNCC).ToListAsync();
            return View(models);
        }
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.tbl_SanPham.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.NhaCungCap = await _context.tbl_NhaCungCap.ToListAsync();
            ViewBag.LoaiSanPham = await _context.tbl_LoaiSanPham.ToListAsync();

            return View(product);
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Edit([FromForm] IFormCollection form, IFormFile imageFile)
        {
            var productJson = form["product"];
            //Console.WriteLine("Check productJson:" + productJson);
            var model = JsonConvert.DeserializeObject<SanPhamModel>(productJson);
            //Console.WriteLine("Check model:" + model);
            var settings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            };
            //Console.WriteLine("Deserialized model: " + JsonConvert.SerializeObject(model));
            if (model == null || !ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid data" });
            }

            var product = await _context.tbl_SanPham.FirstOrDefaultAsync(p => p.PK_sMaSP == model.PK_sMaSP);
            if (product == null)
            {
                return Json(new { success = false, message = "Product not found" });
            }

            product.sTenSP = model.sTenSP;
            product.FK_sMaNCC = model.FK_sMaNCC;
            product.FK_sMaLSP = model.FK_sMaLSP;
            product.iSoLuong = model.iSoLuong;
            product.fGiaSP = model.fGiaSP;
            if (imageFile != null && imageFile.Length > 0)
            {
                // Tạo đường dẫn để lưu ảnh
                var imageFolder = Path.Combine("wwwroot", "uploads");
                var imagePath = Path.Combine(imageFolder, imageFile.FileName);

                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(imageFolder))
                {
                    Directory.CreateDirectory(imageFolder);
                }

                // Lưu file ảnh lên server
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                // Lưu đường dẫn ảnh vào database (chỉ lưu phần đường dẫn tương đối)
                product.sIMG = Path.Combine("uploads", imageFile.FileName);
            }
            else
            {
                product.sIMG = model.sIMG;
            }
            _context.tbl_SanPham.Update(product);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Product updated successfully" });
        }
    }
}
