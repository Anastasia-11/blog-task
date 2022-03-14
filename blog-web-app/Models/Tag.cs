namespace blog_web_app.Models;

public class Tag
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; }
}