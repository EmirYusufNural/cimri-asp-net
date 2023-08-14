using cimri.entity;

namespace cimri.webui.Models
{
    public class DescriptionModel

    {         
    public int Id { get; set; }
    public string? Text { get; set; }
    public int? ProductId { get; set; }
    public int? EditId {get; set;}

    public ProductModel Product { get; set; }
    }
}