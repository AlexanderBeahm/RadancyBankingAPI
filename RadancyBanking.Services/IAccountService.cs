using RadancyBanking.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
