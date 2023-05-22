using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StreetStuff_Shop.Interfaces;
using StreetStuff_Shop.Models;
using StreetStuff_Shop.ViewModels;
using System.Text.Json.Serialization;

namespace StreetStuff_Shop.Controllers
{
    public class AccountController : Controller
    {
        private IDbContext db;
        private IUserService userService;
        
        public AccountController(IDbContext db ,IUserService userService) 
        { 
            this.db = db;
            this.userService = userService;
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            User? user = userService.FoundUser(login.email, login.password);
            if (user != null)
            {
                userService.RegistrUserInSession(user);
                return RedirectToAction("index", "home");
            }
            else
            {
                return Redirect("Login");
            }
        }
        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AccountController/Details/5
        public ActionResult Profile()
        {
            ProfileViewModel profile = new ProfileViewModel();
            profile.products=db.AppDbContext().Products.ToList<Product>();
            profile.liked=db.AppDbContext().Liked.ToList<Liked>();

            return View(profile);
        }
        [HttpPost]
        public ActionResult AddProductToLiked(int id)
        {
            return Redirect("Profile");
        }
        [HttpPost]
        public ActionResult RemoveProductFromLiked(int ProductId, int UserId)
        {
            Liked liked = db.AppDbContext().Liked.FirstOrDefault(p => p.ProductId == ProductId && p.UserId == UserId);
            if (liked != null)
            {
                StreetStuffContext db = new StreetStuffContext();
                     db.Liked.Remove(liked);
                     db.SaveChanges();
                
            }
            return Redirect("Profile");
        }
        [HttpPost]
        public ActionResult AddProductToLiked(int ProductId, int UserId)
        {
            
                StreetStuffContext db = new StreetStuffContext();
            Liked liked = new Liked();

            do
            {
                liked.Id = db.Liked.Count() + 1;
            }
            while (db.Liked.FirstOrDefault(l => l.Id == liked.Id)!=null);

            liked.ProductId = ProductId;
            liked.UserId = UserId;
            
                db.Liked.Add(liked);
                db.SaveChanges();

            
            return Redirect("Profile");
        }


        // GET: AccountController/Create
        public ActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAccount(CreateUserViewModel user)
        {
            if(user != null)
            {
                if (user.Password == user.ConfirmPassword)
                {
                    User user1 = new User()
                    {
                        Id = db.AppDbContext().Users.Count() + 1,
                        Email = user.Email,
                        Password = user.Password,
                        Photo = user.Photo,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        ShippingAddress = user.ShippingAddress,
                        PhoneNumber = user.PhoneNumber
                    };
                    
                    userService.CreateUser(user1);
                    userService.RegistrUserInSession(user1);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
            
        }
        public ActionResult Logout()
        {

            userService.LogoutUser();
            return RedirectToAction("Index", "Home");
        }

       


       

        
    }
}
