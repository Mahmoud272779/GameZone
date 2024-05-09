using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services
{
	public interface IDeviceService
	{
		public IEnumerable<SelectListItem> GetListOfDevices();
	}
}
