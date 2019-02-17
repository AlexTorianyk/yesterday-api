using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer.Core.Users;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;

namespace IdentityServer.Core
{
    public class ProfileService : IProfileService
    {
        private readonly IUserIdentityService _userIdentityService;

        public ProfileService(IUserIdentityService userIdentityService)
        {
            _userIdentityService = userIdentityService;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var subNumber = Convert.ToInt32(sub);

            var user = await _userIdentityService.GetById(subNumber);

            var claims = await GetUserClaims(user);

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
        }

        private async Task<List<Claim>> GetUserClaims(UserIdentity user)
        {
            var claims = new List<Claim> { new Claim(JwtClaimTypes.Email, user.Email) };

            if (await _userIdentityService.IsInRoleAsync(user, "Admin"))
            {
                claims.Add(new Claim(JwtClaimTypes.Role, "Admin"));
            }

            return claims;
        }
    }
}