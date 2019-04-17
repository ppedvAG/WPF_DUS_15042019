using ppedv.HalloSerien.Logic;
using ppedv.HalloSerien.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.HalloSerien.UI.DevConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** HalloSerien ***");

            var core = new Core();
            if (core.Repository.Query<Series>().Count() == 0)
                core.CreateDemoData();

            foreach (var series in core.Repository.Query<Series>().ToList())
            {
                Console.WriteLine($"{series.Title}");
                foreach (var ep in series.Episodes.OrderBy(x => x.Season))
                {
                    Console.WriteLine($"\t{ep.Title} {ep.Length.TotalMinutes} Minuten von {ep.Director.Name}");
                    Console.WriteLine($"\t\t{string.Join(", ", ep.Actors.Select(x => x.Name))}");
                }
            }

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
