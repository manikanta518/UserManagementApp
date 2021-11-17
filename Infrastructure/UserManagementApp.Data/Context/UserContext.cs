using JobPortalApp.Model;
using Microsoft.EntityFrameworkCore;

namespace JobPortalApp.Data.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the Users.
        /// </summary>
        /// <value>
        /// The Users.
        /// </value>
        public DbSet<User> Users { get; set; }

       
    }
}
