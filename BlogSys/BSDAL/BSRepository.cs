using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSDAL
{
    public class BSRepository
    {
        //method level repository 

        IObjectContextAdapter _context;

        public BSRepository()
        {
            _context = BSContextProvider.BSdb;
        }

        public T Insert<T>(T entity) where T : class,new()
        {
            _context.ObjectContext.CreateObjectSet<T>().AddObject(entity);
            _context.ObjectContext.SaveChanges();
            return entity;
        }

        public bool Update<T>()
        {
            _context.ObjectContext.SaveChanges();
            return true;
        }

        public void Delete<T>(T entity) where T:class,new()
        {
            _context.ObjectContext.CreateObjectSet<T>().DeleteObject(entity);
            _context.ObjectContext.SaveChanges();
        }

        public List<T> GetAll<T>(T entity) where T : class,new()
        {
            return _context.ObjectContext.CreateObjectSet<T>().ToList();
        }

    }
}
