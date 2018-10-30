using System.Collections.ObjectModel;

namespace DataTrigger_302 {
  public class Emp {
    public int Empno { get; set; }
    public string Ename { get; set; }
    public int Deptno { get; set; }

    public Emp(int Empno, string Ename, int Deptno) {
      this.Empno = Empno;
      this.Ename = Ename;
      this.Deptno = Deptno;
    }
  }

  public class Emps : ObservableCollection<Emp> {
    public Emps() {
      Add(new Emp(1001, "SMITH", 10));
      Add(new Emp(1002, "KING", 10));
      Add(new Emp(1003, "ALLEN", 20));
      Add(new Emp(1004, "TIGER", 10));
      Add(new Emp(1005, "SCOTT", 20));
      Add(new Emp(1006, "JHON", 10));
    }
  }
}