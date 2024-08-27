using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uhf.MsgBox
{
  public partial class MsgYesNoForm : Form
  {
    public MsgYesNoForm(string str)
    {
      InitializeComponent();

      m_btn.TextDescrLT.Text = str;
    }

    private void m_btnYes_ClickEvent(object sender, EventArgs e)
    {
			AxBTNENHLib4.AxBtnEnh btn = (AxBTNENHLib4.AxBtnEnh)sender;

			switch (btn.Name)
			{
				case "m_btnYes":
					this.DialogResult = DialogResult.OK;
					break;
				case "m_btnNo":
					this.DialogResult = DialogResult.Cancel;
					break;
			}
    }
  }
}
