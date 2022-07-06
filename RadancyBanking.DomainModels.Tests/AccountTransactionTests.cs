namespace RadancyBanking.DomainModels.Tests
{
    public class AccountTransactionTests
    {
        [Fact]
        public void WithdrawalTransactionSuccessTest()
        {
            var expectedBalance = 9990;
            var withdrawalTransaction = new WithdrawalTransaction()
            {
                Amount = 10
            };

            var userAccount = new UserAccount()
            {
                Balance = 10000
            };

            var updatedBalance = withdrawalTransaction.ApplyTransaction(userAccount);
            Assert.Equal(expectedBalance, updatedBalance);
            Assert.Equal(expectedBalance, userAccount.Balance);
        }

        [Fact]
        public void DepositTransactionSuccessTest()
        {
            var expectedBalance = 10010;
            var depositTransaction = new DepositTransaction()
            {
                Amount = 10
            };

            var userAccount = new UserAccount()
            {
                Balance = 10000
            };

            var updatedBalance = depositTransaction.ApplyTransaction(userAccount);
            Assert.Equal(expectedBalance, updatedBalance);
            Assert.Equal(expectedBalance, userAccount.Balance);
        }
    }
}