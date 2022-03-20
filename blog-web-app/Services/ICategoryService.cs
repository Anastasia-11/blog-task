using blog_web_app.Models;

namespace blog_web_app.Services;

public interface ICategoryService
{
    IQueryable<Category> Categories { get; }
    Task<Category?> GetByIdAsync(Guid? id);
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(Guid? id);
}