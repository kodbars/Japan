using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_DB_and_Request.ModelsRequest.ExternalMenu
{
    public class Restrictions
    {
        public int minQuantity { get; set; }
        public int maxQuantity { get; set; }
        public int freeQuantity { get; set; }
        public int byDefault { get; set; }
        public bool hideIfDefaultQuantity { get; set; }
    }
}
