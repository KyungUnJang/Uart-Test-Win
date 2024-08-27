using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics; //for stopwatch
using System.Reflection; //for grid double buffer


namespace uhf
{
  public partial class View : Form
  {
		static public MsgBox.MsgDlg m_pMsgDlg;

		//post message
		public const int msg_trace = 1;
		public const int msg_short_msg = 2;

		static public View m_pView;

		public ViewMasterDlg m_pViewMasterDlg;
		public ViewSlaveDlg m_pViewSlaveDlg;

    static public MasterComDrv m_pMasterComDrv;
    static public SlaveComDrv m_pSlaveComDrv;

		public int m_nTimerCount;

    public enum eTab
    {
      master,
      slave,
      MAX,
    }

		public int m_nCurrentTab;


    public View()
    {
			InitializeComponent();

			m_pView = this;

			kFunc.Func.SetBtnAntialiasDisable(this);
			SetStyle(ControlStyles.Selectable, false); //버튼 space나 이런키로 동작 안되게 안눌리게
		}

		private void View_Load(object sender, EventArgs e)
		{
			kFunc.Clock.Init();

			/* param modify start */
			ParamSys.Init();
			ParamFunc.Init();
			/* param modify end */

			MsgBox.ShowMsgProc.Init();

			m_pMsgDlg = new MsgBox.MsgDlg();

			SetTitleVersion();

			//m_pViewMasterDlg = new ViewMasterDlg();
			m_pViewSlaveDlg = new ViewSlaveDlg();
			
      m_pMasterComDrv = new MasterComDrv();
      m_pSlaveComDrv = new SlaveComDrv();

			MasterConnect();
      SlaveConnect();

			m_nCurrentTab = -1;
			SetTab(0, true);

			tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

			timer1.Enabled = true;

			this.DoubleBuffered = true;

      KeyPreview = true;

			MsgBox.MsgFunc.OnPostStr(this.Handle, (IntPtr)msg_trace, "System On");

			//this.TopMost = true;
			//this.FormBorderStyle = FormBorderStyle.None;
			this.WindowState = FormWindowState.Maximized;
		}

		public void MasterConnect()
		
		{

			if (m_pMasterComDrv.Init(false))
			{ //통신 성공
				//m_btnMaster.TextDescrLT.Text = "Connected!";
				//m_btnMaster.TextDescrLT.ColorNormal = kFunc.Colors.greenyellow;
			}
			else
			{
				//m_btnMaster.TextDescrLT.Text = "Not Connected!";
				//m_btnMaster.TextDescrLT.ColorNormal = kFunc.Colors.red;

			}
		}

		public void SlaveConnect()
    {
			if (m_pSlaveComDrv.Init(false))
			{ //통신 성공
				m_btnSlave.TextDescrLT.Text = "Connected!";
				m_btnSlave.TextDescrLT.ColorNormal = kFunc.Colors.greenyellow;
			} else {
				m_btnSlave.TextDescrLT.Text = "Not Connected!";
				m_btnSlave.TextDescrLT.ColorNormal = kFunc.Colors.red;
      }
		}

		private void View_FormClosing(object sender, FormClosingEventArgs e)
		{
			timer1.Stop();

			//Environment.Exit(0);
			System.Diagnostics.Process.GetCurrentProcess().Kill();
			//this.Close();
			//Application.Exit();
		}

		private void SetTitleVersion()
		{
			string title = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
			Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
			DateTime buildDate = new DateTime(2000, 1, 1).AddDays(version.Build).AddSeconds(version.Revision * 2);
			string displayableVersion = $"{title} V{version} ({buildDate})";

			this.Text = displayableVersion;
		}

		public void Trace(string str)
		{
			MsgBox.MsgFunc.OnPostStr(this.Handle, (IntPtr)msg_trace, str);
			if ((int)ParamSys.m_o[(int)ParamSys.e.log_sys_trace] == 1)
			{
				Logs.Log.WriteDebugLog("SysTrace", str);
			}
		}

    public void SetTab(int nTab, bool bUpdate = false) 
    {
      if (bUpdate == false)
      {
        if (m_nCurrentTab == nTab) return;
      }

      switch (nTab)
      {
        case (int)eTab.master:
					//panel1.Controls.Remove(m_pViewMasterDlg);
					panel1.Controls.Add(m_pViewSlaveDlg);
					m_pViewSlaveDlg.Show();
					m_btnSlave.Value = 1;
					break;
        case (int)eTab.slave:
          //panel1.Controls.Remove(m_pViewMasterDlg);
					panel1.Controls.Add(m_pViewSlaveDlg);
					m_pViewSlaveDlg.Show();
					m_btnSlave.Value = 1;
					break;
        default:
          return;
      }

      m_nCurrentTab = nTab;
    }

		private void timer1_Tick(object sender, EventArgs e) //300ms
		{
		}

		private void m_btnLoadModel_ClickEvent(object sender, EventArgs e)
		{
			AxBTNENHLib4.AxBtnEnh btn = (AxBTNENHLib4.AxBtnEnh)sender;

			switch(btn.Name)
      {
				case "m_btnSet":
					{
						Trace("Button - Set");
						ParamForm dlg = new ParamForm();
						dlg.ShowDialog();
					}
					break;
				case "m_btnMaster":
					SetTab((int)eTab.master);
					break;
				case "m_btnSlave":
					SetTab((int)eTab.slave);
					break;
			}
		}

		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
			string str = "";
			if (m.Msg == MsgBox.MsgFunc.WM_MSG)
			{
				Point pt = new Point();
				pt.X = Location.X + Size.Width / 2;
				pt.Y = Location.Y + Size.Height / 2;

				switch ((int)m.WParam)
				{
					case msg_trace:
						str = string.Format("{0} : {1}", DateTime.Now.ToString(), kFunc.Parsing.intptr2str(m.LParam));

						m_listboxTrace.Items.Add(str);
						m_listboxTrace.SelectedIndex = m_listboxTrace.Items.Count - 1;
						break;
				}
			}

			base.WndProc(ref m);
		}

    private void View_SizeChanged(object sender, EventArgs e)
    {
	/*
      if (m_pViewMasterDlg != null)
      {
        m_pViewMasterDlg.Size = panel1.Size;
        m_pViewMasterDlg.Invalidate(false);
      }
	*/
      if (m_pViewSlaveDlg != null)
      {
        m_pViewSlaveDlg.Size = panel1.Size;
				m_pViewSlaveDlg.Invalidate(false);
      }
    }
  }
}
