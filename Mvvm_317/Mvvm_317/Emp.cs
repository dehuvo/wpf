using System.ComponentModel;

namespace Mvvm_317.Model {
  class Emp : INotifyPropertyChanged {
    int _Empno;
    public int Empno {
      get {
        return _Empno;
      }
      set {
        _Empno = value;
        OnPropertyChanged("Empno");
      }
    }

    string _Ename;
    public string Ename {
      get {
        return _Ename;
      }
      set {
        _Ename = value;
        OnPropertyChanged("Ename");
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    
    void OnPropertyChanged(string pname) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(pname));
    }
  }
}