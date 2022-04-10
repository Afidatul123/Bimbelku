using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bimbelku.Helper
{
    public static class BantuDapatkan
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                return user.Claims.FirstOrDefault(
                    dapatuser => 
                    dapatuser.Type == "Username"
                    )?
                    .Value ?? string.Empty;
            }
            return string.Empty;
        }
    }
}
