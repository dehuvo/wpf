using System;
using System.Windows;
using System.Windows.Threading;

namespace clock_169 {
  public class ClockTicker : DependencyObject {
    public static DependencyProperty DateTimeProperty
     = DependencyProperty.Register("DateTime", typeof(DateTime), typeof(ClockTicker));

    public DateTime DateTime {
      set { SetValue(DateTimeProperty, value); }
      get { return (DateTime) GetValue(DateTimeProperty); }
    }

    public ClockTicker() {
      DispatcherTimer timer = new DispatcherTimer() {
        Interval = TimeSpan.FromSeconds(1)
      };
      timer.Tick += TimerOnTick;
      timer.Start();
    }

    void TimerOnTick(object sender, EventArgs args) {
      DateTime = DateTime.Now;
    }
  }
}