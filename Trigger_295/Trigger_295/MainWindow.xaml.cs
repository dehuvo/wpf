using System.Windows;
using System.Windows.Controls;
using System.Threading;

namespace Trigger_295 {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    void ButtonOnClick(object sender, RoutedEventArgs args) {
      Thread.Sleep(1000);
      Button btn = args.Source as Button;
      MessageBox.Show(btn.Content + " has been clicked", Title);
    }
  }
}