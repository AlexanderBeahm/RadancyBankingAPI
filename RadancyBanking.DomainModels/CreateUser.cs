using System.ComponentModel.DataAnnotations;

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

        [StringLength(maximumLength: 255, MinimumLength = 0, ErrorMessage = "Given name must have length in range (0-255)")]

        public string? GivenName { get; set; }
        /// <summary>
        /// Family (last) name, if provided.
        /// </summary>

        [StringLength(maximumLength: 255, MinimumLength = 0, ErrorMessage = "Username is required and have length in range (0-255)")]

        public string? FamilyName { get; set; }
    }
}
