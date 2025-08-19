using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.IRepo;
using UtilityLayer.DTO;

namespace ELECTRICIA_Shopping_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryDetailController : ControllerBase
    {
        private readonly ICategoryDetailService _categoryDetailService;
        public CategoryDetailController(ICategoryDetailService categoryDetailService)
        {
            _categoryDetailService = categoryDetailService;
        }
        [HttpGet]
        [Route("getCategorylist")]
        public async Task<IActionResult> GetCategoryDetails()
        {
            var categoryDetails = await _categoryDetailService.GetCategoryDetails();
            return Ok(categoryDetails);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryDetail(int id)
        {
            var categoryDetail = await _categoryDetailService.GetCategoryDetail(id);
            return Ok(categoryDetail);
        }

        [HttpGet]
        [Route("getParentCategory")]
        public async Task<IActionResult> GetParentCategories()
        {
            var parentCategories = await _categoryDetailService.GetParentCategories();
            return Ok(parentCategories);
        }

        
        [HttpGet]
        [Route("getParentCategoryList")]
        public async Task<IActionResult> getListParentCategoryForCategory()
        {
            var getCategoryList = await _categoryDetailService.getListParentCategoryForCategory();
            
            return Ok(getCategoryList);
        }
    }   
}
