﻿using System;
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
  public partial class WarningMsgForm : Form
  {
    public WarningMsgForm(string str)
    {
      InitializeComponent();
			SetText(str);
      TopMost = true;
    }

    public void SetText(string str)
    {
      m_btn.TextDescrCaption.Text = str;
    }

    private void m_btnClose_ClickEvent(object sender, EventArgs e)
    {
      AxBTNENHLib4.AxBtnEnh btn = (AxBTNENHLib4.AxBtnEnh)sender;

      switch (btn.Name)
      {
        case "m_btnClose":
          this.DialogResult = DialogResult.OK;
          break;
      }
    }
  }
}
