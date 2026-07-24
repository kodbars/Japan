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
        private readonly IExternalMenuService _externalMenuService;
        private readonly ILogger<ExternalMenuCacheDB> _logger;

        public ExternalMenuCacheDB(IDbContextFactory<AppDbContext> dbContextFactory, IExternalMenuService externalMenuService, ILogger<ExternalMenuCacheDB> logger)
        {
            _dbContextFactory = dbContextFactory;
            _externalMenuService = externalMenuService;
            _logger = logger;
        }

        public Task<CityMenu> CreateMenuCache(Root menu)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CityMenu>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CityMenu> GetMenuCache(Root menu)
        {
            throw new NotImplementedException();
        }

        public async Task<CityMenu> UpdateMenuCache(Root menu)
        {
            using var _db = _dbContextFactory.CreateDbContext();
            if (await _db.CityMenus.FirstOrDefaultAsync(x => x.OrganizationId == menu.) is CityMenu found)
            {
                _db.Entry(found).CurrentValues.SetValues(obj);
                await _db.SaveChangesAsync();
            }
            return obj;
        }
    }
}
