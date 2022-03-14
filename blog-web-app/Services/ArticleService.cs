using blog_web_app.Database;
using blog_web_app.Models;

namespace blog_web_app.Services;

public class ArticleService : IArticleService
{
    private readonly ApplicationContext _applicationContext;

    public ArticleService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public IQueryable<Article> Articles => _applicationContext.Articles;

    public Article? GetArticleById(Guid id)
    {
        return Articles.FirstOrDefault(a => a.Id == id);
    }
}