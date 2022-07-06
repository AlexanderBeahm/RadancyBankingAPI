using RadancyBanking.Enumerations;

namespace RadancyBanking.Services.Validation.Implementations
{
    public class ValidatorFactory : IValidatorFactory
    {
        public ITransactionValidation GenerateTransactionValidator(TransactionType type)
        {
            ITransactionValidation validator = type switch
            {
                TransactionType.Withdrawal => new WithdrawalTransactionValidation(),
                TransactionType.Deposit => new DepositTransactionValidation(),
                _ => throw new InvalidOperationException()
            };
            return validator;
        }
    }
}
