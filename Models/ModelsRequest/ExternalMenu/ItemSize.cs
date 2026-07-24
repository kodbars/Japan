using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_DB_and_Request.ModelsRequest.ExternalMenu
{
    public class ItemSize
    {
        public string sku { get; set; }
        public string sizeCode { get; set; }
        public string sizeName { get; set; }
        public bool isDefault { get; set; }
        public double portionWeightGrams { get; set; }
        public List<ItemModifierGroup> itemModifierGroups { get; set; }
        public string sizeId { get; set; }
        public NutritionPerHundredGrams nutritionPerHundredGrams { get; set; }
        public List<Price> prices { get; set; }
        public List<Nutrition> nutritions { get; set; }
        public bool isHidden { get; set; }
        public string measureUnitType { get; set; }
        public string buttonImageUrl { get; set; }
    }
}
