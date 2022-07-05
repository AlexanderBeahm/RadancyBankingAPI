using RadancyBanking.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.Services.Validation.Implementations
{
    public class TransactionValidationTests
    {
        [Fact]
        public void ValidateWithdrawSuccessTest()
        {
            var userAccount = new UserAccount
            {
                Balance = 10000.0m,
                Id = 1,
                Name = "ExampleAccount",
                UserId = 1
            };

            var transaction = new WithdrawalTransaction
            {
                Amount = 100.0m
            };

            ITransactionValidation validation = new WithdrawalTransactionValidation();
            var result = validation.Validate(userAccount, transaction);
            Assert.True(result.Item1);

        }

        [Fact]
        public void ValidateWithdrawInsufficientFundsTest()
        {
            var userAccount = new UserAccount
            {
                Balance = 5000.00m,
                Id = 1,
                Name = "ExampleAccount",
                UserId = 1
            };

            var transaction = new WithdrawalTransaction
            {
                Amount = 10000.00m
            };

            ITransactionValidation validation = new WithdrawalTransactionValidation();
            var result = validation.Validate(userAccount, transaction);
            Assert.False(result.Item1);
        }

        [Fact]
        public void ValidateWithdrawAccountMinimumExceededTest()
        {
            var userAccount = new UserAccount
            {
                Balance = 1000.00m,
                Id = 1,
                Name = "ExampleAccount",
                UserId = 1
            };

            var transaction = new WithdrawalTransaction
            {
                Amount = 900.01m
            };

            ITransactionValidation validation = new WithdrawalTransactionValidation();
            var result = validation.Validate(userAccount, transaction);
            Assert.False(result.Item1);
        }

        [Fact]
        public void ValidateDepositSuccessTest()
        {
            var userAccount = new UserAccount
            {
                Balance = 100.00m,
                Id = 1,
                Name = "ExampleAccount" ,
                UserId = 1
            };

            var transaction = new DepositTransaction
            {
                Amount = 100.00m
            };

            ITransactionValidation validation = new DepositTransactionValidation();
            var result = validation.Validate(userAccount, transaction);
            Assert.True(result.Item1);
        }

        [Fact]
        public void ValidateDepositDepositMaximumTest()
        {
            var userAccount = new UserAccount
            {
                Balance = 100.00m,
                Id = 1,
                Name = "ExampleAccount",
                UserId = 1
            };

            var transaction = new DepositTransaction
            {
                Amount = 10000.01m
            };

            ITransactionValidation validation = new DepositTransactionValidation();
            var result = validation.Validate(userAccount, transaction);
            Assert.False(result.Item1);
        }
    }
}
