using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Stateless;
using System.Windows;
using System.Windows.Data;
using System.Globalization;

namespace PL
{
   
    public enum States
    {
        Start, User, Manager, NewUser
    }   
    public enum Triggers
    {
        UserEntrySucceeded, UserEntryFailed, ManagerEntrySucceeded,ManagerEntryFailed,
        CreateNewUser, AddNewUserSucceeded, AddNewUserFailed, NewUserBack, Disconnect
    }

    public class StateMachine : Stateless.StateMachine<States, Triggers>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public StateMachine(Action action=null) : base(States.Start)
        {
            Configure(States.Start)
              .Permit(Triggers.CreateNewUser, States.NewUser)
              .Permit(Triggers.ManagerEntrySucceeded, States.Manager)
              .PermitReentry(Triggers.ManagerEntryFailed)
              .Permit(Triggers.UserEntrySucceeded, States.User)
              .PermitReentry(Triggers.UserEntryFailed);

            Configure(States.User)
              .Permit(Triggers.Disconnect, States.Start);

            Configure(States.Manager)
               .Permit(Triggers.Disconnect, States.Start);

            Configure(States.NewUser)
              .Permit(Triggers.NewUserBack, States.Start)
              .Permit(Triggers.AddNewUserSucceeded, States.User)
              .PermitReentry(Triggers.AddNewUserFailed);



            OnTransitioned((t) => { OnPropertyChanged("State"); CommandManager.InvalidateRequerySuggested(); });

            //used to debug commands and UI components
            OnTransitioned((t) => Debug.WriteLine
         ("State Machine transitioned from {0} -> {1} [{2}]", t.Source, t.Destination, t.Trigger));
        }

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
    public static class StateMachineExtensions
    {
        public static ICommand CreateCommand<TState, TTrigger>(this StateMachine<TState, TTrigger> stateMachine,
            TTrigger trigger)
        {
            return new RelayCommand
              (
                () => stateMachine.Fire(trigger),
                () => stateMachine.CanFire(trigger)
              );
        }
        public static ICommand CreateCommandWithAction<TState, TTrigger>(this StateMachine<TState, TTrigger> stateMachine,
            TTrigger trigger,Action action )
        {
            return new RelayCommand
              (
                () => action(),
                () => stateMachine.CanFire(trigger)
              ) ;
        }
    }
    public class StateMachineVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string state = value != null ? value.ToString() : String.Empty;
            string targetState = parameter.ToString();

            return state == targetState ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
