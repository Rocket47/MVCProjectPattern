using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MVCApps.Models
{
    public class UniversityContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }

        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {
            Database.EnsureCreated();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Group>()
            //    .HasOne<Course>(s => s.Course)
            //    .WithMany(g => g.Courses)
            //    .HasForeignKey(s => s.CurrentGroupId);
        }
    }
}
