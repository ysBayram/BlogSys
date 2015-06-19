using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BSEntities;

namespace BSDAL
{
    public class BSContext : DbContext
    {
        public DbSet<BSUser> BSUser { get; set; }
        public DbSet<BSPost> BSPost { get; set; }
        public DbSet<BSComment> BSComment { get; set; }

        public BSContext()
        {
            Database.SetInitializer(new BSDBInitializer());
        }
    }

    public static class BSContextProvider
    {
        public static BSContext BSdb = new BSContext();
    }

}
