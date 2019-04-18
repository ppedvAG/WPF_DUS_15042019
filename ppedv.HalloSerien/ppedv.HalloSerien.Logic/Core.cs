using ppedv.HalloSerien.Model;
using ppedv.HalloSerien.Model.Contracts;
using System;

namespace ppedv.HalloSerien.Logic
{
    public class Core
    {
        public IRepository Repository { get; private set; }

        public Core(IRepository repository) //<-- Dependency Injection
        {
            Repository = repository;
        }

        public Core() : this(new Data.EF.EfRepository())
        { }

        public void CreateDemoData()
        {
            var p1 = new Person() { Name = "Fred Feuerstein" };
            var p2 = new Person() { Name = "Wilma Feuerstein" };
            var p3 = new Person() { Name = "Barney Geröllheimer" };


            var s1 = new Series() { Title = "Game of Drones" };
            var ep1 = new Episode()
            {
                Title = "Auspacken und Aufbauen",
                Length = TimeSpan.FromMinutes(43),
                Release = DateTime.Now.AddYears(-3),
                Season = 1,
                Director = p1
            };
            ep1.Actors.Add(p2);
            ep1.Actors.Add(p3);
            s1.Episodes.Add(ep1);

            var ep2 = new Episode()
            {
                Title = "Aufladen",
                Length = TimeSpan.FromMinutes(33),
                Release = DateTime.Now.AddYears(-3),
                Season = 1,
                Director = p2
            };
            ep2.Actors.Add(p1);
            ep2.Actors.Add(p3);
            s1.Episodes.Add(ep2);


            var ep3 = new Episode()
            {
                Title = "Starten",
                Length = TimeSpan.FromMinutes(86),
                Release = DateTime.Now.AddYears(-3),
                Season = 1,
                Director = p3
            };
            ep3.Actors.Add(p1);
            ep3.Actors.Add(p2);
            s1.Episodes.Add(ep3);

            var ep4 = new Episode()
            {
                Title = "Absturz",
                Length = TimeSpan.FromMinutes(11),
                Release = DateTime.Now.AddYears(-3),
                Season = 1,
                Director = p1
            };
            ep4.Actors.Add(p1);
            s1.Episodes.Add(ep4);

            Repository.Add(s1);
            Repository.SaveAll();
        }

        public int CalcAge(DateTime birthdate)
        {
            // Save today's date.
            var today = DateTime.Today;
            // Calculate the age.
            var age = today.Year - birthdate.Year;
            // Go back to the year the person was born in case of a leap year
            if (birthdate > today.AddYears(-age)) age--;

            return age;
        }
    }
}
