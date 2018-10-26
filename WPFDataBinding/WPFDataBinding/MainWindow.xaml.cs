using System.Windows;

namespace WPFDataBinding {
  public partial class MainWindow : Window {
    Person person = new Person { Name = "Salman", Age = 26 };

    public MainWindow() {
      InitializeComponent();
      DataContext = person;
    }

    private void Button_Click(object sender, RoutedEventArgs e) {
      MessageBox.Show(person.Name + " is " + person.Age);
    }
  }

  public class Person {
    public string Name { get; set; }

    private double ageValue;
    public double Age {
      get { return ageValue; }
      set {
        if (value != ageValue) {
          ageValue = value;
        }
      }
    }
  }
}