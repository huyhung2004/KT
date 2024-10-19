using KKT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;

namespace KKT.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		QlthuVienContext _context = new QlthuVienContext();
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index(int? page)
		{
			int pageSize = 12;
			int pageNumber = page == 0 || page == null ? 1 : page.Value;
			var lst = _context.TSaches.AsNoTracking();
			PagedList<TSach> lstSP = new PagedList<TSach>(lst, pageNumber, pageSize);
			return View(lstSP);
		}
		[Route("SuaSanPham")]
		
		[HttpGet]

		public IActionResult SuaSanPham(string maSach)
		{
			ViewBag.MaLoai = new SelectList(_context.TLoaiSaches.ToList(), "MaLoai", "TenLoai");
			ViewBag.MaNgonNgu = new SelectList(_context.TNgonNgus.ToList(), "MaNgonNgu", "TenNgonNgu");
			ViewBag.MaNxb = new SelectList(_context.TNhaXbs.ToList(), "MaNxb", "TenNxb");
			var sanPham = _context.TSaches.Find(maSach);
			return View(sanPham);
		}

		[Route("SuaSanPham")]
		
		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult SuaSanPham(TSach sanPham)
		{
			if (ModelState.IsValid)
			{
				_context.Entry(sanPham).State = EntityState.Modified;
				_context.SaveChanges();
				return RedirectToAction("Index", "Home");
			}
			return View(sanPham);

		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
