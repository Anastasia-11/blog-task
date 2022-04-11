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

    public IActionResult List(ArticleSearchViewModel searchViewModel, int currentPage = 1)
    {
        var categories = _categoryService.Categories.ToList();
        categories.Insert(0, new Category { Id = Guid.Empty, Name = "Все" });
        
        int pageSize = 3;

        var articles = searchViewModel.CategoryId != null && searchViewModel.CategoryId != Guid.Empty
            ? _articleService.Articles
                .Where(a => a.CategoryId == searchViewModel.CategoryId)
            : _articleService.Articles;

        if (searchViewModel.StartDate != null && searchViewModel.EndDate != null)
        {
            articles = articles.Where(a => a.CreationDate.Date >= searchViewModel.StartDate
                                                && a.CreationDate.Date <= searchViewModel.EndDate);
        }
        
        var count = articles.Count();
        var pageViewModel = new PageViewModel(count, currentPage, pageSize);
        
        var model = new ArticleListViewModel
        {
            SearchViewModel = new ArticleSearchViewModel { Categories = categories.AsQueryable() },
            Articles = articles.Skip((currentPage - 1) * pageSize).Take(pageSize),
            PageViewModel = pageViewModel
        };

        return View(model);
    }

    public async Task<IActionResult> ArticleInfo(Guid id)
    {
        var model = await _articleService.GetByIdAsync(id);
        if(model != null)
        {
            var category = _categoryService.GetByIdAsync(model.CategoryId).Result;
            ViewBag.Category = category == null ? "не указано" : category.Name;
        }

        return View(model);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}