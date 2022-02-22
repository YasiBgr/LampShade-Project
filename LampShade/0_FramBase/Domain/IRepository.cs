using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _0_FramBase.Domain
{
   public interface IRepository<TKey,T> where T : class
    {
        T Get(TKey id);
        List<T> Get();
        bool Exist(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Save();
    }
}
