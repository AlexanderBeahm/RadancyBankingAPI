namespace RadancyBanking.DataModels
{
    public class AuditData
    {
        public DateTime? Updated { get; set; }
        public DateTime? Created { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
