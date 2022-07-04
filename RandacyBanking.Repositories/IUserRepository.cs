﻿using RadancyBanking.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandacyBanking.Repositories
{
    public interface IUserRepository
    {
        User GetUser(int id);
        void CreateUser(User user);
        void DeleteUser(int id);
    }
}
