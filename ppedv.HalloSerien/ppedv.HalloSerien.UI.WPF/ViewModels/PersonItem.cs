using ppedv.HalloSerien.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.HalloSerien.UI.WPF.ViewModels
{
    class PersonItem : ViewModelBase
    {
        private Person person;

        public Person Person
        {
            get => person;
            set
            {
                person = value;
                IChanged();
            }
        }


        public string Name
        {
            get { return person.Name; }
            set
            {
                person.Name = value;
                IChanged();
            }
        }

        public DateTime BirthDate
        {
            get { return person.BirthDate; }
            set
            {
                person.BirthDate = value;
                IChanged();
            }
        }


        public PersonItem(Person person)
        {
            Person = person;
        }
    }
}
