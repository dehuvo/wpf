namespace WindowsFormsApp2 {
  partial class Form1 {
    /// <summary>
    /// 필수 디자이너 변수입니다.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 사용 중인 모든 리소스를 정리합니다.
    /// </summary>
    /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form 디자이너에서 생성한 코드

    /// <summary>
    /// 디자이너 지원에 필요한 메서드입니다. 
    /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
    /// </summary>
    private void InitializeComponent() {
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.chkItalic = new System.Windows.Forms.CheckBox();
      this.chkBold = new System.Windows.Forms.CheckBox();
      this.comFont = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.txtMessage = new System.Windows.Forms.TextBox();
      this.rdoSoccer = new System.Windows.Forms.RadioButton();
      this.rdoBaseball = new System.Windows.Forms.RadioButton();
      this.rdoBasketball = new System.Windows.Forms.RadioButton();
      this.rdoTkd = new System.Windows.Forms.RadioButton();
      this.lblSports = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.txtMessage);
      this.groupBox1.Controls.Add(this.chkItalic);
      this.groupBox1.Controls.Add(this.chkBold);
      this.groupBox1.Controls.Add(this.comFont);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Location = new System.Drawing.Point(44, 36);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(723, 177);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "폰트 설정";
      // 
      // chkItalic
      // 
      this.chkItalic.AutoSize = true;
      this.chkItalic.Location = new System.Drawing.Point(563, 38);
      this.chkItalic.Name = "chkItalic";
      this.chkItalic.Size = new System.Drawing.Size(72, 16);
      this.chkItalic.TabIndex = 3;
      this.chkItalic.Text = "이탤릭체";
      this.chkItalic.UseVisualStyleBackColor = true;
      // 
      // chkBold
      // 
      this.chkBold.AutoSize = true;
      this.chkBold.Location = new System.Drawing.Point(432, 38);
      this.chkBold.Name = "chkBold";
      this.chkBold.Size = new System.Drawing.Size(48, 16);
      this.chkBold.TabIndex = 2;
      this.chkBold.Text = "굵게";
      this.chkBold.UseVisualStyleBackColor = true;
      // 
      // comFont
      // 
      this.comFont.FormattingEnabled = true;
      this.comFont.Location = new System.Drawing.Point(78, 32);
      this.comFont.Name = "comFont";
      this.comFont.Size = new System.Drawing.Size(301, 20);
      this.comFont.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(26, 32);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(29, 12);
      this.label1.TabIndex = 0;
      this.label1.Text = "폰트";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.lblSports);
      this.groupBox2.Controls.Add(this.rdoTkd);
      this.groupBox2.Controls.Add(this.rdoBasketball);
      this.groupBox2.Controls.Add(this.rdoBaseball);
      this.groupBox2.Controls.Add(this.rdoSoccer);
      this.groupBox2.Location = new System.Drawing.Point(46, 240);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(720, 183);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "좋아하는 스포츠 하나만";
      this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
      // 
      // txtMessage
      // 
      this.txtMessage.Location = new System.Drawing.Point(33, 80);
      this.txtMessage.Name = "txtMessage";
      this.txtMessage.Size = new System.Drawing.Size(601, 21);
      this.txtMessage.TabIndex = 4;
      this.txtMessage.Text = "오라클자바컴뮤니티";
      // 
      // rdoSoccer
      // 
      this.rdoSoccer.AutoSize = true;
      this.rdoSoccer.Location = new System.Drawing.Point(64, 56);
      this.rdoSoccer.Name = "rdoSoccer";
      this.rdoSoccer.Size = new System.Drawing.Size(47, 16);
      this.rdoSoccer.TabIndex = 0;
      this.rdoSoccer.TabStop = true;
      this.rdoSoccer.Text = "축구";
      this.rdoSoccer.UseVisualStyleBackColor = true;
      // 
      // rdoBaseball
      // 
      this.rdoBaseball.AutoSize = true;
      this.rdoBaseball.Location = new System.Drawing.Point(227, 62);
      this.rdoBaseball.Name = "rdoBaseball";
      this.rdoBaseball.Size = new System.Drawing.Size(47, 16);
      this.rdoBaseball.TabIndex = 1;
      this.rdoBaseball.TabStop = true;
      this.rdoBaseball.Text = "야구";
      this.rdoBaseball.UseVisualStyleBackColor = true;
      // 
      // rdoBasketball
      // 
      this.rdoBasketball.AutoSize = true;
      this.rdoBasketball.Location = new System.Drawing.Point(401, 66);
      this.rdoBasketball.Name = "rdoBasketball";
      this.rdoBasketball.Size = new System.Drawing.Size(47, 16);
      this.rdoBasketball.TabIndex = 2;
      this.rdoBasketball.TabStop = true;
      this.rdoBasketball.Text = "농구";
      this.rdoBasketball.UseVisualStyleBackColor = true;
      // 
      // rdoTkd
      // 
      this.rdoTkd.AutoSize = true;
      this.rdoTkd.Location = new System.Drawing.Point(534, 60);
      this.rdoTkd.Name = "rdoTkd";
      this.rdoTkd.Size = new System.Drawing.Size(47, 16);
      this.rdoTkd.TabIndex = 3;
      this.rdoTkd.TabStop = true;
      this.rdoTkd.Text = "태권";
      this.rdoTkd.UseVisualStyleBackColor = true;
      // 
      // lblSports
      // 
      this.lblSports.AutoSize = true;
      this.lblSports.Location = new System.Drawing.Point(51, 107);
      this.lblSports.Name = "lblSports";
      this.lblSports.Size = new System.Drawing.Size(149, 12);
      this.lblSports.TabIndex = 4;
      this.lblSports.Text = "선택한 스포츠가 없습니다.";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 457);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Name = "Form1";
      this.Text = "CheckBox, RadioButton, ComboBox, TextBox 예제";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckBox chkItalic;
    private System.Windows.Forms.CheckBox chkBold;
    private System.Windows.Forms.ComboBox comFont;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.TextBox txtMessage;
    private System.Windows.Forms.RadioButton rdoTkd;
    private System.Windows.Forms.RadioButton rdoBasketball;
    private System.Windows.Forms.RadioButton rdoBaseball;
    private System.Windows.Forms.RadioButton rdoSoccer;
    private System.Windows.Forms.Label lblSports;
  }
}

