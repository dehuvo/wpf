using System.Windows;
using System.Windows.Media;

namespace LinearGradient {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();

      Title = "Gradiate the Brush";
      LinearGradientBrush brush = new LinearGradientBrush(Colors.Red, Colors.Blue,
                                   new Point(0, 0), new Point(1, 1));
      Background = brush;
    }
  }
}