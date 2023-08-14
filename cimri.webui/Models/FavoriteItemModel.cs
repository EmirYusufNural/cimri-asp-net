using cimri.entity;

namespace cimri.webui.Models
{
    public class FavoriteItemModel

    {             
    public int Id { get; set; }
    public int? ProductId { get; set; }
    public ProductModel Product { get; set; }
    public int? FavoriteId { get; set; }
    public int? EditId {get; set;}

    public FavoriteModel Favorite { get; set; }
    }
}