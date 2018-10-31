using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Calculator {
  public class Calculator : INotifyPropertyChanged {
    public ICommand Append    { protected set; get; }
    public ICommand Backspace { protected set; get; }
    public ICommand Clear     { protected set; get; }
    public ICommand Operator  { protected set; get; }
    public ICommand Calculate { protected set; get; }

    public Calculator() {
      Append    = new Append(this);
      Backspace = new Backspace(this);
      Clear     = new Clear(this);
      Operator  = new Operator(this);
      Calculate = new Calculate(this);
    }

    public string  Op  { get; set; }  // Opertaor
    public double? Op1 { get; set; }  // Operand 1

    string inputString = "";
    string displayText = "";

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

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName) {
      if (PropertyChanged != null) {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }

  class Append : ICommand {
    private Calculator c;
    
    public Append(Calculator c) {
      this.c = c;
    }

    public event EventHandler CanExecuteChanged {
      add    { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter) {
      return c.InputString.IndexOf('.') < 0 || (string) parameter != ".";
    }

    public void Execute(object parameter) {
      c.InputString += parameter;
    }
  }

  class Backspace : ICommand {
    private Calculator c;

    public Backspace(Calculator c) {
      this.c = c;
    }

    public event EventHandler CanExecuteChanged {
      add    { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter) {
      return 0 < c.InputString.Length;
    }

    public void Execute(object parameter) {
      int length = c.InputString.Length - 1;
      if (0 < length) {
        c.InputString = c.InputString.Substring(0, length);
      } else {
        c.InputString = c.DisplayText = "";
      }
    }
  }

  class Clear : ICommand {
    private Calculator c;

    public Clear(Calculator c) {
      this.c = c;
    }

    public event EventHandler CanExecuteChanged {
      add    { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter) {
      return 0 < c.InputString.Length;
    }

    public void Execute(object parameter) {
      c.InputString = c.DisplayText = "";
      c.Op1 = null;
    }
  }

  class Operator : ICommand {
    private Calculator c;

    public Operator(Calculator c) {
      this.c = c;
    }

    public event EventHandler CanExecuteChanged {
      add    { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter) {
      double op1;
      return c.InputString == "" && (string) parameter == "-" ||
             c.Op1 == null && double.TryParse(c.InputString, out op1);
    }

    public void Execute(object parameter) {
      if (c.InputString == "") {
        c.InputString = "-";
      } else {
        c.Op1 = double.Parse(c.InputString);
        c.Op = (string) parameter;
        c.InputString = "";
      }
    }
  }

  class Calculate : ICommand {
    private Calculator c;

    public Calculate(Calculator c) {
      this.c = c;
    }

    public event EventHandler CanExecuteChanged {
      add    { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter) {
      double op2;
      return c.Op1 != null && double.TryParse(c.InputString, out op2)
                           && (c.Op != "/" || op2 != 0);
    }

    public void Execute(object parameter) {
      double op2 = double.Parse(c.InputString);
      c.InputString = calculate(c.Op, (double) c.Op1, op2).ToString();
      c.Op1 = null;
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