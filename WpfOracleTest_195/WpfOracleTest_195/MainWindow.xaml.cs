﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace WpfOracleTest_195 {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    OracleConnection conn;

    private void DB_Connect(object sender, RoutedEventArgs e) {
      try {
        string strCon = @"data source=(DESCRIPTION =
          (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.27)(PORT = 1521))
           (CONNECT_DATA =
           (SERVER = DEDICATED)
           (SERVICE_NAME = topcredu)
          )
        ); User ID = scott; Password = tiger";
        conn = new OracleConnection(strCon);
        conn.Open();
        MessageBox.Show("DB Connection OK!");
      } catch (Exception error) {
        MessageBox.Show(error.ToString());
      }
    }

    private void Select_Emp(object sender, RoutedEventArgs e) {
      OracleCommand comm = new OracleCommand();
      if (conn == null) {
        DB_Connect(this, null);
      }
      comm.Connection = conn;
      comm.CommandText = "select empno, nvl(ename, ' ') ename, nvl(job, ' ') job from emp";

      OracleDataReader reader = comm.ExecuteReader(CommandBehavior.CloseConnection);
      List<EmpViewModel> emps = new List<EmpViewModel>();
      while (reader.Read()) {
        emps.Add(new EmpViewModel {
          Empno = reader.GetInt32(reader.GetOrdinal("empno")),
          Ename = reader.GetString(reader.GetOrdinal("ename")),
          Job = reader.GetString(reader.GetOrdinal("job"))
        });
        Console.WriteLine(reader.GetInt32(reader.GetOrdinal("empno")) + " " +
          reader.GetString(reader.GetOrdinal("ename")) + " " +
          reader.GetString(reader.GetOrdinal("job")));
      }
      lstView.ItemsSource = emps;
      reader.Close();
    }
  }
}