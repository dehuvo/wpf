using System;
using System.Windows;
using System.Windows.Controls;

namespace Calendar_239 {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e) {
      var calendar = sender as Calendar;
      if (calendar.SelectedDate.HasValue) {
        DateTime date = calendar.SelectedDate.Value;
        this.Title = date.ToShortDateString();
        MessageBox.Show(date.ToString());
      }
    }
  }
}