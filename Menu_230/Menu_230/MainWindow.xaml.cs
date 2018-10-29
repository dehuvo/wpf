using System;
using System.Windows;
using System.Windows.Controls;

namespace Menu_230 {
  public partial class MainWindow : Window {
    public MainWindow() {
      Title = "Peruse the Menu";
      DockPanel dock = new DockPanel();
      Content = dock;

      Menu menu = new Menu();
      dock.Children.Add(menu);
      DockPanel.SetDock(menu, Dock.Top);

      dock.Children.Add(new TextBlock {
        Text = Title,
        FontSize = 32, // 24 points.
        TextAlignment = TextAlignment.Center
      });

      MenuItem itemFile = new MenuItem { Header = "_File" };
      menu.Items.Add(itemFile);

      MenuItem itemNew = new MenuItem { Header = "_New" };
      itemNew.Click += UnimplementedOnClick;
      itemFile.Items.Add(itemNew);

      MenuItem itemOpen = new MenuItem { Header = "_Open" };
      itemOpen.Click += UnimplementedOnClick;
      itemFile.Items.Add(itemOpen);

      MenuItem itemSave = new MenuItem { Header = "_Save" };
      itemSave.Click += UnimplementedOnClick;
      itemFile.Items.Add(itemSave);

      itemFile.Items.Add(new Separator());

      MenuItem itemExit = new MenuItem { Header = "E_xit" };
      itemExit.Click += ExitOnClick;
      itemFile.Items.Add(itemExit);

      MenuItem itemWindow = new MenuItem { Header = "_Window" };
      menu.Items.Add(itemWindow);

      MenuItem itemTaskbar = new MenuItem {
        Header = "_Show in Taskbar",
        IsCheckable = true,
        IsChecked = ShowInTaskbar
      };
      itemTaskbar.Click += TaskbarOnClick;
      itemWindow.Items.Add(itemTaskbar);

      MenuItem itemSize = new MenuItem {
        Header = "Size to _Content",
        IsCheckable = true,
        IsChecked = SizeToContent == SizeToContent.WidthAndHeight
      };
      itemSize.Checked += SizeOnCheck;
      itemSize.Unchecked += SizeOnCheck;
      itemWindow.Items.Add(itemSize);

      MenuItem itemResize = new MenuItem {
        Header = "_Resizable",
        IsCheckable = true,
        IsChecked = ResizeMode == ResizeMode.CanResize
      };
      itemResize.Click += ResizeOnClick;
      itemWindow.Items.Add(itemResize);

      MenuItem itemTopmost = new MenuItem {
        Header = "_Topmost",
        IsCheckable = true,
        IsChecked = Topmost
      };
      itemTopmost.Checked += TopmostOnCheck;
      itemTopmost.Unchecked += TopmostOnCheck;
      itemWindow.Items.Add(itemTopmost);
    }

    void UnimplementedOnClick(object sender, RoutedEventArgs args) {
      MenuItem item = sender as MenuItem;
      string s = item.Header.ToString().Replace("_", "");
      MessageBox.Show("The " + s + " option has not yet been implemented", Title);
    }

    void ExitOnClick(object sender, RoutedEventArgs args) {
      Close();
    }

    void TaskbarOnClick(object sender, RoutedEventArgs args) {
      ShowInTaskbar = (sender as MenuItem).IsChecked;
    }

    void SizeOnCheck(object sender, RoutedEventArgs args) {
      SizeToContent = (sender as MenuItem).IsChecked ?
                        SizeToContent.WidthAndHeight :
                        SizeToContent.Manual;
    }

    void ResizeOnClick(object sender, RoutedEventArgs args) {
      MenuItem item = sender as MenuItem;
      ResizeMode = item.IsChecked ? ResizeMode.CanResize :
                                    ResizeMode.NoResize;
    }

    void TopmostOnCheck(object sender, RoutedEventArgs args) {
      Topmost = (sender as MenuItem).IsChecked;
    }
  }
}