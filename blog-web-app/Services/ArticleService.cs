using blog_web_app.Database;
using blog_web_app.Models;
using Microsoft.EntityFrameworkCore;

namespace blog_web_app.Services;

public class ArticleService : IArticleService
{
    private readonly ApplicationContext _applicationContext;

    public ArticleService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public IQueryable<Article> Articles => _applicationContext.Articles;

    public async Task<Article?> GetByIdAsync(Guid? id)
    {
        return await Articles.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task AddAsync(Article article)
    {
        await _applicationContext.AddAsync(article);
        await _applicationContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Article article)
    {
        _applicationContext.Update(article);
        await _applicationContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid? id)
    {
        var article = await GetByIdAsync(id);
        if(article != null)
            _applicationContext.Remove(article);
    }
}