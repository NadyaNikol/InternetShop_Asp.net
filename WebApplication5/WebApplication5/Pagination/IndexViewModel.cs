using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.Pagination
{
    public class IndexViewModel
    {
        public IEnumerable<Good> Goods { get; set; }
        public PageInfo PageInfo { get; set; }
        public string SelectedCategory { get; set; }
    }
}