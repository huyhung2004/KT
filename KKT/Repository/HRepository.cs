using KKT.Models;

namespace KKT.Repository
{
	public class HRepository
	{
		private readonly QlthuVienContext _context;

		public HRepository(QlthuVienContext context)
		{
			_context = context;
		}
		public IEnumerable<TLoaiSach> GetAll()
		{
			return _context.TLoaiSaches;
		}
	}
}
