using Microsoft.Extensions.Logging;
using RadancyBanking.DomainModels;
using RadancyBanking.Services.Validation;
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
        private readonly IValidatorFactory validatorFactory;

        public AccountService(ILogger<AccountService> logger, IAccountRepository accountRepository, IUserRepository userRepository, IValidatorFactory validatorFactory)
        {
            this.logger = logger;
            this.accountRepository = accountRepository;
            this.userRepository = userRepository;
            this.validatorFactory = validatorFactory;
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
