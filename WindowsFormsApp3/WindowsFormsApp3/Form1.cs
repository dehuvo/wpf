using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3 {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
    }

    private void trb1_Scroll(object sender, EventArgs e) {
      trb1.Maximum = 100;
      prb1.Maximum = 100;
      prb1.Value = trb1.Value;
    }

    private void btnStart_Click(object sender, EventArgs e) {
      int count = int.Parse(txtLoopCount.Text);
      prb1.Maximum = count;
      prb1.Step = count / 100;
      for (int i = 0; i <= count; i++) {
        prb1.Value = i;
      }
    }
  }
}
