using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Server.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        //For Now use You will be using a symetric key 
        private string key = "qwasxcdfskfdserwasdmlpdj-dsadasjodadpwadmasdmwansda;fnsakfnainfa;ewandas";
            
        public string GenerateJWTToken(string userId)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var credentials = new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);
            var payloads = new JwtPayload(userId,null,null,null,DateTime.Today.AddDays(1));
            var securityToken = new JwtSecurityToken(header,payloads);
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}