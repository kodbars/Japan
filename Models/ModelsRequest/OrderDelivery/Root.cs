using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_DB_and_Request.ModelsRequest.OrderDelivery
{
    public class Root
    {
        public string organizationId { get; set; }
        public string terminalGroupId { get; set; }
        public CreateOrderSettings createOrderSettings { get; set; }
        public Order order { get; set; }
    }
}
