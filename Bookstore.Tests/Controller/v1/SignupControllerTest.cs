using Bookstore.Controller.v1;
using Bookstore.Core.Authentication;
using Bookstore.Core.Entities;
using Bookstore.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace Bookstore.Tests.Controller.v1
{
    public class SignupControllerTest
    {
        private SignupRequest request = new SignupRequest
        {
            Email = "test@gmail.com",
            Password = "abc12345",
            PasswordConfirmation = "abc12345"
        };

        [Fact]
        public void Create_WithSuccess_ReturnsOk()
        {
            var user = new User()
            {
                Email = "test@gmail.com"
            };
            var signupServiceMock = new Mock<ISignupService>();
            signupServiceMock.Setup(m => m.CreateUser("test@gmail.com", "abc12345")).Returns(user);
            var controller = new SignupController(signupServiceMock.Object);

            var result = controller.Create(request);

            OkObjectResult objectResult = Assert.IsType<OkObjectResult>(result.Result);
            User userResult = Assert.IsType<User>(objectResult.Value);

            Assert.Equal("test@gmail.com", userResult.Email);
        }

        [Fact]
        public void Create_WithError_ReturnsUnprocessableEntity()
        {
            var user = new User()
            {
                Email = "test@gmail.com"
            };
            var signupServiceMock = new Mock<ISignupService>();
            signupServiceMock.Setup(m => m.CreateUser("test@gmail.com", "abc12345")).Throws(new Exception("error"));
            var controller = new SignupController(signupServiceMock.Object);

            var result = controller.Create(request);

            Assert.IsType<UnprocessableEntityObjectResult>(result.Result);
        }

    }
}
