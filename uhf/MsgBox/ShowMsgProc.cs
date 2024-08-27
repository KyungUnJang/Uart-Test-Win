using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uhf.MsgBox
{
  enum eLevel
  {
    information,
    warning,
    error,
  }

  static class ShowMsgProc
  {
		private static object m_lock = new object(); //critical section

    static int[] msgBufferCode;
    static int[] msgBufferLevel;
    static string [] msgBufferMsg;
    static int msgBufferCounter;
    const int msgMax = 1000;

    static public void Init()
    {
      msgBufferCode = new int[msgMax];
      msgBufferLevel = new int[msgMax];
      msgBufferMsg = new string[msgMax];
      msgBufferCounter = 0;

      for(int i = 0; i < msgMax; i++)
      {
        msgBufferCode[i] = -1;
        msgBufferLevel[i] = -1;
        msgBufferMsg[i] = "";
      }
    }

    static public bool IsCodeExist(int code)
		{
			for(int i = 0; i < msgBufferCounter; i++)
			{
				if(msgBufferCode[i] == code) return true;
			}

			return false;
		}

    static public void Add(int code, int level, string msg)
    {
			lock (m_lock)
			{
				bool bShow = false;
				if (msgBufferCounter == 0) bShow = true;

				msgBufferCode[msgBufferCounter] = code;
				msgBufferLevel[msgBufferCounter] = level;
				msgBufferMsg[msgBufferCounter] = msg;
				msgBufferCounter++;

				if(msgBufferCounter >= msgMax)
				{
					MessageBox.Show("ShowMsgProc message overflow!\n");
					msgBufferCounter = 0;
				}

				if(bShow) ShowMsg();
			}
    }

    static public void ShowMsg()
    {
			lock (m_lock)
			{
				if (msgBufferCounter <= 0) return;

				int code = msgBufferCode[0];
				int level = msgBufferLevel[0];
				string msg = msgBufferMsg[0];

				System.Drawing.Point pt = new System.Drawing.Point();
				pt.X = View.m_pView.Location.X + View.m_pView.Width / 2;
				pt.Y = View.m_pView.Location.Y + View.m_pView.Height / 2;

				switch(level)
				{
					case (int)eLevel.information:
						{
							MsgBox.InformationMsgForm dlg;
							dlg = new MsgBox.InformationMsgForm(string.Format("{0} : {1}", code.ToString(), msg));
							//dlg.StartPosition = FormStartPosition.CenterParent;
							pt.X -= dlg.Width / 2;
							pt.Y -= dlg.Height / 2;
							dlg.StartPosition = FormStartPosition.Manual;
							dlg.Location = pt;
							dlg.ShowDialog();
						}
						break;
					case (int)eLevel.warning:
						{
							MsgBox.WarningMsgForm dlg;
							dlg = new MsgBox.WarningMsgForm(string.Format("{0} : {1}", code.ToString(), msg));
							pt.X -= dlg.Width / 2;
							pt.Y -= dlg.Height / 2;
							dlg.Parent = View.m_pView.Parent;
							dlg.StartPosition = FormStartPosition.Manual;
							dlg.Location = pt;
							dlg.ShowDialog();
						}
						break;
					case (int)eLevel.error:
						{
							MsgBox.ErrorMsgForm dlg;
							dlg = new MsgBox.ErrorMsgForm(string.Format("{0} : {1}", code.ToString(), msg));
							pt.X -= dlg.Width / 2;
							pt.Y -= dlg.Height / 2;
							dlg.Parent = View.m_pView.Parent;
							dlg.StartPosition = FormStartPosition.Manual;
							dlg.Location = pt;
							dlg.ShowDialog();
						}
						break;
				}

				//show
				if (msgBufferCounter > 0)
				{
					kFunc.Func.DataShift(ref msgBufferCode, -1, msgBufferCounter);
					kFunc.Func.DataShift(ref msgBufferLevel, -1, msgBufferCounter);
					kFunc.Func.DataShift(ref msgBufferMsg, "", msgBufferCounter);

					msgBufferCounter--;
				}
			}

      if (msgBufferCounter > 0)
        ShowMsg();
    }
  }
}
