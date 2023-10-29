using TimyApp.Domain.Common;

namespace TimyApp.Domain.Entities
{
    public class Employee : BaseAuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public Guid? ProjectId { get; set; }
        public virtual Project? Project { get; set; }
        public Guid? TeamId { get; set; }
        public virtual Team? Team { get; set; }
    }
}
