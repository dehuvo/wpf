using System.Collections.ObjectModel;
using Mvvm_317.Model;
using Mvvm_317.Helpers;

namespace Mvvm_317.ViewModel {
  class ViewModelMain : ViewModelBase {
    public ObservableCollection<Emp> Emps { get; set; }

    object _SelectedEmp;
    public object SelectedEmp {
      get {
        return _SelectedEmp;
      }
      set {
        _SelectedEmp = value;
        OnPropertyChanged("SelectedEmp");
      }
    }

    string _TextProperty;
    public string TextProperty {
      get {
        return _TextProperty;
      }
      set {
        _TextProperty = value;
        OnPropertyChanged("TextProperty1");
      }
    }

    public RelayCommand AddEmpCommand { get; set; }

    public ViewModelMain() {
      Emps = new ObservableCollection<Emp>() {
        new Emp { Empno = 1, Ename="공길동"},
        new Emp { Empno = 2, Ename="정길동"},
        new Emp { Empno = 3, Ename="박길동"},
        new Emp { Empno = 4, Ename="윤길동"},
        new Emp { Empno = 5, Ename="김길동"},
        new Emp { Empno = 6, Ename="홍길동"},
      };
      TextProperty = "이순신";
      AddEmpCommand = new RelayCommand(AddEmp);
    }

    void AddEmp(object param) {
      if (param == null) {
        param = "NAME";
      }
      Emps.Add(new Emp { Empno = Emps.Count + 1, Ename = param.ToString() });
    }
  }
}