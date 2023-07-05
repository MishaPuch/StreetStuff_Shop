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
        private StreetStuffContext db;


        public HomeController(ILogger<HomeController> logger, StreetStuffContext db)
        {
            this.db = db;
            _logger = logger;
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
            if (db.Carts.FirstOrDefault(x => (x.UserId == UserId) && (x.ProductId == ProductId)) == null)
            {
                using (StreetStuffContext db = new StreetStuffContext())
                {
                    Cart cart = new Cart();
                    bool isIdUnique = false;

                    do
                    {
                        cart.Id = GenerateUniqueCartId();
                        if (cart.Id > 0)
                            isIdUnique = !db.Carts.Any(c => c.Id == cart.Id);
                    }
                    while (!isIdUnique);

                    cart.ProductId = ProductId;
                    cart.UserId = UserId;
                    cart.Quantity = 1;

                    db.Carts.Add(cart);
                    db.SaveChanges();
                }
            }
            
                return RedirectToAction("Basket");
            
        }

        private int GenerateUniqueCartId()
        {
            using (StreetStuffContext db = new StreetStuffContext())
            {
                int maxAttempts = 100; 
                int attemptCount = 0;

                while (attemptCount < maxAttempts)
                {
                    int newId = new Random().Next(1, int.MaxValue);
                    if (!db.Carts.Any(c => c.Id == newId))
                        return newId;

                    attemptCount++;
                }
            }

            return 0; 
        }

        [HttpPost]
        public ActionResult RemoveFromBasket(int id)
        {
            StreetStuffContext db = new StreetStuffContext();

            Cart? cart = db.Carts.FirstOrDefault(cart => cart.Id == id);

            db.Carts.Remove(cart);
            db.SaveChanges();

            return Redirect("Basket");

        }
        [HttpPost]
        public ActionResult AddQuantity(int id)
        {
            using (StreetStuffContext db = new StreetStuffContext())
            {
                Cart ? cart= db.Carts.FirstOrDefault(c => c.Id == id);
                cart.Quantity++;
                db.SaveChanges();
            }

                return Redirect("Basket");

        }
        [HttpPost]
        public ActionResult MinusQuantity(int id)
        {
            using (StreetStuffContext db = new StreetStuffContext())
            {
                Cart? cart = db.Carts.FirstOrDefault(c => c.Id == id);
                cart.Quantity--;
                db.SaveChanges();
            }

            return Redirect("Basket");

        }
        [HttpPost]
        public ActionResult ChangeQuantity(int id ,int quantity)
        {
            using (StreetStuffContext db = new StreetStuffContext())
            {
                Cart? cart = db.Carts.FirstOrDefault(c => c.Id == id);
                cart.Quantity=quantity;
                db.SaveChanges();
            }
            return Redirect("Basket");

        }
    }
}