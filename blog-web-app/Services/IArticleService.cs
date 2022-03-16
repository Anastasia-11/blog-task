using blog_web_app.Models;

namespace blog_web_app.Services;

public interface IArticleService
{
    IQueryable<Article> Articles { get; }
    Task<Article?> GetByIdAsync(Guid? id);
    Task AddAsync(Article article);
    Task UpdateAsync(Article article);
    Task DeleteAsync(Guid? id);
}