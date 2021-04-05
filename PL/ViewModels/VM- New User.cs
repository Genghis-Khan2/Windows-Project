using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PL
{
    public partial class VM 
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


       

       
        
        private void AddNewUserButton()
        {
            try
            {
                var pwargs = new HarvestPasswordEventArgs();
                HarvestPassword(this, pwargs);
                if (!char.IsLetter(AddName.FirstOrDefault()))
                    MessageBox.Show("Name should start with letter");
                else
                {
                    SelectedUser = IBL.AddUser(new User(AddName, pwargs.Password));
                    StateMachine.Fire(Triggers.AddNewUserSucceeded);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                StateMachine.Fire(Triggers.AddNewUserFailed);
            }


        }



    }
}
