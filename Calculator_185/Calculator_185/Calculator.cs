using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Calculator {
  public class Calculator : INotifyPropertyChanged {
    public string Input {
      internal set {
        if (input != value) {
          input = value;
          if (value != "") {
            Display = value;
          }
        }
      }
      get { return input; }
    }
    public string Display {
      internal set {
        if (display != value) {
          display = value;
          notifyPropertyChanged("Display");
        }
      }
      get { return display; }
    }
    private string input   = "";
    private string display = "";

    public bool IsNumber() {
      return input != "" && input != "." && input != "-" && input != "-."; 
    }
    public double Number { get { return double.Parse(input); } }

    public string  Op  { get; set; }  // Opertaor
    public double? Op1 { get; set; }  // Operand 1

    public Calculator() {
      Back     = new Back(this);
      Clear    = new Clear(this);
      Digit    = new Digit(this);
      Operator = new Operator(this);
      Equal    = new Equal(this);
    }
    public ICommand Back     { private set; get; }
    public ICommand Clear    { private set; get; }
    public ICommand Digit    { private set; get; }
    public ICommand Operator { private set; get; }
    public ICommand Equal    { private set; get; }

    private void notifyPropertyChanged(string propertyName) {
      if (PropertyChanged != null) {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
    public event PropertyChangedEventHandler PropertyChanged;
  }

  class Back : ICommand {
    public bool CanExecute(object parameter) {
      return c.Input != "";
    }

    public void Execute(object parameter) {
      int length = c.Input.Length - 1;
      if (0 < length) {
        c.Input = c.Input.Substring(0, length);
      } else {
        c.Input = c.Display = "";
      }
    }

    public Back(Calculator c) {
      this.c = c;
    }
    private Calculator c;

    public event EventHandler CanExecuteChanged {
      add    { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }
  }

  class Clear : ICommand {
    public bool CanExecute(object parameter) {
      return c.Display != "";
    }

    public void Execute(object parameter) {
      c.Input = c.Display = "";
      c.Op1 = null;
    }

    public Clear(Calculator c) {
      this.c = c;
    }
    private Calculator c;

    public event EventHandler CanExecuteChanged {
      add    { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }
  }

  class Digit : ICommand {
    public bool CanExecute(object parameter) {
      return c.Input.IndexOf('.') < 0 || (string) parameter != ".";
    }

    public void Execute(object parameter) {
      c.Input += parameter;
    }

    public Digit(Calculator c) {
      this.c = c;
    }
    private Calculator c;

    public event EventHandler CanExecuteChanged {
      add    { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }
  }

  class Operator : ICommand {
    public bool CanExecute(object parameter) {
      return c.Input == "" && (string) parameter == "-" ||
             c.Op1 == null && c.IsNumber();
    }

    public void Execute(object parameter) {
      if (c.Input == "") {
        c.Input = (string) parameter;
      } else {
        c.Op    = (string) parameter;
        c.Op1   = c.Number;
        c.Input = "";
      }
    }

    public Operator(Calculator c) {
      this.c = c;
    }
    private Calculator c;

    public event EventHandler CanExecuteChanged {
      add    { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }
  }

  class Equal : ICommand {
    public bool CanExecute(object parameter) {
      return c.Op1 != null && c.IsNumber() && (c.Number != 0 || c.Op != "/");
    }

    public void Execute(object parameter) {
      c.Input = calculate(c.Op, (double) c.Op1, c.Number).ToString();
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

    public Equal(Calculator c) {
      this.c = c;
    }
    private Calculator c;

    public event EventHandler CanExecuteChanged {
      add    { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }
  }
}