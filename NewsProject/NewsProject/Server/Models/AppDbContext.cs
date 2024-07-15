using Microsoft.EntityFrameworkCore;
using NewsProject.Shared.Models;

namespace NewsProject.Server.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<NewsList> NewsLists { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
