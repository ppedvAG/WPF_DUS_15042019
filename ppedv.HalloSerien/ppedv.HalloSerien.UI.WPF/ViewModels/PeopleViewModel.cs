using ppedv.HalloSerien.Logic;
using ppedv.HalloSerien.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ppedv.HalloSerien.UI.WPF.ViewModels
{
    class PeopleViewModel : ViewModelBase
    {
        Core core = new Core();
        private Person selectedPerson;


        public ObservableCollection<Person> PeopleList { get; set; }

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

        public SaveCommand SaveCommandOldSchool { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand NewCommand { get; set; }

        public PeopleViewModel()
        {
            PeopleList = new ObservableCollection<Person>(core.Repository.Query<Person>());
            SaveCommandOldSchool = new SaveCommand(core);

            SaveCommand = new RelayCommand(o => core.Repository.SaveAll());

            NewCommand = new RelayCommand(UserWantsToAddNewPerson);
        }

        private void UserWantsToAddNewPerson(object obj)
        {
            var p = new Person() { Name = "NEU", BirthDate = DateTime.Now };
            core.Repository.Add(p);
            PeopleList.Add(p);

        }
    }
}
