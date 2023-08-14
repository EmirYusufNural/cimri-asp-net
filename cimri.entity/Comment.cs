namespace cimri.entity
{
    public class Comment
    {
    public int Id { get; set; }
    public int? ProductId { get; set; }
    public Product Product { get; set; }
    public string? Message { get; set; }
    public int? Point { get; set; }
    public DateTime Time { get; set; }
    }
}