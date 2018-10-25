using System;
using System.Data;
using Oracle.ManagedDataAccessClient;

class CommandExam {
  public static void Main() {
    string str = "data source=topcredu;User ID = scott; Password = tiger";
    OracleConnection Conn = new OracleConnection(str);
    Conn.Open();
    OracleDataAdapter adapter = new OracleDataAdapter("select * from emp order by empno", Conn);
    DataSet ds = new DataSet("myemp");
    adapter.Fill(ds, "사원");
    printData(ds);
    //데이터를 변경 하자...
    ds.Tables["사원"].Rows[0]["ename"] = "홍길동";
    /*Update Method를 호출 하기 위해 CommandBuilder를 만들자.
    하나의 테이블을 갱신하는 간단한 경우 라면 변경용 Query를 사용 할 필요가 없다.
    단지 자동적으로 적절핚 SQL을 만들고 그것을 관련된 DataAdapter에 연관 시키는
    CommandBuilder 개체를 사용하면 된다.
    CommandBuilder에 DataAdapter를 인자로
    주었는데 이렇게 하면 CommandBuilder가 생성될때 생성자에 의해 적절핚
    SQL 명령문이 만들어지며 그것이 DataAdapter에 연결 된다. */
    OracleCommandBuilder thisBuilder = new OracleCommandBuilder(adapter);
    /* Update 메소드는 DataTable의 행들 중 변경된 데이터를 데이터베이스에
    적용한다. Rows 컬렉션안의 DataRow 개체에는 RowState 라는 속성이 있는데
    이 속성은 그 행의 삭제, 추가, 수정 여부 상태를 의미한다.
    */
    // adapter.Update(ds, "사원");
    //변경 후 DataTable 자료 출력
    printData(ds);
    DataRow row = ds.Tables["사원"].NewRow();
    row["empno"] = 6708;
    row["ename"] = "89길동";
    row["sal"] = 7777;
    ds.Tables["사원"].Rows.Add(row);
    // adapter.Update(ds, "사원");
    //다시 DB에서 데이터 원본을 추출, 테이블의 내용이 바뀐 것을 확인하자.
    adapter = new OracleDataAdapter("select * from emp", Conn);
    adapter.Fill(ds, "사원");
    printData(ds);
    //추가 후 자료 출력
    Console.WriteLine(" 총 {0} 건 입니다.", ds.Tables["사원"].Rows.Count);
  }

  static void printData(DataSet ds) {
    Console.WriteLine();
    foreach (DataRow r in ds.Tables["사원"].Rows) {
      Console.WriteLine("Empno : {0}, Ename : {1}, Sal : {2}",
                            r["empno"], r["ename"], r["sal"]);
    }
  }
}