using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.DomainModels
{
    public class PostDeposit
    {
        public DepositTransaction? Transaction { get; set; }
    }
}
