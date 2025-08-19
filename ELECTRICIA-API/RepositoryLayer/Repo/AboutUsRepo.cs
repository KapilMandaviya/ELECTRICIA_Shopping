using DataAccessLayer.Data;
using RepositoryLayer.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLayer.DTO;

namespace RepositoryLayer.Repo
{
    public class AboutUsRepo : IAboutUsDetail
    {
        private readonly ELECTRICIADBContext _Context;
        public AboutUsRepo(ELECTRICIADBContext eLECTRICIADBContext)
        {
            this._Context = eLECTRICIADBContext;
        }
        public async Task<AboutusDto> AboutUsDetail()
        {
            //var aboutus = _Context.AboutDetails
            //    .Select(x => new AboutusDto
            //    {
            //        AbId = x.AbId,
            //        AboutHeader = x.AboutHeader,
            //        AboutDescription= x.AboutDescription,
            //        CreatedByUserId = x.CreatedByUserId,
            //        CreatedDate = x.CreatedDate,    

            //    }).Where(x=>x.IsDelete==false).FirstOrDefault();

            var result = _Context.AboutDetails
            .Where(a => a.IsDelete == false) // Filter directly on entity
            .Select(a => new AboutusDto
            {
                AbId = a.AbId,
                AboutHeader = a.AboutHeader,
                AboutDescription = a.AboutDescription,
                CreatedByUserId = a.CreatedByUserId,
                
            })
            .FirstOrDefault();

            return result;
        }

        public async Task<List<ContactUs>> ContactUsList()
        {
            var result = _Context.ContactUs
           .Where(a => a.IsDelete == false) // Filter directly on entity
           .Select(a => new ContactUs
           {
               ContactId = a.ContactId,
               EmailAddress = a.EmailAddress,
               PhoneNumber = a.PhoneNumber,
               OfficeAddress = a.OfficeAddress,


           })
           .ToList();

            return result;
            }

        public async Task<List<FAQDto>> FaqList()
        {
            var FAQ = _Context.FaqDetails
         .Where(a => a.IsDelete == false) // Filter directly on entity
         .Select(a => new FAQDto
         {
             FaqAnswer = a.FaqAnswer,
             FaqId = a.FaqId,
             FaqQuestion = a.FaqQuestion,


         })
         .ToList();

            return FAQ;
        }

        public async Task<List<ServicesDetailsDto>> getServicesDetails()
        {
            var getServices= _Context.ServiceDetails
            .Where(a => a.IsDelete == false) // Filter directly on entity
            .Select(a => new ServicesDetailsDto
            {
               ServiceId=a.ServiceId,
                ServiceCaption = a.ServiceCaption,
                ServiceDetail1= a.ServiceDetail1,
                ServiceLink = a.ServiceLink,  
            })
            .ToList();

            return getServices;
        }
    }
}
