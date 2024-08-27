using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uhf
{
  public partial class ViewMasterDlg : UserControl
  {
    public ViewMasterSubDlg[] m_pSubDlg;

		//post message
		public const int msg_trace = 1;

    const int m_nMaxSlave = 9;
    const int m_nMaxSleepMin = 59;
    const int m_nMaxSleepSec = 59;


    public ViewMasterDlg()
    {
      InitializeComponent();
    }

    private void ViewMasterDlg_Load(object sender, EventArgs e)
    {
      InitPanel();
      InitCombo();

      m_btnSleepMin.TextDescrCaption.Text = "00";
      m_btnSleepSec.TextDescrCaption.Text = "00";
      UpdateSleepTimeProtocol();

      tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			tableLayoutPanel4.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
    }

    public void UpdateSleepTimeProtocol()
    {
      m_btnSleepSend.TextDescrCaption.Text = string.Format("{0}{1:D2}{2:D2}",
        comboBox1.SelectedItem.ToString(),
        Int32.Parse(m_btnSleepMin.TextDescrCaption.Text),
        Int32.Parse(m_btnSleepSec.TextDescrCaption.Text));
    }

    public void UpdateSubDlg(string str)
    {
      int length = str.Length;

      int data_len = kFunc.Parsing.str2int(str, ViewMasterSubDlg.DATA_LEN_OFFSET, 2);

      if (length != (data_len + 2))
      {
        return;
      }

      int id = kFunc.Parsing.str2int(str, ViewMasterSubDlg.ID_OFFSET, 1);
	

      string trace = str + string.Format(" (ID:{0})", id);

      this.Invoke(new MethodInvoker(delegate ()
            {
							MsgBox.MsgFunc.OnPostStr(this.Handle, (IntPtr)msg_trace, trace);
            }));


      if(m_pSubDlg[id - 1] != null)
			{
        m_pSubDlg[id - 1].UpdateData(str);
			}
    }

    public void InitPanel()
		{
      m_pSubDlg = new ViewMasterSubDlg[m_nMaxSlave];

      for(int i = 0; i < m_nMaxSlave; i++)
      {
        m_pSubDlg[i] = new ViewMasterSubDlg(i);

        string txt = "panel" + (i + 1).ToString();
        Panel panel = this.Controls.Find(txt, true).FirstOrDefault() as Panel;
        panel.Controls.Add(m_pSubDlg[i]);
        m_pSubDlg[i].Show();
      }
		}

    public void InitCombo()
    {
      for (int i = 0; i < m_nMaxSlave; i++)
      {
        comboBox1.Items.Add((i + 1).ToString());
      }

      // 각 콤보박스에 데이타를 초기화

      // 처음 선택값 지정. 첫째 아이템 선택
      comboBox1.SelectedIndex = 0;
    }

    private void ViewMasterDlg_SizeChanged(object sender, EventArgs e)
    {
            /*
      for(int i = 0; i < m_nMaxSlave; i++)
      {
        string txt = "panel" + (i + 1).ToString();
        Panel panel = this.Controls.Find(txt, true).FirstOrDefault() as Panel;

        m_pSubDlg[i].Size = panel.Size;
        m_pSubDlg[i].Invalidate(false);
      }
            */
    }

    private void m_btnSleepMin_ClickEvent(object sender, EventArgs e)
    {
			AxBTNENHLib4.AxBtnEnh btn = (AxBTNENHLib4.AxBtnEnh)sender;

			switch(btn.Name)
      {
				case "m_btnSleepMin":
          {
            int n = Int32.Parse(m_btnSleepMin.TextDescrCaption.Text);
            if (Pad.NumPadFunc.ShowInt(0, m_nMaxSleepMin, ref n))
            {
              m_btnSleepMin.TextDescrCaption.Text = n.ToString("D2");
              UpdateSleepTimeProtocol();
            }
          }
					break;
				case "m_btnSleepSec":
          {
            int n = Int32.Parse(m_btnSleepSec.TextDescrCaption.Text);
            if (Pad.NumPadFunc.ShowInt(0, m_nMaxSleepSec, ref n))
            {
              m_btnSleepSec.TextDescrCaption.Text = n.ToString("D2");
              UpdateSleepTimeProtocol();
            }
          }
					break;
				case "m_btnSleepSend":
          {
            string str = m_btnSleepSend.TextDescrCaption.Text;
            View.m_pMasterComDrv.SleepTime(str);
          }
					break;
			}
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      UpdateSleepTimeProtocol();
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
            DateTime datetime = DateTime.Now; ;
						str = string.Format("{0} : {1}", datetime.ToString("yyyyMMdd HH:mm:ss.fff"), kFunc.Parsing.intptr2str(m.LParam));

						m_listboxTrace.Items.Add(str);
						m_listboxTrace.SelectedIndex = m_listboxTrace.Items.Count - 1;
						break;
				}
			}

			base.WndProc(ref m);
		}

  }
}
