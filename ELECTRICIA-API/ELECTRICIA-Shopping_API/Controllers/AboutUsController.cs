using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.IRepo;

namespace ELECTRICIA_Shopping_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        readonly IAboutUsDetail aboutUsDetail ;
        readonly IBlogServices blogServices;

        public AboutUsController(IAboutUsDetail aboutUs,IBlogServices blog)
        {
             this.aboutUsDetail = aboutUs;
            this.blogServices = blog;
        }
 
        [Route("AboutUsDetail")]
        [HttpGet]
        public async Task<IActionResult> AboutUs() {

            var aboutUs = await aboutUsDetail.AboutUsDetail();
            return Ok(aboutUs);
        }
        
        [Route("ContactDetail")]
        [HttpGet]
        public async Task<IActionResult> contactUsDetail()
        {

            var contactUsDetail = await aboutUsDetail.ContactUsList();
            return Ok(contactUsDetail);
        }

        
        [Route("FAQDtails")]
        [HttpGet]
        public async Task<IActionResult> FAQDtails()
        {

            var FAQDtails = await aboutUsDetail.FaqList();
            return Ok(FAQDtails);
        }

        [Authorize]
        [Route("ServicesDetails")]
        [HttpGet]
        public async Task<IActionResult> ServicesDetails()
        {
            var ServicesDetails = await aboutUsDetail.getServicesDetails();
            return Ok(ServicesDetails);
        }

        [Authorize]
        [Route("BlogServices")]
        [HttpGet]
        public async Task<IActionResult> BlogServices()
        {
            var ServicesDetails = await blogServices.listBlogDetails();
            return Ok(ServicesDetails);
        }

        [Authorize]
        [Route("getBlogDetailById/{Id}")]
        [HttpGet]
        public async Task<IActionResult> getBlogDetailById(int Id)
        {
            var ServicesDetails = await blogServices.GetBlogDetailsById(Id);
            return Ok(ServicesDetails);
        }

        [Route("getRecentBlogDetails")]
        [HttpGet]
        public async Task<IActionResult> getRecentBlogDetails( )
        {
            var ServicesDetails = await blogServices.recentblogDescriptions();
            return Ok(ServicesDetails);
        }
    }
}
