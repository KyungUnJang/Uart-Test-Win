namespace uhf
{
  partial class ViewSlaveDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewSlaveDlg));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.m_btnBoardReset = new AxBTNENHLib4.AxBtnEnh();
            this.m_btnSleepOn = new AxBTNENHLib4.AxBtnEnh();
            this.m_listboxTrace = new System.Windows.Forms.ListBox();
            this.m_btnSleepOff = new AxBTNENHLib4.AxBtnEnh();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnBoardReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnSleepOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnSleepOff)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1107, 674);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(879, 668);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.m_btnBoardReset, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.m_btnSleepOn, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.m_listboxTrace, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.m_btnSleepOff, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(888, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(216, 668);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // m_btnBoardReset
            // 
            this.m_btnBoardReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_btnBoardReset.Location = new System.Drawing.Point(3, 570);
            this.m_btnBoardReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.m_btnBoardReset.Name = "m_btnBoardReset";
            this.m_btnBoardReset.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("m_btnBoardReset.OcxState")));
            this.m_btnBoardReset.Size = new System.Drawing.Size(210, 96);
            this.m_btnBoardReset.TabIndex = 36;
            this.m_btnBoardReset.ClickEvent += new System.EventHandler(this.m_btnSleepOn_ClickEvent);
            // 
            // m_btnSleepOn
            // 
            this.m_btnSleepOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_btnSleepOn.Location = new System.Drawing.Point(3, 370);
            this.m_btnSleepOn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.m_btnSleepOn.Name = "m_btnSleepOn";
            this.m_btnSleepOn.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("m_btnSleepOn.OcxState")));
            this.m_btnSleepOn.Size = new System.Drawing.Size(210, 96);
            this.m_btnSleepOn.TabIndex = 34;
            this.m_btnSleepOn.ClickEvent += new System.EventHandler(this.m_btnSleepOn_ClickEvent);
            // 
            // m_listboxTrace
            // 
            this.m_listboxTrace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.m_listboxTrace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_listboxTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_listboxTrace.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.m_listboxTrace.ForeColor = System.Drawing.Color.GreenYellow;
            this.m_listboxTrace.FormattingEnabled = true;
            this.m_listboxTrace.ItemHeight = 16;
            this.m_listboxTrace.Location = new System.Drawing.Point(3, 3);
            this.m_listboxTrace.Name = "m_listboxTrace";
            this.m_listboxTrace.Size = new System.Drawing.Size(210, 362);
            this.m_listboxTrace.TabIndex = 2;
            // 
            // m_btnSleepOff
            // 
            this.m_btnSleepOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_btnSleepOff.Location = new System.Drawing.Point(3, 470);
            this.m_btnSleepOff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.m_btnSleepOff.Name = "m_btnSleepOff";
            this.m_btnSleepOff.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("m_btnSleepOff.OcxState")));
            this.m_btnSleepOff.Size = new System.Drawing.Size(210, 96);
            this.m_btnSleepOff.TabIndex = 35;
            this.m_btnSleepOff.ClickEvent += new System.EventHandler(this.m_btnSleepOn_ClickEvent);
            // 
            // ViewSlaveDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ViewSlaveDlg";
            this.Size = new System.Drawing.Size(1107, 674);
            this.Load += new System.EventHandler(this.ViewSlaveDlg_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnBoardReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnSleepOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnSleepOff)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.ListBox m_listboxTrace;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private AxBTNENHLib4.AxBtnEnh m_btnBoardReset;
    private AxBTNENHLib4.AxBtnEnh m_btnSleepOff;
        public AxBTNENHLib4.AxBtnEnh m_btnSleepOn;
    }
}
