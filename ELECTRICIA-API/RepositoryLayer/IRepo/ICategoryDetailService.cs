using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLayer.DTO;

namespace RepositoryLayer.IRepo
{
    public interface ICategoryDetailService
    {
         Task<List<CategoriesMasterDto>> GetCategoryDetails();
        Task<CategoriesMasterDto> GetCategoryDetail(int id);
        

        Task<List<ParentCategoryDto>>   GetParentCategories();
        Task<ParentCategoryDto> GetParentCategory(int id);

        Task<List<CategoriesMasterDto>> getListParentCategoryForCategory();
    }
}
