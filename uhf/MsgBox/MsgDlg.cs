using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; //color
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uhf.MsgBox
{
  public partial class MsgDlg : Form
  {
    public System.Windows.Forms.Timer timer1;
    public Color m_colDefault; //red
    public int m_nTimerShortTime;
    public int m_nTimerShortCnt;
    public long m_clock;
    public bool m_bMsgLive;
    public bool m_bCountDown;

    public MsgDlg()
    {
      InitializeComponent();
      kFunc.Func.SetBtnAntialiasDisable(this);
      m_colDefault = m_btn.CtlBackColor;

      Opacity = 1.0;
      m_bMsgLive = false;
			m_bCountDown = false;
      Hide();
    }

    public void SetTimer(int time)
    {
      timer1 = new System.Windows.Forms.Timer();
      timer1.Interval = time;
      timer1.Tick += new System.EventHandler(this.timer1_Tick);
      timer1.Start();
    }

    public void SetTimerShort(int time)
    {
      kFunc.Clock.setclock(out m_clock);
      m_nTimerShortCnt = 100;
      m_nTimerShortTime = time;

      timer1 = new System.Windows.Forms.Timer();
      timer1.Interval = 50;
      timer1.Tick += new System.EventHandler(this.timer1_Tick);
      timer1.Start();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
			if(m_bCountDown)
			{
				int n = kFunc.Clock.calclock2ms(m_clock) / 1000;
        int nn = (m_nTimerShortTime / 1000) - n;
        if (nn < 0) nn = 0;
        m_btn.TextDescrCaption.Text = nn.ToString();
			}

      if (kFunc.Clock.calclock2ms(m_clock) >= m_nTimerShortTime)
      {
        m_nTimerShortCnt -= 5;

        if (m_nTimerShortCnt < 0) m_nTimerShortCnt = 0;

        Opacity = (double)m_nTimerShortCnt / 100.0;
      }

      if (m_nTimerShortCnt <= 0)
      {
        timer1.Dispose();
        Hide();
        m_bMsgLive = false;
				m_bCountDown = false;
      }
    }

    public void ShowMsgTimeout(Point pt, string text, int timeout, Color col)
    {
      Point p = new Point();
      if (m_bMsgLive) return;
      m_bMsgLive = true;

      m_btn.TextDescrCaption.Text = text; //문구
      m_btn.CtlBackColor = col; //배경 색
      Opacity = 1.0; //투명도
      SetTimerShort(timeout);
      StartPosition = FormStartPosition.Manual;
      p.X = pt.X - Size.Width / 2;
      p.Y = pt.Y - Size.Height / 2;
      Location = p;
      TopMost = true;

      Show();
    }

    public void ShowMsgCountDownTimeout(Point pt, int timeout, Color col) //초단위 카운트다운
    {
      Point p = new Point();
      if (m_bMsgLive) return;
      m_bMsgLive = true;
			m_bCountDown = true;

      m_btn.TextDescrCaption.Text = (timeout / 1000).ToString(); //문구
      m_btn.CtlBackColor = col; //배경 색
      Opacity = 1.0; //투명도
      SetTimerShort(timeout);
      StartPosition = FormStartPosition.Manual;
      p.X = pt.X - Size.Width / 2;
      p.Y = pt.Y - Size.Height / 2;
      Location = p;
      TopMost = true;

      Show();
    }
  }
}
