using RadancyBanking.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.Services.Validation.Implementations
{
    public class TransactionValidation : ITransactionValidation
    {
        public virtual Tuple<bool, string> Validate(UserAccount account, AccountTransaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
