using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.EntityFramework
{
    public interface IRepository<T>
    {

        List<T> GetList();

        List<T> FindList(Expression<Func<T, bool>> filter);

        T Get(Expression<Func<T, bool>> filter);

        int Insert(T entity);

        int Remove(T entity);

        int Update(T entity);

    }
}
