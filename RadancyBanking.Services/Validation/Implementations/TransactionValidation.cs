using RadancyBanking.DomainModels;

namespace RadancyBanking.Services.Validation.Implementations
{
    public class TransactionValidation : ITransactionValidation
    {
        public virtual Tuple<bool, string> Validate(UserAccount account, AccountTransaction transaction)
        {
            return new Tuple<bool, string>(true, string.Empty);
        }
    }
}
