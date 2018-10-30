using System;
using System.Collections.Generic;
using System.Windows;

namespace DataGrid_256 {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();

      List<User> users = new List<User>();
      users.Add(new User() {
        Id = 1,
        Name = "홍길동",
        Birthday = new DateTime(1971, 7, 23)
      });
      users.Add(new User() {
        Id = 2,
        Name = "박길동",
        Birthday = new DateTime(1974, 1, 17)
      });
      users.Add(new User() {
        Id = 3,
        Name = "정길동",
        Birthday = new DateTime(1991, 9, 2)
      });
      dgUsers.ItemsSource = users;
    }
  }

  public class User {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
  }
}