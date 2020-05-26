using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.EF
{
    public class ShopContext: DbContext
    {

        public DbSet<Category> categories { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Good> goods { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer(new ShopDbInitializer());

        //    modelBuilder.Entity<Good>().HasOptional(c => c.Category).WithMany(g => g.Goods).
        //        Map(t => t.MapKey("ID"));

        //    modelBuilder.Entity<Comment>().HasOptional(c => c.Good).WithMany(g => g.Comments).
        //        Map(t => t.MapKey("ID"));
        //}

        public ShopContext():base("ShopConString")
        {
            //Database.SetInitializer<ShopContext>(new ShopDbInitializer());
            //Database.Initialize(true);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new ShopDbInitializer());
        }

    }
}