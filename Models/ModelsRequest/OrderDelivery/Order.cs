using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_DB_and_Request.ModelsRequest.OrderDelivery
{
    public class Order
    {
        public List<Item> items { get; set; }
        public List<Payment> payments { get; set; }
        public string orderTypeId { get; set; }
        public DeliveryPoint deliveryPoint { get; set; }
        public string phone { get; set; }
        public string status { get; set; }
        public string comment { get; set; }
        public Customer customer { get; set; }
    }
}
