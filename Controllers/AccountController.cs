using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using PizzaShopController.models;

namespace PizzaShopController.Controllers
{
    public class AccountController
    {
        [HttpPost("/token")]
        public ActionResult Token(string username, string password)
        {


            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                issuer: TokenOps.ISSUER,
                audience: TokenOps.AUDIENCE,
                notBefore: now,
                expires: now.Add(TimeSpan.FromMinutes(TokenOps.LIFETIME)),
                signingCredentials: new SigningCredentials(TokenOps.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username
            };
            return new JsonResult(response);
        }
    }
}
