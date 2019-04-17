using ppedv.HalloSerien.Logic;
using ppedv.HalloSerien.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.HalloSerien.UI.WPF.ViewModels
{
    class PeopleViewModel
    {
        public List<Person> PeopleList { get; set; }
        Core core = new Core();

        public PeopleViewModel()
        {
            PeopleList = new List<Person>(core.Repository.Query<Person>());
        }


    }
}
