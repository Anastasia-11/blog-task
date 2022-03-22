using blog_web_app.Models;

namespace blog_web_app.ViewModels;

public class ArticleListViewModel
{
    public IQueryable<Article> Articles { get; set; }
    public IQueryable<Category> Categories { get; set; }
}