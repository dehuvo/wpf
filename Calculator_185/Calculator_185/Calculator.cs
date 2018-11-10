using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Calculator {
  public class Calculator : INotifyPropertyChanged {
    public string Display {
      private set {
        if (display != value) {
          display = value;
          OnPropertyChanged();
        }
      }
      get { return display; }
    }
    private string Input {
      set {
        if (input != value) {
          input = value;
          if (value != "") {
            Display = value;
          }
        }
      }
      get { return input; }
    }
    private string  display = "";
    private string  input = "";

    private bool IsNumber {
      get {
        return input != "" && input != "." && input != "-" && input != "-.";
      }
    }
    private double Number { get { return double.Parse(input); } }

    private double? Op1;  // Operand 1
    private string  Op;   // Opertaor
 
    private double calculate(double a, double b) {
      switch (Op) {
        case "+": return a + b;
        case "-": return a - b;
        case "*": return a * b;
        case "/": return a / b;
      }
      return 0;
    }

    private void OnPropertyChanged([CallerMemberName] string name = null) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    public event PropertyChangedEventHandler PropertyChanged;

    public Calculator() {
      Back     = new     BackImpl(this);
      Clear    = new    ClearImpl(this);
      Digit    = new    DigitImpl(this);
      Operator = new OperatorImpl(this);
      Equal    = new    EqualImpl(this);
    }
    public ICommand Back     { private set; get; }
    public ICommand Clear    { private set; get; }
    public ICommand Digit    { private set; get; }
    public ICommand Operator { private set; get; }
    public ICommand Equal    { private set; get; }

    private class BackImpl : ICommand {
      public BackImpl(Calculator c) {
        this.c = c;
      }
      private Calculator c;

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

      public event EventHandler CanExecuteChanged {
        add    { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
      }
    }

    private class ClearImpl : ICommand {
      public ClearImpl(Calculator c) {
        this.c = c;
      }
      private Calculator c;

      public bool CanExecute(object parameter) {
        return c.Display != "";
      }

      public void Execute(object parameter) {
        c.Input = c.Display = "";
        c.Op1 = null;
      }

      public event EventHandler CanExecuteChanged {
        add    { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
      }
    }

    private class DigitImpl : ICommand {
      public DigitImpl(Calculator c) {
        this.c = c;
      }
      private Calculator c;

      public bool CanExecute(object parameter) {
        return c.Input.IndexOf('.') < 0 || (string) parameter != ".";
      }

      public void Execute(object parameter) {
        c.Input += parameter;
      }

      public event EventHandler CanExecuteChanged {
        add    { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
      }
    }

    private class OperatorImpl : ICommand {
      public OperatorImpl(Calculator c) {
        this.c = c;
      }
      private Calculator c;

      public bool CanExecute(object parameter) {
        return c.Input == "" && (string) parameter == "-" ||
               c.Op1 == null && c.IsNumber;
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

      public event EventHandler CanExecuteChanged {
        add    { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
      }
    }

    private class EqualImpl : ICommand {
      public EqualImpl(Calculator c) {
        this.c = c;
      }
      private Calculator c;

      public bool CanExecute(object parameter) {
        return c.Op1 != null && c.IsNumber && (c.Number != 0 || c.Op != "/");
      }

      public void Execute(object parameter) {
        c.Input = c.calculate((double) c.Op1, c.Number).ToString();
        c.Op1 = null;
      }

      public event EventHandler CanExecuteChanged {
        add    { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
      }
    }
  }
}