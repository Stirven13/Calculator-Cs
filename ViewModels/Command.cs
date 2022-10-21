using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ViewModels
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute();
        }

        private Func<bool> canExecute;

        private Action execute;
        private Command pressEqual;

        public Command(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public Command(Command pressEqual)
        {
            this.pressEqual = pressEqual;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(null)) execute.Invoke();
        }

        public void RaiseCanExecuteChanged() 
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    public class Command<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute((T)parameter);
        }

        private Func<T, bool> canExecute;

        private Action<T> execute;

        private IErrorHandler errorHandler;

        public Command(Action<T> execute, Func<T, bool> canExecute = null, IErrorHandler errorHandler = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
            this.errorHandler = errorHandler;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(null) && parameter != null) 
            {
                try
                {
                    execute.Invoke((T)parameter);
                }
                catch (Exception exception)
                {
                    if (errorHandler != null) errorHandler.ErrorHandle(exception);
                    else throw;
                }
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
