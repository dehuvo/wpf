using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Calculator {
  public class Calculator : INotifyPropertyChanged {
    string inputString = "";
    string displayText = "";
    public event PropertyChangedEventHandler PropertyChanged;

    public Calculator() {
      this.AddCharCommand = new AddCharCommand(this);
      this.DeleteCharCommand = new DeleteCharCommand(this);
      this.ClearCommand = new ClearCommand(this);
      this.OperationCommand = new OperationCommand(this);
      this.CalcCommand = new CalcCommand(this);
    }

    public string InputString {
      internal set {
        if (inputString != value) {
          inputString = value;
          OnPropertyChanged("InputString");
          if (value != "") {
            DisplayText = value;
          }
        }
      }
      get { return inputString; }
    }

    public string DisplayText {
      internal set {
        if (displayText != value) {
          displayText = value;
          OnPropertyChanged("DisplayText");
        }
      }
      get { return displayText; }
    }

    public string Op { get; set; }
    public double? Op1 { get; set; }

    public ICommand AddCharCommand { protected set; get; }
    public ICommand DeleteCharCommand { protected set; get; }
    public ICommand ClearCommand { protected set; get; }
    public ICommand OperationCommand { protected set; get; }
    public ICommand CalcCommand { protected set; get; }

    protected void OnPropertyChanged(string propertyName) {
      if (PropertyChanged != null) {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }

  class AddCharCommand : ICommand {
    private Calculator calculator;
    public event EventHandler CanExecuteChanged;
    
    public AddCharCommand(Calculator calculator) {
      this.calculator = calculator;
    }

    public bool CanExecute(object parameter) {
      return true;
    }

    public void Execute(object parameter) {
      calculator.InputString += parameter;
    }
  }

  class DeleteCharCommand : ICommand {
    private Calculator calculator;

    public DeleteCharCommand(Calculator calculator) {
      this.calculator = calculator;
    }

    public event EventHandler CanExecuteChanged {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter) {
      return calculator.InputString.Length > 0;
    }

    public void Execute(object parameter) {
      calculator.InputString = calculator.InputString.Substring(0,
     calculator.InputString.Length - 1);
    }
  }

  class ClearCommand : ICommand {
    private Calculator calculator;

    public ClearCommand(Calculator calculator) {
      this.calculator = calculator;
    }

    public event EventHandler CanExecuteChanged {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter) {
      return calculator.InputString.Length > 0;
    }

    public void Execute(object parameter) {
      calculator.InputString = calculator.DisplayText = "";
      calculator.Op1 = null;
    }
  }

  class OperationCommand : ICommand {
    private Calculator calculator;

    public OperationCommand(Calculator calculator) {
      this.calculator = calculator;
    }

    public event EventHandler CanExecuteChanged {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter) {
      return calculator.InputString.Length > 0;
    }

    public void Execute(object parameter) {
      calculator.Op = parameter.ToString();
      double op1;
      if (double.TryParse(calculator.InputString, out op1)) {
        calculator.Op1 = op1;
        calculator.InputString = "";
      }
    }
  }

  class CalcCommand : ICommand {
    private Calculator calculator;

    public CalcCommand(Calculator calculator) {
      this.calculator = calculator;
    }

    public event EventHandler CanExecuteChanged {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter) {
      double op2;
      return calculator.Op1 != null && double.TryParse(calculator.InputString, out op2);
    }

    public void Execute(object parameter) {
      double op2 = double.Parse(calculator.InputString);
      calculator.InputString = calculate(calculator.Op, (double) calculator.Op1, op2).ToString();
      calculator.Op1 = null;
    }

    private static double calculate(string op, double op1, double op2) {
      switch (op) {
        case "+": return op1 + op2;
        case "-": return op1 - op2;
        case "*": return op1 * op2;
        case "/": return op1 / op2;
      }
      return 0;
    }
  }
}