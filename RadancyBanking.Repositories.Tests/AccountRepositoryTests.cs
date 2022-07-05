using Microsoft.Extensions.Logging;
using Moq;
using RadancyBanking.DataModels;
using RandacyBanking.Repositories;
using RandacyBanking.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.Repositories.Tests
{
    public class AccountRepositoryTests
    {
        [Fact]
        public void CreateAccountSuccessTest()
        {
            var logger = Mock.Of<ILogger<AccountRepository>>();
            IAccountRepository accountRepository = new AccountRepository(logger);

            UserAccount account = new UserAccount
            {
                Id = 0,
                Balance = 1000.00m,
                UserId = 1,
                CorrelationId = Guid.NewGuid(),
                Created = new DateTime(),
                Updated = new DateTime()
            };

            var id = accountRepository.CreateAccount(account);
            Assert.True(id > 0);
            var foundAccount = accountRepository.GetAccount(id);
            Assert.Equal(account.UserId, foundAccount.UserId);
            Assert.Equal(account.Balance, foundAccount.Balance);
            Assert.Equal(account.Created, foundAccount.Created);
            Assert.Equal(account.Updated, foundAccount.Updated);
            Assert.Equal(account.CorrelationId, foundAccount.CorrelationId);
            Assert.Equal(id, foundAccount.Id);
        }

        [Fact]
        public void GetAccountSuccessTest()
        {
            var logger = Mock.Of<ILogger<AccountRepository>>();
            IAccountRepository accountRepository = new AccountRepository(logger);

            UserAccount account = new UserAccount
            {
                Id = 0,
                Balance = 1000.00m,
                UserId = 2,
                CorrelationId = Guid.NewGuid(),
                Created = new DateTime(),
                Updated = new DateTime()
            };

            var id = accountRepository.CreateAccount(account);

            accountRepository.DeleteAccount(id);

            var foundAccount = accountRepository.GetAccount(id);
            Assert.Null(foundAccount);
        }

        [Fact]
        public void GetAccountsSuccessTest()
        {
            var logger = Mock.Of<ILogger<AccountRepository>>();
            IAccountRepository accountRepository = new AccountRepository(logger);

            var userIdToGet = 3;
            var expectedSize = 2;

            UserAccount account1 = new UserAccount
            {
                Id = 0,
                Balance = 1000.00m,
                UserId = userIdToGet,
                CorrelationId = Guid.NewGuid(),
                Created = new DateTime(),
                Updated = new DateTime()
            };

            UserAccount account2 = new UserAccount
            {
                Id = 0,
                Balance = 1001.00m,
                UserId = userIdToGet,
                CorrelationId = Guid.NewGuid(),
                Created = new DateTime(),
                Updated = new DateTime()
            };

            UserAccount account3 = new UserAccount
            {
                Id = 0,
                Balance = 1002.00m,
                UserId = 4,
                CorrelationId = Guid.NewGuid(),
                Created = new DateTime(),
                Updated = new DateTime()
            };

            accountRepository.CreateAccount(account1);
            accountRepository.CreateAccount(account2);
            accountRepository.CreateAccount(account3);

            var accountsFound = accountRepository.GetAccountsForUser(userIdToGet);
            Assert.Equal(expectedSize, accountsFound.ToList().Count);
        }

        [Fact]
        public void GetAccountsNotFoundTest()
        {
            var logger = Mock.Of<ILogger<AccountRepository>>();
            IAccountRepository accountRepository = new AccountRepository(logger);

            var userIdToGet = 100;
            var expectedSize = 0;

            UserAccount account1 = new UserAccount
            {
                Id = 0,
                Balance = 1000.00m,
                UserId = 5,
                CorrelationId = Guid.NewGuid(),
                Created = new DateTime(),
                Updated = new DateTime()
            };

            UserAccount account2 = new UserAccount
            {
                Id = 0,
                Balance = 1001.00m,
                UserId = 5,
                CorrelationId = Guid.NewGuid(),
                Created = new DateTime(),
                Updated = new DateTime()
            };

            UserAccount account3 = new UserAccount
            {
                Id = 0,
                Balance = 1002.00m,
                UserId = 6,
                CorrelationId = Guid.NewGuid(),
                Created = new DateTime(),
                Updated = new DateTime()
            };

            accountRepository.CreateAccount(account1);
            accountRepository.CreateAccount(account2);
            accountRepository.CreateAccount(account3);

            var accountsFound = accountRepository.GetAccountsForUser(userIdToGet);
            Assert.Equal(expectedSize, accountsFound.ToList().Count);
        }

        [Fact]
        public void UpdateAccountsTest()
        {
            var logger = Mock.Of<ILogger<AccountRepository>>();
            IAccountRepository accountRepository = new AccountRepository(logger);

            UserAccount account = new UserAccount
            {
                Id = 0,
                Balance = 1000.00m,
                UserId = 7,
                CorrelationId = Guid.NewGuid(),
                Created = new DateTime(),
                Updated = new DateTime()
            };

            var id = accountRepository.CreateAccount(account);

            account.Id = id;
            account.Updated = new DateTime();
            account.CorrelationId = Guid.NewGuid();
            account.Balance = 10001.00m;

            var foundAccount = accountRepository.GetAccount(id);
            Assert.Equal(account.UserId, foundAccount.UserId);
            Assert.Equal(account.Balance, foundAccount.Balance);
            Assert.Equal(account.Created, foundAccount.Created);
            Assert.Equal(account.Updated, foundAccount.Updated);
            Assert.Equal(account.CorrelationId, foundAccount.CorrelationId);
            Assert.Equal(id, foundAccount.Id);
        }

        [Fact]
        public void DeleteAccountSuccessTest()
        {
            var logger = Mock.Of<ILogger<AccountRepository>>();
            IAccountRepository accountRepository = new AccountRepository(logger);

            UserAccount account = new UserAccount
            {
                Id = 0,
                Balance = 1000.00m,
                UserId = 8,
                CorrelationId = Guid.NewGuid(),
                Created = new DateTime(),
                Updated = new DateTime()
            };

            var id = accountRepository.CreateAccount(account);
            
            accountRepository.DeleteAccount(id);

            var foundAccount = accountRepository.GetAccount(id);
            Assert.Null(foundAccount);
        }
    }
}
