using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Toolbar_243 {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();

      List<string> list = new List<string>();
      list.Add("서울");
      list.Add("대전");
      list.Add("춘천");
      list.Add("제주");
      toolbar.ItemsSource = list;
    }

    public void ButtonClick(object sender, EventArgs args) {
      MessageBox.Show(((Button) sender).Content.ToString());
    }
  }
}