using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BE;
namespace PL
{
    public class AddCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private T CurrentVM;

        public AddCommand(T VM)
        {
            CurrentVM = VM;
        }

        public bool CanExecute(object parameter)
        {
            if (CurrentVM is ManagerVM)
                return !(CurrentVM as ManagerVM).Products.Contains(parameter as Product);
            return false;
        }

        public void Execute(object parameter)
        {
            if (CurrentVM is ManagerVM)
                (CurrentVM as ManagerVM).Products.Add(parameter as Product);
        }
    }
}
