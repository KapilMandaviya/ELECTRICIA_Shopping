
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.IRepo;
using UtilityLayer.DTO;

namespace ELECTRICIA_Shopping_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartWishListController : Controller
    {
        private readonly ICartWishList _data;
        public CartWishListController(ICartWishList dataAccess)
        {
            this._data = dataAccess;
        }

        [HttpPost]
        [Route("saveCartandWishList")]
        public async Task<ActionResult> saveCartandWishList([FromBody] Cart_dto cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cartWishList = await this._data.ClearAndSaveCartAndWishList(cart);
            return Ok(new
            {
                result = cartWishList.result,
                errorMessage = cartWishList.errorMessage
            });

        }

        [HttpPost]
        [Route("deleteCartandWishList")]
        public async Task<ActionResult> deleteCartandWishList([FromBody] cart_WishlistRemoveDto cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cartWishList = await this._data.deleteCartandWishList(cart);
            return Ok(new
            {
                result = cartWishList.result,
                errorMessage = cartWishList.errorMessage
            });

        }


        [HttpGet]
        [Route("getUserWiseCartList/{Id}")]
        public async Task<ActionResult> getUserWiseCartList(int? Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cartItemList = await this._data.getUserWiseCartList(Id);
            return Ok(cartItemList);

        }

        [HttpGet]
        [Route("getUserWiseWishList/{Id}")]
        public async Task<ActionResult> getUserWiseWishList(int? Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var WishItemList = await this._data.getUserWiseWishList(Id);
            return Ok(WishItemList);

        }
    }
}
