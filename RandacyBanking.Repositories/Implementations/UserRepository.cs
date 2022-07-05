using Microsoft.Extensions.Logging;
using RadancyBanking.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandacyBanking.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        // In most cases, I would inject a DB connector of some sort but due to project and time restrictions, I will just make this a static dictionary.

        private static Dictionary<int, User> userDictionary = new Dictionary<int, User>();
        private readonly ILogger<AccountRepository> logger;

        public UserRepository(ILogger<AccountRepository> logger)
        {
            this.logger = logger;
        }

        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
