using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class SP_GET_TopFeauteredProduct
    {
        public int ProductId { get; set; }
        public string P_Name { get; set; }
        public string P_SKU { get; set; }
        public double P_BasePrice { get; set; }
        public int P_Stock { get; set; }
        public string img_name { get; set; }
        public string P_Description { get; set; }
        public string CategoryName { get; set; }

     
        public int SortOrder { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? DiscountName { get; set; } 
        public string? DiscountType { get; set; } 
        public decimal? DiscountValue { get; set; }

        public DateTime? DiscountEndDate { get; set; } 
        // Computed field for convenience
        public double FinalPrice { get; set; }

    }
}
