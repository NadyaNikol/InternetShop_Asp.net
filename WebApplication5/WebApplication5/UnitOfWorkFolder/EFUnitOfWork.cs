using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.EF;
using WebApplication5.Models;
using WebApplication5.Repositories;



namespace WebApplication5.UnitOfWorkFolder
{
    public class EFUnitOfWork : IUnitOfWork
    {
        IRepository<Category> categories;
        IRepository<Good> goods;
        private ShopContext context = new ShopContext();

        public IRepository<Category> Categories
        {
            get
            {
                if (categories == null)
                    categories = new CategoryRepository(context);
                return categories;
            }
        }

        public IRepository<Good> Goods
        {
            get
            {
                if (goods == null)
                    goods = new GoodRepository(context);
                return goods;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты).
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~GoodRepository()
        // {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}