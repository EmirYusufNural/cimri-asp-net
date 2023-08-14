using cimri.entity;

namespace cimri.webui.Models
{
    public class FavoriteModel

    {             
        public int Id { get; set; }
        public int? EditId {get; set;}

        public List<FavoriteItemModel> FavoriteItems {get; set;}
    }
}