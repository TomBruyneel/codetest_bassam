using Microsoft.EntityFrameworkCore;

namespace CommuteTypeTracker.Model
{
    public class CommuteTypeTrackerContext : DbContext
    {
        protected CommuteTypeTrackerContext(DbContextOptions<CommuteTypeTrackerContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<DailyCommute> DailyCommute { get; set; }

    }
}
