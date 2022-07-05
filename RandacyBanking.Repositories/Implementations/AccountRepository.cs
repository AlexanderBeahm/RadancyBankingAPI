using Microsoft.Extensions.Logging;
using RadancyBanking.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandacyBanking.Repositories.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        // In most cases, I would inject a DB connector of some sort but due to project and time restrictions, I will just make this a static dictionary.

        private static Dictionary<int, UserAccount> accountDictionary = new Dictionary<int, UserAccount>();
        private readonly ILogger<AccountRepository> logger;

        public AccountRepository(ILogger<AccountRepository> logger)
        {
            this.logger = logger;
        }

        public void CreateAccount(UserAccount account)
        {
            throw new NotImplementedException();
        }

        public void DeleteAccount(int id)
        {
            throw new NotImplementedException();
        }

        public UserAccount GetAccount(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAccount(UserAccount account)
        {
            throw new NotImplementedException();
        }
    }
}
