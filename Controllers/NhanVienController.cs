using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyQuanCaPhe.Data;
using QuanLyQuanCaPhe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe.Controllers
{
    public class NhanVienController : Controller
    {

        private readonly ApplicationDbContext _context;

        public NhanVienController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult NewEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewEmployee(NhanVienModel nhanvien)
        {
            if (ModelState.IsValid)
            {
                if (_context.tbl_NhanVien.Any(p => p.PK_sMaNV.ToLower().Equals(nhanvien.PK_sMaNV.ToLower()))){
                    ModelState.AddModelError("PK_sMaNV", "Mã nhân viên đã tồn tại!");
                    return View("NewEmployee", nhanvien);
                }
                if (_context.tbl_NhanVien.Any(p => p.sCCCD.Equals(nhanvien.sCCCD)))
                {
                    ModelState.AddModelError("sCCCD", "CCCD đã tồn tại!");
                    return View("NewEmployee", nhanvien);
                }

                // Kiểm tra định dạng số điện thoại (chỉ cho phép các chữ số và độ dài 10-11 ký tự)
                if (!System.Text.RegularExpressions.Regex.IsMatch(nhanvien.sSDT, @"^0[0-9]{9}$"))
                {
                    ModelState.AddModelError("sSDT", "Số điện thoại không hợp lệ!");
                    return View("NewEmployee", nhanvien);
                }
                if (_context.tbl_NhanVien.Any(p => p.sSDT.Equals(nhanvien.sSDT)))
                {
                    ModelState.AddModelError("sSDT", "SDT đã tồn tại!");
                    return View("NewEmployee", nhanvien);
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(nhanvien.sEmail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    ModelState.AddModelError("sEmail", "Email không đúng định dạng!");
                    return View("NewEmployee", nhanvien);
                }

                if (_context.tbl_NhanVien.Any(p => p.sEmail.ToLower().Equals(nhanvien.sEmail.ToLower())))
                {
                    ModelState.AddModelError("sEmail", "Email đã tồn tại!");
                    return View("NewEmployee", nhanvien);
                }
                _context.tbl_NhanVien.Add(nhanvien);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Thêm thành công!";
                return RedirectToAction("ListEmployee");
                
            }
            return View("NewEmployee", nhanvien);
        }

        [HttpGet]
        public async Task<IActionResult> ListEmployee()
        {
            // Lấy danh sách nhân viên từ cơ sở dữ liệu
            var employees =await _context.tbl_NhanVien.ToListAsync();
            return View("ListEmployee", employees);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete (string id)
        {
            var nhanvien = _context.tbl_NhanVien.Find(id);
            if(nhanvien != null)
            {
                _context.tbl_NhanVien.Remove(nhanvien);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        // Hiển thị form chỉnh sửa nhân viên
     
        public IActionResult EditEmployee(string id)
        {
            // Tìm nhân viên theo ID
            var employee = _context.tbl_NhanVien.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // Cập nhật thông tin của nhân viên
        [HttpPost]
        public async Task<IActionResult>EditEmployee(NhanVienModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("ListEmployee");
            }
            return View(model);
        }

        
    }
}
