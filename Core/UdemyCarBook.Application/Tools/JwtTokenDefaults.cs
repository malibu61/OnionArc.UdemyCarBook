using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "https://localhost";
        public const string ValidIssuer = "https://localhost";
        public const string Key = "bY9*FgL$uWmZqR7@2DkNpA1&HsXeCjQ3";
        public const int Expire = 3;    //3 dakika
    }
}
