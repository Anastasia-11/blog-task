namespace blog_web_app.ViewModels;

public class EditArticleViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? ShortDescription { get; set; }
    public string Description { get; set; }
}