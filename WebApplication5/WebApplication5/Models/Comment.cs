using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }
        public string CommentText { get; set; }
        public string UserName { get; set; }
        public int GoodId { get; set; }
        public virtual Good Good { get; set; }
    }
}