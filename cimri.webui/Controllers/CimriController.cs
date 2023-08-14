using Microsoft.AspNetCore.Mvc;
using cimri.webui.Models;
using cimri.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cimri.Controllers
{
    public class CimriController:Controller
    {
        // public string index()
        // {
        //     return "course/index";
        // }

        private readonly EntityContext _context;
        public CimriController(EntityContext context)
        {
            _context=context;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        //ShopAdd AND ShopList
        [HttpGet]
        public async Task<IActionResult> ShopList()
        {
            var shopsWithproducts = await _context.Shops
            .Include(b => b.Products) 
            .ToListAsync();
            return View(shopsWithproducts);
        }

        public IActionResult ShopAdd()
        {
            var model = new ShopModel();
            var products=_context.Products.ToList();
            model.Products=products.Select(product=>new ProductModel
            {
                Id=product.Id,
                ProductName=product.ProductName
            }).ToList();
            return View(model);
            
        }
      
        [HttpPost]
        public async Task<IActionResult> ShopAdd(ShopModel model)
        {  
            var entity = new Shop(){
                ShopName =model.ShopName,
                webSite=model.webSite,
                Image=model.Image,
                CargoInfo=model.CargoInfo,
                CargoTime=model.CargoTime,
                ProductId=model.ProductId,
            };
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("ProductDetails",new{Id=model.ProductId});
            
        }


      
        // public async Task<IActionResult> ShopDetails(ShopModel model)
        // {
        //     model.Products = await _context.Products.ToListAsync();

        //     return View(model);
        // }
        // public async Task<IActionResult> ShopDetails(int Id)
        // {
        //     var model = new Shop();
        //     model.Products = await _context.Products.Where(p => p.ShopId == Id).ToListAsync();
        //     return View(model);
        //     // var shop=await _context.Shops.FindAsync(Id);
        //     //  return View(shop);  
        // }


        //shop update
        [HttpGet]
        public async Task<IActionResult> ShopUpdate(int? id)
       {
        var shop=await _context.Shops.FindAsync(id);

            var model = new ShopModel{
                EditId = shop.Id,
                ShopName = shop.ShopName,
                webSite=shop.webSite,
                Image=shop.Image,
                CargoInfo=shop.CargoInfo,
                CargoTime=shop.CargoTime

            };
            
            return View(model);
       }
       [HttpPost]
       public async Task<IActionResult> ShopUpdate(ShopModel model)
       {
            var shop = new Shop{
            Id = (int)model.EditId,
            ShopName = model.ShopName,
            webSite=model.webSite,
            Image=model.Image,
            CargoInfo=model.CargoInfo,
            CargoTime=model.CargoTime
            }; 
        _context.Update(shop);
        await _context.SaveChangesAsync();
         return RedirectToAction("ShopList");
       }
         

       //shop delete
       [HttpGet]
       public async Task<IActionResult> ShopDelete(int? id)
       {
        var shop=await _context.Shops.FindAsync(id);
        _context.Shops.Remove(shop);
        await _context.SaveChangesAsync();
        return RedirectToAction("ShopList");
        
       }

      

        //DescriptionAdd AND DescriptionList//
        [HttpGet]
        public async Task<IActionResult> DescriptionList()
        {
             var descriptionsWithProducts = await _context.Descriptions
                .Include(c => c.Product)
                .ToListAsync();
            return View(descriptionsWithProducts);
        }
        public IActionResult DescriptionAdd()
        {
             var products = _context.Products.ToList();
            ViewBag.ProductList = new SelectList(products, "Id", "ProductName");
            return View();
            
        }
        [HttpPost]
        public async Task<IActionResult> DescriptionAdd(Description model)
        {  
            var entity = new Description()
            {
                Text = model.Text,
                ProductId=model.ProductId,

            };
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("ProductDetails",new{Id=model.ProductId});
        }
    
         [HttpGet]
        public async Task<IActionResult> DescriptionUpdate(int? id)
       {
        var description=await _context.Descriptions.FindAsync(id);

            var model = new DescriptionModel{
                EditId = description.Id,
                Text=description.Text
            };
            
            return View(model);
       }
       [HttpPost]
       public async Task<IActionResult> DescriptionUpdate(DescriptionModel model)
       {
            var description = new Description{
            Id = (int)model.EditId,
            Text=model.Text
            }; 
            _context.Update(description);
            await _context.SaveChangesAsync();
            return RedirectToAction("DescriptionList");
       }
         

       //description delete
       [HttpGet]
       public async Task<IActionResult> DescriptionDelete(int? id)
       {
        var description=await _context.Descriptions.FindAsync(id);
        _context.Descriptions.Remove(description);
        await _context.SaveChangesAsync();
        return RedirectToAction("DescriptionList");
        
       }
             
       
       
        //Favoriteadd AND FatoriteList
        // [HttpGet]
        // public async Task<IActionResult> FavoriteList()
        // {
        //     var model = new List<FavoriteItemModel>(){};
        //     var favorites=await _context.Favorites.ToListAsync();
        //     return View(favorites);
        // }  
        
        // public IActionResult FavoriteAdd()
        // {
        //     var model = new FavoriteModel(){};
        //     return View(model);
            
        // }
        
        // [HttpPost]
        // public async Task<IActionResult>FavoriteAdd(FavoriteModel model)
        // {
        //     if(model.Id != null)
        //     {
        //         _context.Favorites.Add(model);
        //         await _context.SaveChangesAsync();
        //     }
        //     return RedirectToAction("FavoriteAdd","Cimri");
        // }

      //CommentAdd And CommentList
       [HttpGet]
        public async Task<IActionResult> CommentList()
        {
        var commentsWithProducts = await _context.Comments
                .Include(c => c.Product)
                .ToListAsync();
            return View(commentsWithProducts);
        }

        public IActionResult CommentAdd()
        {   
            var products = _context.Products.ToList();
            ViewBag.ProductList = new SelectList(products, "Id", "ProductName");
            return View();
        }
              
          [HttpPost]
        public async Task<IActionResult> CommentAdd(CommentModel model)
        { 
          
                var entity = new Comment(){
                Message =model.Message,
                Point=model.Point,
                ProductId=model.ProductId,
                Time=DateTime.Now
            };
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("ProductDetails",new{Id=model.ProductId});

        } 




     
        //Comment delete
       [HttpGet]
       public async Task<IActionResult> CommentDelete(int? id)
       {
        var comment=await _context.Comments.FindAsync(id);
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        return RedirectToAction("CommentList");
       }
   

        //Brandadd And Brandlist
        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
        var brandsWithCategories = await _context.Brands
        .Include(b => b.Categories) 
        .ToListAsync();
        return View(brandsWithCategories);
        }
        public IActionResult BrandAdd()
        {   
         var model = new BrandModel();

         var categories =  _context.Categories.ToList();
        model.Categories = categories.Select(category => new CategoryModel
            {
            Id = category.Id,
            CategoryName = category.CategoryName,
             // Diğer özellikleri dönüştürebilirsiniz
        }).ToList();

        return View(model); 
            
        }
        [HttpPost]
        public async Task<IActionResult> BrandAdd(BrandModel model)
        {
            // ViewBag.Categories=new SelectList(await _context.Categories.ToListAsync(),"CategoryId","CategoryName");
            var entity = new Brand(){
                BrandName =model.BrandName,
                CategoryId = model.CategoryId
            };
            
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("BrandList", new { Id = model.CategoryId });
        }

        // public async Task<IActionResult> BrandDetails(BrandModel model)
        // {
        //     model.Products = await _context.Products.ToListAsync();
        //     model.Categories = await _context.Categories.ToListAsync();

        //     return View(model);
        // }
        public async Task<IActionResult> BrandDetails(int Id)
        {
            var model = new BrandModel();
            var brand = await _context.Brands.FindAsync(Id);

        var categories = await _context.Categories
        .Where(category => category.BrandId == Id)
        .ToListAsync();

         var products = await _context.Products
        .Where(product => product.BrandId == Id)
        .ToListAsync();

        model.Categories = categories.Select(category => new CategoryModel
        {
        Id = category.Id,
        CategoryName = category.CategoryName,
        }).ToList();

         model.Products = products.Select(product => new ProductModel
        {
        Id = product.Id,
        ProductName = product.ProductName,
        }).ToList();

         return View(model);
        }
      



        //Brand update
        [HttpGet]
        public async Task<IActionResult> BrandUpdate(int? id)
       {
            var brand=await _context.Brands.FindAsync(id);

            var model = new BrandModel{
             EditId = brand.Id,
                BrandName = brand.BrandName,
            };
            
            return View(model);
       }
       [HttpPost]
       public async Task<IActionResult> BrandUpdate(BrandModel model)
       {
            var brand = new Brand{
                Id = (int)model.EditId,
                BrandName = model.BrandName,
            }; 
        _context.Update(brand);
        await _context.SaveChangesAsync();
         return RedirectToAction("BrandList");
       }
       //Brand delete
       [HttpGet]
       public async Task<IActionResult> BrandDelete(int? id)
       {
        var brand=await _context.Brands.FindAsync(id);
        _context.Brands.Remove(brand);
        await _context.SaveChangesAsync();
        return RedirectToAction("BrandList");
       }
       


        ///Complaintadd and complaintlist

        public IActionResult Complaint()
        {   
            return View();
        }


        //Productadd and productlist
       [HttpGet]
        public async Task<IActionResult> ProductList()
        {

         var productsWithbrands = await _context.Products
        .Include(b => b.Brands) 
        .ToListAsync();
        return View(productsWithbrands);
        }

        public IActionResult ProductAdd()
        {   
            var brands = _context.Brands.ToList();
            var model = new ProductModel
            {
            Brands = brands.Select(brand => new BrandModel
            {
             Id = brand.Id,
             BrandName = brand.BrandName
            }).ToList()
            };
            return View(model);
        }
       [HttpPost]
        public async Task<IActionResult> ProductAdd(ProductModel model)
        {
            // ViewBag.Categories=new SelectList(await _context.Categories.ToListAsync(),"CategoryId","CategoryName");
            var entity = new Product(){
                ProductName =model.ProductName,
                BrandId = model.BrandId,
                CategoryId=model.CategoryId
            };
            
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("BrandDetails", new { Id = model.BrandId });
        }
        
        public async Task<IActionResult> ProductDetails(int Id)
        {
               var model = new ProductModel();
               var product = await _context.Products.FindAsync(Id);
               model.ProductName = product.ProductName; 


         var shops = await _context.Shops
        .Where(shop => shop.ProductId == Id)
        .ToListAsync();
        var comments = await _context.Comments
        .Where(comment => comment.ProductId == Id)
        .ToListAsync();
         var descriptions = await _context.Descriptions
        .Where(description => description.ProductId == Id)
       .ToListAsync();

        model.Shops = shops.Select(shop => new ShopModel
        {
        Id = shop.Id,
        ShopName = shop.ShopName,
        webSite=shop.webSite,
        CargoInfo=shop.CargoInfo,
        CargoTime=shop.CargoTime
        }).ToList();

        model.Comments = comments.Select(comment => new CommentModel
        {
        Id = comment.Id,
        Message = comment.Message,
        Point=comment.Point,
        Time=comment.Time,
        
        }).ToList();
 

      model.Descriptions = descriptions.Select(description => new DescriptionModel
        {
        Id=description.Id,
        Text=description.Text
        }).ToList();
        return View(model);
        
        }
        
        //Product update
        [HttpGet]
        public async Task<IActionResult> ProductUpdate(int? id)
       {
            var product=await _context.Products.FindAsync(id);

            var model = new ProductModel{
                EditId = product.Id,
                ProductName = product.ProductName,
                Price=product.Price,
                Url=product.Url,
                Image=product.Image
            };
            
            return View(model);
       }
       [HttpPost]
       public async Task<IActionResult> ProductUpdate(ProductModel model)
       {
            var product = new Product{
                Id = (int)model.EditId,
                ProductName = model.ProductName,
                Price=model.Price,
                Url=model.Url,
                Image=model.Image
            }; 
        _context.Update(product);
        await _context.SaveChangesAsync();
         return RedirectToAction("ProductList");
       }
       //Brand delete
       [HttpGet]
       public async Task<IActionResult> ProductDelete(int? id)
       {
        var product=await _context.Products.FindAsync(id);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return RedirectToAction("ProductList");
       }

                                    
        //Brochurelist and brochureadd
        [HttpGet]
        public async Task<IActionResult> BrochureList()
        {
            var brochure=await _context.Brochures.ToListAsync();
            return View(brochure);
        }
        public IActionResult BrochureAdd()
        {   
             var model = new BrochureModel(){};
             return View(model);
            
        }
          [HttpPost]
        public async Task<IActionResult> BrochureAdd(BrochureModel model)
        {
            var entity = new Brochure(){
                Url =model.Url
               
            };
            _context.Add(entity);
            await _context.SaveChangesAsync();
             return RedirectToAction("BrochureList","Cimri");
        }
        //Brochure update
        [HttpGet]
        public async Task<IActionResult> BrochureUpdate(int? id)
       {
            var brochure=await _context.Brochures.FindAsync(id);

            var model = new BrochureModel{
                EditId = brochure.Id,
                Url = brochure.Url,
               
            };
            
            return View(model);
       }
       [HttpPost]
       public async Task<IActionResult> BrochureUpdate(BrochureModel model)
       {
            var brochure = new Brochure{
                Id = (int)model.EditId,
                Url = model.Url,
           
            }; 
        _context.Update(brochure);
        await _context.SaveChangesAsync();
         return RedirectToAction("BrochureList");
       }
       //Brochure delete
        [HttpGet]
       public async Task<IActionResult> BrochureDelete(int? id)
       {
        var brochure=await _context.Brochures.FindAsync(id);
        _context.Brochures.Remove(brochure);
        await _context.SaveChangesAsync();
        return RedirectToAction("BrochureList");
       }
       
        //Categoryadd AND categorylist
       [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var category=await _context.Categories.ToListAsync();
            return View(category);
        }
        public IActionResult CategoryAdd()
        {   
             var model = new CategoryModel(){};
             return View(model);
            
        }
          [HttpPost]
        public async Task<IActionResult> CategoryAdd(CategoryModel model)
        {
            var entity = new Category(){
                CategoryName =model.CategoryName
               
            };
            _context.Add(entity);
            await _context.SaveChangesAsync();
             return RedirectToAction("CategoryList","Cimri");
        }
        // public async Task<IActionResult> CategoryDetails(int categoryId)
        // {
        //     var category = await _context.Categories
        //                         .Include(c => c.Brands) 
        //                         .FirstOrDefaultAsync(c => c.Id == categoryId);

        //     if (category == null)
        //     {
        //      return NotFound();
        //     }

        //      return View(category); 
        // }
        public async Task<IActionResult> CategoryDetails(int Id)
        {
            var model = new CategoryModel();
            var brandEntities = await _context.Brands.Where(p => p.CategoryId == Id).ToListAsync();

             model.Brands = brandEntities.Select(brand => new BrandModel
            {
              Id = brand.Id,
            BrandName = brand.BrandName,
            
             }).ToList();

            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> CategoryUpdate(int? id)
       {
            var category=await _context.Categories.FindAsync(id);

            var model = new CategoryModel{
                EditId = category.Id,
                CategoryName = category.CategoryName,
               
            };
            
            return View(model);
       }
       [HttpPost]
       public async Task<IActionResult> CategoryUpdate(CategoryModel model)
       {
            var category = new Category{
                Id = (int)model.EditId,
                CategoryName = model.CategoryName,
           
            }; 
        _context.Update(category);
        await _context.SaveChangesAsync();
         return RedirectToAction("CategoryList");
       }
       //category delete
        [HttpGet]
       public async Task<IActionResult> CategoryDelete(int? id)
       {
        var category=await _context.Categories.FindAsync(id);
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return RedirectToAction("CategoryList");
       }
     // //Favoriteıtemadd and favoriteıtemlist
                                    //  public IActionResult FavoriteItemAdd()
                                    // {   
                                    //     var model = new FavoriteItemModel();
                                    //     return View(model);
                                    // }
                                    //   [HttpPost]
                                    // public async Task<IActionResult> FavoriteItemAdd(FavoriteItemModel model)
                                    // {           
                                    //     _context.FavoriteItems.Add(model);
                                    //     await _context.SaveChangesAsync();
                                        
                                    //     return RedirectToAction("FavoriteItemAdd","Cimri");
                                    // }
                                    // public async Task<IActionResult> FavoriteItemAdd()
                                    // {   
                                    //     return View(favoriteitemadd);
                                    /// }

    }
}