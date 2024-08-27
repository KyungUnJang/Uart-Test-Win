using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uhf.Pad
{
  static public class NumPadFunc
  {
    public static bool ShowInt(int min, int max, ref int n)
    {
      NumPadDlg dlg = new NumPadDlg();
      dlg.SetData(min.ToString("0"), max.ToString("0"), 0, n.ToString("0"));


      dlg.StartPosition = FormStartPosition.CenterParent;
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        n = Convert.ToInt32(dlg.m_sReturn);

        return true;
      }
      return false;
    }

    public static bool ShowInt(ref int n) //min max 사용 안 함
    {
      NumPadDlg dlg = new NumPadDlg();
      dlg.SetData(0, n.ToString("0"));


      dlg.StartPosition = FormStartPosition.CenterParent;
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        n = Convert.ToInt32(dlg.m_sReturn);

        return true;
      }
      return false;
    }

    public static bool ShowDouble(double min, double max, int dotcnt, ref double d)
    {
      int i;
      string s = "0.";
      NumPadDlg dlg = new NumPadDlg();

      if (dotcnt < 1 || dotcnt > 6) return false;

      for (i = 0; i < dotcnt; i++) s += "0";
      
      dlg.SetData(min.ToString(s), max.ToString(s), dotcnt, d.ToString(s));

      dlg.StartPosition = FormStartPosition.CenterParent;
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        d = Convert.ToDouble(dlg.m_sReturn);

        return true;
      }
      return false;
    }

    public static bool ShowDouble(int dotcnt, ref double d) //min max 사용 안 함
    {
      int i;
      string s = "0.";
      NumPadDlg dlg = new NumPadDlg();

      if (dotcnt < 1 || dotcnt > 6) return false;

      for (i = 0; i < dotcnt; i++) s += "0";
      
      dlg.SetData(dotcnt, d.ToString(s));

      dlg.StartPosition = FormStartPosition.CenterParent;
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        d = Convert.ToDouble(dlg.m_sReturn);

        return true;
      }
      return false;
    }
  }
}
