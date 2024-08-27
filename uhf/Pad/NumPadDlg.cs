using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uhf.Pad
{
  public partial class NumPadDlg : Form
	{
    public string m_sMin;
    public string m_sMax;
    public int    m_nDotCnt;
    public bool   m_bUseMinMax;

    public string m_sOrigin;
    public string m_sReturn;
    public string m_sTarget;

    public Color m_colCurr;


		public NumPadDlg()
		{
			InitializeComponent();
      kFunc.Func.SetBtnAntialiasDisable(this);

      m_colCurr = m_btnCurr.CtlBackColor;
      m_sTarget = "0";
      m_btnCurr.TextDescrCaption.Text = m_sTarget;
  }

    public void SetData(string min, string max, int dotcnt, string origin)
    {
      m_sMin = min;
      m_sMax = max;
      m_nDotCnt = dotcnt;
      m_sOrigin = origin;
			m_bUseMinMax = true;

      m_btnMin.TextDescrCaption.Text = m_sMin;
      m_btnMax.TextDescrCaption.Text = m_sMax;
      m_btnCurr.TextDescrCaption.Text = "0";
      m_btnOrg.TextDescrCaption.Text = m_sOrigin;

      if (m_nDotCnt == 0)
        m_btnDot.Enabled = false;
    }

    public void SetData(int dotcnt, string origin) //min max 사용 안 함
    {
      m_sMin = "";
      m_sMax = "";
      m_nDotCnt = dotcnt;
      m_sOrigin = origin;
			m_bUseMinMax = false;

      m_btnMin.TextDescrCaption.Text = m_sMin;
      m_btnMax.TextDescrCaption.Text = m_sMax;
      m_btnCurr.TextDescrCaption.Text = "0";
      m_btnOrg.TextDescrCaption.Text = m_sOrigin;

      if (m_nDotCnt == 0)
        m_btnDot.Enabled = false;
    }

    public int CheckRange()
    {
      int nRet = 1;
      int n;
      double dbl;

      int nAddSubSts; //0 : None, 1 : Add, -1 : Sub

			if(m_bUseMinMax == false) return 1;

      if(m_btnAdd.GetValueEx() == 1)
      {
        nAddSubSts = 1;
      }
      else if (m_btnSub.GetValueEx() == 1)
      {
        nAddSubSts = -1;
      }
      else
      {
        nAddSubSts = 0;
      }

      if (m_nDotCnt == 0) //int type
      {
        n = Convert.ToInt32(m_sTarget);

        if (nAddSubSts == 1) //Add
        {
          n = Convert.ToInt32(m_sOrigin) + n;
        }
        else if (nAddSubSts == -1)
        {//Sub
          n = Convert.ToInt32(m_sOrigin) - n;
        }
        else
        {
        }

        if (n < Convert.ToInt32(m_sMin) ||
           n > Convert.ToInt32(m_sMax))
        {
          nRet = 0;
        }
      }
      else
      {
        dbl = Convert.ToDouble(m_sTarget);

        if (nAddSubSts == 1) //Add
        {
          dbl = Convert.ToDouble(m_sOrigin) + dbl;
        }
        else if (nAddSubSts == -1)
        {//Sub
          dbl = Convert.ToDouble(m_sOrigin) - dbl;
        }
        else
        {
        }

        if (dbl < Convert.ToDouble(m_sMin) ||
           dbl > Convert.ToDouble(m_sMax))
        {
          nRet = 0;
        }
      }

      if (nRet == 1)
      {
        m_btnCurr.CtlBackColor = m_colCurr;
      }
      else
      {
        m_btnCurr.CtlBackColor = kFunc.Colors.Uint2Color(kFunc.Colors.red);
      }

      return nRet;
    }

		public void NumClick(int n)
		{
			if ((m_sTarget == "0" || m_sTarget == "-0") && n == 0)
			{
			}
			else
			{
				if (m_sTarget == "0")
				{
					m_sTarget = "";
				} 
				else if(m_sTarget == "-0")
				{
					m_sTarget = "-";
				}
				m_sTarget += n.ToString();
			}
		}

		public void BackClick()
		{
			m_sTarget = m_sTarget.Remove(m_sTarget.Length - 1);
			if ((m_sTarget == "") || (m_sTarget == "-")) m_sTarget = "0";
		}

		public void DotClick()
		{
      if (m_sTarget.IndexOf(".") != -1) return;
      m_sTarget += ".";
		}

		public void MinusClick()
		{
			//if (m_sTarget != "0")
			{
				if (m_sTarget.IndexOf("-") != -1)
				{
					m_sTarget = m_sTarget.Replace("-", "");
				}
				else
				{
					m_sTarget = "-" + m_sTarget;
				}
			}
		}

		public void EnterClick()
		{
			int nAddSubSts; //0 : None, 1 : Add, -1 : Sub

			if (CheckRange() == 0) //range over
			{
        Point pt = new Point();
        pt.X = Location.X + Size.Width / 2;
        pt.Y = Location.Y + Size.Height / 2;
        View.m_pMsgDlg.ShowMsgTimeout(pt, "Range Over!", 1000, Color.OrangeRed);
        return;
			}

			if (m_btnAdd.GetValueEx() == 1)
			{
				nAddSubSts = 1;
			}
			else if (m_btnSub.GetValueEx() == 1)
			{
				nAddSubSts = -1;
			}
			else
			{
				nAddSubSts = 0;
			}

			if (nAddSubSts == 1) //Add
			{
				if (m_nDotCnt == 0) //int type
				{
					m_sReturn = (Convert.ToDouble(m_sOrigin) + Convert.ToDouble(m_sTarget)).ToString();
				}
				else
				{
					m_sReturn = (Convert.ToDouble(m_sOrigin) + Convert.ToDouble(m_sTarget)).ToString();
				}
			}
			else if (nAddSubSts == -1)
			{//Sub
				if (m_nDotCnt == 0) //int type
				{
					m_sReturn = (Convert.ToDouble(m_sOrigin) - Convert.ToDouble(m_sTarget)).ToString();
				}
				else
				{
					m_sReturn = (Convert.ToDouble(m_sOrigin) - Convert.ToDouble(m_sTarget)).ToString();
				}
			}
			else
			{
				m_sReturn = m_sTarget;
			}

			this.DialogResult = DialogResult.OK;
		}

		public void CancelClick()
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void m_btnCancel_ClickEvent(object sender, EventArgs e)
		{
			AxBTNENHLib4.AxBtnEnh btn;
      string s;
      int n;

			btn = (AxBTNENHLib4.AxBtnEnh)sender;

			switch (btn.Name)
			{
				case "m_btn0":
				case "m_btn1":
				case "m_btn2":
				case "m_btn3":
				case "m_btn4":
				case "m_btn5":
				case "m_btn6":
				case "m_btn7":
				case "m_btn8":
				case "m_btn9":
          s = btn.Name.Substring("m_btn".Length);
          n = Convert.ToInt32(s);
					NumClick(n);
          break;
				case "m_btn00":
          if (m_sTarget == "0" || m_sTarget == "-0")
          {
            //none
          }
          else 
          {
            m_sTarget += "00";
          }
          break;
				case "m_btn000":
          if (m_sTarget == "0" || m_sTarget == "-0")
          {
            //none
          }
          else 
          {
            m_sTarget += "000";
          }
          break;
        case "m_btnDot":
					DotClick();
          break;
        case "m_btnClear":
          m_sTarget = "0";
          break;
				case "m_btnAdd":
          if (m_btnAdd.GetValueEx() == 1)
          {
            m_btnSub.SetValueEx(0);
          }
          break;
        case "m_btnSub":
          if (m_btnSub.GetValueEx() == 1)
          {
            m_btnAdd.SetValueEx(0);
          }
          break;
        case "m_btnMinus":
					MinusClick();
          break;
				case "m_btnBack":
					BackClick();
          break;
        case "m_btnEnter":
					EnterClick();
          break;
        case "m_btnCancel":
					CancelClick();
          break;
			}
      m_btnCurr.TextDescrCaption.Text = m_sTarget;
      CheckRange();
		}

    private void NumPadDlg_KeyDown(object sender, KeyEventArgs e)
    {
			int n = 0;

			switch(e.KeyCode)
			{
				default: return;
				case Keys.D0:
				case Keys.D1:
				case Keys.D2:
				case Keys.D3:
				case Keys.D4:
				case Keys.D5:
				case Keys.D6:
				case Keys.D7:
				case Keys.D8:
				case Keys.D9:
					n = e.KeyCode - Keys.D0;
					NumClick(n);
					break;
				case Keys.NumPad0:
				case Keys.NumPad1:
				case Keys.NumPad2:
				case Keys.NumPad3:
				case Keys.NumPad4:
				case Keys.NumPad5:
				case Keys.NumPad6:
				case Keys.NumPad7:
				case Keys.NumPad8:
				case Keys.NumPad9:
					n = e.KeyCode - Keys.NumPad0;
					NumClick(n);
					break;
				case Keys.OemMinus:
					MinusClick();
					break;
				case Keys.Back:
					BackClick();
					break;
				case Keys.OemPeriod:
					DotClick();
					break;
				case Keys.Enter:
					EnterClick();
					break;
				case Keys.Escape:
					CancelClick();
					break;
			}

			m_btnCurr.TextDescrCaption.Text = m_sTarget;
			CheckRange();
		}
  }
}
