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
        private bool showDialog;
        private string dlgText;

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

        public ICommand DeleteCommand { get; set; }

        public string DlgText
        {
            get => dlgText;
            set
            {
                dlgText = value;
                IChanged();
            }
        }
        public bool ShowDialog
        {
            get => showDialog;
            set
            {
                showDialog = value;
                IChanged();
            }
        }
        public ICommand UserConfirmedCommand { get; set; }
        public ICommand UserDeniedCommand { get; set; }



        public PeopleViewModel()
        {
            PeopleList = new ObservableCollection<Person>(core.Repository.Query<Person>());
            SaveCommandOldSchool = new SaveCommand(core);

            SaveCommand = new RelayCommand(o => core.Repository.SaveAll());

            NewCommand = new RelayCommand(UserWantsToAddNewPerson);

            DeleteCommand = new RelayCommand(UserWantsToDeleteSelectedPerson);

            UserConfirmedCommand = new RelayCommand(DeleteSelectedPerson);
            UserDeniedCommand = new RelayCommand(x => ShowDialog = false);
        }

        private void UserWantsToDeleteSelectedPerson(object obj)
        {
            if (SelectedPerson != null)
            {
                DlgText = $"Soll der Mensch {SelectedPerson.Name} wirlich gelöscht werden";
                ShowDialog = true;
            }
        }

        private void DeleteSelectedPerson(object obj)
        {
            ShowDialog = false;

            if (SelectedPerson != null)
            {
                core.Repository.Delete(selectedPerson);
                PeopleList.Remove(selectedPerson);
            }
        }

        private void UserWantsToAddNewPerson(object obj)
        {
            var p = new Person() { Name = "NEU", BirthDate = DateTime.Now };
            core.Repository.Add(p);
            PeopleList.Add(p);
        }
    }
}
