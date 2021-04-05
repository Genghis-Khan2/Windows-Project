using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for RegularUser_UserControl.xaml
    /// </summary>
    public partial class NewUser_UserControl : UserControl
    {
        VM vm;
        public NewUser_UserControl()
        {
            vm = MainWindow.vm;
            InitializeComponent();
            vm.HarvestPassword += (sender, args) =>
            args.Password = insertPassword.Password;
            DataContext = vm;
        }
        private void start_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            insertName.Text = "";
            insertPassword.Password = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var pwargs = new HarvestPasswordEventArgs();
               
                if (!char.IsLetter(insertName.Text.FirstOrDefault()))
                    MessageBox.Show("Name should start with letter");
                else
                {
                    vm.SelectedUser = vm.IBL.AddUser(new User(insertName.Text, insertPassword.Password));
                    vm.StateMachine.Fire(PL.Triggers.AddNewUserSucceeded);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                vm.StateMachine.Fire((PL.Triggers.AddNewUserFailed));
            }
        }
    }
}
