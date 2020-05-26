using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using WebApplication5.UnitOfWorkFolder;
using WebApplication5.CartFolder;

namespace WebApplication5.Controllers
{
    public class CartController : Controller
    {
        IUnitOfWork db;

        public CartController(IUnitOfWork database)
        {
            db = database;
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }


        public ActionResult AddToCart(Cart cart, int id, string returnUrl)
        {
            Good good = db.Goods.GetList().FirstOrDefault(g => g.ID == id);

            if (good != null)
                cart.AddItem(good, 1);

            CartIndexViewModel viewModel = new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl };

            //return RedirectToAction("Index", viewModel);
            return View("Index", viewModel);
        }

        public ActionResult RemoveFromCart(Cart cart, int id, string returnUrl)
        {
            Good good = db.Goods.GetList().FirstOrDefault(g => g.ID == id);

            if (good != null)
                cart.RemoveItem(good);

            CartIndexViewModel viewModel = new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl };
            //return RedirectToAction("Index", new { returnUrl });
            return View("Index", viewModel);
        }

        public ActionResult Index(Cart cart, string returnUrl)
        {
            CartIndexViewModel viewModel = new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl };
            return View(viewModel);
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}