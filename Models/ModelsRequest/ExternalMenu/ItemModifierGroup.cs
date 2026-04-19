using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_DB_and_Request.ModelsRequest.ExternalMenu
{
    public class ItemModifierGroup
    {
        public string name { get; set; }
        public string description { get; set; }
        public Restrictions restrictions { get; set; }
        public List<Item> items { get; set; }
        public bool canBeDivided { get; set; }
        public string itemGroupId { get; set; }
        public bool isHidden { get; set; }
        public bool childModifiersHaveMinMaxRestrictions { get; set; }
        public string sku { get; set; }
    }
}
