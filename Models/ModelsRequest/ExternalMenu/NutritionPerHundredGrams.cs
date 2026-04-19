using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_DB_and_Request.ModelsRequest.ExternalMenu
{
    public class NutritionPerHundredGrams
    {
        public double fats { get; set; }
        public double proteins { get; set; }
        public double carbs { get; set; }
        public double energy { get; set; }
        public List<object> organizations { get; set; }
        public object saturatedFattyAcid { get; set; }
        public object salt { get; set; }
        public object sugar { get; set; }
    }
}
