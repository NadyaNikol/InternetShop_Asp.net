using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Good> Goods { get; set; }

        public Category()
        {
            Goods = new List<Good>();
        }

        public override string ToString()
        {
            return $"{CategoryName}";
        }
    }
}