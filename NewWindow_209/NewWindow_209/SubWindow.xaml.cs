using System;
using System.Windows;

namespace NewWindow_209 {
  public partial class SubWindow : Window {
    // 메인 윈도우의 하단 ListBox를 Refresh하기 위한 델리게이트
    // 메인 윈도우에서 직무추가 버튼을 클릭할 때 이벤트를 할당해준다.
    public Delegate UpdateActor;

    public SubWindow() {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e) {
      if (rdoInner.IsChecked == true || rdoOutside.IsChecked == true) {
        DutyType dutyType = rdoInner.IsChecked == true ? DutyType.Inner : DutyType.Outside;
        MainWindow.duties.Add(new Duty(txtDutyName.Text, dutyType));
        UpdateActor.DynamicInvoke(dutyType);
        MessageBox.Show("저장OK!", "저장확인");
        this.Close();
      } else {
        MessageBox.Show("내근 또는 외근을 선택하세요.", "항목선택");
      }
    }
  }
}