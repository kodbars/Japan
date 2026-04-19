using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_DB_and_Request.ModelsRequest.OrderDelivery
{
    public class Payment
    {
        public string paymentTypeKind { get; set; }
        public double sum { get; set; }
        public string paymentTypeId { get; set; }
    }
}
