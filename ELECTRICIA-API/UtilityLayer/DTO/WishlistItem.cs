using System;
using System.Collections.Generic;

namespace UtilityLayer.DTO
{

    public partial class WishlistItem_DTO
    {
        public int? ProductId { get; set; }

        public string? productName { get; set; }

        public string? imageUrl { get; set; }


        public int? quantity { get; set; }

        public double? price { get; set; }

        public double? totalPrice { get; set; }


    }
}