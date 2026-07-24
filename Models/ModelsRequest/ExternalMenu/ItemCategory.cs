using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_DB_and_Request.ModelsRequest.ExternalMenu
{
    public class ItemCategory
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string buttonImageUrl { get; set; }
        public object headerImageUrl { get; set; }
        public object iikoGroupId { get; set; }
        public List<Item> items { get; set; }
        public object scheduleId { get; set; }
        public object scheduleName { get; set; }
        public List<object> schedules { get; set; }
        public bool isHidden { get; set; }
        public List<object> tags { get; set; }
        public List<object> labels { get; set; }
    }
}
