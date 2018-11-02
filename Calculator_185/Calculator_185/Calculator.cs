using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Calculator {
  public class Calculator : INotifyPropertyChanged {
    protected void OnPropertyChanged(string propertyName) {
      if (PropertyChanged != null) {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
    public event PropertyChangedEventHandler PropertyChanged;

    public string Input {
      internal set {
        if (input != value) {
          input = value;
          OnPropertyChanged("Input");
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
          OnPropertyChanged("Display");
        }
      }
      get { return display; }
    }
    private string   input = "";
    private string display = "";

    public bool isNumber() {
      return input != "" && input != "." && input != "-" && input != "-."; 
    }
    public double Number { get { return double.Parse(input);} }

    public string  Op  { get; set; }  // Opertaor
    public double? Op1 { get; set; }  // Operand 1

    public Calculator() {
      Append    = new Append(this);
      Backspace = new Backspace(this);
      Clear     = new Clear(this);
      Operator  = new Operator(this);
      Calculate = new Calculate(this);
    }
    public ICommand Append    { protected set; get; }
    public ICommand Backspace { protected set; get; }
    public ICommand Clear     { protected set; get; }
    public ICommand Operator  { protected set; get; }
    public ICommand Calculate { protected set; get; }
  }

  class Append : ICommand {
    public event EventHandler CanExecuteChanged {
      add    { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter) {
      return c.Input.IndexOf('.') < 0 || (string) parameter != ".";
    }

    public void Execute(object parameter) {
      c.Input += parameter;
    }

    public Append(Calculator c) {
      this.c = c;
    }
    private Calculator c;
  }

  class Backspace : ICommand {
    public event EventHandler CanExecuteChanged {
      add    { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

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

    public Backspace(Calculator c) {
      this.c = c;
    }
    private Calculator c;
  }

  class Clear : ICommand {
    public event EventHandler CanExecuteChanged {
      add    { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

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
  }

  class Operator : ICommand {
    public event EventHandler CanExecuteChanged {
      add    { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter) {
      return c.Input == "" && (string) parameter == "-" ||
             c.Op1 == null && c.isNumber();
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
  }

  class Calculate : ICommand {
    public event EventHandler CanExecuteChanged {
      add    { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter) {
      return c.Op1 != null && c.isNumber() && (c.Op != "/" || c.Number != 0);
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

    public Calculate(Calculator c) {
      this.c = c;
    }
    private Calculator c;
  }
}