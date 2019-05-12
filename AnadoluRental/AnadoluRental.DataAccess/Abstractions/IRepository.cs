using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnadoluRental.DataAccess.Abstractions
{
    public interface IRepository<T> where T : class
    {
        bool Insert(T entity);
        bool Update(T entity);
        bool DeletedById(int id);
        T SelectedById(int id);
        IList<T> SelectAll();
    }
}
