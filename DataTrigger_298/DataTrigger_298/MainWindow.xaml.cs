using System.Windows;

namespace DataTrigger_298 {
  public class DataObject {
    public int TheValue { get; set; }
  }

  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
      DataContext = new DataObject();
    }
  }
}