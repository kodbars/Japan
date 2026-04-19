using Models_DB_and_Request.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japan_DB.Repository.IRepository
{
    public interface ICityMenuRepository
    {
        public Task Update(CityMenu obj);
        public Task<CityMenu> Get(string city);
    }
}
