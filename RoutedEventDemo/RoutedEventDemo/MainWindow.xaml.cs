using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;

namespace RoutedEventDemo {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }
    private void ContextMenu_Click(object sender, RoutedEventArgs e) {
      string str = (e.Source as MenuItem).Header as string;
      Color color = (Color) ColorConverter.ConvertFromString(str);
      txtBlk.Foreground = new SolidColorBrush(color);
    }
    public void TextBlock_Click(object sender, MouseEventArgs e) {
      Point p = e.GetPosition(null);
      string MousePosText = string.Format("X = {0}, Y = {1}", p.X, p.Y);
      if (e.LeftButton == MouseButtonState.Pressed) MessageBox.Show("왼쪽 "
      + MousePosText);
      else if (e.RightButton == MouseButtonState.Pressed)
        MessageBox.Show("오른쪽 " + MousePosText);
      else if (e.MiddleButton == MouseButtonState.Pressed)
        MessageBox.Show("가운데 " + MousePosText);
    }
  }
}