using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2 {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
    }

    private void groupBox2_Enter(object sender, EventArgs e) {

    }

    private void label2_Click(object sender, EventArgs e) {

    }

    private void Form1_Load(object sender, EventArgs e) {
      var font = FontFamily.Families;
      foreach (FontFamily f in font) {
        comFont.Items.Add(f.Name);
      }
    }

    void ChangeFont() {
      
      if (comFont.SelectedIndex < 0) { //선택한 폰트가 없는 경우
        return;
      }
      
      FontStyle fs = FontStyle.Regular; //FontStyle을 초기화
      
      if (chkBold.Checked) {  //굵게가 체크 되었다면
        fs |= FontStyle.Bold; //기존 폰트에 논리합 수행
      }
      
      if (chkItalic.Checked) { //이탤릭체가 체크 되었다면
        fs |= FontStyle.Italic;
      }
      txtMessage.Font = new Font((string) comFont.SelectedItem, 10, fs);
    }
  }
}
