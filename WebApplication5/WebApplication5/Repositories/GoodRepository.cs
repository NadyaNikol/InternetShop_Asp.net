using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using WebApplication5.EF;
using WebApplication5.Models;

namespace WebApplication5.Repositories
{
    public class GoodRepository: IRepository<Good> 
    {
        ShopContext db = null;
        public int Count => db.goods.Count();

        public GoodRepository(ShopContext context)
        {
            //db = new ShopContext();
            db = context;
        }


        public void Create(Good entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
          Good obj= db.goods.Find(id);
            Delete(obj);

        }

        public void Delete(Good entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }

        //public void Dispose()
        //{
        //    db.Dispose();
        //}

        public Good GetById(int id)
        {
            //throw new NotImplementedException();
            return db.goods.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<Good> GetList()
        {
            //throw new NotImplementedException();
            return db.goods.ToList();
        }

        public IEnumerable<Good> GetList(string include)
        {
            return db.goods.Include(include).ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Good entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Good> Search(string name)
        {
            return db.goods.Where(n => n.Title.Contains(name)).ToList();
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