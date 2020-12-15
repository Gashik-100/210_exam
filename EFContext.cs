using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210
{
    [DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
    public class EFContext : DbContext
    {
        //public DbSet<> {get; set;}
        public EFContext() : base("server=210; port=3306; user=sa; password=Qw123456")
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            Database.CreateIfNotExists();
        }
      public void Refresh()
        {
            var changedEntries = this.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();
            foreach (var entry in changedEntries)
            {
                entry.Reload();
            }
        }

    }
}
