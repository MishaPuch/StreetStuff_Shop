using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreetStuff_Shop.BLL.Interfaces;
using StreetStuff_Shop.DAL.RepositoriumsInterface;
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
        private IUserService userService;
        private ISessionService sessionService;
        private ICartServicecs cartServicecs;
        private ILikedService likedService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IUserService userService, ISessionService sessionService, ICartServicecs cartServicecs, ILikedService likedService)
        {
            _logger = logger;
            this.productService = productService;
            this.userService = userService;
            this.sessionService = sessionService;
            this.cartServicecs = cartServicecs;
            this.likedService = likedService;
        }

        public async Task<IActionResult> Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.Products =await productService.GetProducts();
            return View(model);
        }


        public ActionResult About()
        {
            return View();
        }
        public async Task<ActionResult> Basket()
        {
            BasketViewModel model = new BasketViewModel();
            model.Products =await productService.GetProducts();
            model.Carts = await cartServicecs.GetCarts();

            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> AddToBasket(int UserId, int ProductId)
        {
            var cart = await cartServicecs.GetCartById(ProductId,UserId);
            if ( cart == null)
            {
                await cartServicecs.AddToCart(UserId, ProductId);
            }

            return RedirectToAction("Basket");

        }
       

        [HttpPost]
        public async Task<ActionResult> RemoveFromBasket(int id)
        {
            var cart =await cartServicecs.GetCartById(id);
            await cartServicecs.RemoveFromCart(cart);

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