using COMP_.Entities;
using Microsoft.EntityFrameworkCore;

namespace COMP_.Context
{
    public class PostgreeContext : DbContext
    {
        public PostgreeContext(DbContextOptions<PostgreeContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
