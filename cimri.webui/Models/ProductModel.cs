using cimri.entity;

namespace cimri.webui.Models
{
    public class ProductModel

    {                 
    public int Id { get; set; }
    public int? BrandId { get; set; }
    public string? ProductName { get; set; }
    public double? Price { get; set; }
    public string? Url { get; set; }
    public string? Image { get; set; }

    public List<ComplaintModel> Complaints { get; set; }
    public List<CommentModel> Comments {get; set;}
    public List<DescriptionModel> Descriptions {get; set;}

    public List<CategoryModel> Categories {get; set;}
    public int? ShopId { get; set; }
    public List<ShopModel> Shops { get; set; }
    public int? CategoryId { get; set; }
     public List<ProductModel> Products {get; set;}
    public CategoryModel Category { get; set; }
    public int? EditId {get; set;}
    public List<BrandModel> Brands { get;  set; }
    }
}