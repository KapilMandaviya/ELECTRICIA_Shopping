using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.IRepo;

namespace ELECTRICIA_Shopping_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeRepo _data;
        public HomeController(IHomeRepo dataAccess)
        {
            this._data = dataAccess;
        }

        [HttpGet]
        [Route("getTopDiscountProduct")]
        public async Task<ActionResult> getTopDiscountProduct()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cartItemList = await this._data.GetTOPDiscountProducts();
            return Ok(cartItemList);

        }

        [HttpGet]
        [Route("GET_TopFeauteredProduct")]
        public async Task<ActionResult> GET_TopFeauteredProduct()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cartItemList = await this._data.GET_TopFeauteredProduct();
            return Ok(cartItemList);

        }

        [HttpGet]
        [Route("GET_TopNewArrivalProducts")]
        public async Task<ActionResult> GET_TopNewArrivalProducts()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cartItemList = await this._data.GET_TopNewArrivalProducts();
            return Ok(cartItemList);

        }

    }
}
