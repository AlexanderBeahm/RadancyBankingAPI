namespace RadancyBanking.DomainModels
{
    /// <summary>
    /// Account associated to a banking User
    /// </summary>
    public class UserAccount
    {
        /// <summary>
        /// Generated system id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Associated User Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Name of account
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Current account balance.
        /// </summary>
        public decimal Balance { get; set; }
    }
}
