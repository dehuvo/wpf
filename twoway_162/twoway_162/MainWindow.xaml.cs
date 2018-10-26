using System;
using System.Windows;

namespace twoway_162 {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    private void OnClicked(object sender, RoutedEventArgs args) {
      Emp e = Grid1.DataContext as Emp;
      Console.WriteLine(e.Ename);
      Console.WriteLine(e.City);
    }
  }
}