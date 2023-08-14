
namespace cimri.entity
{
        public class Brand
        {
                public int Id { get; set; }
                public string? BrandName { get; set; }
                public List<Category> Categories { get; set; }
                public int? CategoryId { get; set; }
                public int? ProductId { get; set; }
                public List<Product> Products {get; set;}
        }
}