using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PL
{
    public class RegularUserVM 
    {
        public static ViewModel viewModel;

        public ICommand DisconnectCommand { get; private set; }
       
        public RegularUserVM(ViewModel _viewModel)
        {
            viewModel = _viewModel;
            DisconnectCommand = viewModel.StateMachine.CreateCommand(Triggers.Disconnect);
        }
    }
}
