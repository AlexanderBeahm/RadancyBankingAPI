using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.DomainModels
{
    public class User
    {
        public int Id { get; set; }
        public string? GivenName { get; set; } 
        public string? FamilyName { get; set; }
        public IList<UserAccount>? Accounts { get; set; }
    }
}
