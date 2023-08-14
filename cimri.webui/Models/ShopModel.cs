using cimri.entity;

namespace cimri.webui.Models
{
    public class ShopModel

    {                 
    public int Id { get; set; }
    public int? ProductId { get; set; }
    public int? EditId {get; set;}

    public List<ProductModel> Products { get; set; }
    public string? ShopName { get; set; }
    public string? webSite { get; set; }
    public string? Image { get; set; }
    public string? CargoInfo { get; set; }
    public string? CargoTime { get; set; }
    
    }
}