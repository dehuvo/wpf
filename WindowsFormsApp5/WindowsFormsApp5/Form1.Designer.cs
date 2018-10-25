namespace WindowsFormsApp5 {
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
      this.lv = new System.Windows.Forms.ListView();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.sb = new System.Windows.Forms.ToolStripStatusLabel();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // lv
      // 
      this.lv.AllowColumnReorder = true;
      this.lv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lv.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lv.FullRowSelect = true;
      this.lv.GridLines = true;
      this.lv.Location = new System.Drawing.Point(0, 0);
      this.lv.Name = "lv";
      this.lv.Size = new System.Drawing.Size(334, 261);
      this.lv.TabIndex = 0;
      this.lv.UseCompatibleStateImageBehavior = false;
      this.lv.View = System.Windows.Forms.View.Details;
      this.lv.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
      this.lv.Click += new System.EventHandler(this.lv_Click);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sb});
      this.statusStrip1.Location = new System.Drawing.Point(0, 239);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(334, 22);
      this.statusStrip1.TabIndex = 1;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // sb
      // 
      this.sb.Name = "sb";
      this.sb.Size = new System.Drawing.Size(0, 17);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(334, 261);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.lv);
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "ListView";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListView lv;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel sb;
  }
}

