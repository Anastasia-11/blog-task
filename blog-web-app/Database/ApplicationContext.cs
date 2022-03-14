using blog_web_app.Models;
using Microsoft.EntityFrameworkCore;

namespace blog_web_app.Database;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Article> Articles { get; set; }
}