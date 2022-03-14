namespace blog_web_app.Models;

public class Article
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; }
    public string? ShortDescription { get; set; }
    public string Description { get; set; }
}