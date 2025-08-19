using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLayer.DTO;
using UtilityLayer.ResponseDto;

namespace RepositoryLayer.IRepo
{
    public interface IAboutUsDetail
    {
        Task<AboutusDto> AboutUsDetail();

        Task<List<ContactUs>> ContactUsList();

        Task<List<FAQDto>> FaqList();

        Task<List<ServicesDetailsDto>> getServicesDetails();
    }
}
