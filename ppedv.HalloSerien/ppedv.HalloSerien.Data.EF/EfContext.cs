using ppedv.HalloSerien.Model;
using System.Data.Entity;

namespace ppedv.HalloSerien.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Series> Series { get; set; }

        public EfContext(string conString) : base(conString)
        { }

      // //Express
      // public EfContext() : this("Server=.\\SQLEXRESS;Database=HalloSerien_dev;Trusted_Connection=true")
      // { }
      //
      // //localdb
      // public EfContext() : this("Server=(localdb)\\mssqllocaldb;Database=HalloSerien_dev;Trusted_Connection=true")
      // { }
        //VOLL
        public EfContext() : this("Server=.;Database=HalloSerien_dev;Trusted_Connection=true")
        { }
    }
}
