using System.Windows;
using System;

namespace WpfApp1 {
  public class DPTest : DependencyObject {
    public static readonly DependencyProperty TestProperty = DependencyProperty.Register(
      "Test",
      typeof(string),
      typeof(DPTest),
      new PropertyMetadata("Dependency Property Initial Value", OnTestPropertyChanged)
    );

    public string Test {
      get {
        Console.WriteLine("Test GetValue");
        return (string) GetValue(TestProperty);
      }
      set {
        Console.WriteLine("Test SetValue");
        SetValue(TestProperty, value);
      }
    }

    private static void OnTestPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
      Console.WriteLine("Property Changed : {0}", e.NewValue);
    }
  }
}