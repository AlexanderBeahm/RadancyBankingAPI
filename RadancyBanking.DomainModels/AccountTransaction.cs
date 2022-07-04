using RadancyBanking.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.DomainModels
{
    public abstract class AccountTransaction
    {
        [Required]
        [Range(0.0, Double.MaxValue)]
        public decimal Amount { get; set; }

        public virtual TransactionType TransactionType => throw new InvalidOperationException();
    
    }
}
