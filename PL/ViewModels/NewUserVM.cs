using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PL
{
    public class NewUserVM :BindableObject
    {
        private string _addName;
        public string AddName
        {
            get
            {
                return _addName;
            }
            set
            {
                if (value != _addName)
                {
                    _addName = value;
                    OnPropertyChanged(() => AddName);
                }
            }
        }

        ViewModel viewModel;
        public ICommand AddNewUserCommand { get; private set; }
        public ICommand NewUserBackCommand { get; private set; }

        public event EventHandler<HarvestPasswordEventArgs> HarvestPassword;
        public NewUserVM(ViewModel _viewModel)
        {
            viewModel = _viewModel;
            AddNewUserCommand = viewModel.StateMachine.CreateCommandWithAction
                (Triggers.AddNewUserSucceeded, AddNewUserButton);
            NewUserBackCommand = viewModel.StateMachine.CreateCommand(Triggers.NewUserBack);
        }
        private void AddNewUserButton()
        {
            try
            {
                var pwargs = new HarvestPasswordEventArgs();
                HarvestPassword(this, pwargs);
                viewModel.SelectedUser = ViewModel.IBL.AddUser(new User(AddName, pwargs.Password));
                viewModel.StateMachine.Fire(Triggers.AddNewUserSucceeded);
            }
            catch (Exception e)
            {
                string str = e.Message;
                //
                viewModel.StateMachine.Fire(Triggers.AddNewUserFailed);
            }


        }



    }
}
