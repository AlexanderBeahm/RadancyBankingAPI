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
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> logger;
        private readonly IAccountRepository accountRepository;
        private readonly IUserRepository userRepository;

        public UserService(ILogger<UserService> logger, IAccountRepository accountRepository, IUserRepository userRepository)
        {
            this.logger = logger;
            this.accountRepository = accountRepository;
            this.userRepository = userRepository;
        }
        
        public User CreateUser(CreateUser createUser)
        {
            var user = new DataModels.User
            {
                CorrelationId = Guid.NewGuid(),
                Created = DateTime.UtcNow,
                FamilyName = createUser.FamilyName,
                GivenName = createUser.GivenName,
                Id = 0,
                Updated = DateTime.UtcNow
            };

            var generatedId = userRepository.CreateUser(user);

            return new User
            {
                FamilyName = createUser.FamilyName,
                GivenName = createUser.GivenName,
                Id = generatedId,
                Accounts = new List<UserAccount>()
            };
        }

        public User GetUser(int userId)
        {
            var foundUser = userRepository.GetUser(userId);

            if(foundUser == null)
            {
                return null;
            }

            var accounts = accountRepository.GetAccountsForUser(userId);

            return new User
            {
                FamilyName = foundUser.FamilyName,
                GivenName = foundUser.GivenName,
                Id = foundUser.Id,
                Accounts = accounts.Select(x=> new UserAccount { Balance = x.Balance, Id = x.Id, Name = x.Name, UserId = x.UserId}).ToList()
            };
        }
    }
}
