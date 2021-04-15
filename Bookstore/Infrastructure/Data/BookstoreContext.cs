using Bookstore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Bookstore.Infrastructure.Data
{
    public class BookstoreContext: DbContext
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<User> Users { get; set; }
    }
}
