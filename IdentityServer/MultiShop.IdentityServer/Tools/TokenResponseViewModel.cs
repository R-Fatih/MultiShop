using System;

namespace MultiShop.IdentityServer.Tools
{
    public class TokenResponseViewModel
    {
       

        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
