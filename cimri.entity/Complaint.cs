namespace cimri.entity
{
    public class Complaint
    {
    public int Id { get; set; }
    public int? ProductId { get; set; }
    public Product Product { get; set; }
    public string? Message { get; set; }
    }
}
