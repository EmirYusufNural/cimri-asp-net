using cimri.entity;
namespace cimri.webui.Models
{
    public class BrochureModel
    {
    public int Id { get; set; }
    public string? Url { get; set; }
    public int? ShopId { get; set; }
    public int? EditId {get; set;}

    public ShopModel Shop { get; set; }
    }
}