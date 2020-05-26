using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using WebApplication5.Repositories;

namespace WebApplication5.Controllers
{
    public class NavController : Controller
    {
        IRepository<Category> repository;
        public NavController(IRepository<Category> repository)
        {
            this.repository = repository;
        }
        // GET: Nav

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.GetList().Select(c => c.CategoryName);
            return PartialView(categories);
        }


    }
}