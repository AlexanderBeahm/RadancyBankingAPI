using Microsoft.Extensions.Logging;
using RadancyBanking.DataModels;

namespace RandacyBanking.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        // In most cases, I would inject a DB connector of some sort but due to project and time restrictions, I will just make this a static dictionary.

        private static Dictionary<int, User> userDictionary = new Dictionary<int, User>();
        private static int userIdNextNumber = 1;
        private readonly ILogger<UserRepository> logger;

        public UserRepository(ILogger<UserRepository> logger)
        {
            this.logger = logger;
        }

        public int CreateUser(User user)
        {
            if (userDictionary.Any(x => string.Equals(x.Value.UserName, user.UserName, StringComparison.OrdinalIgnoreCase)))
            {
                return -1;
            }

            user.Id = userIdNextNumber;
            var added = userDictionary.TryAdd(user.Id, user);
            if (!added)
            {
                return -1;
            }
            IterateNextNumber();
            return user.Id;
        }

        public User GetUser(int id)
        {
            bool found = userDictionary.TryGetValue(id, out var user);
            if (!found)
            {
                return null;
            }
            return user;
        }

        private void IterateNextNumber()
        {
            userIdNextNumber++;
        }
    }
}
