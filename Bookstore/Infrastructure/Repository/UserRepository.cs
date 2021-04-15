using Bookstore.Core.Entities;
using Bookstore.Infrastructure.Data;
using Bookstore.Infrastructure.Repository.Interface;

namespace Bookstore.Infrastructure.Repository
{
    public class UserRepository: IUserRepository
    {
        public UserRepository(BookstoreContext context)
        {
            _context = context;
        }

        private readonly BookstoreContext _context;

        public User Create(User user)
        {
            _context.Add(user);
            _context.SaveChanges();

            return user;
        }
    }
}
