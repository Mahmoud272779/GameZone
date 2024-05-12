using GameZone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly AppDbContext _context;

		public CategoryService(AppDbContext context)
		{
			_context = context;
		}

		public IEnumerable<SelectListItem> GetListOfCategories()
		{
			return _context.Categories.ToList()
				.Select(c => new SelectListItem(value: c.Id.ToString(), text: c.Name))
				.OrderBy(c => c.Text).ToList();
		}
	}
}
