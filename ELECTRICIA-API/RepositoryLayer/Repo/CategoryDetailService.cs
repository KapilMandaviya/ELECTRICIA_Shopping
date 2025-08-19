using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLayer.DTO;

namespace RepositoryLayer.Repo
{
    public class CategoryDetailService : ICategoryDetailService
    {
        private readonly ELECTRICIADBContext _Context;
        public CategoryDetailService(ELECTRICIADBContext eLECTRICIADBContext) {
            this._Context = eLECTRICIADBContext;
        }
        

        public Task<CategoriesMasterDto> GetCategoryDetail(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoriesMasterDto>> GetCategoryDetails()
        {
            var result = await _Context.CategoriesMasters
         .Select(x => new CategoriesMasterDto
         {
             CategoriesId = x.CategoriesId,
             Cat_Name = x.CatName,
             PC_Id = x.PcId
         })
         .ToListAsync();
            return result;
        }

      

        public async  Task<List<ParentCategoryDto>> GetParentCategories()
        {
            var parentCategories = await _Context.ParentCategories
                .Select(x => new ParentCategoryDto
                {
                    PcId = x.PcId,
                    PcName = x.PcName
                })
                .ToListAsync();
           return parentCategories;
        }

        public Task<ParentCategoryDto> GetParentCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoriesMasterDto>> getListParentCategoryForCategory()
        {
            var categoryList=  _Context.Set<SPCategoryList>().FromSqlRaw("EXECUTE dbo.getParentandSubCategoriesList")
            .AsEnumerable() // Switch to client-side processing
                .Select(x => new CategoriesMasterDto
            {
                    category= x.category,
                    subcategories=x.subcategories
                })
            .ToList();
            
            
            return categoryList;
        }
    }
}
