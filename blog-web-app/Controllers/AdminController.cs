using blog_web_app.Models;
using blog_web_app.Services;
using blog_web_app.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace blog_web_app.Controllers;

public class AdminController : Controller
{
    private readonly IArticleService _articleService;
    
    public AdminController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    public IActionResult Index() => View(_articleService.Articles);

    [HttpGet]
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null) 
            return NotFound();
        
        var article = await _articleService.GetByIdAsync(id);
        if (article == null)
            return NotFound();
            
        var model = new EditArticleViewModel
        {
            Id = article.Id, Name = article.Name, ShortDescription = article.ShortDescription,
            Description = article.Description
        };
        
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(EditArticleViewModel model)
    {
        if (!ModelState.IsValid) 
            return View(model);
        
        var article = await _articleService.GetByIdAsync(model.Id);
        if (article == null) 
            return View(model);
        
        article.Name = model.Name;
        article.ShortDescription = model.ShortDescription;
        article.Description = model.Description;
        
        await _articleService.UpdateAsync(article);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Create() => View("Create");

    [HttpPost]
    public async Task<IActionResult> Create(CreateArticleViewModel model)
    {
        if (!ModelState.IsValid) 
            return View(model);
        
        var article = new Article
            { Name = model.Name, Description = model.Description, ShortDescription = model.ShortDescription };
        await _articleService.AddAsync(article);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null) return NotFound();
        await _articleService.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}