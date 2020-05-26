using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.Models;
using WebApplication5.Repositories;

namespace WebApplication5.UnitOfWorkFolder
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Category> Categories { get; }
        IRepository<Good> Goods { get; }

        void Save();
    }
}
