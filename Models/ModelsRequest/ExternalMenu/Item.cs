using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_DB_and_Request.ModelsRequest.ExternalMenu
{
    public class Item
    {
        public string sku { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<object> allergens { get; set; }
        public List<object> tags { get; set; }
        public List<object> labels { get; set; }
        public List<ItemSize> itemSizes { get; set; }
        public string itemId { get; set; }
        public object modifierSchemaId { get; set; }
        public object taxCategory { get; set; }
        public string modifierSchemaName { get; set; }
        public string type { get; set; }
        public bool canBeDivided { get; set; }
        public bool canSetOpenPrice { get; set; }
        public bool useBalanceForSell { get; set; }
        public string measureUnit { get; set; }
        public string productCategoryId { get; set; }
        public List<object> customerTagGroups { get; set; }
        public string paymentSubject { get; set; }
        public string paymentSubjectCode { get; set; }
        public object outerEanCode { get; set; }
        public bool isMarked { get; set; }
        public bool isHidden { get; set; }
        public object barcodes { get; set; }
        public string orderItemType { get; set; }
        public Restrictions restrictions { get; set; }
        public List<object> allergenGroups { get; set; }
        public NutritionPerHundredGrams nutritionPerHundredGrams { get; set; }
        public double portionWeightGrams { get; set; }
        public List<Price> prices { get; set; }
        public int position { get; set; }
        public bool independentQuantity { get; set; }
        public string measureUnitType { get; set; }
        public object buttonImageUrl { get; set; }
    }
}
