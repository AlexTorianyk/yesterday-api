using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace IdentityServer.Utilities.Extensions
{
    public static class PersistentGrantExtension
    {
        public static void UpdateRefreshToken(this PersistedGrant persistedGrant, PersistedGrant refreshToken)
        {
            persistedGrant.Key = refreshToken.Key;
            persistedGrant.Expiration = refreshToken.Expiration;
        }
    }
}
