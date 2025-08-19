using System;
using System.Collections.Generic;

namespace UtilityLayer.DTO
{

    public partial class ProductsMaster_DTO
    {
        public int? ProductId { get; set; }

        public string? PName { get; set; }

        public string? PSku { get; set; }

        public string? CategoryId { get; set; }

        public double? PBasePrice { get; set; }

        public int? PStock { get; set; }

        public string? PDescription { get; set; }


        public int? ImageID { get; set; }
        public string? Img_Name { get; set; }
    }
}