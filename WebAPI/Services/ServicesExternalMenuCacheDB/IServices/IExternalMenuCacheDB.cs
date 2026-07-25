using Models_DB_and_Request.DB;
using Models_DB_and_Request.ModelsRequest.ExternalMenu;

namespace WebAPI.Services.ServicesExternalMenuCacheDB.IServices
{
    public interface IExternalMenuCacheDB
    {
        public Task<CityMenu> GetMenuCacheAsync(string city);
        public Task<CityMenu> CreateMenuCacheAsync(CityMenu menu);
        public Task<CityMenu> UpdateMenuCacheAsync(CityMenu menu);
        public Task<int> DeleteAsync(int id);
        public Task<IEnumerable<CityMenu>> GetAllAsync(); //тут надо додумать, так как получать надо список городов
    }
}
