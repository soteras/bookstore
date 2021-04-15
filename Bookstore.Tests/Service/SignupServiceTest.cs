using Bookstore.Core.Entities;
using Bookstore.Infrastructure.Repository.Interface;
using Bookstore.Services;
using Moq;
using System;
using Xunit;

namespace Bookstore.Tests.Service
{
    public class SignupServiceTest
    {
        [Fact]
        public void CreateUser_Returns_User()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.Create(It.IsAny<User>())).Returns<User>((user) => user);
            var service = new SignupService(mockUserRepository.Object);

            var result = service.CreateUser("test@gmail.com", "abc12345");

            Assert.Equal("test@gmail.com", result.Email);
            Assert.NotNull(result.PasswordDigest);
            Assert.Equal(DateTime.Now.Day, result.CreatedAt.Day);
        }
    }
}
