using GameZone.Data;
using GameZone.Services;
using GameZone.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly AppDbContext _context;
		private readonly ICategoryService _categoryService;
		private readonly IDeviceService _deviceService;
		private readonly IGameService _gameService;

		public GamesController(AppDbContext context, ICategoryService categoryService, IDeviceService deviceService, IGameService gameService)
		{
			_context = context;
			_categoryService = categoryService;
			_deviceService = deviceService;
			_gameService = gameService;
		}

		public IActionResult Index()
        {
            return View();
        }
		[HttpGet]
        public IActionResult Create()
        {
            
			var model = new CreateGameFormViewModel
            {
                Categories=_categoryService.GetListOfCategories(),
                Devices=_deviceService.GetListOfDevices(),
			};

			return View(model);
        }

		[HttpPost]
		public async Task< IActionResult> Create(CreateGameFormViewModel m)
		{
			if (!ModelState.IsValid)
			{
				m.Categories = _categoryService.GetListOfCategories();

				m.Devices = _deviceService.GetListOfDevices();
				return View(m);
			}

			await _gameService.Create(m);

			return RedirectToAction(nameof(Index));
			
		}
	}
}
