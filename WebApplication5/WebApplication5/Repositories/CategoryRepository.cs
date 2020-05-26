using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.EF;
using WebApplication5.Models;

namespace WebApplication5.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        ShopContext db = null;
        public int Count => db.categories.Count();

        public CategoryRepository(ShopContext context)
        {
            //db = new ShopContext();
            db = context;
        }


        public void Create(Category entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Category obj = db.categories.Find(id);
            Delete(obj);
        }

        public void Delete(Category entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }

        //public void Dispose()
        //{
        //    db.Dispose();
        //}

        public Category GetById(int id)
        {
            return db.categories.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<Category> GetList()
        {
            return db.categories.ToList();
        }

        public IEnumerable<Category> GetList(string include)
        {
            return db.categories.Include(include).ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Category entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Category> Search(string name)
        {
            return db.categories.Where(c => c.CategoryName == name).ToList();
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