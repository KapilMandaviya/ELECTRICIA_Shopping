using DataAccessLayer.Data;

using DataAccessLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using UtilityLayer.DTO;
//using UtilityLayer.DTO;

namespace RepositoryLayer.Repo
{
    public class BlogServices : IBlogServices
    {
        private readonly ELECTRICIADBContext _Context;
        public BlogServices(ELECTRICIADBContext eLECTRICIADBContext)
        {
            this._Context = eLECTRICIADBContext;
        }

        

        public async Task<List<DataAccessLayer.DTO.BlogDetailDTO>> listBlogDetails()
        {
            try
            {
                var result = await _Context.Set<DataAccessLayer.DTO.BlogDetailDTO>().FromSqlRaw("EXECUTE dbo.getBlogDetailComments").ToListAsync();

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<DataAccessLayer.DTO.BlogDetailDTO>> GetBlogDetailsById(int Id)
        {
            try
            {
                var result = await _Context.Set<DataAccessLayer.DTO.BlogDetailDTO>()
                .FromSqlRaw("EXECUTE dbo.getBlogDetailById @BlogId = {0}", Id)
                .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<BlogDetailDTO>> recentblogDescriptions()
        {
            var parameters = new[]
            {
            //    new SqlParameter("@BlogId", blogId),
                new SqlParameter("@status", "recentBlogPost" ),
              //  new SqlParameter("@UserId", userId.HasValue ? (object)userId.Value : DBNull.Value)
            };

            var result = await _Context.BlogDescriptions
                .FromSqlRaw("EXECUTE dbo.AllBlogDetail @status ", parameters)
                .ToListAsync();

            // Map to BlogDetailDTO
            var  result1 =  result.Select(b => new BlogDetailDTO
            {
                Blog_Id = b.BlogId,
                Blog_By =b.  BlogBy,
                Blog_Caption = b.BlogCaption,
                Blog_Description= b.BlogDescription1,
                Blog_Date=b.BlogDate,
                Blog_Image=b.BlogImage,
                Blog_Tags=b.BlogTags
               
                
            }).ToList();

            return result1;
        }
    }
}
