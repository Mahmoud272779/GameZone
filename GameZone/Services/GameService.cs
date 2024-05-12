using GameZone.Data;
using GameZone.Models;
using GameZone.ViewModel;

namespace GameZone.Services
{
	public class GameService : IGameService
	{
		private readonly AppDbContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly string _imagesPath;

		public GameService(AppDbContext context, IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
			_webHostEnvironment = webHostEnvironment;
			_imagesPath= $"{_webHostEnvironment.WebRootPath}{Settings.ImagesPath}";
		}
		public async Task Create(CreateGameFormViewModel m)
		{
			var coverName = await saveCover(m.Cover);
			Game gameObj = new Game {

				Name = m.Name,
				Cover = coverName,
				Description = m.Description,
				CategoryId = m.CategoryId,
				Devices = m.SelectedDevices.Select(c=>new GameDevice { DeviceId=c}).ToList(),
			
			};
			_context.Add(gameObj);
			_context.SaveChanges();
		}

		private async Task<string> saveCover(IFormFile cover) 
		{
			var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
			var path = Path.Combine(_imagesPath,coverName);

			using var stream = File.Create(path);
			await cover.CopyToAsync(stream);
			return coverName;
		
		}
	}
}
