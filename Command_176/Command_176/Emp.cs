namespace Command_176 {
  class Emp {
    public string Ename { get; set; }
    public string Job { get; set; }
    public string Detail {
      get {
        return "[" + Ename + ", " + Job + "]";
      }
    }
  }
}