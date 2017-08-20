using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace TaskScheduler.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<WorkingTask> WorkingTasks { get; set; }

        public ApplicationDbContext()
           : base("TaskScheduler", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }

    
}