using RadancyBanking.DataModels;

namespace RandacyBanking.Repositories
{
    public interface IAccountRepository
    {
        UserAccount GetAccount(int id);
        IEnumerable<UserAccount> GetAccountsForUser(int userId);
        int CreateAccount(UserAccount account);
        void DeleteAccount(int id);
        void UpdateAccount(UserAccount account);
    }
}
