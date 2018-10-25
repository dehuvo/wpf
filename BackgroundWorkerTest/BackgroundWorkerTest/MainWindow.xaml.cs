using System;
using System.ComponentModel;
using System.Windows;
using System.Threading;
using System.Windows.Threading;

namespace BackgroundWorkerTest {
  public partial class MainWindow : Window {
    private BackgroundWorker worker;   // 백그라운드 워커 선언
    int sum = 0;                       // 짝수의 합을 저장할 인스턴스 변수

    public MainWindow() {
      InitializeComponent();
    }

    protected override void OnInitialized(EventArgs e) {
      base.OnInitialized(e);
      worker = new BackgroundWorker() {    //백그라운드 워커 초기화
        WorkerReportsProgress = true,      // ProgressChanged 이벤트 발생
        WorkerSupportsCancellation = true  // 작업취소 가능
      };
      //백그라운드에서 실행될 콜백 이벤트 생성
      //For the performing operation in the background.
      //해야할 작업을 실행할 메소드 정의
      worker.DoWork += doWork;
      //UI쪽에 진행사항을 보여주기 위해
      //WorkerReportsProgress 속성값이 true 일때만 이벤트 발생
      worker.ProgressChanged += progressChanged;
      //작업이 완료되었을 때 실행할 콜백메소드 정의
      worker.RunWorkerCompleted += runWorkerCompleted;
      MessageBox.Show("Worker 초기화");
    }
    //백그라운드 워커가 실행하는 작업
    //DoWork 이벤트 처리 메소드에서 lstNumber.Items.Add(i) 와 같은 코드를
    //직접 실행시키면 "InvalidOperationException" 오류발생
    private void doWork(object sender, DoWorkEventArgs e) {
      int count = (int) e.Argument;
      for (int i = 1; i <= count; i++) {
        if (worker.CancellationPending) {
          e.Cancel = true;
          return;
        }
        Thread.Sleep(100);
        this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart) delegate () {
          if (i % 2 == 0) {
            e.Result = sum += i;
            lstNumber.Items.Add(i);
          }
        });
        worker.ReportProgress(i);
      }
    }
    //작업의 진행률이 바뀔때 발생, ProgressBar에 변경사항을 출력
    //대체로 현재의 진행상태를 보여주는 코드 여기에 작성.
    private void progressChanged(object sender, ProgressChangedEventArgs e) {
      progressBar.Value = e.ProgressPercentage;
    }

    //작업완료
    private void runWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
      if (e.Cancelled) {
        MessageBox.Show("작업 취소...");
      } else if (e.Error == null) {
        tblkSum.Text = ((int) e.Result).ToString();
        MessageBox.Show("작업 완료!!");
      } else {
        MessageBox.Show("에러발생..." + e.Error);
      }
    }
    private void btnStart_Click(object sender, RoutedEventArgs e) {
      int num;
      if (int.TryParse(txtNumber.Text, out num)) {
        progressBar.Maximum = num;
        lstNumber.Items.Clear();
        worker.RunWorkerAsync(num);
      } else {
        MessageBox.Show("숫자를 입력하세요.!");
      }
    }
    private void btnCancel_Click(object sender, RoutedEventArgs e) {
      worker.CancelAsync();
    }
  }
}