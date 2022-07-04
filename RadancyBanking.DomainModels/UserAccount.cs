using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.DomainModels
{
    public class UserAccount
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Name { get; set; }
        public decimal Balance { get; set; }
    }
}
