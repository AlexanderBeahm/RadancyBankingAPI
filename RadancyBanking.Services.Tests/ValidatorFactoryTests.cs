using RadancyBanking.Services.Validation;
using RadancyBanking.Services.Validation.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.Services.Tests
{
    public class ValidatorFactoryTests
    {
        [Fact]
        public void GenerateWithdrawalFactorySuccess() 
        {
            IValidatorFactory validatorFactory = new ValidatorFactory();
            var validator = validatorFactory.GenerateTransactionValidator(Enumerations.TransactionType.Withdrawal);
            Assert.IsType<WithdrawalTransactionValidation>(validator);
        }

        [Fact]
        public void GenerateDepositFactorySuccess()
        {
            IValidatorFactory validatorFactory = new ValidatorFactory();
            var validator = validatorFactory.GenerateTransactionValidator(Enumerations.TransactionType.Deposit);
            Assert.IsType<DepositTransactionValidation>(validator);
        }
    }
}
