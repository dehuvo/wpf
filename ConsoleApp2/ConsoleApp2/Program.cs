public class Chat_Class {
  //한글 처리를 위해 Encod 정의
  private Encoding ecd_Encode = Encoding.GetEncoding("KS_C_5601-1987");
  //글자를 Display할 Object
  private System.Windows.Forms.TextBox txt_Chat;
  private Socket sktClient;
  private NetworkStream netStream;
  private StreamReader strReader;
  private Form1 form1;
  public void Chat_Class_Setup(Form1 form1, Socket sktClient,
 System.Windows.Forms.TextBox txt_Chat) { //TextBox를 할당함.
    this.txt_Chat = txt_Chat; //Socket 을 할당함.
    this.sktClient = sktClient; //Network Stream을 생성
    this.netStream = new NetworkStream(sktClient);
    Form1.soketArray.Add(sktClient); //Stream Reader을 생성
    this.strReader = new StreamReader(netStream, ecd_Encode);
    this.form1 = form1;
  }
  public void Chat_Process() {
    while (true) {
      try {
        //문자열을 받음
        string lstMessage = strReader.ReadLine();
        if (lstMessage != null && lstMessage != "") {
          //Form1클래스의 SetText메소드를 호출
          //SetText에서는 델리게이트를 통해 켁스트박스에 글을 쓴다.
          form1.SetText(lstMessage + "\r\n");
          //직접 다른 쓰레드의 TextBox에 값을 쓰면 오류 발생
          //Cross-thread operation not valid: Control accessed from a
          thread other than the thread it was created on
        //this.txt_Chat.AppendText(lstMessage + "\r\n");
 byte[] bytSand_Data = Encoding.Default.GetBytes(lstMessage
+ "\r\n");
          ArrayList remove_soketArray = new ArrayList();
          lock (Form1.soketArray) {
            foreach (Socket soket in Form1.soketArray) {
              NetworkStream stream = new NetworkStream(soket); stream.Write(bytSand_Data, 0,
            bytSand_Data.Length);
            }
          }
        }
      } catch (System.Exception e) {
        MessageBox.Show(e.ToString());
        Form1.soketArray.Remove(sktClient);
        break;
      }
    }
  }
}
}