namespace uhf.MsgBox
{
  partial class ErrorMsgForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorMsgForm));
      this.m_btn = new AxBTNENHLib4.AxBtnEnh();
      this.m_btnClose = new AxBTNENHLib4.AxBtnEnh();
      ((System.ComponentModel.ISupportInitialize)(this.m_btn)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.m_btnClose)).BeginInit();
      this.SuspendLayout();
      // 
      // m_btn
      // 
      this.m_btn.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_btn.Location = new System.Drawing.Point(0, 0);
      this.m_btn.Name = "m_btn";
      this.m_btn.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("m_btn.OcxState")));
      this.m_btn.Size = new System.Drawing.Size(812, 214);
      this.m_btn.TabIndex = 89;
      // 
      // m_btnClose
      // 
      this.m_btnClose.Location = new System.Drawing.Point(776, 6);
      this.m_btnClose.Name = "m_btnClose";
      this.m_btnClose.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("m_btnClose.OcxState")));
      this.m_btnClose.Size = new System.Drawing.Size(30, 29);
      this.m_btnClose.TabIndex = 118;
      this.m_btnClose.ClickEvent += new System.EventHandler(this.m_btnClose_ClickEvent);
      // 
      // ErrorMsgForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(812, 214);
      this.Controls.Add(this.m_btnClose);
      this.Controls.Add(this.m_btn);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ErrorMsgForm";
      this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "AlarmMsgForm";
      ((System.ComponentModel.ISupportInitialize)(this.m_btn)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.m_btnClose)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private AxBTNENHLib4.AxBtnEnh m_btn;
    private AxBTNENHLib4.AxBtnEnh m_btnClose;
  }
}