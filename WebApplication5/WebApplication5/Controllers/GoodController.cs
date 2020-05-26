using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using WebApplication5.Pagination;
using WebApplication5.Repositories;
using WebApplication5.UnitOfWorkFolder;

namespace WebApplication5.Controllers
{
    public class GoodController : Controller
    {
        //GoodRepository repository = null;
        //CategoryRepository categoryRep = null;

        readonly IUnitOfWork unit = null;

        public object Tread { get; private set; }

        //EFUnitOfWork eFUnit = null;


        public GoodController(IUnitOfWork u)
        {
            //repository = new GoodRepository();
            unit = u;
        }


        public ActionResult Index(string category, int page = 1)
        {
            //int pageSize = 4;
            //IEnumerable<Good> goodsPerRages = eFUnit.Goods.GetList().Skip((page - 1) * pageSize).Take(pageSize);
            //PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = repository.Count };
            //IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Goods = goodsPerRages };
            //return View(ivm);

            var goo = unit.Goods.GetList();

            int pageSize = 4;
            PageInfo pageInfo = new PageInfo
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = goo.Count()
            };

            IEnumerable<Good> goods = (category==null)? goo.Skip((page - 1) * pageSize).Take(pageSize) :
                goo.Where(g => /*g.Category.CategoryName == null || */g.Category.CategoryName == category).OrderBy(g => g.ID).Skip((page - 1) * pageSize).Take(pageSize);

            // IEnumerable<Good> goods = goo.Where(g => g.Category.CategoryName == null || g.Category.CategoryName == category).OrderBy(g => g.ID).Skip((page - 1) * pageSize).Take(pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                Goods = goods,
                PageInfo = pageInfo,
                SelectedCategory = category
            };


            return View(viewModel);

        }


        //public ActionResult Index()
        //{
        //    return View(unit.Goods.GetList());
        //}

        public ActionResult DetailsGood(int id)
        {
            return View(unit.Goods.GetById(id));
        }

        [HttpGet]
        public ActionResult CreateGood()
        {
            SelectList items = new SelectList(unit.Goods.GetList(), "CategoryId", "Category");
            ViewBag.category = items;
            return View();
        }

        [HttpPost]
        public ActionResult CreateGood(Good g)
        {
            if(g!=null)
            unit.Goods.Create(g);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateGood(int id)
        {
            SelectList items = new SelectList(unit.Goods.GetList(), "CategoryId", "Category");
            ViewBag.category = items;
            var good = unit.Goods.GetById(id);
            return View(good);
        }

        [HttpPost]
        public ActionResult UpdateGood(Good g)
        {
            unit.Goods.Update(g);
            return RedirectToAction("Index", unit.Goods.GetList());
        }

        [HttpGet]
        public ActionResult DeleteGood(int id)
        {
            Good g = unit.Goods.GetById(id);
            if (g == null)
                return HttpNotFound();

            return View(g);
        }

        [HttpPost, ActionName("DeleteGood")]
        public ActionResult DeleteGood2(int id)
        {
            unit.Goods.Delete(id);
            return RedirectToAction("Index", unit.Goods.GetList());
        }

        [HttpPost]
        public ActionResult GoodSearch(string name)
        {
            var list = unit.Goods.Search(name);

            if (list.Count() <= 0)
                return HttpNotFound();

                

            return View(list);
        }

    }
}