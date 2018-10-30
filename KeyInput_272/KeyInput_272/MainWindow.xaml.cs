using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace KeyInput_272 {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();      //txt은 한글 입력을 막자
      InputMethod.SetIsInputMethodEnabled(this.txt1, false);
    }

    // 한글의 입력만 막고 ESC 키를 누르면 프로그램 종료
    private void txt1_KeyDown(object sender, KeyEventArgs e) {
      Key inputKey = e.Key.Equals(Key.ImeProcessed) ? e.ImeProcessedKey : e.Key;
      if (inputKey == Key.Escape) {
        Close();
      }
    }

    // 숫자만 입력 가능하도록
    private void txt2_PreviewTextInput(object sender, TextCompositionEventArgs e) {

      // 또는 아래처럼 IsDigit 함수를 사용해도 된다.
      if (!char.IsDigit(e.Text, e.Text.Length - 1)) {
        e.Handled = true;
      }
    }

    // Ascii코드 입력인 경우 KeyDown/KeyUp 이벤트에서는 체크안됨
    // PreviewKeyDown Ascii 코드 키입력을 감지한다.
    // KeyEventArgs의 ImeProcessed를 체크하여 한글키 입력을 알수있다.
    private void txt2_PreviewKeyDown(object sender, KeyEventArgs e) {
      if (e.Key.Equals(Key.ImeProcessed)) {  // 한글이면 키입력 막음
        e.Handled = true;
      }
      if (e.Key.Equals(Key.Escape)) {
        Close();
      }
    }
  }
}