using Microsoft.EntityFrameworkCore;
using Models_DB_and_Request.Data;
using Models_DB_and_Request.DB;
using Models_DB_and_Request.ModelsRequest.ExternalMenu;
using WebAPI.Services.ServicesExternalMenu.IServices;
using WebAPI.Services.ServicesExternalMenuCacheDB.IServices;

namespace WebAPI.Services.ServicesExternalMenuCacheDB
{
    public class ExternalMenuCacheDB : IExternalMenuCacheDB
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;
        private readonly ILogger<ExternalMenuCacheDB> _logger;

        public ExternalMenuCacheDB(IDbContextFactory<AppDbContext> dbContextFactory, ILogger<ExternalMenuCacheDB> logger)
        {
            _dbContextFactory = dbContextFactory;
            _logger = logger;
        }

        public async Task<CityMenu> CreateMenuCacheAsync(CityMenu menu)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CityMenu>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CityMenu> GetMenuCacheAsync(string city)
        {
            using var _db = _dbContextFactory.CreateDbContext();
            var obj = await _db.CityMenus.FirstOrDefaultAsync(x => x.City == city);
            if (obj != null)
            {
                return obj;
            }
            return new CityMenu();
        }

        public async Task<CityMenu> UpdateMenuCacheAsync(CityMenu menu)
        {
            using var _db = _dbContextFactory.CreateDbContext();
            if (await _db.CityMenus.FirstOrDefaultAsync(x => x.City == menu.City) is CityMenu found)
            {
                _db.Entry(found).CurrentValues.SetValues(menu);
                await _db.SaveChangesAsync();
            }
            return menu;
        }
    }
}
