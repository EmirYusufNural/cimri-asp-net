using System;
using cimri.webui.Models;
using cimri.entity;
namespace cimri.webui.Models;

    public class CommentModel

    {     
    public int Id { get; set; }
    public int? ProductId { get; set; }
    public int? EditId {get; set;}

    public ProductModel Products { get; set; }
    public string? Message { get; set; }
    public int? Point { get; set; }
    public DateTime Time { get; set; }
    }
 