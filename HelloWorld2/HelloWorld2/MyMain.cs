using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HelloWorld2 {
  class MyMain {
    [STAThread]
    public static void Main() {
      Window mainWindow = new Window();
      mainWindow.Title = "WPF Sample(Main)";
      mainWindow.MouseDown += WinMouseDown;
      // mainWindow.Show();

      for (int i = 0; i < 2; i++) {
        Window win = new Window();
        win.Title = "Extra Window No." + (i + 1);
        win.Show();
      }

      Application app = new Application();
      app.Run(mainWindow);
    }

    static void WinMouseDown(object sender, MouseEventArgs e) {
      Window win = new Window();
      win.Title = "Modal DialogBox";
      win.Width = 400;
      win.Height = 200;

      Button b = new Button();
      b.Content = "Click Me!";
      b.Click += Button_Click;

      win.Content = b;
      win.ShowDialog();
    }

    static void Button_Click(object sender, EventArgs e) {
      MessageBox.Show("Button Click!", sender.ToString());
    }
  }
}