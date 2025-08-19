using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.IRepo;
using System.Security.Cryptography;
using UtilityLayer;
using UtilityLayer.DTO;

namespace ELECTRICIA_Shopping_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticController : ControllerBase
    {
        readonly IAuthenticRepo _data;
        public AuthenticController(IAuthenticRepo dataAccess)
        {
            this._data = dataAccess;
        }
        
        [Route("authenticateLogin")]
        [HttpPost]
        public async Task<IActionResult> authenticateLogin(UserMaster_DTO user)
            {
            try
            {
                var employeeToken = "";
                if (user.Email == null || user.Email=="")
                    return Ok(new { message = "Please Enter valid Username" });
                var remoteIpAddress = HttpContext.Connection.RemoteIpAddress;
                string? message="", RefToken = "";

                var Userlogin = await _data.checkUserLogin(user,remoteIpAddress.ToString());

                if (Userlogin.IsLogin == true)
                {
                    message = "Login SuccessFully";
                    employeeToken = Userlogin.Token;
                    RefToken = Userlogin.RefreshToken;
                }
                else if (Userlogin.LoginStatus == "InvalidUsername" && Userlogin.IsLogin == false) {
                    message = "This Username not registered with us."; 
                }
                else if (Userlogin.LoginStatus == "InvalidPassword" && Userlogin.IsLogin == false)
                {
                    message = "Invalid cridentials. Please try again.";
                }
                // Store token in session
                //HttpContext.Session.SetString("Token", Userlogin.Token);

                // Optionally store refresh token if you have one

                //HttpContext.Session.SetString("RefreshToken", Userlogin.RefreshToken);
                return Ok(new
                {
                    Token = employeeToken,
                    Message = message,
                    RefreshToken = RefToken
                });
            }
            catch (Exception ex)
            {

                throw ex;   
            }

        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(LoginStatus_DTO user)
        {
            if (user is null)
                return BadRequest("Invalid Request");
             
            var refreshToken = await _data.TokenDetail(user);
            // Store token in session
           // HttpContext.Session.SetString("Token", refreshToken.Token);

            // Optionally s     tore refresh token if you have one

            //HttpContext.Session.SetString("RefreshToken", refreshToken.RefreshToken);
            return Ok(new {
                token = refreshToken.Token,
                refreshToken = refreshToken.RefreshToken,
                message = refreshToken.Message
            });
        }


        //[HttpPost("checkedIsLogin")]
        //public async Task<IActionResult> checkedIsLogin(LoginStatus_DTO user)
        //{
        //    if (user is null)
        //        return BadRequest("Invalid Request");

        //    // Read the token from session
        //    //string token = HttpContext.Session.GetString("Token");

        //    if (string.IsNullOrEmpty(token))
        //    {
        //        return Unauthorized("No token found in session");
        //    }

        //    var refreshToken = await _data.TokenDetail(user);
        //    // Store token in session
        //   // HttpContext.Session.SetString("Token", refreshToken.Token);

        //    // Optionally store refresh token if you have one

        //   //
        // a  //HttpContext.Session.SetString("RefreshToken", refreshToken.RefreshToken);
        //    return Ok(new
        //    {
        //        UserToken = refreshToken.Token,
        //        UserRefToken = refreshToken.RefreshToken,
        //        UserMessage = refreshToken.Message
        //    });
        //}






    }

}

