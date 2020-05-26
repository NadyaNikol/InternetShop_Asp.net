using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.EF;
using WebApplication5.Models;
using WebApplication5.Repositories;
using WebApplication5.UnitOfWorkFolder;

namespace WebApplication5.Utils
{
    public class AutofacRegistraion
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //builder.Register( ctor =>new CustomRepository<QuestRoom>
            //(QuestRoomsSeed.GetSeed())).As<IRepository<QuestRoom>>();

            builder.RegisterType<GoodRepository>()
                .As<IRepository<Good>>()
                .WithParameter("context", new ShopContext());

            builder
                .RegisterType<CategoryRepository>()
                .As<IRepository<Category>>()
                .WithParameter("context", new ShopContext());

            builder
                .RegisterType<EFUnitOfWork>().As<IUnitOfWork>();


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}