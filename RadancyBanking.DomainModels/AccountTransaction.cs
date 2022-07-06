using RadancyBanking.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.DomainModels
{
    /// <summary>
    /// Represents a transaction against one or more accounts.
    /// </summary>
    public abstract class AccountTransaction
    {
        /// <summary>
        /// The amount for the transaction, enforced to be a positive decimal.
        /// </summary>
        [Required]
        [Range(0.0, Double.MaxValue)]
        public decimal Amount { get; set; }

        /// <summary>
        /// Transaction type
        /// </summary>
        public virtual TransactionType GetTransactionType() => throw new InvalidOperationException();
        

        /// <summary>
        /// Applies transaction to user account object.
        /// </summary>
        /// <param name="userAccount">User account to modify</param>
        /// <returns>New balance value</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public virtual decimal ApplyTransaction(UserAccount userAccount) => throw new InvalidOperationException();
    
    }
}
