namespace cimri.entity;

public class Description
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public int? ProductId { get; set; }
    public Product Product { get; set; }
}