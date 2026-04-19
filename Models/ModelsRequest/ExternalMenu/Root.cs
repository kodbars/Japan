using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_DB_and_Request.ModelsRequest.ExternalMenu
{
    public class Root
    {
        public List<ProductCategory> productCategories { get; set; }
        public List<object> customerTagGroups { get; set; }
        public int revision { get; set; }
        public int formatVersion { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public object buttonImageUrl { get; set; }
        public List<object> intervals { get; set; }
        public List<ItemCategory> itemCategories { get; set; }
        public List<object> comboCategories { get; set; }
    }
}
