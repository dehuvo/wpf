using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace TransactionExam {
  public partial class Form1 : Form {
    OleDbDataAdapter adapter = null;
    DataSet ds = null;

    public Form1() {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e) {
      ds = new DataSet("emp");
      string conStr = "Provider=ORAOLEDB.ORACLE;data source=topcredu;User ID = scott; Password = tiger";
      using (OleDbConnection connection = new OleDbConnection(conStr)) {
        OleDbCommand command = new OleDbCommand();
        OleDbTransaction tr = null;
        try {
          connection.Open();
          tr = connection.BeginTransaction();
          command.Connection = connection;
          command.Transaction = tr;
          command.CommandText = "insert into emp (empno, ename) values (9499, '3234 길동')";
          int i = command.ExecuteNonQuery();
          Console.WriteLine(i + "건 Inserted!");
          command.CommandText = "insert into emp (empno, ename) values (8797, '3324 길동')";
          i = command.ExecuteNonQuery();
          tr.Commit();
          adapter = new OleDbDataAdapter("select * from emp", connection);
          adapter.Fill(ds, "EMP");
          dataGridView1.DataSource = ds.Tables["EMP"];
          adapter.Fill(ds, "EMP");
        } catch (Exception ex) {
          tr?.Rollback();
          MessageBox.Show(ex.Message, "emp Table Loading Error");
        } finally {
          connection.Close();
        }
      }
    }
  }
}