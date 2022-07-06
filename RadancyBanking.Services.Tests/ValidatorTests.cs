using RadancyBanking.DomainModels;
using RadancyBanking.Services.Validation.Implementations;

namespace RadancyBanking.Services.Tests
{
    public class ValidatorTests
    {
        private WithdrawalTransactionValidation withdrawalValidator = new WithdrawalTransactionValidation();
        private DepositTransactionValidation depositValidator = new DepositTransactionValidation();

        [Fact]
        public void WithdrawalValidationSuccess()
        {
            var account = new UserAccount { Balance = 10000m };
            var transaction = new WithdrawalTransaction { Amount = 100m };

            var result = withdrawalValidator.Validate(account, transaction);
            Assert.True(result.Item1);
            Assert.True(string.IsNullOrWhiteSpace(result.Item2));
        }

        [Fact]
        public void DepositValidationSuccess()
        {
            var account = new UserAccount { Balance = 10000m };
            var transaction = new WithdrawalTransaction { Amount = 100m };

            var result = depositValidator.Validate(account, transaction);
            Assert.True(result.Item1);
            Assert.True(string.IsNullOrWhiteSpace(result.Item2));
        }

        [Fact]
        public void OverdraftFullAccountFailure()
        {
            var account = new UserAccount { Balance = 10000m };
            var transaction = new WithdrawalTransaction { Amount = 1000000m };

            var result = withdrawalValidator.Validate(account, transaction);
            Assert.False(result.Item1);
            Assert.False(string.IsNullOrWhiteSpace(result.Item2));
        }

        [Fact]
        public void OverdraftAccountMaximumPercentageFailure()
        {
            var account = new UserAccount { Balance = 10000m };
            var transaction = new WithdrawalTransaction { Amount = 9001m };

            var result = withdrawalValidator.Validate(account, transaction);
            Assert.False(result.Item1);
            Assert.False(string.IsNullOrWhiteSpace(result.Item2));
        }

        [Fact]
        public void OverdraftAccountMinimumFailure()
        {
            var account = new UserAccount { Balance = 10000m };
            var transaction = new WithdrawalTransaction { Amount = 9901m };

            var result = withdrawalValidator.Validate(account, transaction);
            Assert.False(result.Item1);
            Assert.False(string.IsNullOrWhiteSpace(result.Item2));
        }

        [Fact]
        public void DepositMaximumFailure()
        {
            var account = new UserAccount { Balance = 10000m };
            var transaction = new DepositTransaction { Amount = 1000000m };

            var result = depositValidator.Validate(account, transaction);
            Assert.False(result.Item1);
            Assert.False(string.IsNullOrWhiteSpace(result.Item2));
        }
    }
}
