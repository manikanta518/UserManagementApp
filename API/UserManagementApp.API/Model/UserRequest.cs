using System.ComponentModel.DataAnnotations;

namespace UserManagementApp.API.Model
{
    public class UserRequest
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
