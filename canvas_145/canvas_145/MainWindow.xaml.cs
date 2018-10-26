using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace canvas_145 {
  class MyRectangle {
    public int Width { get; set; }
    public int Height { get; set; }
    public int Left { get; set; }
    public int Top { get; set; }
    public SolidColorBrush Color { get; set; }
  }
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }
    private void WindowOnLoaded(object sender, RoutedEventArgs e) {
      // MyRectangle을 담기위한 ArrayList
      List<MyRectangle> rects = new List<MyRectangle>();
      // MyRectangle을 담는다.
      rects.Add(new MyRectangle() {
        Width = 100,
        Height = 100,
        Left = 0,
        Top = 0,
        Color = Brushes.MediumSpringGreen
      });
      rects.Add(new MyRectangle() {
        Width = 50,
        Height = 50,
        Left = 100,
        Top = 100,
        Color = Brushes.YellowGreen
      });
      rects.Add(new MyRectangle() {
        Width = 25,
        Height = 25,
        Left = 150,
        Top = 150,
        Color = Brushes.PowderBlue
      });
      foreach (MyRectangle rect in rects) {
        // Rectangle 객체생성
        Rectangle r = new Rectangle();
        r.Width = rect.Width;
        r.Height = rect.Height;
        r.Fill = rect.Color;
        // Canvas내 위치를 기본적인 MyRectangle의 위치로 설정
        Canvas.SetLeft(r, rect.Left);
        Canvas.SetTop(r, rect.Top);
        // Canvas에 추가
        canvas1.Children.Add(r);
      }
    }
  }
}