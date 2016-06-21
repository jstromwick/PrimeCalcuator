using System;
using System.Windows.Input;

namespace PrimeCalculatorApp.Commands
{
    internal class Command : ICommand
    {
        private readonly Func<object, bool> _canExecuteAction;
        private readonly Action<object> _excuteAction;

        public Command(Action<object> excuteAction, Func<object, bool> canExecuteAction)
        {
            _excuteAction = excuteAction;
            _canExecuteAction = canExecuteAction;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteAction(parameter);
        }

        public void Execute(object parameter)
        {
            _excuteAction(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}