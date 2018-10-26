using System;
using System.Windows.Threading;
using System.ComponentModel;

namespace clock_169 {
  public class ClockTicker1 : INotifyPropertyChanged {
    public event PropertyChangedEventHandler PropertyChanged;

    public DateTime DateTime {
      get { return DateTime.Now; }
    }

    public ClockTicker1() {
      DispatcherTimer timer = new DispatcherTimer() {
        Interval = TimeSpan.FromSeconds(1)
      };
      timer.Tick += TimerOnTick;
      timer.Start();
    }

    void TimerOnTick(object sender, EventArgs args) {
      if (PropertyChanged != null) {  // 이벤트 가입자가 있으면
        PropertyChanged(this, new PropertyChangedEventArgs("DateTime"));
      }
    }
  }
}