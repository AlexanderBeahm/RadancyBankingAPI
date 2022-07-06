using RadancyBanking.DomainModels;

namespace RadancyBanking.Services
{
    public interface IAccountService
    {
        UserAccount GetAccount(int id);
        UserAccount CreateAccount(CreateAccount createAccount);
        void DeleteAccount(int id);
        UserAccount ApplyTransaction(int id, AccountTransaction transaction);
    }
}
