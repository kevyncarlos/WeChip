using System;
using System.Collections.Generic;
using System.Text;

namespace WeChip.Business.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IList<T> GetAll();
        IList<T> Search(Func<T, bool> filter);
    }
}
