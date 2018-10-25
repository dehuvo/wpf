using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace CompileXamlWindow {
  public partial class MainWindow : Window {
    public MainWindow() {
      //필드초기화 후 이벤트 핸들러를 가지고 오기 위한 메소드 호출
      InitializeComponent();
      //브러시 이름으로 ListBox를 채움
      foreach (PropertyInfo prop in typeof(Brushes).GetProperties())
        lstbox.Items.Add(prop.Name);
    }
    //버튼 클릭 이벤트 핸들러
    void ButtonOnClick(object sender, RoutedEventArgs args) {
      Button b = sender as Button;
      MessageBox.Show(b.Content.ToString());
    }
    //Ellipse의 Fill 프로퍼티를 바꾸는 ListBox 선택변경 이벤트 핸들러
    void ListBoxOnSelection(object sender, SelectionChangedEventArgs args) {
      ListBox listBox = sender as ListBox;
      string items = listBox.SelectedItem as string;
      PropertyInfo pInfo = typeof(Brushes).GetProperty(items);
      elips.Fill = (Brush) pInfo.GetValue(null, null);
    }
  }
}