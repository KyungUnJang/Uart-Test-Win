namespace uhf.MsgBox
{
  partial class MsgDlg
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsgDlg));
      this.m_btn = new AxBTNENHLib4.AxBtnEnh();
      ((System.ComponentModel.ISupportInitialize)(this.m_btn)).BeginInit();
      this.SuspendLayout();
      // 
      // m_btn
      // 
      this.m_btn.Location = new System.Drawing.Point(0, -1);
      this.m_btn.Name = "m_btn";
      this.m_btn.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("m_btn.OcxState")));
      this.m_btn.Size = new System.Drawing.Size(684, 194);
      this.m_btn.TabIndex = 88;
      // 
      // MsgDlg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(686, 194);
      this.Controls.Add(this.m_btn);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "MsgDlg";
      this.Text = "MsgDlg";
      ((System.ComponentModel.ISupportInitialize)(this.m_btn)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private AxBTNENHLib4.AxBtnEnh m_btn;
  }
}