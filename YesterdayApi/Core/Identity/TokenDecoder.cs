using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using YesterdayApi.Utilities.AutomaticDI;

namespace YesterdayApi.Core.Identity
{
    public class TokenDecoder : ITokenDecoder, ITransient
    {
        public int GetUserId(string authHeader)
        {
            if (string.IsNullOrEmpty(authHeader))
            {
                throw new UnauthorizedException("Error", "Authorization header is empty.");
            }

            var decodedToken = GetDecodedToken(authHeader);

            if (TokenTooOld(decodedToken.ValidTo))
            {
                throw new UnauthorizedException("Error", "Access token is too old, please login.");
            }

            var id = Convert.ToInt32(decodedToken.Subject);
            return id;
        }

        private static JwtSecurityToken GetDecodedToken(string authHeader)
        {
            var encodedJwt = authHeader.Substring(7);
            var decodedToken = new JwtSecurityToken(encodedJwt);
            return decodedToken;
        }

        private static bool TokenTooOld(DateTime expiryDate)
        {
            return (DateTime.Now.Date - expiryDate).TotalDays > 5;
        }
    }
}
