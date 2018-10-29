using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace NewWindow_209 {
  public partial class MainWindow : Window {
    internal static Duties duties = new Duties();

    public MainWindow() {
      InitializeComponent();
    }

    private void OnSelected(object sender, SelectionChangedEventArgs e) {
      if ((sender as ListBox).SelectedItem != null) {
        string dutyType = ((sender as ListBox).SelectedItem as ListBoxItem).Content.ToString();
        DataContext = from duty in duties
                      where duty.DutyType.ToString() == dutyType
                      select duty;
      }
    }

    private void OnSelected2(object sender, SelectionChangedEventArgs e) {
      var duty = (Duty) myListBox2.SelectedItem;
      string value = duty == null ? "No selection" :  duty.ToString();
      MessageBox.Show(duty.DutyName + "::" + duty.DutyType, "선택한 직무");
    }

    private void OpenNewWindow(object sender, RoutedEventArgs e) {
      SubWindow subWindow = new SubWindow();
      RefreshListEvent += new RefreshList(RefreshListBox); //event initialization
      subWindow.UpdateActor = RefreshListEvent; // assigning event to the Delegate
      subWindow.Show();
    }

    public delegate void RefreshList(DutyType dutyType);
    public event RefreshList RefreshListEvent;

    private void RefreshListBox(DutyType dutyType) {
      myListBox1.SelectedItem = null;
      myListBox1.SelectedIndex = dutyType == DutyType.Inner ? 0 : 1;
    }
  }
}