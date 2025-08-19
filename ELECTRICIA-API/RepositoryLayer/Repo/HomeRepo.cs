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
    public class HomeRepo :IHomeRepo
    {
        private readonly ELECTRICIADBContext _Context;
        public HomeRepo(ELECTRICIADBContext eLECTRICIADBContext)
        {
            this._Context = eLECTRICIADBContext;
        }

        public async Task<List<SP_GET_TOPDiscountProduct>> GetTOPDiscountProducts()
        {
            try
            {
                var categoryList = await _Context.Set<SP_GET_TOPDiscountProduct>().FromSqlRaw("EXECUTE GET_TOPDiscountProduct")
                      .ToListAsync(); // Switch to client-side processing

                var resultCategoryList = categoryList.Select(x => new SP_GET_TOPDiscountProduct
                {
                    CategoryName = x.CategoryName,
                    DiscountName = x.DiscountName,
                    DiscountType = x.DiscountType,
                    DiscountValue = x.DiscountValue,
                    FinalPrice = x.FinalPrice,
                    ProductId = x.ProductId,
                    P_BasePrice = x.P_BasePrice,
                    P_Description = x.P_Description,
                    P_Name = x.P_Name,
                    P_SKU = x.P_SKU,
                    P_Stock = x.P_Stock,
                    EndDate=x.EndDate,
                    img_name =x.img_name
                    
                })
               .ToList();


                return resultCategoryList;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<List<SP_GET_TopFeauteredProduct>> GET_TopFeauteredProduct()
        {
            try
            {
                var categoryList = await _Context.Set<SP_GET_TopFeauteredProduct>().FromSqlRaw("EXECUTE [GET_TopFeauteredProducts]")
                      .ToListAsync(); // Switch to client-side processing

                var resultCategoryList = categoryList.Select(x => new SP_GET_TopFeauteredProduct
                {
                   ProductId= x.ProductId,
                   P_Name=x.P_Name,
                   img_name=x.img_name,
                   CategoryName=x.CategoryName,
                   P_Description=x.P_Description,
                   P_SKU=x.P_SKU,
                   P_Stock  =x.P_Stock,
                   StartDate=x.StartDate,
                    SortOrder = x.SortOrder,
                   EndDate =x.EndDate,
                   P_BasePrice = x.P_BasePrice,
                   FinalPrice = x.FinalPrice,
                   DiscountName = x.DiscountName,
                   DiscountType = x.DiscountType,
                   DiscountValue = x.DiscountValue,
                   DiscountEndDate = x.DiscountEndDate, 
                   
                  
                    
                }).OrderBy(x=>x.SortOrder)
               .ToList();


                return resultCategoryList;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<SP_GET_TopNewArrivalProduct>> GET_TopNewArrivalProducts()
        {
            try
            {
                var categoryList = await _Context.Set<SP_GET_TopNewArrivalProduct>().FromSqlRaw("EXECUTE [GET_TopNewArrivalProducts]")
                      .ToListAsync(); // Switch to client-side processing

                var resultCategoryList = categoryList.Select(x => new SP_GET_TopNewArrivalProduct
                {
                    ProductId = x.ProductId,
                    P_Name = x.P_Name,
                    img_name = x.img_name,
                    CategoryName = x.CategoryName,
                    P_Description = x.P_Description,
                    P_SKU = x.P_SKU,
                    P_Stock = x.P_Stock,
                    StartDate = x.StartDate,
                    
                    EndDate = x.EndDate,
                    P_BasePrice = x.P_BasePrice,
                    FinalPrice = x.FinalPrice,
                    DiscountName = x.DiscountName,
                    DiscountType = x.DiscountType,
                    DiscountValue = x.DiscountValue,
                    DiscountEndDate = x.DiscountEndDate,



                })
               .ToList();


                return resultCategoryList;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
