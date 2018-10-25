using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2 {
  class MyMain {
    [STAThread]
    public static void Main() {
      Application app = new Application();
      app.Run(new MainWindow());
    }
  }
}
