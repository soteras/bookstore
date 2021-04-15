using Bookstore.Core.Entities;
using Bookstore.Infrastructure.Data;
using Bookstore.Infrastructure.Repository.Interface;
using System.Linq;

namespace Bookstore.Infrastructure.Repository
{
    public class UserRepository: IUserRepository
    {
        public UserRepository(BookstoreContext context)
        {
            _context = context;
        }

        private readonly BookstoreContext _context;

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email.ToLower().Equals(email.ToLower()));
        }

        public User Create(User user)
        {
            _context.Add(user);
            _context.SaveChanges();

            return user;
        }
    }
}
