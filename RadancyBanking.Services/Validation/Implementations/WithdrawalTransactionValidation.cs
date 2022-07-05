using RadancyBanking.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.Services.Validation.Implementations
{
    public class WithdrawalTransactionValidation : TransactionValidation
    {
        public override Tuple<bool, string> Validate(UserAccount userAccount, AccountTransaction transaction)
        {
            base.Validate(userAccount, transaction);
            throw new NotImplementedException();
        }
    }
}
