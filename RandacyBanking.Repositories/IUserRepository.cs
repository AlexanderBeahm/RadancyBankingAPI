using RadancyBanking.DataModels;

namespace RandacyBanking.Repositories
{
    public interface IUserRepository
    {
        User GetUser(int id);
        int CreateUser(User user);
    }
}
