using blog_web_app.Models;
using blog_web_app.Services;
using blog_web_app.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blog_web_app.Controllers;

[Authorize]
public class AdminController : Controller
{
    private readonly IArticleService _articleService;
    private readonly ICategoryService _categoryService;
    
    public AdminController(IArticleService articleService, ICategoryService categoryService)
    {
        _articleService = articleService;
        _categoryService = categoryService;
    }

    public IActionResult Articles() => View(_articleService.Articles);
    
    public IActionResult Categories() => View(_categoryService.Categories);

    [HttpGet]
    public async Task<IActionResult> EditArticle(Guid? id)
    {
        if (id == null) 
            return NotFound();
        
        var article = await _articleService.GetByIdAsync(id);
        if (article == null)
            return NotFound();

        var model = new ArticleViewModel
        {
            Article = article,
            Categories = _categoryService.Categories
        };

        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> EditArticle(ArticleViewModel model, IFormFile? image = null)
    {
        if (!ModelState.IsValid)
        {
            model.Categories = _categoryService.Categories;
            return View(model);
        }

        var article = await _articleService.GetByIdAsync(model.Article.Id);
        if (article == null) 
            return View(model);
        
        article.Name = model.Article.Name;
        article.ShortDescription = model.Article.ShortDescription;
        article.Description = model.Article.Description;
        article.CategoryId = model.Article.CategoryId;
        
        if (image != null)
        {
            using (var binaryReader = new BinaryReader(image.OpenReadStream()))
            {
                article.ImageData = binaryReader.ReadBytes((int)image.Length);
            }
        }
        
        await _articleService.UpdateAsync(article);
        return RedirectToAction("Articles");
    }
    
    [HttpGet]
    public async Task<IActionResult> EditCategory(Guid? id)
    {
        if (id == null) 
            return NotFound();
        
        var category = await _categoryService.GetByIdAsync(id);
        if (category == null)
            return NotFound();
            
        var model = new Category
        {
            Id = category.Id, Name = category.Name
        };
        
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> EditCategory(Category model)
    {
        if (!ModelState.IsValid) 
            return View(model);
        
        var category = await _categoryService.GetByIdAsync(model.Id);
        if (category == null) 
            return View(model);
        
        category.Name = model.Name;
        
        await _categoryService.UpdateAsync(category);
        return RedirectToAction("Categories");
    }

    [HttpGet]
    public IActionResult CreateArticle()
    {
        var model = new ArticleViewModel
        {
            Categories = _categoryService.Categories
        };
        return View("CreateArticle", model);
    }

    [HttpPost]
    public async Task<IActionResult> CreateArticle(ArticleViewModel model, IFormFile? image = null)
    {
        if (!ModelState.IsValid)
        {
            model.Categories = _categoryService.Categories;
            return View(model);
        }

        var article = model.Article;
        if (image != null)
        {
            using (var binaryReader = new BinaryReader(image.OpenReadStream()))
            {
                article.ImageData = binaryReader.ReadBytes((int)image.Length);
            }
        }
        
        await _articleService.AddAsync(article);
        return RedirectToAction("Articles");
    }

    [HttpGet]
    public IActionResult CreateCategory() => View();

    [HttpPost]
    public async Task<IActionResult> CreateCategory(Category model)
    {
        if (!ModelState.IsValid) 
            return View(model);
        
        await _categoryService.AddAsync(model);
        return RedirectToAction("Categories");
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteArticle(Guid? id)
    {
        if (id == null) return NotFound();
        await _articleService.DeleteAsync(id);
        return RedirectToAction("Articles");
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteCategory(Guid? id)
    {
        if (id == null) return NotFound();
        if (_articleService.Articles.Any(a => a.CategoryId == id))
        {
            await _categoryService.DeleteAsync(id);
        }
        return RedirectToAction("Categories");
    }
}