using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace RadialGradient {
  public partial class MainWindow : Window {
    RadialGradientBrush brush;
    DispatcherTimer timer;

    public MainWindow() {
      InitializeComponent();

      brush = new RadialGradientBrush(Colors.White, Colors.Blue);
      brush.Center = brush.GradientOrigin = new Point(0.5, 0.5);
      brush.RadiusX = brush.RadiusY = 0.10;
      brush.SpreadMethod = GradientSpreadMethod.Repeat;

      Title = "Rotate the Gradient Origin";
      WindowStartupLocation = WindowStartupLocation.CenterScreen;
      Width = Height = 384; // ie, 4 inches
      Background = brush;

      timer = new DispatcherTimer();
      timer.Interval = TimeSpan.FromMilliseconds(100);
      timer.Tick += TimerOnTick;
      timer.Start();
    }

    void TimerOnTick(object sender, EventArgs args) {
      double angle = 0;
      brush.GradientOrigin = new Point(0.5 + 0.05 * Math.Cos(angle),
                                       0.5 + 0.05 * Math.Sin(angle));
      angle += Math.PI / 6;
    }

    protected override void OnMouseDown(MouseButtonEventArgs args) {
      timer.Stop();
    }
  }
}