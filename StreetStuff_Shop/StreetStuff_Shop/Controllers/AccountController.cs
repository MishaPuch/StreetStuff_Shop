using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StreetStuff_Shop.BLL.Interfaces;
using StreetStuff_Shop.DAL;
using StreetStuff_Shop.Interfaces;
using StreetStuff_Shop.Models;
using StreetStuff_Shop.ViewModels;
using System.Text.Json.Serialization;

namespace StreetStuff_Shop.Controllers
{
    public class AccountController : Controller
    {
        private IUserService userService;
        private ISessionService sessionService;
        private IProductService productService;
        private IRepository repository;

        public AccountController(IUserService userService, ISessionService sessionService , IProductService productService, IRepository repository) 
        { 
            this.userService = userService;
            this.sessionService = sessionService;
            this.productService = productService;   
            this.repository = repository;
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            User? user = repository.GetUser(login.email, login.password);
            if (user != null)
            {
                sessionService.RegistrUserInSession(user);
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
        public async Task<ActionResult> Profile()
        {
            ProfileViewModel profile = new ProfileViewModel();
            profile.products=await repository.GetProducts();
            profile.liked=await repository.GetAllLikedProducts();

            return View(profile);
        }
        
        [HttpPost]
        public ActionResult RemoveProductFromLiked(int ProductId, int UserId)
        {
            Liked liked = repository.GetLikedById(ProductId, UserId);
            if (liked != null)
            {
                productService.RemoveProductFromLiked(liked);
            }
            return Redirect("Profile");
        }
        //.....................................................................
        [HttpPost]
        public ActionResult AddProductToLiked(int ProductId, int UserId)
        {
            Liked liked = repository.GetLikedById(ProductId, UserId);

            if (liked == null)
            {
                productService.AddProductToLiked(ProductId, UserId);              
            }

            return RedirectToAction("Profile");
        }             
        //......................................................................

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
                        Id = repository.GetUserCount() + 1,
                        Email = user.Email,
                        Password = user.Password,
                        Photo = user.Photo,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        ShippingAddress = user.ShippingAddress,
                        PhoneNumber = user.PhoneNumber
                    };
                    
                    userService.CreateUser(user1);
                    sessionService.RegistrUserInSession(user1);
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

            sessionService.LogoutUser();
            return RedirectToAction("Index", "Home");
        }

       


       

        
    }
}
