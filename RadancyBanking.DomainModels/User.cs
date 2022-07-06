﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.DomainModels
{
    /// <summary>
    /// Represents a banking user.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Generated system id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Given (first) name
        /// </summary>
        public string? GivenName { get; set; } 
        /// <summary>
        /// Family (last) name
        /// </summary>
        public string? FamilyName { get; set; }
        /// <summary>
        /// List of accounts associated with User
        /// </summary>
        public IList<UserAccount>? Accounts { get; set; } = new List<UserAccount>();
    }
}
