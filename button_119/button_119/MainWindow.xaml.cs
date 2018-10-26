using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace button_119 {
  public partial class MainWindow : Window {
    Run runButton1;
    Run runButton2;

    public MainWindow() {
      InitializeComponent();
      Title = "ButtonTest1";

      Button btn = new Button();
      btn.HorizontalAlignment = HorizontalAlignment.Center;
      btn.VerticalAlignment = VerticalAlignment.Center;
      btn.MouseEnter += ButtonOnMouseEnter;
      btn.MouseLeave += ButtonOnMouseLeave;
      Content = btn;

      // Create the TextBlock and set as button content.
      TextBlock txtblk = new TextBlock();
      txtblk.FontSize = 24;
      txtblk.TextAlignment = TextAlignment.Center;
      btn.Content = txtblk;

      // 서식화된 텍스트 출력
      txtblk.Inlines.Add(new Italic(new Run("Click")));
      txtblk.Inlines.Add(" the ");
      txtblk.Inlines.Add(runButton1 = new Run("button"));
      txtblk.Inlines.Add(new LineBreak());
      txtblk.Inlines.Add("to launch the ");
      txtblk.Inlines.Add(new Bold(runButton2 = new Run("rocket")));
    }

    void ButtonOnMouseEnter(object sender, MouseEventArgs args) {
      runButton1.Foreground = Brushes.Red;
      runButton2.Foreground = Brushes.Blue;
    }

    void ButtonOnMouseLeave(object sender, MouseEventArgs args) {
      runButton1.Foreground = SystemColors.ControlTextBrush;
      runButton2.Foreground = SystemColors.ControlTextBrush;
    }
  }
}