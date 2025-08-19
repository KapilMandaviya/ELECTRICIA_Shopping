using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLayer.ResponseDto
{
    public class LoginResponse
    {
        public bool IsLogin { get; set; }
        public string LoginStatus { get; set; }

        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }

    public class TokenResponse
    {
        public string Message { get; set; }
        public bool IsLogin { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
