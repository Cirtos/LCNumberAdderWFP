using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ScreeningAdder.Commands
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _action;
        private readonly Predicate<object> _canExecute;

        public DelegateCommand(Action action, Predicate<object> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void InvokeCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

    }
}
