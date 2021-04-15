using Bookstore.Core.Entities;
using Bookstore.Infrastructure.Repository.Interface;
using Bookstore.Services.Interface;
using System;

namespace Bookstore.Services
{
    public class SignupService: ISignupService
    {
        public SignupService(IUserRepository repository)
        {
            _repository = repository;
        }

        private readonly IUserRepository _repository;

        public User CreateUser(string email, string password)
        {
            var user = new User
            {
                Email = email,
                PasswordDigest = BCrypt.Net.BCrypt.HashPassword(password),
                Role = "user",
                CreatedAt = DateTime.Now
            };

            return _repository.Create(user);
        }
    }
}
