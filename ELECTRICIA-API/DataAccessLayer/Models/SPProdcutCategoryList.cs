using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class SPProdcutCategoryList
    {
        //PM.P_Name,P_SKU,cm.Cat_Name,P_BasePrice,P_Description,ImageID,Img_Name
        public int? ProductId { get; set; }

        public string? P_Name { get; set; }

        public string? P_SKU { get; set; }

        public string? Cat_Name { get; set; }

        public double? P_BasePrice { get; set; }

        public int? P_Stock { get; set; }

        public string? P_Description { get; set; }

        public int? ImageID { get; set; }
        public string? Img_Name { get; set; }
    }
}
