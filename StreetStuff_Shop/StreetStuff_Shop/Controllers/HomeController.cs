using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreetStuff_Shop.BLL.Interfaces;
using StreetStuff_Shop.Interfaces;
using StreetStuff_Shop.Models;
using StreetStuff_Shop.ViewModels;
using System.Diagnostics;

namespace StreetStuff_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private StreetStuffContext db;
        private IProductService productService;


        public HomeController(ILogger<HomeController> logger, StreetStuffContext db, IProductService productService)
        {
            this.db = db;
            _logger = logger;
            this.productService = productService;
        }

        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.products = db.Products.ToList();
            return View(model);
        }


        public ActionResult About()
        {
            return View();
        }
        public ActionResult Basket()
        {
            BasketViewModel model = new BasketViewModel();
            model.products = db.Products.ToList();
            model.carts = db.Carts.ToList();

            return View(model);
        }
        [HttpPost]
        public ActionResult AddToBasket(int UserId, int ProductId)
        {

            if (productService.GetCartById(ProductId) == null)
            {
                productService.AddToBasket(UserId, ProductId);
            }

            return RedirectToAction("Basket");

        }

       

        [HttpPost]
        public ActionResult RemoveFromBasket(int id)
        {
            Cart ? cart =productService.GetCartById(id);
            productService.RemoveFromBasket(cart);

            return Redirect("Basket");
        }
        [HttpPost]
        public ActionResult AddQuantity(int id)
        {

            Cart? cart = productService.GetCartById(id);
            cart.Quantity++;
            db.SaveChanges();


            return Redirect("Basket");

        }
        [HttpPost]
        public ActionResult MinusQuantity(int id)
        {

            Cart? cart = productService.GetCartById(id);
            cart.Quantity--;
            db.SaveChanges();


            return Redirect("Basket");

        }
        [HttpPost]
        public ActionResult ChangeQuantity(int id, int quantity)
        {

            Cart? cart = productService.GetCartById(id);
            cart.Quantity = quantity;
            db.SaveChanges();

            return Redirect("Basket");
        }
    }
}