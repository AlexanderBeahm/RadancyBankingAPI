using RadancyBanking.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.Services.Validation.Implementations
{
    public class DepositTransactionValidation : TransactionValidation
    {
        private const decimal DepositMaximum = 10000.0m;
        public override Tuple<bool, string> Validate(UserAccount userAccount, AccountTransaction transaction)
        {
            var result = base.Validate(userAccount, transaction);
            if (!result.Item1)
            {
                return result;
            }

            if (transaction.Amount > DepositMaximum)
            {
                return Tuple.Create(false, string.Format("Maximum deposit amount exceeded. Accounts are limitied to deposit {0:C}.", DepositMaximum));
            }

            return result;
        }
    }
}
