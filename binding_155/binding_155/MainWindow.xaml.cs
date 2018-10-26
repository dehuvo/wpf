using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Controls.Primitives;

namespace binding_155 {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();

      label.SetBinding(Label.ContentProperty, new Binding() {
        Source = scrollbar,
        Path = new PropertyPath(ScrollBar.ValueProperty)
      });

      // Binding bind = new Binding();
      // bind.Source = scrollbar;
      // bind.Path = new PropertyPath(ScrollBar.ValueProperty);
      // label.SetBinding(Label.ContentProperty, bind);
    }
  }
}