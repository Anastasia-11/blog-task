using blog_web_app.Models;

namespace blog_web_app.ViewModels;

public class ArticleListViewModel
{
    public IQueryable<Article> Articles { get; set; }
    public ArticleSearchViewModel SearchViewModel { get; set; }
    public PageViewModel PageViewModel { get; set; }
}