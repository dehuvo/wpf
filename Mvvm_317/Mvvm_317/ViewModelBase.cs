using System.ComponentModel;

namespace Mvvm_317.ViewModel {
  class ViewModelBase : INotifyPropertyChanged {
    public event PropertyChangedEventHandler PropertyChanged;
    
    internal void OnPropertyChanged(string pname) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(pname));
    }
  }
}
