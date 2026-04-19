using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_DB_and_Request.ModelsRequest.OrderDelivery
{
    public class Item
    {
        public string type { get; set; }
        public string productId { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
    }
}
