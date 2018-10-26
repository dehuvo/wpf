using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DependencyPropertyTest {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }
 
    public String MyText {
      get { return (String) GetValue(MyProperty); }
      set { SetValue(MyProperty, value); }
    }
 
    public static readonly DependencyProperty MyProperty = DependencyProperty.Register(
      "MyText", //등록할 의존성 속성 이름
      typeof(String),
      typeof(MainWindow),
      new FrameworkPropertyMetadata(new PropertyChangedCallback(OnMyPropertyChanged))
    );

    private static void OnMyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
      MainWindow win = d as MainWindow;
      win.Background = (SolidColorBrush) new BrushConverter().ConvertFromString(e.NewValue.ToString());
      win.Title = e.OldValue == null ? "제목없음" : e.OldValue.ToString();
      win.textBox1.Text = e.NewValue.ToString();
    }

    private void ContextMenu_Click(object sender, RoutedEventArgs e) {
      MyText = (e.Source as MenuItem).Header as string;
    }
  }
}