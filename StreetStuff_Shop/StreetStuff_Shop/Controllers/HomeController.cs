using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreetStuff_Shop.BLL.Interfaces;
using StreetStuff_Shop.DAL;
using StreetStuff_Shop.Interfaces;
using StreetStuff_Shop.Models;
using StreetStuff_Shop.ViewModels;
using System.Diagnostics;

namespace StreetStuff_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProductService productService;
        private IRepository repository;


        public HomeController(ILogger<HomeController> logger, IProductService productService, IRepository repository)
        {
            _logger = logger;
            this.productService = productService;
            this.repository = repository;
        }

        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.products = repository.GetProducts();
            return View(model);
        }


        public ActionResult About()
        {
            return View();
        }
        public ActionResult Basket()
        {
            BasketViewModel model = new BasketViewModel();
            model.products = repository.GetProducts();
            model.carts = repository.GetCarts();

            return View(model);
        }
        [HttpPost]
        public ActionResult AddToBasket(int UserId, int ProductId)
        {

            if (repository.GetCartById(UserId, ProductId) == null)
            {
                productService.AddToBasket(UserId, ProductId);
            }

            return RedirectToAction("Basket");

        }

       

        [HttpPost]
        public ActionResult RemoveFromBasket(int id)
        {
            Cart ? cart =repository.GetCartById(id);
            productService.RemoveFromBasket(cart);

            return Redirect("Basket");
        }
        [HttpPost]
        public ActionResult AddQuantity(int id)
        {
            productService.AddQuantity(id);
            
            return Redirect("Basket");

        }
        [HttpPost]
        public ActionResult MinusQuantity(int id)
        {
            productService.MinusQuantity(id);                 

            return Redirect("Basket");

        }
        [HttpPost]
        public ActionResult ChangeQuantity(int id, int quantity)
        {

            productService.ChangeQuantity(id, quantity);

            return Redirect("Basket");
        }
    }
}