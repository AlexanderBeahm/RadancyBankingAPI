using RadancyBanking.DomainModels;

namespace RadancyBanking.Services.Validation
{
    public interface ITransactionValidation
    {
        Tuple<bool, string> Validate(UserAccount account, AccountTransaction transaction);
    }
}
