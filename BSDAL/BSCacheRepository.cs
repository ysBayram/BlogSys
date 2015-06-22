using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace BSDAL
{
    public class BSCacheRepository
    {
        public List<T> Get<T>() where T : class,new()
        {
            Type entityType = typeof(T);
            BSRepository BSRepo = new BSRepository();

            try
            {
                if (HttpContext.Current.Cache[entityType.Name] == null)
                {
                    SqlCacheDependency dep = new SqlCacheDependency("BSDependency", entityType.Name);
                    var tempList = BSRepo.GetAll<T>();
                    HttpContext.Current.Cache.Insert(entityType.Name, tempList, dep, DateTime.Now.AddHours(1), Cache.NoSlidingExpiration);
                }
                return HttpContext.Current.Cache[entityType.Name] as List<T>;
            }
            catch (Exception ex)
            {
                return BSRepo.GetAll<T>();
            }
        }

    }
}
