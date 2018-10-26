using System.Windows;
using System.Windows.Input;

namespace EventRouting {
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

    private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e) {
      MessageBox.Show("PreviewMouseDown Window\n");
    }

    private void Button_Click(object sender, RoutedEventArgs e) {
      MessageBox.Show("Button is Clicked");
    }

    private void StackPanel_Click(object sender, RoutedEventArgs e) {
      MessageBox.Show("Click event is bubbled to Stack Panel");
      // e.Handled = true;
    }

    private void Window_Click(object sender, RoutedEventArgs e) {
      MessageBox.Show("Click event is bubbled to Window");
    }
  }
}