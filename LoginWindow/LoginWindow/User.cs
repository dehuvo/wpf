using System.ComponentModel;

namespace LoginWindow.Model {
  public class User : INotifyPropertyChanged {
    private string firstname;
    public string FirstName {
      get {
        return firstname;
      }
      set {
        firstname = value;
        RaisePropertyChange("FirstName");
      }
    }

    private string lastname;
    public string LastName {
      get {
        return lastname;
      }
      set {
        lastname = value;
        RaisePropertyChange("LastName");
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void RaisePropertyChange(string propertyname) {
      if (PropertyChanged != null) {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
      }
    }
  }
}