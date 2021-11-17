using System.Collections.Generic;
using System.Threading.Tasks;
using JobPortalApp.Model;

namespace JobPortalApp.Domain.Contracts
{
    public interface IUserService
    {
        /// <summary>
        /// Gets the Users.
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetUsers();

        /// <summary>
        /// Adds the specified User
        /// </summary>
        /// <param name="candidate">The User.</param>
        /// <returns></returns>
        Task Add(User user);

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task Update(User user);

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task Delete(int userId);

        /// <summary>
        /// Is User Exists
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool IsUserExists(User user);

        /// <summary>
        /// Is UserId Exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool IsUserIdExists(int id);

    }
}