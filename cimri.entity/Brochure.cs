    namespace cimri.entity{
    public class Brochure
    {
    public int Id { get; set; }
    public string? Url { get; set; }
    public int? ShopId { get; set; }
    public Shop Shop { get; set; }
    }
}

