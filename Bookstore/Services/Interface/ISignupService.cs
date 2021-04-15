using Bookstore.Core.Entities;

namespace Bookstore.Services.Interface
{
    public interface ISignupService
    {
        public User CreateUser(string email, string password);
    }
}
