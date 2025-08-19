using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepo;
using UtilityLayer.DTO;

namespace RepositoryLayer.Repo
{
    public class ProductServiceDetails : IProductServiceDetails
    {
        private readonly ELECTRICIADBContext _Context;
        public ProductServiceDetails(ELECTRICIADBContext eLECTRICIADBContext)
        {
            this._Context = eLECTRICIADBContext;
        }


        public async Task<List<ProductsMaster_DTO>> getProductCategoryListDetils(int category)
        {
            try
            {
                var categoryList = await _Context.Set<SPProdcutCategoryList>().FromSqlRaw("EXECUTE dbo.getProductCategoryByList @categoryId = {0}", category)
                 .ToListAsync(); // Switch to client-side processing

                var resultCategoryList = categoryList.Select(x => new ProductsMaster_DTO
                {
                    ProductId = x.ProductId,
                    PBasePrice = x.P_BasePrice,
                    PDescription = x.P_Description,
                    PName = x.P_Name,
                    PSku = x.P_SKU,
                    CategoryId = x.Cat_Name,
                    PStock = x.P_Stock,
                    ImageID = x.ImageID,
                    Img_Name = x.Img_Name,

                })
               .ToList();


                return resultCategoryList;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ProductsMaster_DTO> getProductDetils(int productId)
        {
            try
            {
                var categoryList =  _Context.Set<SPProdcutCategoryList>().FromSqlRaw("EXECUTE dbo.getProductByProductId @productId = {0}", productId)
                 .AsEnumerable().FirstOrDefault(); // Switch to client-side processing

                ProductsMaster_DTO productDto = new ProductsMaster_DTO();

                if (categoryList != null)
                {
                    productDto.ProductId = categoryList.ProductId;
                    productDto.PBasePrice = categoryList.P_BasePrice;
                    productDto.PDescription = categoryList.P_Description;
                    productDto.PName = categoryList.P_Name;
                    productDto.PSku = categoryList.P_SKU;
                    productDto.CategoryId = categoryList.Cat_Name;
                    productDto.PStock = categoryList.P_Stock;
                    productDto.ImageID = categoryList.ImageID;
                    productDto.Img_Name = categoryList.Img_Name;
                }

                return productDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
