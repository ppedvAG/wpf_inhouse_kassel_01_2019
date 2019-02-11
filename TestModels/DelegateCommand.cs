using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TestModels
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        //Für Kompatibilität zu anderen Frameworks
        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        Action<object> _executeMethod;
        Func<object, bool> _canExecuteMethod;

        public DelegateCommand(Action<object> executeMethod, Func<object, bool> canExecuteMethod = null)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteMethod != null)
            {
                return _canExecuteMethod(parameter);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            _executeMethod?.Invoke(parameter);
        }
    }
}
