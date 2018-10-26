using System.Windows;

namespace Tunneling {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    private void Button_PreviewMouseDown(object sender, RoutedEventArgs e) {
      MessageBox.Show("PreviewMouseDown Button\n");
    }

    private void StackPanel_PreviewMouseDown(object sender, RoutedEventArgs e) {
      MessageBox.Show("PreviewMouseDown StackPanel\n");
    }

    private void Window_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
      MessageBox.Show("PreviewMouseDown Window\n");
    }
  }
}