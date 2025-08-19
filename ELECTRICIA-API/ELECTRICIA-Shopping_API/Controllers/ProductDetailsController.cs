using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.IRepo;
using RepositoryLayer.Repo;

namespace ELECTRICIA_Shopping_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : Controller
    {
        private readonly IProductServiceDetails _data;
        public ProductDetailsController(IProductServiceDetails dataAccess)
        {
            this._data = dataAccess;
        }

        [HttpGet]
        [Route("getProductListByProdcutCategory/{Id}")]
        public async Task<IActionResult> getProductListByProdcutCategory(int Id)
        {
            var productCategoryList = await this._data.getProductCategoryListDetils(Id);
            return Ok(productCategoryList);


        }

        [HttpGet]
        [Route("getProductByProdcutId/{Id}")]
        public async Task<IActionResult> getProductByProdcutId(int Id)
        {
            var productDetails = await this._data.getProductDetils(Id);
            return Ok(productDetails);


        }




    }
}
