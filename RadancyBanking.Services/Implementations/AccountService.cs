using Microsoft.Extensions.Logging;
using RadancyBanking.DomainModels;
using RandacyBanking.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly ILogger<AccountService> logger;
        private readonly IAccountRepository accountRepository;
        private readonly IUserRepository userRepository;

        public AccountService(ILogger<AccountService> logger, IAccountRepository accountRepository, IUserRepository userRepository)
        {
            this.logger = logger;
            this.accountRepository = accountRepository;
            this.userRepository = userRepository;
        }

        public UserAccount ApplyTransaction(int id, AccountTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public UserAccount CreateAccount(CreateAccount createAccount)
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
    }
}
