using ppedv.HalloSerien.Logic;
using System;
using System.Windows.Input;

namespace ppedv.HalloSerien.UI.WPF.ViewModels
{
    class SaveCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            core.Repository.SaveAll();
        }

        Core core;

        public SaveCommand(Core core)
        {
            this.core = core;
        }
    }
}
