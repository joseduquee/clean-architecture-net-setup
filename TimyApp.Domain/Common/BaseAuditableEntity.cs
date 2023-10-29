namespace TimyApp.Domain.Common
{
    public abstract class BaseAuditableEntity
    {
        public string? CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDate { get; set; }
    }

}
