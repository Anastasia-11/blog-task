using System.ComponentModel.DataAnnotations;

namespace blog_web_app.ViewModels;

public class CreateArticleViewModel
{
    [Required]
    [Display(Name = "Название")]
    public string Name { get; set; }
    
    [Display(Name = "Краткое описание")]
    public string? ShortDescription { get; set; }
    
    [Required]
    [Display(Name = "Описание")]
    public string Description { get; set; }
}