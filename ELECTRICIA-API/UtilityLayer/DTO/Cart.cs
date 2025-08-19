using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UtilityLayer.DTO
{
    public partial class Cart_dto
    {
        public int? UserId { get; set; }

        [JsonPropertyName("cartItems")]
        public List<CartItem_DTO> CartItem { get; set; } = new();

        [JsonPropertyName("wishlistItems")]
        public List<WishlistItem_DTO> Wishlistitem { get; set; } = new();

    }

    public partial class cart_WishlistRemoveDto
    {
        public int? UserId { get; set; }

        [JsonPropertyName("Cart_ProductId")]
        public int? Cart_ProductId { get; set; }

        [JsonPropertyName("wishlist_ProductId")]
        public int? wishlist_ProductId { get; set; }


    }
}