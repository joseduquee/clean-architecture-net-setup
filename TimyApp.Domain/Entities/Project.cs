using TimyApp.Domain.Common;

namespace TimyApp.Domain.Entities
{
    public class Project : BaseAuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Employee>? Employees { get; set; }
        public List<Team>? Teams { get; set; }
    }
}
