using KKT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KKT.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class KTController : ControllerBase
	{
        QlthuVienContext _context = new QlthuVienContext();

        [HttpGet("{CauThuId}")]
        public IEnumerable<TSach> GetProductsByCategory(string CauThuId)
        {
            var sp = (from p in _context.TSaches
                      where p.MaLoai == CauThuId
                      select new TSach
                      {
                          MaSach=p.MaSach,
                          FileAnh=p.FileAnh,
                          MaLoai=p.MaLoai,
                          GiaTriSach=p.GiaTriSach
                      }).ToList();
            return sp;
        }
    }
}
