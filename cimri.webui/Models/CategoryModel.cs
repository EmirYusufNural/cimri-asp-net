using cimri.entity;
namespace cimri.webui.Models
{
    public class CategoryModel
    {    
    public int Id { get; set; }
    public int? EditId {get; set;}
    public int BrandId { get; set; }
    public string? CategoryName { get; set; }
    public List<BrandModel> Brands { get; set; }
    }
}