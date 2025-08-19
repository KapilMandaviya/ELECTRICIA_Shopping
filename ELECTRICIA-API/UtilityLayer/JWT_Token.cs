using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UtilityLayer.DTO;

namespace UtilityLayer
{
    public class JWT_Token
    {
        public static string CreatejwtToken(UserMaster_DTO user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();


            var key = Encoding.ASCII.GetBytes("JaiShreeKrishnaThisIsA256BitKey!!!!!!!..");
            var identity = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Role,"user"),
                new Claim("FirstName",$"{user.FirstName}"),
                new Claim("LastName",$"{user.LastName}"),
               // new Claim("Address",$"{user.Address}"),
                new Claim("UserId",$"{user.UserId}"),
                new Claim("CreatedAt",$"{user.CreatedDate}"),
                new Claim("Role",$"{user.RoleId}"),
                new Claim("Username",$"{user.Email}")
            });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescripter = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = credentials

            };
            var token = jwtTokenHandler.CreateToken(tokenDescripter);
            // Verify the expiration

            var jwtString = jwtTokenHandler.WriteToken(token);
            var decodedToken = jwtTokenHandler.ReadJwtToken(jwtString);
            Console.WriteLine("Issued At (iat): " + new DateTimeOffset(decodedToken.IssuedAt).ToUnixTimeSeconds());
            Console.WriteLine("Expires (exp): " + new DateTimeOffset(decodedToken.ValidTo).ToUnixTimeSeconds());
            Console.WriteLine("Expiration DateTime: " + decodedToken.ValidTo.ToString("o"));
            //return jwtTokenHandler.WriteToken(token);
            return jwtString;
        }


      
        public static ClaimsPrincipal GetPrincipalFromEpToken(string token)
        {
            var key = Encoding.ASCII.GetBytes("JaiShreeKrishnaThisIsA256BitKey!!!!!!!..");
            var tokenValidationParameter = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameter, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("This Is Invalid Token");
            }
            return principal;
        }

        public static string CreateRefreshToken()
        {
            var refreshToken = "";
            // Create an instance of the RandomNumberGenerator class
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                // Specify the number of bytes you want to generate
                int numberOfBytes = 64; // 16 bytes for example

                // Create a byte array to store the generated random bytes
                byte[] randomBytes = new byte[numberOfBytes];

                // Use the GetBytes() method to fill the array with random bytes
                rng.GetBytes(randomBytes);

                // Display the generated random bytes as a hexadecimal string

                refreshToken = Convert.ToBase64String(randomBytes);

                
            }
            return refreshToken;
        } 

    }

}

