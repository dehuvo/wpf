using System;
using System.Windows.Input;

namespace Command_176 {
  class RelayCommand : ICommand {
    #region Variables
    Func<object, bool> canExecute;
    Action<object> executeAction;
    #endregion

    #region Construction/Initialization
    public RelayCommand(Action<object> executeAction) : this(executeAction, null) {
    }

    public RelayCommand(Action<object> executeAction, Func<object, bool> canExecute) {
      this.executeAction = executeAction ?? throw new ArgumentNullException("Execute Action was null for ICommanding Operation.");
      this.canExecute = canExecute;
    }
    #endregion

    #region ICommand Member
    public bool CanExecute(object param) {
      if (param?.ToString().Length == 0) return false;
//      bool result = this.canExecute == null ? true : this.canExecute.Invoke(param);
//      return result;
      return this.canExecute == null || this.canExecute.Invoke(param);
    }

    public void Execute(object param) {
      this.executeAction.Invoke(param);
    }

    public event EventHandler CanExecuteChanged {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }
    #endregion
  }
}