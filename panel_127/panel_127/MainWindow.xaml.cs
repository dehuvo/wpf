using System.Windows;
using System.Windows.Controls;

namespace panel_127 {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    private void btnAddMore_Click(object sender, RoutedEventArgs e) {
      Button button = new Button();
      button.Content = "A New Button";
      button.Click += new RoutedEventHandler(button_Click);
      stackPanel.Children.Add(button);
    }

    private void button_Click(object sender, RoutedEventArgs e) {
      MessageBox.Show("New Button Clicked!", "I got pressed");
      Label label = new Label();
      label.Content = "Hi~!";
      stackPanel.Children.Add(label);
    }
  }
}