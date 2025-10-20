using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise4
{
    public class Account
    {
        public string User {  get; init; }
        public string Password { get; init; }

        public Account (string user, string password)
        {
            User = user;
            Password = password;
        }
    }
}
