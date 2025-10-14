using System;
using System.Collections.Generic;
using System.Data;
using WebApplicationEntities;
using dbConnectionTest;
using MyProjectDataEF;
using System.Data.Entity;

namespace DataAccess
{
    public class DataRepository<T> : IRepository<T> where T : class
    {

        //public T GetById(int id)
        //{
        //    return _dbSet.Find(id);
        //}


        //public void Add(T entity)
        //{
        //    _dbSet.Add(entity);
        //    _context.SaveChanges();
        //}


        //public void Update(T entity)
        //{
        //    _context.Entry(entity).State = EntityState.Modified;
        //    _context.SaveChanges();
        //}

        //public void Delete(int id)
        //{
        //    var entity = _dbSet.Find(id);
        //    if (entity != null)
        //    {
        //        _dbSet.Remove(entity);
        //        _context.SaveChanges();
        //    }
        //}


        //public void Save()
        //{
        //    _context.SaveChanges();
        //}
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }


}
