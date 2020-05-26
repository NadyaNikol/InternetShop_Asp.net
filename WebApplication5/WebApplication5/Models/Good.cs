using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Good
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        //public string CountryOfOrigin { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }


        public override string ToString()
        {
            return $"{ Title} {Price} {Category.CategoryName}";
        }
    }
}