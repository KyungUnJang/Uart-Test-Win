using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace uhf.kFunc
{
  static public class AxBtn
  {
    static public void SetFontSize(AxBTNENHLib4.AxBtnEnh btn, float f)
    {
      btn.FontTextCaption = new Font(btn.FontTextCaption.Name, f,
            btn.FontTextCaption.Style, btn.FontTextCaption.Unit);
    }
  }
}
