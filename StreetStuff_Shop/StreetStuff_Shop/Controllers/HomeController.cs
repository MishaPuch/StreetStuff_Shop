using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreetStuff_Shop.Interfaces;
using StreetStuff_Shop.Models;
using StreetStuff_Shop.ViewModels;
using System.Diagnostics;

namespace StreetStuff_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IDbContext db;

        
        public HomeController(ILogger<HomeController> logger , IDbContext db)
        {
            this.db = db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<User> users=db.AppDbContext().Users.ToList();
            
            return View(users);
        }
                
       
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Basket() 
        { 
            BasketViewModel model = new BasketViewModel();
            model.products = db.AppDbContext().Products.ToList();
            model.carts = db.AppDbContext().Carts.ToList();

            return View(model);
        }
        [HttpPost]
        public ActionResult AddToBasket(int ProductId, int UserId,int Quantity) 
        {
            StreetStuffContext db=new StreetStuffContext();
            Cart cart=new Cart();

            cart.Id = db.Carts.Count() + 1;
            cart.ProductId = ProductId;
            cart.UserId = UserId;
            cart.Quantity=Quantity;

            db.Carts.Add(cart);
            db.SaveChanges();

            return Redirect("Index"); 
        }
        [HttpPost]
        public ActionResult RemoveFromBasket(int id)
        {
            StreetStuffContext db = new StreetStuffContext();
            
            Cart ? cart=db.Carts.FirstOrDefault(cart=>cart.Id==id);

            db.Carts.Remove(cart);
            db.SaveChanges();

            return Redirect("Index");

        }
    }
}