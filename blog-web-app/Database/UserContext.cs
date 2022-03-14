using blog_web_app.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace blog_web_app.Database;

public class UserContext : IdentityDbContext<User>
{
    public UserContext()
    {
    }

    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
    }
}