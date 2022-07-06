using Microsoft.Extensions.Logging;
using RadancyBanking.DomainModels;
using RadancyBanking.Services.Validation;
using RandacyBanking.Repositories;

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
            var validator = validatorFactory.GenerateTransactionValidator(transaction.GetTransactionType());
            var foundAccount = accountRepository.GetAccount(id);

            if (foundAccount == null)
            {
                return null;
            }

            //TODO Implement automapping if time allows
            var domainAccount = new UserAccount
            {
                Balance = foundAccount.Balance,
                Id = foundAccount.Id,
                Name = foundAccount.Name,
                UserId = foundAccount.UserId
            };

            var validationResult = validator.Validate(domainAccount, transaction);
            if (!validationResult.Item1)
            {
                return null;
            }

            transaction.ApplyTransaction(domainAccount);

            foundAccount.Updated = DateTime.UtcNow;
            foundAccount.Balance = domainAccount.Balance;

            accountRepository.UpdateAccount(foundAccount);
            return domainAccount;
        }

        public UserAccount CreateAccount(CreateAccount createAccount)
        {
            var dataAccount = new DataModels.UserAccount()
            {
                Balance = createAccount.InitialDeposit,
                Id = 0,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                Name = createAccount.Name,
                UserId = createAccount.UserId,
                CorrelationId = Guid.NewGuid()
            };

            int generatedId = accountRepository.CreateAccount(dataAccount);

            var domainAccount = new UserAccount
            {
                Balance = createAccount.InitialDeposit,
                Id = generatedId,
                Name = createAccount.Name,
                UserId = createAccount.UserId
            };

            return domainAccount;
        }

        public void DeleteAccount(int id)
        {
            accountRepository.DeleteAccount(id);
        }

        public UserAccount GetAccount(int id)
        {
            var foundAccount = accountRepository.GetAccount(id);
            if (foundAccount == null)
            {
                return null;
            }

            return new UserAccount
            {
                Balance = foundAccount.Balance,
                Name = foundAccount.Name,
                Id = foundAccount.Id,
                UserId = foundAccount.UserId
            };
        }
    }
}
