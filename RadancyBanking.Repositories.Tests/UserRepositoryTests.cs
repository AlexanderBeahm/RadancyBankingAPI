using Microsoft.Extensions.Logging;
using RandacyBanking.Repositories;
using RandacyBanking.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using RadancyBanking.DataModels;

namespace RadancyBanking.Repositories.Tests
{
    public class UserRepositoryTests
    {
        [Fact]
        public void CreateUserSuccessTest()
        {
            var logger = Mock.Of<ILogger<UserRepository>>();
            IUserRepository userRepository = new UserRepository(logger);

            User user = new User {
                FamilyName = "Example",
                GivenName = "Jack",
                Id = 0,
                CorrelationId = Guid.NewGuid(),
                Created = new DateTime(),
                Updated = new DateTime()
            };

            var id = userRepository.CreateUser(user);
            Assert.True(id > 0);
        }

        [Fact]
        public void CreateUserDuplicateFailureTest()
        {
            var logger = Mock.Of<ILogger<UserRepository>>();
            IUserRepository userRepository = new UserRepository(logger);

            User user = new User
            {
                FamilyName = "Example",
                GivenName = "Jack",
                Id = 0,
                CorrelationId = Guid.NewGuid(),
                Created = new DateTime(),
                Updated = new DateTime()
            };

            userRepository.CreateUser(user);
            var duplicateId = userRepository.CreateUser(user);
            Assert.Equal(-1, duplicateId);
        }

        [Fact]
        public void GetUserSuccessTest()
        {
            var logger = Mock.Of<ILogger<UserRepository>>();
            IUserRepository userRepository = new UserRepository(logger);

            User user = new User
            {
                FamilyName = "Example",
                GivenName = "Jack",
                Id = 0,
                CorrelationId = Guid.NewGuid(),
                Created = new DateTime(),
                Updated = new DateTime()
            };

            var userId = userRepository.CreateUser(user);

            var foundUser = userRepository.GetUser(userId);

            Assert.Equal(user.FamilyName, foundUser.FamilyName);
            Assert.Equal(user.GivenName, foundUser.GivenName);
            Assert.Equal(user.Created, foundUser.Created);
            Assert.Equal(user.Updated, foundUser.Updated);
            Assert.Equal(user.CorrelationId, foundUser.CorrelationId);
            Assert.Equal(userId, foundUser.Id);
        }

        [Fact]
        public void GetUserNotFoundTest()
        {
            var logger = Mock.Of<ILogger<UserRepository>>();
            IUserRepository userRepository = new UserRepository(logger);

            User user = new User
            {
                FamilyName = "Example",
                GivenName = "Jack",
                Id = 1,
                CorrelationId = Guid.NewGuid(),
                Created = new DateTime(),
                Updated = new DateTime()
            };

            var foundUser = userRepository.GetUser(user.Id);
            Assert.Null(foundUser);
        }
    }
}
