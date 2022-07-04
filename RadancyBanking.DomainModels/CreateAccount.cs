using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.DomainModels
{
    public class CreateAccount
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }

        [Required]
        [StringLength(maximumLength: 255, MinimumLength = 2)]
        public string? Name { get; set; }

        [Required]
        [Range(0.0, 10000.0)]
        public decimal InitialDeposit { get; set; }
    }
}
