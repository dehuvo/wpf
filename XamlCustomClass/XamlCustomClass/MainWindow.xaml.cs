using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows;
using SelectColorFromGrid;
using System.Windows.Controls;
using System.Windows.Media;

namespace XamlCustomClass {
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    void ColorGridBoxOnSelectionChanged(object sender, SelectionChangedEventArgs args) {
      ColorGridBox box = args.Source as ColorGridBox;
      Background = (Brush) box.SelectedValue;
    }
  }
}
