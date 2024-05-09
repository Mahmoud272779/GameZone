using GameZone.Data;
using GameZone.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly AppDbContext _context;

		public GamesController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
        {
            return View();
        }
		[HttpGet]
        public IActionResult Create()
        {
            var cats= _context.Categories.ToList();
            var devs= _context.Devices.ToList();

			var model = new CreateGameFormViewModel
            {
                Categories=cats.Select(c=>new SelectListItem(value:c.Id.ToString(),text:c.Name)).OrderBy(c=>c.Text).ToList(),
                Devices=devs.Select(c=>new SelectListItem(value: c.Id.ToString(), text: c.Name)).OrderBy(c => c.Text).ToList(),
			};

			return View(model);
        }

		[HttpPost]
		public IActionResult Create(CreateGameFormViewModel m)
		{
			
			return View();
		}
	}
}
