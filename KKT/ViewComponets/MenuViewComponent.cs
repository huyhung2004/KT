using KKT.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KKT.ViewComponets
{
	public class MenuViewComponent : ViewComponent
	{
		private readonly HRepository _loaiSPRepository;

		public MenuViewComponent(HRepository loaiSPRepository)
		{
			_loaiSPRepository = loaiSPRepository;
		}
		public IViewComponentResult Invoke()
		{
			var loaiSP = _loaiSPRepository.GetAll();
			return View(loaiSP);
		}
	}
}
