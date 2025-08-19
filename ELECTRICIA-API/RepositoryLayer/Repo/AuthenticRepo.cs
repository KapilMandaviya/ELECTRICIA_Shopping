using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepo;
using UtilityLayer;
using UtilityLayer.DTO;
using UtilityLayer.ResponseDto;


namespace RepositoryLayer.Repo
{
    public class AuthenticRepo :IAuthenticRepo
    {
        private readonly ELECTRICIADBContext _Context;
        private readonly string dateFormat;

        public AuthenticRepo(ELECTRICIADBContext context)
        {
            _Context = context;

        }
  
        public string checkPasswordstrength(string password)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginResponse> checkUserLogin(UserMaster_DTO user, string  remoteIpAddress)
        {
            try
            {
                LoginResponse response=new LoginResponse();
                var userdetail = _Context.UserMasters
                  .Where(x => x.Email == user.Email && x.IsDelete==false)
                  .Select(x => new
                  {
                      x.UserId,
                      x.FirstName,
                      x.LastName,
                      x.Email,
                      x.Password,
                      x.RoleId

                  })
                  .FirstOrDefault();
                

                if (userdetail == null)
                {
                    response.Token = "";
                    response.IsLogin = false;
                    response.LoginStatus = "InvalidUsername";
                    return response;
                }
                var decode = (DataEncryption.DecodeFrom64(userdetail.Password));


                if (!(DataEncryption.DecodeFrom64(userdetail.Password) == user.Password))
                {
                    response.Token = "";
                    response.IsLogin = false;
                    response.LoginStatus = "InvalidPassword";
                    return response;
                }

                var usertokendetail = new UserMaster_DTO();
                usertokendetail.UserId = userdetail.UserId;
                usertokendetail.FirstName = userdetail.FirstName;
                usertokendetail.LastName= userdetail.LastName;
                usertokendetail.Email = userdetail.Email;
                usertokendetail.RoleId = userdetail.RoleId;
                usertokendetail.CreatedByUserId = userdetail.UserId.ToString();
                

                var token= JWT_Token.CreatejwtToken(usertokendetail);
                var refreshToken = JWT_Token.CreateRefreshToken();
                

                var tokenInUser = _Context.LoginStatuses
                    .Any(a => a.RefreshToken== refreshToken);
                if (tokenInUser)
                {
                    refreshToken= JWT_Token.CreateRefreshToken();
                }
                //  var loginstatus = new LoginStatus();
                //  loginstatus.UserId= userdetail.UserId;
                //  loginstatus.Token = token;
                //  loginstatus.RefreshToken = refreshToken;
                //  loginstatus.IpAddress= remoteIpAddress.ToString();
                //  loginstatus.LoginStatus1 = "200";
                //  loginstatus.CreatedDate = DateTime.Now;
                //  loginstatus.CreatedByUserId = userdetail.UserId.ToString();
                //  loginstatus.IsDelete = false;
                //  loginstatus.ModifyAction = "I";
                //  loginstatus.TokenExpiration = DateTime.Now.AddMinutes(15);
                ////  await _Context.LoginStatuses.AddAsync(loginstatus);
                //  await _Context.SaveChangesAsync();


                // Check if user already has an existing login status
                var existingLoginStatus = await _Context.LoginStatuses
                    .FirstOrDefaultAsync(a => a.UserId == userdetail.UserId);

                if (existingLoginStatus != null)
                {
                    // Update existing record
                    existingLoginStatus.Token = token;
                    existingLoginStatus.RefreshToken = refreshToken;
                    existingLoginStatus.IpAddress = remoteIpAddress.ToString();
                    existingLoginStatus.LoginStatus1 = "200";
                    existingLoginStatus.ModifyAction = "U";
                    existingLoginStatus.TokenExpiration = DateTime.Now.AddMinutes(15);
                    existingLoginStatus.UpdatedDate = DateTime.Now; // Add if you have this column
                    existingLoginStatus.CreatedByUserId = userdetail.UserId.ToString();
                }
                else
                {
                    // Create new record
                    var loginstatus = new LoginStatus
                    {
                        UserId = userdetail.UserId,
                        Token = token,
                        RefreshToken = refreshToken,
                        IpAddress = remoteIpAddress.ToString(),
                        LoginStatus1 = "200",
                        CreatedDate = DateTime.Now,
                        CreatedByUserId = userdetail.UserId.ToString(),
                        IsDelete = false,
                        ModifyAction = "I",
                        TokenExpiration = DateTime.Now.AddMinutes(15)
                    };
                    await _Context.LoginStatuses.AddAsync(loginstatus);
                }

                await _Context.SaveChangesAsync();



                response.Token = token;
                response.RefreshToken = refreshToken;
                response.IsLogin = true;
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Task<bool> checkUsernameExistvalidation(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<TokenResponse> TokenDetail(LoginStatus_DTO loginStatus_DTO)
        {
            TokenResponse response = new TokenResponse();
            string accessToken = loginStatus_DTO.Token;
            string refreshToken = loginStatus_DTO.RefreshToken;

            var principal = JWT_Token.GetPrincipalFromEpToken(accessToken);
            //var username = principal.Identity.Name;
            var usernameClaim = principal.Claims.FirstOrDefault(c => c.Type == "Username");
            var userId = _Context.UserMasters.Where(x=>x.Email==usernameClaim.Value.ToString()).FirstOrDefault();
            var emp = await _Context.LoginStatuses.FirstOrDefaultAsync(x => x.UserId == userId.UserId);
            if (emp is null || emp.RefreshToken != refreshToken || emp.TokenExpiration <= DateTime.Now)
            {
                response.Message = "Bad Request";
                return response;
            }
            else
            {
                var user = await _Context.UserMasters.FirstOrDefaultAsync(x => x.UserId == emp.UserId);
                UserMaster_DTO dto= new UserMaster_DTO();   
                dto.UserId = user.UserId;
                dto.FirstName = user.FirstName;
                dto.LastName = user.LastName;
                 dto.Email = user.Email;
                

                string token = JWT_Token.CreatejwtToken(dto);
                response.Token = token;
                string returnrefreshToken = JWT_Token.CreateRefreshToken();
                response.RefreshToken= returnrefreshToken;

                var tokenInUser = _Context.LoginStatuses
                    .Where(a => a.RefreshToken== response.RefreshToken && a.UserId==emp.UserId).FirstOrDefault();
                if (tokenInUser !=null)
                {
                    returnrefreshToken= JWT_Token.CreateRefreshToken();
                }
                emp.Token = token;
                emp.RefreshToken = returnrefreshToken;
                await _Context.SaveChangesAsync();
                response.Message = "Success";
                
            }
            return response;
        }
    }
}
