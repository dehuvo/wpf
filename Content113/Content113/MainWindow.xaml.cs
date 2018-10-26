using System.Windows;
using System.Windows.Input;
using System.Text;

namespace Content113 {
  public partial class MainWindow : Window {
    StringBuilder s;

    public MainWindow() {
      InitializeComponent();
      Title = "사용자 입력을 Window의 Content 속성에 매핑하기";

      Content = s = new StringBuilder("");
    }

    protected override void OnTextInput(TextCompositionEventArgs args) {
      if (args.Text != "\b") {
        s.Append(args.Text);
      } else if (0 < s.Length) {
        s.Remove(s.Length - 1, 1);
      }
      Content = null;
      Content = s;
    }
  }
}