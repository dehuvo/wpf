using System;
using System.Windows;

namespace Mvvm_317 {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e) {
      Environment.Exit(0);
      //System.Diagnostics.Process.GetCurrentProcess().Kill();
      //this.Close();
    }
  }
}