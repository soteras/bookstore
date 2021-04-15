using Bookstore.Core.Entities;

namespace Bookstore.Infrastructure.Repository.Interface
{
    public interface IUserRepository
    {
        public User Create(User user);
    }
}
