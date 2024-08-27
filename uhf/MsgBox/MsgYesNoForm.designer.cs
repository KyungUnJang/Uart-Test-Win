namespace uhf.MsgBox
{
  partial class MsgYesNoForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsgYesNoForm));
      this.m_btn = new AxBTNENHLib4.AxBtnEnh();
      this.m_btnYes = new AxBTNENHLib4.AxBtnEnh();
      this.m_btnNo = new AxBTNENHLib4.AxBtnEnh();
      ((System.ComponentModel.ISupportInitialize)(this.m_btn)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.m_btnYes)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.m_btnNo)).BeginInit();
      this.SuspendLayout();
      // 
      // m_btn
      // 
      this.m_btn.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_btn.Location = new System.Drawing.Point(0, 0);
      this.m_btn.Name = "m_btn";
      this.m_btn.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("m_btn.OcxState")));
      this.m_btn.Size = new System.Drawing.Size(1053, 333);
      this.m_btn.TabIndex = 91;
      // 
      // m_btnYes
      // 
      this.m_btnYes.Location = new System.Drawing.Point(26, 222);
      this.m_btnYes.Name = "m_btnYes";
      this.m_btnYes.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("m_btnYes.OcxState")));
      this.m_btnYes.Size = new System.Drawing.Size(473, 75);
      this.m_btnYes.TabIndex = 110;
      this.m_btnYes.ClickEvent += new System.EventHandler(this.m_btnYes_ClickEvent);
      // 
      // m_btnNo
      // 
      this.m_btnNo.Location = new System.Drawing.Point(552, 222);
      this.m_btnNo.Name = "m_btnNo";
      this.m_btnNo.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("m_btnNo.OcxState")));
      this.m_btnNo.Size = new System.Drawing.Size(473, 75);
      this.m_btnNo.TabIndex = 111;
      this.m_btnNo.ClickEvent += new System.EventHandler(this.m_btnYes_ClickEvent);
      // 
      // MsgYesNoForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1053, 333);
      this.ControlBox = false;
      this.Controls.Add(this.m_btnNo);
      this.Controls.Add(this.m_btnYes);
      this.Controls.Add(this.m_btn);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MsgYesNoForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.Text = "MsgYesNoForm";
      ((System.ComponentModel.ISupportInitialize)(this.m_btn)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.m_btnYes)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.m_btnNo)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private AxBTNENHLib4.AxBtnEnh m_btn;
    private AxBTNENHLib4.AxBtnEnh m_btnYes;
    private AxBTNENHLib4.AxBtnEnh m_btnNo;
  }
}