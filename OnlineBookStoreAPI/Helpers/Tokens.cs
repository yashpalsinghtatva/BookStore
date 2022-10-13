using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Helpers
{
    public class Tokens
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
    }
}
