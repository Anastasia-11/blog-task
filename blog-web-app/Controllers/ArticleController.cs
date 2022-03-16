using System.Diagnostics;
using blog_web_app.Services;
using blog_web_app.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace blog_web_app.Controllers;

public class ArticleController : Controller
{
    private readonly IArticleService _articleService;

    public ArticleController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    public IActionResult List() => View(_articleService.Articles);

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