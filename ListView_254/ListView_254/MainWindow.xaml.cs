using System.Collections.Generic;
using System.Windows;

namespace ListView_254 {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();

      List<User> items = new List<User>();
      items.Add(new User { Name = "홍길동", Age = 42, Mail = "h@a.co.kr" });
      items.Add(new User { Name = "박길동", Age = 39, Mail = "p@a.co.kr" });
      items.Add(new User { Name = "정길동", Age = 7, Mail = "j@a.co.kr" });
      lvUsers.ItemsSource = items;
    }
  }

  public class User {
    public string Name { get; set; }
    public int Age { get; set; }
    public string Mail { get; set; }
  }
}