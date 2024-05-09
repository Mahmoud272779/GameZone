using GameZone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services
{
	public class DeviceService : IDeviceService
	{
		private readonly AppDbContext _context;

		public DeviceService(AppDbContext context)
		{
			_context = context;
		}

		public IEnumerable<SelectListItem> GetListOfDevices()
		{
			return _context.Devices.ToList().Select(c => new SelectListItem(value: c.Id.ToString(), text: c.Name)).OrderBy(c => c.Text).ToList();
		}
	}
}
