using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.HalloSerien.Model;

namespace ppedv.HalloSerien.Data.EF.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void EfContext_can_create_database()
        {
            using (var con = new EfContext())
            {
                if (con.Database.Exists())
                    con.Database.Delete();

                con.Database.Create();
                Assert.IsTrue(con.Database.Exists());
            }
        }

        [TestMethod]
        public void EfContext_can_add_Episode()
        {
            var ep = new Episode()
            {
                Season = 7,
                Title = $"Testfolge_{Guid.NewGuid()}",
                Length = TimeSpan.FromMinutes(111)
            };


            using (var con = new EfContext())
            {
                con.Episodes.Add(ep);
                int result = con.SaveChanges();

                Assert.AreEqual(1, result);
            }

            using (var con = new EfContext())
            {
                var loaded = con.Episodes.Find(ep.Id);
                Assert.AreEqual(ep.Title, loaded.Title);
            }
        }
    }
}
