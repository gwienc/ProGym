using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ProGym.App_Start;
using ProGym.DAL;
using ProGym.Infrastructure;
using ProGym.Models;
using ProGym.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProGym.Controllers
{
    public class CartController : Controller
    {
        private ShoppingCartManager _shoppingCartManager;

        private ISessionManager _sessionManager;

        private StoreContext _db = new StoreContext();

        private ApplicationUserManager _userManager;

        private IMailService _mailService;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public CartController(IMailService mailService, ISessionManager sessionManager)
        {
            _mailService = mailService;
            _sessionManager = sessionManager;
            _shoppingCartManager = new ShoppingCartManager(_sessionManager, _db);
        }

        public ActionResult Index()
        {
            var cartItems = _shoppingCartManager.GetCart();
            var cartTotalPrice = _shoppingCartManager.GetCartTotalPrice();

            CartViewModel cartViewModel = new CartViewModel()
            {
                CartItems = cartItems,
                TotalPrice = cartTotalPrice
            };

            return View(cartViewModel);
        }

        public ActionResult AddToCart(int id)
        {
            _shoppingCartManager.AddToCart(id);

            return RedirectToAction("Index");
        }

        public int GetCartItemsCount()
        {
            return _shoppingCartManager.GetCartItemsCount();
        }

        public ActionResult RemoveFromCart(int productID)
        {
            var itemCount = _shoppingCartManager.RemoveFromCart(productID);
            var cartItemsCount = _shoppingCartManager.GetCartItemsCount();
            var cartTotal = _shoppingCartManager.GetCartTotalPrice();

            var result = new CartRemoveViewModel
            {
                RemoveItemId = productID,
                RemovedItemCount = itemCount,
                CartTotal = cartTotal,
                CartItemsCount = cartItemsCount
            };
            return Json(result);
        }

        public async Task<ActionResult> Checkout()
        {
            if (Request.IsAuthenticated)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                var order = new Order
                {
                    FirstName = user.UserData.FirstName,
                    LastName = user.UserData.LastName,
                    Address = user.UserData.Address,
                    CodeAndCity = user.UserData.CodeAndCity,
                    Email = user.UserData.Email,
                    PhoneNumber = user.UserData.PhoneNumber
                };
                return View(order);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Checkout", "Cart") });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Checkout(Order orderdetails)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var newOrder = _shoppingCartManager.CreateOrder(orderdetails, userId);

                var user = await UserManager.FindByIdAsync(userId);
                TryUpdateModel(user.UserData);
                await UserManager.UpdateAsync(user);

                _shoppingCartManager.EmptyCart();

                var order = _db.Orders.Include(x => x.OrderItems.Select(p => p.Product)).SingleOrDefault(o => o.OrderID == newOrder.OrderID);

                _mailService.SendOrderConfirmationEmail(order);

                return RedirectToAction("OrderConfirmation");
            }
            else
            {
                return View(orderdetails);
            }
        }

        public ActionResult OrderConfirmation()
        {
            return View();
        }
    }
}