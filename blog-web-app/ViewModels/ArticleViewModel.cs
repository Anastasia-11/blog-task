using System.ComponentModel.DataAnnotations;
using blog_web_app.Models;

namespace blog_web_app.ViewModels;

public class ArticleViewModel
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid CategoryId { get; set; }
    
    [Required(ErrorMessage = "Не указано название статьи")]
    [Display(Name = "Название")]
    public string Name { get; set; }
    
    [Display(Name = "Краткое описание")]
    public string? ShortDescription { get; set; }
    
    [Required(ErrorMessage = "Не указано описание статьи")]
    [Display(Name = "Описание")]
    public string Description { get; set; }
    
    public IQueryable<Category>? Categories { get; set; }
}