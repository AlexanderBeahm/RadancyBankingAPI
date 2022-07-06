using System.ComponentModel.DataAnnotations;

namespace RadancyBanking.DomainModels
{
    /// <summary>
    /// Domain model for creating new accounts.
    /// </summary>
    /// <example>
    /// {
    ///     "userId": 2,
    ///     "name": "Jack Example Savings",
    ///     "initialDeposit": 300.00
    /// }
    /// </example>
    public class CreateAccount
    {
        /// <summary>
        /// UserId
        /// </summary>
        [Required(ErrorMessage = "UserId required.")]
        [Range(1, int.MaxValue, ErrorMessage = "UserId must be greater than 0.")]
        public int UserId { get; set; }

        /// <summary>
        /// Account Name
        /// </summary>
        [Required]
        [StringLength(maximumLength: 255, MinimumLength = 1, ErrorMessage = "Name is required and have length in range (1-255)")]
        public string? Name { get; set; }

        /// <summary>
        /// Initial deposit, minimum $100 and maximum $10000.
        /// </summary>
        [Required]
        [Range(100.0, 10000.0, ErrorMessage = "Initial deposit must be between $100.00 and $10000.00")]
        public decimal InitialDeposit { get; set; }
    }
}
