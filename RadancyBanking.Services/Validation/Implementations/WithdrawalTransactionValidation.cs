using RadancyBanking.DomainModels;

namespace RadancyBanking.Services.Validation.Implementations
{
    public class WithdrawalTransactionValidation : TransactionValidation
    {
        private const decimal WithdrawalMaximumPercentage = 0.9m;
        private const decimal AccountMinimum = 100m;

        public override Tuple<bool, string> Validate(UserAccount userAccount, AccountTransaction transaction)
        {
            var result = base.Validate(userAccount, transaction);
            if (!result.Item1)
            {
                return result;
            }

            var maximumWithdrawal = userAccount.Balance * WithdrawalMaximumPercentage;
            maximumWithdrawal = userAccount.Balance - maximumWithdrawal >= 100 ? maximumWithdrawal : userAccount.Balance - AccountMinimum;

            if (transaction.Amount > maximumWithdrawal)
            {
                return Tuple.Create(false, string.Format("Maximum withdrawal amount exceeded. Accounts must have a minimum of {0:C} and withdrawals must not exceed {1}% of account balance.", AccountMinimum, WithdrawalMaximumPercentage * 100));
            }

            return result;
        }
    }
}
