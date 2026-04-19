using Japan_DB.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models_DB_and_Request.Data;
using Models_DB_and_Request.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japan_DB.Repository
{
    public class CityMenuRepository : ICityMenuRepository
    {
        IDbContextFactory<AppDbContext> _factory;

        public CityMenuRepository(IDbContextFactory<AppDbContext> factory)
        {
            _factory = factory;
        }

        public Task<CityMenu> Get(string city)
        {
            throw new NotImplementedException();
        }

        public async Task Update(CityMenu obj)
        {
            using var _db = _factory.CreateDbContext();
            if (await _db.CityMenus.FirstOrDefaultAsync(x => x.Id == obj.Id) is CityMenu found)
            {
                _db.Entry(found).CurrentValues.SetValues(obj);
                await _db.SaveChangesAsync();
            }
        }
    }
}
