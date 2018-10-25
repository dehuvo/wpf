using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Text {
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
      new Thread(Update).Start();
    }
    /*
        private void Update() {
          Thread.Sleep(TimeSpan.FromSeconds(5));
          txtName.Text = "홍길동";
        }
    */
    private void Update() {
      Thread.Sleep(TimeSpan.FromSeconds(5));
      this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
            (ThreadStart) delegate() { txtName.Text = "홍길동"; } );
    }
  }
}
