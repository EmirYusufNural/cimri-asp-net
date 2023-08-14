using System.Collections.Generic;

namespace cimri.entity
{
    public class Category
    {
    public int Id { get; set; }
    public string? CategoryName { get; set; }
    public int BrandId { get; set; }
    public List<Brand> Brands{ get; set; }
    }
}