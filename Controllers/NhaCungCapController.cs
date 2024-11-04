using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyQuanCaPhe.Data;
using QuanLyQuanCaPhe.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe.Controllers
{
    public class NhaCungCapController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NhaCungCapController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var models = await _context.tbl_NhaCungCap.ToListAsync();
            //Console.WriteLine("Check models", models);
            return View(models);
        }
    }
}
