using System;
using System.Windows;

namespace MessageBox_264 {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    private void Button2_Click(object sender, RoutedEventArgs e) {
      MessageBoxResult result = MessageBox.Show("YES/NO를 선택하세요. ",
                      "2버튼 메시지 박스 테스트", MessageBoxButton.YesNo);
      if (result == MessageBoxResult.Yes) {
        tb.Text = "2버튼 YES 클릭";
      } else {
        tb.Text = "2버튼 NO 클릭";
      }
    }

    private void Button3_Click(object sender, RoutedEventArgs e) {
      MessageBoxResult result = MessageBox.Show("메시지",
                  "타이틀(Question 메시지박스, YesNoCancel)",
                      MessageBoxButton.YesNoCancel,
                      MessageBoxImage.Question);
      if (result == MessageBoxResult.Yes) {
        tb.Text = "3버튼 YES 클릭";
      } else if (result == MessageBoxResult.No) {
        tb.Text = "3버튼 NO 클릭";
      } else if (result == MessageBoxResult.Cancel) {
        tb.Text = "3버튼 CANCEL 클릭";
      }
    }
  }
}