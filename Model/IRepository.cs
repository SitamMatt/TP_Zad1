using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Model
{
    interface IRepository<T, K>
    {
        T Get(K key);
        void Add(T obj);
        void Update(K key, T obj);
        void Delete(T obj);
        IEnumerable<T> GetAll();
    }
}
