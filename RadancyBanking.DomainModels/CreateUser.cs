using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.DomainModels
{
    public class CreateUser
    {
        [Required]
        [StringLength(maximumLength: 255, MinimumLength = 2)]
        public string? UserName { get; set; }
        public string? GivenName { get; set; }
        public string? FamilyName { get; set; }
    }
}
