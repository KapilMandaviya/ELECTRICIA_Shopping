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
    public interface IAuthenticRepo
    {
        string checkPasswordstrength(string password);
        Task<bool> checkUsernameExistvalidation(string username);
        Task<LoginResponse> checkUserLogin(UserMaster_DTO user, string  remoteIpAddress);
        
        Task<TokenResponse> TokenDetail(LoginStatus_DTO loginStatus_DTO);


    }
}
