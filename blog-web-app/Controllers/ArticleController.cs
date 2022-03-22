using System.Diagnostics;
using blog_web_app.Models;
using blog_web_app.Services;
using blog_web_app.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace blog_web_app.Controllers;

public class ArticleController : Controller
{
    private readonly IArticleService _articleService;
    private readonly ICategoryService _categoryService;

    public ArticleController(IArticleService articleService, ICategoryService categoryService)
    {
        _articleService = articleService;
        _categoryService = categoryService;
    }

    public IActionResult List(Guid? categoryId)
    {
        var categories = _categoryService.Categories.ToList();
        categories.Insert(0, new Category { Id = Guid.Empty, Name = "Все" });
 
        var model = new ArticleListViewModel
        {
            Categories = categories.AsQueryable(),
            Articles = categoryId != null && categoryId != Guid.Empty
                ? _articleService.Articles.Where(a => a.CategoryId == categoryId) 
                : _articleService.Articles
        };

        return View(model);
    }

    public async Task<IActionResult> ArticleInfo(Guid id)
    {
        return View(await _articleService.GetByIdAsync(id));
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}