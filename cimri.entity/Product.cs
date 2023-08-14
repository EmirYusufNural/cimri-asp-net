namespace cimri.entity
{
    public class Product
    {
     public int Id { get; set; }
    public int? BrandId { get; set; }
    public string? ProductName { get; set; }
    public double? Price { get; set; }
    public string? Url { get; set; }
    public string? Image { get; set; }

    public List<Complaint> Complaints { get; set; }
    public int CommentId { get; set; }
    public List<Comment> Comments {get; set;}
    public List<Description> Descriptions {get; set;}

    public List<Category> Categories {get; set;}
    public int? ShopId { get; set; }
    public List<Shop> Shops { get; set; }
    public int? CategoryId { get; set; }
    // public List<ProductModel> Products {get; set;}
    public Category Category { get; set; }
    public int? EditId {get; set;}
    public List<Brand> Brands { get; set; }
    }
}