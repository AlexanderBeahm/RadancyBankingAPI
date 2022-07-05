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
            throw new NotImplementedException();
        }

        public User GetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
