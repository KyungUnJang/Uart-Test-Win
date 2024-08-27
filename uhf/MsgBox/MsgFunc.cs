using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; //color
using System.Runtime.InteropServices; //for dll import

namespace uhf.MsgBox
{
	static public class MsgFunc
	{
		public const int WM_MSG = 0x0400 + 10;

		public struct COPYDATASTRUCT
		{
			public IntPtr dwData;
			public UInt32 cbData;
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpData;
		}

		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, uint uMsg, IntPtr WParam, IntPtr LParam);

		[DllImport("user32.dll")]
		//public static extern Int32 PostMessage(Int32 uMsg, IntPtr WParam, IntPtr LParam);
		public static extern IntPtr PostMessage(IntPtr hWnd, uint uMsg, IntPtr WParam, IntPtr LParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, uint uMsg, IntPtr wParam, ref COPYDATASTRUCT lParam);
		/*
		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
			if (m.Msg == WM_COPYDATA)
			{
				COPYDATASTRUCT cds = (COPYDATASTRUCT)m.GetLParam(typeof(COPYDATASTRUCT));
				//strData = cds.lpData; 받을 데이터를 설정.
			}

			base.WndProc(ref m);

		} //WndProc
		*/

		public static void OnPost(IntPtr hWnd, IntPtr WParam)
		{
      OnPostInt(hWnd, WParam, 0);
		}
		public static void OnPostInt(IntPtr hWnd, IntPtr WParam, int n)
		{
			PostMessage(hWnd, WM_MSG, WParam, (IntPtr)n);
		}
		public static void OnPostStr(IntPtr hWnd, IntPtr WParam, string str)
		{
      PostMessage(hWnd, WM_MSG, WParam, kFunc.Parsing.str2intptr(str));
		}

		public static bool YesNo(string str)
		{
		  MsgYesNoForm dlg = new MsgYesNoForm(str);

      dlg.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

      if(dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        return true;
      }
      return false;
		}
  }
}
