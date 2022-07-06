namespace RadancyBanking.DataModels
{
    public class UserAccount : AuditData
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Name { get; set; }
        public decimal Balance { get; set; }
    }
}
