namespace blog_web_app.Models;

public class Category
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; }
}