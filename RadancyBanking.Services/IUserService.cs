using RadancyBanking.DomainModels;

namespace RadancyBanking.Services
{
    public interface IUserService
    {
        User CreateUser(CreateUser createUser);
        User GetUser(int userId);
    }
}
