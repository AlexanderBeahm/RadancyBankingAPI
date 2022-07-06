using RadancyBanking.Enumerations;

namespace RadancyBanking.Services.Validation
{
    public interface IValidatorFactory
    {
        ITransactionValidation GenerateTransactionValidator(TransactionType type);
    }
}
