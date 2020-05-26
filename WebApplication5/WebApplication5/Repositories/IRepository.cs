using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication5.Repositories
{
   public interface IRepository <TEntity>: IDisposable where TEntity:class
    {
        int Count { get; }

        IEnumerable<TEntity> GetList();
        IEnumerable<TEntity> GetList(string include);
        TEntity GetById(int id);
        IEnumerable<TEntity> Search(string name);


        void Delete(int id);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        void Create(TEntity entity);
        void Save();
    }
}
