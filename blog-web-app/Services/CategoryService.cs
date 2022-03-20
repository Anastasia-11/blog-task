using blog_web_app.Database;
using blog_web_app.Models;
using Microsoft.EntityFrameworkCore;

namespace blog_web_app.Services;

public class CategoryService : ICategoryService
{
    private readonly ApplicationContext _applicationContext;

    public CategoryService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public IQueryable<Category> Categories => _applicationContext.Categories;

    public async Task<Category?> GetByIdAsync(Guid? id)
    {
        return await Categories.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task AddAsync(Category category)
    {
        await _applicationContext.AddAsync(category);
        await _applicationContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        _applicationContext.Update(category);
        await _applicationContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid? id)
    {
        var category = await GetByIdAsync(id);
        if (category == null) return;
        _applicationContext.Remove(category);
        await _applicationContext.SaveChangesAsync();
    }
}