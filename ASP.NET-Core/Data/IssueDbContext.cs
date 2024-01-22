using Microsoft.EntityFrameworkCore;
using learn.Models;

namespace learn.Data
{
    public class IssueDbContext: DbContext
    {
        public IssueDbContext(DbContextOptions<IssueDbContext> options)
            :base(options) // Used to communicate between the model Issue and the actual table of the DB
        {
        }

        // actual representation of the table in the db
        public DbSet<Issue> Issues {get; set;}
    }
}