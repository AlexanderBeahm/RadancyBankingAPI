using System.ComponentModel.DataAnnotations;

namespace RadancyBanking.DomainModels
{
    /// <summary>
    /// Domain model for creating new accounts.
    /// </summary>
    public class CreateAccount
    {
        /// <summary>
        /// UserId
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }

        /// <summary>
        /// Account Name
        /// </summary>
        [Required]
        [StringLength(maximumLength: 255, MinimumLength = 2)]
        public string? Name { get; set; }

        /// <summary>
        /// Initial deposit, minimum $100 and maximum $10000.
        /// </summary>
        [Required]
        [Range(100.0, 10000.0)]
        public decimal InitialDeposit { get; set; }
    }
}
