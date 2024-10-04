using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PizzaShopController.models
{
    public class TokenOps
    {
        public const string ISSUER = "bebraINC"; 
        public const string AUDIENCE = "Izmail"; 
        const string KEY = "IaNeOtdamFranciiKluchiOtServicaKakIDurov";   
        public const int LIFETIME = 1; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}

