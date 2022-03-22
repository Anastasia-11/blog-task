using blog_web_app.Models;

namespace blog_web_app.ViewModels;

public class ArticleViewModel
{
    public Article Article { get; set; }
    public IQueryable<Category>? Categories { get; set; }
}