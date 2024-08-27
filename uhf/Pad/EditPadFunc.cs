using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace uhf.Pad
{
  static public class EditPadFunc
  {
    public static bool ShowPad(ref string s)
    {
      Pad.EditPadDlg dlg = new Pad.EditPadDlg(s);

      dlg.StartPosition = FormStartPosition.CenterParent;
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        s = dlg.m_sReturn;

        return true;
      }
      return false;
    }
  }
}
