using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BE;
using BL;

namespace PL
{
    public partial class ViewModel : BindableObject
    {
        public static BL_IMP IBL = new BL_IMP();

        private User _selectedUser;

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged(() => Name);                    
                }
            }
        }

        public  User SelectedUser { get => _selectedUser; set => _selectedUser = value; }
        public ICommand UserEntryCommand { get; private set; }
        public ICommand ManagerEntryCommand { get; private set; }
        public ICommand CreateNewUserCommand { get; private set; }


        public virtual event EventHandler<HarvestPasswordEventArgs> HarvestPassword;
        public StateMachine StateMachine { get; private set; }
      
        public ViewModel()
        {
            StateMachine = new StateMachine();
            UserEntryCommand = StateMachine.CreateCommandWithAction(Triggers.UserEntrySucceeded, UserEntryButton);
            ManagerEntryCommand = StateMachine.CreateCommandWithAction(Triggers.ManagerEntrySucceeded, ManagerEntryButton);
            CreateNewUserCommand = StateMachine.CreateCommand(Triggers.CreateNewUser);           
        }

        private void UserEntryButton()
        {
            try
            {
                var pwargs = new HarvestPasswordEventArgs();
                HarvestPassword(this, pwargs);
                _selectedUser = IBL.ConfirmUser(Name, pwargs.Password);
                StateMachine.Fire(Triggers.UserEntrySucceeded);
            }
            catch (Exception e)
            {
                string str = e.Message;
                //
                StateMachine.Fire(Triggers.UserEntryFailed);
            }
        }

        private void ManagerEntryButton()
        {
            if (!(HarvestPassword == null))
            {
                var pwargs = new HarvestPasswordEventArgs();
                HarvestPassword(this, pwargs);
                if (IBL.ConfirmManager(Name, pwargs.Password))
                    StateMachine.Fire(Triggers.ManagerEntrySucceeded);
                else
                    StateMachine.Fire(Triggers.ManagerEntryFailed);
            }
            else
                throw new ArgumentNullException();
        }

        protected virtual void OnHarvesting(HarvestPasswordEventArgs e)
        {
            EventHandler<HarvestPasswordEventArgs> handler = HarvestPassword;
            if (handler != null)
            {
                handler(this, e);
            }
        }



    }
}
