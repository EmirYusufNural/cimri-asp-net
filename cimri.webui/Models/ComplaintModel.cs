using cimri.entity;

namespace cimri.webui.Models
{
    public class ComplaintModel

    {     
    public int Id { get; set; }
    public int? ProductId { get; set; }
    public int? EditId {get; set;}

    public ProductModel Product { get; set; }
    public string? Message { get; set; }

    }
}
