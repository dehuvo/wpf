using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp5 {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
    }

    private void lv_ColumnClick(object sender, ColumnClickEventArgs e) {
      ListView lv = sender as ListView;
      if (lv.Sorting == SortOrder.Ascending) {
        lv.Sorting = SortOrder.Descending;
      } else {
        lv.Sorting = SortOrder.Ascending;
      }
    }

    private void lv_Click(object sender, EventArgs e) {
      ListView lv = (ListView) sender;
      string name = lv.SelectedItems[0].SubItems[0].Text;
      string year = lv.SelectedItems[0].SubItems[1].Text;
      sb.Text = name + ", " + year;
    }

    private void Form1_Load(object sender, EventArgs e) {
      ColumnHeader name = new ColumnHeader();
      name.Text = "Name";
      name.Width = 150;

      ColumnHeader year = new ColumnHeader();
      year.Text = "Year";

      lv.Columns.AddRange(new ColumnHeader[] { name, year });

      SuspendLayout();

      List<Actress> actresses = new List<Actress>();
      actresses.Add(new Actress("Jessica Alba", 1981));
      actresses.Add(new Actress("Angelina Jolie", 1975));
      actresses.Add(new Actress("Natalie Portman", 1981));
      actresses.Add(new Actress("Rachel Weiss", 1971));
      actresses.Add(new Actress("Scarlett Johansson", 1984));

      foreach (Actress actress in actresses) {
        ListViewItem item = new ListViewItem();
        item.Text = actress.name;
        item.SubItems.Add(actress.year.ToString());
        lv.Items.Add(item);
      }
    }
  }

  public class Actress {
    public string name;
    public int year;

    public Actress(string name, int year) {
      this.name = name;
      this.year = year;
    }
  }
}