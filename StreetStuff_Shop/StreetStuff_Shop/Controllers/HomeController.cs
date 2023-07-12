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

        public async Task<IActionResult> Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.products =await repository.GetProducts();
            return View(model);
        }


        public ActionResult About()
        {
            return View();
        }
        public async Task<ActionResult> Basket()
        {
            BasketViewModel model = new BasketViewModel();
            model.products =await repository.GetProducts();
            model.carts = await repository.GetCarts();

            return View(model);
        }
        //........................................................................
        [HttpPost]
        public ActionResult AddToBasket(int UserId, int ProductId)
        {
            Cart cart =repository.GetCartById(ProductId,UserId);
            if ( cart == null)
            {
                productService.AddToBasket(UserId, ProductId);
            }

            return RedirectToAction("Basket");

        }
        //........................................................................
       

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