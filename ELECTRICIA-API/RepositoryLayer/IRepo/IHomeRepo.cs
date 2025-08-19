using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLayer.DTO;

namespace RepositoryLayer.IRepo
{
    public interface IHomeRepo
    {
        Task<List<SP_GET_TOPDiscountProduct>> GetTOPDiscountProducts();
        Task<List<SP_GET_TopFeauteredProduct>> GET_TopFeauteredProduct();
        Task<List<SP_GET_TopNewArrivalProduct>> GET_TopNewArrivalProducts();
    }
}
