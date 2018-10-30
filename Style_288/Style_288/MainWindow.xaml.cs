using System.Windows;
using System.Windows.Controls;

namespace Style_288 {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    void ButtonOnClick(object sender, RoutedEventArgs args) {
      MessageBox.Show((args.Source as Button).Content + " has been clicked", Title);
    }
  }
}