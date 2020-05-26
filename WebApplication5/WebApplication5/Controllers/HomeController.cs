using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;
using WebApplication5.Pagination;
using WebApplication5.Repositories;
using WebApplication5.UnitOfWorkFolder;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        //GoodRepository repository = null;

        //IUnitOfWork unit = null;
        ////EFUnitOfWork eFUnit = null;

        //public HomeController(IUnitOfWork u)
        //{
        //    //repository = new GoodRepository();
        //    unit = u;
        //}


        //public ActionResult Index(string category, int page=1)
        //{
        //    //int pageSize = 4;
        //    //IEnumerable<Good> goodsPerRages = eFUnit.Goods.GetList().Skip((page - 1) * pageSize).Take(pageSize);
        //    //PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = repository.Count };
        //    //IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Goods = goodsPerRages };
        //    //return View(ivm);


        //    int pageSize = 4;
        //    PageInfo pageInfo = new PageInfo
        //    {
        //        PageNumber = page,
        //        PageSize = pageSize,
        //        TotalItems = unit.Goods.GetList().Count()
        //    };
        //    IEnumerable<Good> goods = unit.Goods.GetList().
        //        Where(g => g.Category.CategoryName == null || g.Category.CategoryName == category).
        //        OrderBy(g => g.ID).
        //        Skip((page - 1) * pageSize).Take(pageSize);
        //    IndexViewModel viewModel = new IndexViewModel
        //    {
        //        Goods = goods,
        //        PageInfo = pageInfo,
        //        SelectedCategory = category
        //    };


        //    return View(viewModel);



        //}


    }
}