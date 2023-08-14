namespace cimri.entity
{
    public class Shop
    {
    public int Id { get; set; }
    public int? ProductId { get; set; }
    // public Product Product { get; set; }
    public List<Product> Products { get; set; }
    public string? ShopName { get; set; }
    public string? webSite { get; set; }
    public string? Image { get; set; }
    public string? CargoInfo { get; set; }
    public string? CargoTime { get; set; }
    }


}