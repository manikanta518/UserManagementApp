using JobPortalApp.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using JobPortalApp.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using JobPortalApp.Model;
using System.Linq;

namespace JobPortalApp.Domain
{
    /// <summary>
    /// Candidate Service Provides CURD functionalists
    /// </summary>
    /// <seealso cref="IUserService" />
    public class UserService : IUserService
    {
        private readonly UserContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UserService(UserContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the Users.
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetUsers()
        {            
            return  await _context.Users.ToListAsync();       
           
        }


        /// <summary>
        /// Adds the specified User.
        /// </summary>
        /// <param name="candidate">The User.</param>
        public async Task Add(User user)
        {           
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Update the specified User.
        /// </summary>
        /// <param name="candidate">The User.</param>
        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task Delete(int userId)
        {
            var user = _context.Users.Find(userId);//.Where(x =>  x.Id == userId);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Is User Exists
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsUserExists(User user)
        {
            if (user.Id == 0)
                return _context.Users.Any(x => x.Name.Equals(user.Name, System.StringComparison.OrdinalIgnoreCase));

            return _context.Users.Any(x => x.Name.Equals(user.Name, System.StringComparison.OrdinalIgnoreCase) && x.Id!=user.Id);
        }


        /// <summary>
        /// Is UserId Exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsUserIdExists(int id)
        {
            return _context.Users.Any(x => x.Id == id);
        }


    }
}