using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Evaluator.ViewModel.Base
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action _action;
        private Func<bool> _canExecuteAction;
        public RelayCommand(Action action, Func<bool> canExecuteAction = null)
        {
            _action = action;
            _canExecuteAction = canExecuteAction;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteAction != null)
            {
                return _canExecuteAction.Invoke();
            }
            return true;
        }

        public void RaiseCanExecute()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
        
        public void Execute(object parameter)
        {
            _action?.Invoke();
        }
    }
}
