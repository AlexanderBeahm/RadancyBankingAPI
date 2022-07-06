using RadancyBanking.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.Services
{
    public interface IUserService
    {
        User CreateUser(CreateUser createUser);
        User GetUser(int userId);
    }
}
