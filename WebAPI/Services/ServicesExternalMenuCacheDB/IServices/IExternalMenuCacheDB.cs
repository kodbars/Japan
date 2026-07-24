using Models_DB_and_Request.DB;
using Models_DB_and_Request.ModelsRequest.ExternalMenu;

namespace WebAPI.Services.ServicesExternalMenuCacheDB.IServices
{
    public interface IExternalMenuCacheDB
    {
        public Task<CityMenu> GetMenuCache(Root menu);
        public Task<CityMenu> CreateMenuCache(Root menu);
        public Task<CityMenu> UpdateMenuCache(Root menu);
        public Task<int> Delete(int id);
        public Task<IEnumerable<CityMenu>> GetAll(); //тут надо додумать, так как получать надо список городов
    }
}
