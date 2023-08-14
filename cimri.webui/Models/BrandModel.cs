using cimri.entity;
namespace cimri.webui.Models
{
    public class BrandModel
    {
    public int Id { get; set; }
    public string? BrandName { get; set; }
    public int? EditId {get; set;}
    public List<CategoryModel> Categories { get; set; }
    public int? CategoryId { get; set; }
    public int? ProductId { get; set; }

    public List<ProductModel> Products {get; set;}
  
    }
}
