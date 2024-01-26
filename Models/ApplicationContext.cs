using Microsoft.EntityFrameworkCore;

namespace demo.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        
    }

    public DbSet<UserItem> UserItems { get; set; }
}