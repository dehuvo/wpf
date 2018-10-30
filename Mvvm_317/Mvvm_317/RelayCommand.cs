using System;
using System.Windows.Input;

namespace Mvvm_317.Helpers {
  class RelayCommand : ICommand {
    #region Fields
    readonly Action<object> _execute;
    readonly Predicate<object> _canExecute;
    #endregion
    
    #region 생성자
    public RelayCommand(Action<object> execute) : this(execute, null) {
    }

    public RelayCommand(Action<object> execute, Predicate<object> canExecute) {
      _execute = execute;
      _canExecute = canExecute;
    }
    #endregion

    #region ICommand Member
    public bool CanExecute(object param) {
      return _canExecute == null ? true : _canExecute(param);
    }

    public event EventHandler CanExecuteChanged {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public void Execute(object param) {
      _execute(param);
    }
    #endregion
  }
}