namespace uhf
{
  partial class ViewMasterSubDlg
  {
    /// <summary> 
    /// 필수 디자이너 변수입니다.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// 사용 중인 모든 리소스를 정리합니다.
    /// </summary>
    /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region 구성 요소 디자이너에서 생성한 코드

    /// <summary> 
    /// 디자이너 지원에 필요한 메서드입니다. 
    /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewMasterSubDlg));
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.m_btnIndex = new AxBTNENHLib4.AxBtnEnh();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.m_btnAdc = new AxBTNENHLib4.AxBtnEnh();
      this.m_btnProgressRssi = new AxBTNENHLib4.AxBtnEnh();
      this.m_btnProgressBattery = new AxBTNENHLib4.AxBtnEnh();
      this.axBtnEnh9 = new AxBTNENHLib4.AxBtnEnh();
      this.axBtnEnh10 = new AxBTNENHLib4.AxBtnEnh();
      this.axBtnEnh11 = new AxBTNENHLib4.AxBtnEnh();
      this.m_btnData = new AxBTNENHLib4.AxBtnEnh();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.m_btnIndex)).BeginInit();
      this.tableLayoutPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.m_btnAdc)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.m_btnProgressRssi)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.m_btnProgressBattery)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.axBtnEnh9)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.axBtnEnh10)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.axBtnEnh11)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.m_btnData)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
      this.tableLayoutPanel1.ColumnCount = 3;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
      this.tableLayoutPanel1.Controls.Add(this.m_btnIndex, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.m_btnData, 1, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(518, 168);
      this.tableLayoutPanel1.TabIndex = 42;
      // 
      // m_btnIndex
      // 
      this.m_btnIndex.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_btnIndex.Location = new System.Drawing.Point(3, 3);
      this.m_btnIndex.Name = "m_btnIndex";
      this.m_btnIndex.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("m_btnIndex.OcxState")));
      this.m_btnIndex.Size = new System.Drawing.Size(54, 162);
      this.m_btnIndex.TabIndex = 41;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
      this.tableLayoutPanel2.ColumnCount = 3;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel2.Controls.Add(this.m_btnAdc, 0, 1);
      this.tableLayoutPanel2.Controls.Add(this.m_btnProgressRssi, 2, 1);
      this.tableLayoutPanel2.Controls.Add(this.m_btnProgressBattery, 1, 1);
      this.tableLayoutPanel2.Controls.Add(this.axBtnEnh9, 0, 0);
      this.tableLayoutPanel2.Controls.Add(this.axBtnEnh10, 1, 0);
      this.tableLayoutPanel2.Controls.Add(this.axBtnEnh11, 2, 0);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(246, 3);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 2;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(269, 162);
      this.tableLayoutPanel2.TabIndex = 40;
      // 
      // m_btnAdc
      // 
      this.m_btnAdc.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_btnAdc.Location = new System.Drawing.Point(3, 35);
      this.m_btnAdc.Name = "m_btnAdc";
      this.m_btnAdc.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("m_btnAdc.OcxState")));
      this.m_btnAdc.Size = new System.Drawing.Size(128, 124);
      this.m_btnAdc.TabIndex = 40;
      // 
      // m_btnProgressRssi
      // 
      this.m_btnProgressRssi.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_btnProgressRssi.Location = new System.Drawing.Point(204, 35);
      this.m_btnProgressRssi.Name = "m_btnProgressRssi";
      this.m_btnProgressRssi.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("m_btnProgressRssi.OcxState")));
      this.m_btnProgressRssi.Size = new System.Drawing.Size(62, 124);
      this.m_btnProgressRssi.TabIndex = 34;
      // 
      // m_btnProgressBattery
      // 
      this.m_btnProgressBattery.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_btnProgressBattery.Location = new System.Drawing.Point(137, 35);
      this.m_btnProgressBattery.Name = "m_btnProgressBattery";
      this.m_btnProgressBattery.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("m_btnProgressBattery.OcxState")));
      this.m_btnProgressBattery.Size = new System.Drawing.Size(61, 124);
      this.m_btnProgressBattery.TabIndex = 33;
      // 
      // axBtnEnh9
      // 
      this.axBtnEnh9.Dock = System.Windows.Forms.DockStyle.Fill;
      this.axBtnEnh9.Location = new System.Drawing.Point(3, 3);
      this.axBtnEnh9.Name = "axBtnEnh9";
      this.axBtnEnh9.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axBtnEnh9.OcxState")));
      this.axBtnEnh9.Size = new System.Drawing.Size(128, 26);
      this.axBtnEnh9.TabIndex = 23;
      // 
      // axBtnEnh10
      // 
      this.axBtnEnh10.Dock = System.Windows.Forms.DockStyle.Fill;
      this.axBtnEnh10.Location = new System.Drawing.Point(137, 3);
      this.axBtnEnh10.Name = "axBtnEnh10";
      this.axBtnEnh10.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axBtnEnh10.OcxState")));
      this.axBtnEnh10.Size = new System.Drawing.Size(61, 26);
      this.axBtnEnh10.TabIndex = 30;
      // 
      // axBtnEnh11
      // 
      this.axBtnEnh11.Dock = System.Windows.Forms.DockStyle.Fill;
      this.axBtnEnh11.Location = new System.Drawing.Point(204, 3);
      this.axBtnEnh11.Name = "axBtnEnh11";
      this.axBtnEnh11.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axBtnEnh11.OcxState")));
      this.axBtnEnh11.Size = new System.Drawing.Size(62, 26);
      this.axBtnEnh11.TabIndex = 31;
      // 
      // m_btnData
      // 
      this.m_btnData.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_btnData.Location = new System.Drawing.Point(63, 3);
      this.m_btnData.Name = "m_btnData";
      this.m_btnData.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("m_btnData.OcxState")));
      this.m_btnData.Size = new System.Drawing.Size(177, 162);
      this.m_btnData.TabIndex = 39;
      // 
      // ViewMasterSubDlg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "ViewMasterSubDlg";
      this.Size = new System.Drawing.Size(518, 168);
      this.Load += new System.EventHandler(this.ViewMasterSubDlg_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.m_btnIndex)).EndInit();
      this.tableLayoutPanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.m_btnAdc)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.m_btnProgressRssi)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.m_btnProgressBattery)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.axBtnEnh9)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.axBtnEnh10)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.axBtnEnh11)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.m_btnData)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private AxBTNENHLib4.AxBtnEnh m_btnProgressRssi;
    private AxBTNENHLib4.AxBtnEnh m_btnProgressBattery;
    private AxBTNENHLib4.AxBtnEnh axBtnEnh9;
    private AxBTNENHLib4.AxBtnEnh axBtnEnh10;
    private AxBTNENHLib4.AxBtnEnh axBtnEnh11;
    private AxBTNENHLib4.AxBtnEnh m_btnData;
    private AxBTNENHLib4.AxBtnEnh m_btnIndex;
    private AxBTNENHLib4.AxBtnEnh m_btnAdc;
  }
}
