using Microsoft.EntityFrameworkCore;
using TimyApp.Domain.Common;
using TimyApp.Domain.Entities;

namespace TimyApp.Persistence
{
    public class TimyAppDbContext : DbContext
    {
        public TimyAppDbContext(DbContextOptions<TimyAppDbContext> options) : base(options) { }

        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Project>? Projects { get; set; }
        public DbSet<Team>? Teams { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now.ToUniversalTime();
                        entry.Entity.CreatedBy = "system";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now.ToUniversalTime();
                        entry.Entity.LastModifiedBy = "system";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasOne(x => x.Project)
                .WithMany(x => x.Teams)
                .HasForeignKey(x => x.ProjectId)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Project)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.ProjectId);
                //.IsRequired();

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Team)
                .WithMany(t => t.Employees)
                .HasForeignKey(e => e.TeamId);
        }

    }
}
