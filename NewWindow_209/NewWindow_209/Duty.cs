using System.Collections.ObjectModel;

namespace NewWindow_209 {
  public enum DutyType {
    Inner,
    Outside
  }

  public class Duty {
    public string DutyName { get; set; }
    public DutyType DutyType { get; set; }

    public Duty(string name, DutyType dutyType) {
      DutyName = name;
      DutyType = dutyType;
    }
  }

  public class Duties : ObservableCollection<Duty> {
    public Duties() {
      Add(new Duty("SALES", DutyType.Outside));
      Add(new Duty("LOGISTICS", DutyType.Outside));
      Add(new Duty("IT", DutyType.Inner));
      Add(new Duty("MARKETING", DutyType.Inner));
      Add(new Duty("HR", DutyType.Inner));
      Add(new Duty("PROPOTION", DutyType.Outside));
    }
  }
}