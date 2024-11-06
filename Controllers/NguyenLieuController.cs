using Microsoft.AspNetCore.Mvc;
using QuanLyQuanCaPhe.Data;
using QuanLyQuanCaPhe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe.Controllers
{
    public class NguyenLieuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NguyenLieuController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.nguyenlieu = _context.tbl_NguyenLieu.ToList();
            ViewBag.nhacungcap = _context.tbl_NhaCungCap.ToList();
            return View();
        }

        // POST: NguyenLieu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NguyenLieuModel nguyenLieu)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem tên nguyên liệu đã tồn tại chưa
                var existingNguyenLieu = _context.tbl_NguyenLieu
                    .FirstOrDefault(nl => nl.sTenNL == nguyenLieu.sTenNL);

                if (existingNguyenLieu != null)
                {
                    // Nếu tồn tại, cập nhật fConLai
                    existingNguyenLieu.fConLai += nguyenLieu.fConLai;

                    // Cập nhật thay đổi vào cơ sở dữ liệu
                    _context.Update(existingNguyenLieu);
                }
                else
                {
                    // Lấy giá trị lớn nhất của mã nguyên liệu hiện có
                    var lastRecord = _context.tbl_NguyenLieu
                        .OrderByDescending(nl => nl.PK_sMaNL)
                        .FirstOrDefault();

                    // Kiểm tra và tạo mã mới
                    string newMaNL;
                    if (lastRecord != null)
                    {
                        // Lấy phần số của mã mới và tăng lên
                        var lastIndex = int.Parse(lastRecord.PK_sMaNL.Substring(2));
                        newMaNL = "NL" + (lastIndex + 1).ToString("D2");
                        Console.WriteLine("New MANL" + newMaNL);
                    }
                    else
                    {
                        // Nếu bảng rỗng, tạo mã đầu tiên
                        newMaNL = "NL01";
                    }

                    // Gán mã mới cho model
                    nguyenLieu.PK_sMaNL = newMaNL;
                    // Nếu không tồn tại, thêm nguyên liệu mới
                    _context.tbl_NguyenLieu.Add(nguyenLieu);
                }

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(nguyenLieu);
    }


        public IActionResult Index()
        {
            var nguyenLieuList = _context.tbl_NguyenLieu.ToList();
            
            return View(nguyenLieuList);
        }

        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenLieu = _context.tbl_NguyenLieu.FirstOrDefault(nl => nl.PK_sMaNL == id);
            if (nguyenLieu == null)
            {
                return NotFound();
            }
            // Lấy danh sách nguyên liệu hiện có
            
            return View(nguyenLieu);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, NguyenLieuModel nguyenLieu)
        {
            if (id != nguyenLieu.PK_sMaNL)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(nguyenLieu);
                _context.SaveChanges();
                TempData["NguyenLieu"] = "Cập nhật nguyên liệu thành công";
                return RedirectToAction(nameof(Index));
            }
            return View(nguyenLieu);
        }
    }
}
