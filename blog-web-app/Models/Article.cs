using System.ComponentModel.DataAnnotations;

namespace blog_web_app.Models;

public class Article
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string? ShortDescription { get; set; }
    public string Description { get; set; }
}