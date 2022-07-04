using RadancyBanking.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.Services.Validation
{
    internal interface ITransactionValidation
    {
        bool Validate(UserAccount account, AccountTransaction transaction);
    }
}
