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
  public partial class EditPadDlg : Form
  {
		public string m_sOrigin;
    public string m_sReturn;

    public EditPadDlg(string s)
    {
      InitializeComponent();
      kFunc.Func.SetBtnAntialiasDisable(this);
      DoubleBuffered = true;

      textBox1.Text = m_sOrigin = s;
    }

    private void m_btnEnter_ClickEvent(object sender, EventArgs e)
    {
			AxBTNENHLib4.AxBtnEnh btn = (AxBTNENHLib4.AxBtnEnh)sender;

      switch (btn.Name)
      {
        case "m_btnEnter":
          EnterClick();
          break;
        case "m_btnCancel":
          CancelClick();
          break;
      }
    }

		public void EnterClick()
		{
      m_sReturn = textBox1.Text;
			this.DialogResult = DialogResult.OK;
		}

		public void CancelClick()
		{
			this.DialogResult = DialogResult.Cancel;
		}

    private void EditPadDlg_KeyDown(object sender, KeyEventArgs e)
    {
			switch(e.KeyCode)
			{
				case Keys.Enter:
					EnterClick();
					break;
				case Keys.Escape:
					CancelClick();
					break;
			}
    }
  }
}
