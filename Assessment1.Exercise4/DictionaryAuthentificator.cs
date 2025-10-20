using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise4
{
    public  class DictionaryAuthentificator : IAuthentificator
    {
        private Dictionary<string, string> _accounts;
        private IHasher _hasher;

        public DictionaryAuthentificator(Dictionary<string, string> accounts, IHasher hasher)
        {
            _accounts = accounts;
            _hasher = hasher;
        }

        public bool Authentificate(string user, string password)
        {
            if(String.IsNullOrEmpty(user) || String.IsNullOrEmpty(password))
            {
                return false;
            }

            string passwordHash = _hasher.Hash(password);
            if (!_accounts.ContainsKey(user) || _accounts[user] != passwordHash)
            {
                return false;
            }

            return true;
        }
    }
}
