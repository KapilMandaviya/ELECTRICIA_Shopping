using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLayer.DTO;

namespace RepositoryLayer.IRepo
{
    public interface ICartWishList
    {
        Task<(int result, string errorMessage)> ClearAndSaveCartAndWishList(Cart_dto cart_Dto);
        Task<(int result, string errorMessage)>  deleteCartandWishList(cart_WishlistRemoveDto cart_Dto);
        Task<List<CartItem_DTO>> getUserWiseCartList(int? Id);
        Task<List<WishlistItem_DTO>> getUserWiseWishList(int? Id);
    }
}
