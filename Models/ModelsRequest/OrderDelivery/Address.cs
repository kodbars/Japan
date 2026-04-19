using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_DB_and_Request.ModelsRequest.OrderDelivery
{
    public class Address
    {
        public Street street { get; set; }
        public string house { get; set; }
        public string type { get; set; }
    }
}
