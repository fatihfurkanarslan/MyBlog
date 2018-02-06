﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace MyBlog.DataAccess.EntityFramework
{
    public class Repository<T> : IRepository<T>
        where T : class
    {

        private MyBlogDbContext db = new MyBlogDbContext();
        private DbSet<T> setObject;

        public Repository()
        {
            setObject = db.Set<T>();
        }

        public List<T> FindList(Expression<Func<T, bool>> filter)
        {
            return setObject.Where(filter).ToList();           
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return setObject.FirstOrDefault(filter);
        }

        public List<T> GetList()
        {
            return setObject.ToList();
        }


        public int Insert(T entity)
        {
            setObject.Add(entity);
            return db.SaveChanges();
        }

        public int Remove(T entity)
        {
            setObject.Remove(entity);
            return db.SaveChanges();
        }

        public int Update(T entity)
        {
           return db.SaveChanges();
        }

      
    }
}
