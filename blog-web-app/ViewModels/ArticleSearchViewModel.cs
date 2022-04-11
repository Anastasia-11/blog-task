using blog_web_app.Models;

namespace blog_web_app.ViewModels;

public class ArticleSearchViewModel
{
    public Guid? CategoryId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public IQueryable<Category>? Categories { get; set; }
}