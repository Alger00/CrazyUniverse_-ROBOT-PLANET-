using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyUniverse__ROBOT_PLANET_.Core.Repositories
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Remove(T item);
        IEnumerable<T> GetAll();
        T? Find(Func<T, bool> predicate);
    }
}
