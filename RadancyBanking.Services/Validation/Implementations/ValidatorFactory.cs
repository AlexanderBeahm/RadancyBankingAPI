using RadancyBanking.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.Services.Validation.Implementations
{
    public class ValidatorFactory : IValidatorFactory
    {
        public ITransactionValidation GenerateTransactionValidator(TransactionType type)
        {
            throw new NotImplementedException();
        }
    }
}
