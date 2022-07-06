using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.DomainModels
{
    /// <summary>
    /// Domain object for creating user.
    /// </summary>
    public class CreateUser
    {
        /// <summary>
        /// UserName to key on.
        /// </summary>
        [Required(ErrorMessage = "UserName required")]
        [StringLength(maximumLength: 255, MinimumLength = 1, ErrorMessage = "Username is required and have length in range (1-255)")]
        public string? UserName { get; set; }
        /// <summary>
        /// Given (first) name, if provided.
        /// </summary>
        public string? GivenName { get; set; }
        /// <summary>
        /// Family (last) name, if provided.
        /// </summary>
        public string? FamilyName { get; set; }
    }
}
