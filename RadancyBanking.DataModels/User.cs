namespace RadancyBanking.DataModels
{
    public class User : AuditData
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? GivenName { get; set; }
        public string? FamilyName { get; set; }
    }
}
