using ppedv.HalloSerien.Logic;
using ppedv.HalloSerien.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ppedv.HalloSerien.UI.WPF.ViewModels
{
    class PeopleViewModel : ViewModelBase
    {
        Core core = new Core();
        private Person selectedPerson;


        public List<Person> PeopleList { get; set; }

        public Person SelectedPerson
        {
            get => selectedPerson;
            set
            {
                selectedPerson = value;
                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(BirthDate));
                IChanged();
            }
        }

        public DateTime BirthDate
        {
            get => selectedPerson == null ? DateTime.MaxValue : selectedPerson.BirthDate;
            set
            {
                if (selectedPerson != null)
                    selectedPerson.BirthDate = value;

                OnPropertyChanged("");//update all

            }
        }

        public int Age
        {
            get
            {
                return SelectedPerson == null ? 0 : core.CalcAge(SelectedPerson.BirthDate);
            }
        }

        public PeopleViewModel()
        {
            PeopleList = new List<Person>(core.Repository.Query<Person>());

        }
    }
}
