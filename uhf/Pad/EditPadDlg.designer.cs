namespace uhf.Pad
{
  partial class EditPadDlg
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPadDlg));
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.m_btnCancel = new AxBTNENHLib4.AxBtnEnh();
      this.m_btnEnter = new AxBTNENHLib4.AxBtnEnh();
      ((System.ComponentModel.ISupportInitialize)(this.m_btnCancel)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.m_btnEnter)).BeginInit();
      this.SuspendLayout();
      // 
      // textBox1
      // 
      this.textBox1.Font = new System.Drawing.Font("굴림", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.textBox1.Location = new System.Drawing.Point(12, 12);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(1225, 63);
      this.textBox1.TabIndex = 0;
      this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditPadDlg_KeyDown);
      // 
      // m_btnCancel
      // 
      this.m_btnCancel.Location = new System.Drawing.Point(638, 88);
      this.m_btnCancel.Name = "m_btnCancel";
      this.m_btnCancel.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("m_btnCancel.OcxState")));
      this.m_btnCancel.Size = new System.Drawing.Size(174, 59);
      this.m_btnCancel.TabIndex = 115;
      this.m_btnCancel.ClickEvent += new System.EventHandler(this.m_btnEnter_ClickEvent);
      // 
      // m_btnEnter
      // 
      this.m_btnEnter.Location = new System.Drawing.Point(430, 88);
      this.m_btnEnter.Name = "m_btnEnter";
      this.m_btnEnter.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("m_btnEnter.OcxState")));
      this.m_btnEnter.Size = new System.Drawing.Size(174, 59);
      this.m_btnEnter.TabIndex = 114;
      this.m_btnEnter.ClickEvent += new System.EventHandler(this.m_btnEnter_ClickEvent);
      // 
      // EditPadDlg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1249, 157);
      this.Controls.Add(this.m_btnCancel);
      this.Controls.Add(this.m_btnEnter);
      this.Controls.Add(this.textBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "EditPadDlg";
      this.Text = "EditPadDlg";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditPadDlg_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.m_btnCancel)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.m_btnEnter)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBox1;
    private AxBTNENHLib4.AxBtnEnh m_btnCancel;
    private AxBTNENHLib4.AxBtnEnh m_btnEnter;
  }
}
