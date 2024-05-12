using GameZone.ViewModel;

namespace GameZone.Services
{
	public interface IGameService
	{
		public Task Create(CreateGameFormViewModel m);
	}
}
