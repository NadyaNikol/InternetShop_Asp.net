using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.EF
{
    public class ShopDbInitializer: DropCreateDatabaseIfModelChanges<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            IList<Category> categories = new List<Category>();

            categories.Add(new Category { CategoryName = "PC" });
            categories.Add(new Category { CategoryName = "Telephones" });

            context.categories.AddRange(categories);

            IList<Good> goods = new List<Good>();

            goods.Add(new Good() { Title = "Samsung", Price = 1234.5, CategoryId = 1 });
            goods.Add(new Good() { Title = "Apple", Price = 45323, CategoryId=2});
            goods.Add(new Good() { Title = "Huawei", Price = 3957.4, CategoryId=1});
            goods.Add(new Good() { Title = "Apple", Price = 34534.7, CategoryId=2 });
            goods.Add(new Good() { Title = "Huawei", Price = 234.5, CategoryId = 1 });
            goods.Add(new Good() { Title = "Samsung", Price = 4645.3, CategoryId=2});
            goods.Add(new Good() { Title = "Apple", Price = 345345.2, CategoryId=1});
            goods.Add(new Good() { Title = "Samsung", Price = 5466.4, CategoryId=1});
            goods.Add(new Good() { Title = "Xiomi", Price = 213.5, CategoryId=1});
            goods.Add(new Good() { Title = "Samsung", Price = 456.4, CategoryId=2 });
            goods.Add(new Good() { Title = "Xiomi", Price = 13213.5, CategoryId=1 });
            goods.Add(new Good() { Title = "Apple", Price = 3453.6, CategoryId=2});
            goods.Add(new Good() { Title = "Xiomi", Price = 13123.5, CategoryId=2});


            //IList<Comment> comments = new List<Comment>();

            //comments.Add(new Comment { UserName = "Vasya", CommentText = "Good", GoodId=1 });
            //comments.Add(new Comment { UserName = "Petya", CommentText = "is normal", GoodId=2 });
            //comments.Add(new Comment { UserName = "Sveta", CommentText = "my chource", GoodId=3 });


            //context.comments.AddRange(comments);
            context.goods.AddRange(goods);

            context.SaveChanges();
        }
    }
}