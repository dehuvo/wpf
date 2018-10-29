using System.Windows;

namespace Homework3 {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    private void MyButton_Click(object sender, RoutedEventArgs e) {
      CarDependencyProperty dpSample = TryFindResource("CarDependency") as CarDependencyProperty;
      MessageBox.Show(dpSample.MyCar);
    }
  }

  public class CarDependencyProperty : DependencyObject {
    public static readonly DependencyProperty CarDependency = DependencyProperty.Register("MyProperty", typeof(string), typeof(CarDependencyProperty));

    public string MyCar {
      get {
        return (string) GetValue(CarDependency);
      }
      set {
        SetValue(CarDependency, value);
      }
    }
  }
}