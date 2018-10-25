using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4 {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
    }

    private void btnModal_Click(object sender, EventArgs e) {
      Form f = new Form();
      f.Text = "Model Windows";
      f.Width = 200;
      f.Height = 100;
      f.BackColor = Color.Blue;
      //모달창으로 윈도우를 연다.
      f.ShowDialog();
    }

    private void btnModeless_Click(object sender, EventArgs e) {
      Form f = new Form();
      f.Text = "Modeless Windows";
      f.Width = 200;
      f.Height = 100;
      f.BackColor = Color.Black;
      //모달창이 아닌 윈도우를 연다.
      f.Show();
    }

    private void btnMessage_Click(object sender, EventArgs e) {
      MessageBox.Show("오라클자바커뮤니티", "메시지박스", MessageBoxButtons.OK,
 MessageBoxIcon.Exclamation); //경고창
    }
  }
}
