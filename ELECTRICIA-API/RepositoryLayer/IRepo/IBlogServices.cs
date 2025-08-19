using UtilityLayer.DTO;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RepositoryLayer.IRepo
{
    public interface IBlogServices
    {
        Task<List<DataAccessLayer.DTO.BlogDetailDTO>> listBlogDetails();

        Task<List<DataAccessLayer.DTO.BlogDetailDTO>> GetBlogDetailsById(int Id);

        Task<List<BlogDetailDTO>> recentblogDescriptions();
    }
}
