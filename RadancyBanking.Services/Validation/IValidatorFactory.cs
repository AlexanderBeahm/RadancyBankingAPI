using RadancyBanking.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.Services.Validation
{
    public interface IValidatorFactory
    {
        ITransactionValidation GenerateTransactionValidator(TransactionType type);
    }
}
