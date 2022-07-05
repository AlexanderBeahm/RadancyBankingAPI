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
        private static int accountIdNextNumber = 1;
        private readonly ILogger<AccountRepository> logger;

        //TODO Fix up returns to make better logical sense in error processing.

        public AccountRepository(ILogger<AccountRepository> logger)
        {
            this.logger = logger;
        }

        public int CreateAccount(UserAccount account)
        {
            account.Id = accountIdNextNumber;
            var added = accountDictionary.TryAdd(account.Id, account);
            if (!added)
            {
                return -1;
            }
            
            IterateNextNumber();
            return account.Id;
        }

        public void DeleteAccount(int id)
        {
            bool found = accountDictionary.TryGetValue(id, out var account);
            if (!found)
            {
                return;
            }
            accountDictionary.Remove(id);
        }

        public UserAccount GetAccount(int id)
        {
            bool found = accountDictionary.TryGetValue(id, out var account);
            if (!found)
            {
                return null;
            }
            return account;
        }

        public IEnumerable<UserAccount> GetAccountsForUser(int userId)
        {
            var accounts = accountDictionary.Values.Where(x => x.UserId == userId).ToList();
            return accounts;
        }

        public void UpdateAccount(UserAccount account)
        {
            bool found = accountDictionary.TryGetValue(account.Id, out var foundAccount);
            if (!found)
            {
                return;
            }
            foundAccount = account;
        }

        private void IterateNextNumber()
        {
            accountIdNextNumber++;
        }
    }
}
