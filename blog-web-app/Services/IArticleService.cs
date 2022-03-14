using blog_web_app.Models;

namespace blog_web_app.Services;

public interface IArticleService
{
    IQueryable<Article> Articles { get; }
    Article? GetArticleById(Guid id);
}