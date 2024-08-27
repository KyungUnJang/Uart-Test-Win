using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uhf
{
  public partial class ParamForm : Form
  {
    public enum eCol
    {
      Object,
      Name,
      Min,
      Max,
      Default,
      Data,
      MAX,
    }

    /* param modify start */
    public enum eTab
    {
      system,
      function,
      MAX,
    }
    /* param modify end */

		int m_nCurrentTab;

		//post message
		public const int msg_eep_not_match = 0;

    public ParamForm()
    {
      InitializeComponent();
      kFunc.Func.SetBtnAntialiasDisable(this);

      Init();
    }

    public void Init()
    {
      InitGrid();

			m_nCurrentTab = -1;
      m_btnTab1.SetValueEx(1);
			SetTab(0);

#if false //checkbox test
      dataGridView1.Rows[0].Cells[0].Value = null;
      DataGridViewCheckBoxCell c= new DataGridViewCheckBoxCell();
      c.FalseValue = "0";
      c.TrueValue = "1";
      c.Style.NullValue = false;
      dataGridView1.Rows[0].Cells[0] = c;
#endif

#if false//combobox test
      dataGridView1.Rows[0].Cells[0].Value = null;
      DataGridViewComboBoxCell c= new DataGridViewComboBoxCell();
      c.Items.Add("On");
      c.Items.Add("Off");
      dataGridView1.Rows[0].Cells[0] = c;
#endif

#if false
      for (int i = 0; i < dataGridView1.RowCount; i++)
      {
        for (int j = 0; j < dataGridView1.ColumnCount; j++)
        {
          dataGridView1.Rows[i].Cells[j].Value = null; //this is important.
          DataGridViewComboBoxCell c = new DataGridViewComboBoxCell();
          c.Items.Add("On");
          c.Items.Add("Off");
          dataGridView1.Rows[i].Cells[j] = c;
        }
      }
      dataGridView1.Invalidate();
#endif
    }

		public void InitGrid()
		{
      int i;

			//column 갯수
      dataGridView1.ColumnCount = (int)eCol.MAX;

      //타이틀  column 추가
      i = 0;
      foreach(eCol col in Enum.GetValues(typeof(eCol)))
      {
        dataGridView1.Columns[i].HeaderText = col.ToString();
        i++;
        if ((i == dataGridView1.ColumnCount) == true) break;
      }

			//타이틀 column 폭 비율 조정
			double size = (double)dataGridView1.Size.Width * 0.97;
			dataGridView1.Columns[(int)eCol.Object].Width  = (int)(size * 0.2);
			dataGridView1.Columns[(int)eCol.Name].Width 			= (int)(size * 0.2);
			dataGridView1.Columns[(int)eCol.Min].Width			= (int)(size * 0.1);
			dataGridView1.Columns[(int)eCol.Max].Width 			= (int)(size * 0.1);
			dataGridView1.Columns[(int)eCol.Default].Width = (int)(size * 0.2);
			dataGridView1.Columns[(int)eCol.Data].Width			= (int)(size * 0.2);

      //타이틀 컬러 변경
      dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(25, 25, 25);
      dataGridView1.EnableHeadersVisualStyles = false;

      //타이틀 높이
      dataGridView1.ColumnHeadersHeight = 45;
      dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

      //타이틀 글자색 변경
      dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

      //셀 내부 글자 정렬
      //dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

      //셀 선택 모드 (칸 선택, 칸 전체 선택 등)
      dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

      //셀 멀티 선택
      dataGridView1.MultiSelect = false;

      //셀 선택 색깔
      dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb( 70,  70,  70); //배경색
      dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White; //글자색

      //column 폭 dock 사이즈에 맞게 증가
      dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

      //row 높이 
      dataGridView1.RowTemplate.Height = 30;

			//첫 row 제거
			dataGridView1.RowHeadersVisible = false;
			dataGridView1.AllowUserToAddRows = false;

			//dataGridView1에 에디트모드
			dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;  //프로그램으로만 입력되게 //UI에서 값을 직접 입력못하도록 함
			//dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;  //combobox 원클릭 시
			//if(nRow > 0) return;

			//전체 컬러 변경
			//this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.Bisque;

			//row height 사이즈 조정 안되게
			dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
			dataGridView1.AllowUserToResizeRows = false;

			// 전체적으로 폰트 적용하기
			dataGridView1.Font = new Font("맑은고딕", 15, FontStyle.Bold);
			// Colum 의 해더부분을 지정하기
			//dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
			// Row 해더부분을 지정하기
			//dataGridView1.RowHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
			// Cell 내용부분을 지정하기
			//dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);

			//정렬 취소(내림차순.. 등)
			foreach (DataGridViewColumn column in dataGridView1.Columns) 
			{
				column.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}

    public void SetTab(int nTab, bool bUpdate = false) 
    {
      if (bUpdate == false)
      {
        if (m_nCurrentTab == nTab) return;
      }

      //표 전체 클리어(타이틀 빼고)
      if (dataGridView1.Rows.Count > 0)
      {
        dataGridView1.Rows.Clear();
        dataGridView1.Refresh();
      }

      int nMax;
      Param.ST[] pSt;
      object[] pObj;

      /* param modify start */
      switch (nTab)
      {
        case (int)eTab.system:
          pSt = ParamSys.m_st;
          pObj = ParamSys.m_o;
          nMax = (int)ParamSys.e.max;
          break;
        case (int)eTab.function:
          pSt = ParamFunc.m_st;
          pObj = ParamFunc.m_o;
          nMax = (int)ParamFunc.e.max;
					break;
        default:
          return;
      }
      /* param modify end */

      string[] pStr = new string[(int)eCol.MAX];
      for (int i = 0; i < nMax; i++)
      {
        for (int j = 0; j < (int)eCol.MAX; j++)
        {
          switch (j)
          {
						case (int)eCol.Object:
              pStr[j] = pSt[i].section;
              break;
            case (int)eCol.Name:
              pStr[j] = pSt[i].key;
              break;
            case (int)eCol.Min:
              pStr[j] = pSt[i].min;
              break;
            case (int)eCol.Max:
              pStr[j] = pSt[i].max;
              break;
            case (int)eCol.Default:
              pStr[j] = pSt[i].default_;
              break;
            case (int)eCol.Data:
              pStr[j] = pObj[i].ToString();
              break;
          }
        }
        dataGridView1.Rows.Add(pStr);
				
        switch (pSt[i].type)
				{
					case (int)Param.eType.int_:
					case (int)Param.eType.byte_:
					case (int)Param.eType.double_:
					case (int)Param.eType.string_:
						break;
					case (int)Param.eType.check:
            //default value
						DataGridViewCheckBoxCell c = new DataGridViewCheckBoxCell();
						if (Convert.ToInt32(pSt[i].default_) == 1)
						{
							c.Value = true;
						} else { 
							c.Value = false;
						}
						dataGridView1.Rows[i].Cells[(int)eCol.Default] = c;

            //data value
						DataGridViewCheckBoxCell c2 = new DataGridViewCheckBoxCell();
						if (Convert.ToInt32(pObj[i]) == 1)
						{
							c2.Value = true;
						} else { 
							c2.Value = false;
						}
						dataGridView1.Rows[i].Cells[(int)eCol.Data] = c2;
						break;
					case (int)Param.eType.combo:
						DataGridViewComboBoxCell cb = new DataGridViewComboBoxCell(); 

             /* param modify start */ //for combobox
            switch (nTab)
						{
							case (int)eTab.system:
								switch(i)
								{
									case (int)ParamSys.e.serial_comport_master:


									case (int)ParamSys.e.serial_comport_slave:
                    dataGridView1.Rows[i].Cells[(int)eCol.Default].Value = ((ParamSys.SERIAL_COMPORT)Convert.ToInt32(pSt[i].default_)).ToString();
                    cb.ValueType = typeof(ParamSys.SERIAL_COMPORT);
                    cb.DataSource = Enum.GetValues(typeof(ParamSys.SERIAL_COMPORT));
                    cb.Value = (ParamSys.SERIAL_COMPORT)Convert.ToInt32(pObj[i]);
										break;
									case (int)ParamSys.e.serial_baudrate_master:
									case (int)ParamSys.e.serial_baudrate_slave:
                    dataGridView1.Rows[i].Cells[(int)eCol.Default].Value = ((ParamSys.SERIAL_BAUDRATE)Convert.ToInt32(pSt[i].default_)).ToString();
                    cb.ValueType = typeof(ParamSys.SERIAL_BAUDRATE);
                    cb.DataSource = Enum.GetValues(typeof(ParamSys.SERIAL_BAUDRATE));
                    cb.Value = (ParamSys.SERIAL_BAUDRATE)Convert.ToInt32(pObj[i]);
										break;
								}
                dataGridView1.Rows[i].Cells[(int)eCol.Data] = cb;
								break;
							case (int)eTab.function:
								break;
							default:
								return;
						}
            /* param modify end */
						break;
				}
      }

      m_nCurrentTab = nTab;
      SetParameterExplain(dataGridView1.CurrentRow.Index);
    }

    public void SetParameterExplain(int nRow) 
		{
      int nTab = m_nCurrentTab;
      Param.ST[] pSt;

			/* param modify start */
      switch (nTab)
      {
        case (int)eTab.system:
          pSt = ParamSys.m_st;
          break;
        case (int)eTab.function:
          pSt = ParamFunc.m_st;
          break;
        default:
          return;
      }
			/* param modify end */

      if (nRow < 0) return;
      if (nRow > pSt.Length - 1) return;
      m_btnExplain.TextDescrCaption.Text = pSt[nRow].explain;

      switch(pSt[nRow].level)
      {
        case (int)Param.eLevel.user:
          m_btnExplain.TextDescrLT.ColorNormal = kFunc.Colors.Color2Uint(Color.White);
          m_btnExplain.TextDescrLT.Text = "User Parameter";
          break;
        case (int)Param.eLevel.supervisor:
          m_btnExplain.TextDescrLT.ColorNormal = kFunc.Colors.Color2Uint(Color.LightCoral);
          m_btnExplain.TextDescrLT.Text = "Supervisor Parameter";
          break;
        case (int)Param.eLevel.read_only:
          m_btnExplain.TextDescrLT.ColorNormal = kFunc.Colors.Color2Uint(Color.Gray);
          m_btnExplain.TextDescrLT.Text = "Read Only Parameter";
          break;
      }
    }

		private void SetData(int nRow, int nCol, string str)
    {
      dataGridView1.Rows[nRow].Cells[nCol].Value = str;
    }

		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
			if (m.Msg == MsgBox.MsgFunc.WM_MSG)
			{
				Point pt = new Point();
				pt.X = View.m_pView.Location.X + View.m_pView.Size.Width / 2;
				pt.Y = View.m_pView.Location.Y + View.m_pView.Size.Height / 2;

				switch ((int)m.WParam)
				{
          case msg_eep_not_match:
						break;
        }
			}

			base.WndProc(ref m);
		}

    private void m_btnTab1_ClickEvent(object sender, EventArgs e) 
    {
      AxBTNENHLib4.AxBtnEnh btn;
			string str;
			int n;

			btn = (AxBTNENHLib4.AxBtnEnh)sender;

			str = btn.Name.Substring(btn.Name.Length - 1, 1);
			Int32.TryParse(str, out n);
			n -= 1;
			
		  /* param modify start */	
      switch(btn.Name)
      {
        case "m_btnTab1":
        case "m_btnTab2":
        case "m_btnTab3":
        case "m_btnTab4":
					SetTab(n);
          break;
      }
		  /* param modify end */	
    }

    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
      int nRow = dataGridView1.CurrentRow.Index;
      int nMaxRow = dataGridView1.Rows.Count;

      string str = string.Format("ParamTestForm : dataGridView1_SelectionChanged({0})", nRow);
      Logs.Log.trace(str);
      
      if (nRow < 0) return;
      if (nRow > nMaxRow - 1) return;

      //선택안되게
      //dataGridView1.ClearSelection();
      SetParameterExplain(nRow);
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      int nRow = e.RowIndex;
      int nCol = e.ColumnIndex;
      int nMaxRow = dataGridView1.Rows.Count;

      string str = string.Format("ParamTestForm : dataGridView1_CellClick({0}, {1})", nRow, nCol);
      Logs.Log.trace(str);

      if (nRow < 0) return;
      if (nRow > nMaxRow - 1) return;

      //combobox, checkbox 클릭시
      if ((nCol != (int)eCol.Data) == true) return;

      if ((dataGridView1.Rows[nRow].Cells[nCol].GetType() == typeof(DataGridViewComboBoxCell)) ||
         (dataGridView1.Rows[nRow].Cells[nCol].GetType() == typeof(DataGridViewCheckBoxCell)))
      {
        DataGridViewCell cell = dataGridView1.Rows[nRow].Cells[nCol];
        dataGridView1.CurrentCell = cell;
        dataGridView1.BeginEdit(true);
      } 
    }

    private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      int nRow = e.RowIndex;
      int nCol = e.ColumnIndex;
      int nMaxRow = dataGridView1.Rows.Count;

      string str = string.Format("ParamTestForm : dataGridView1_CellDoubleClick({0}, {1})", nRow, nCol);
      Logs.Log.trace(str);

      if (nRow < 0) return;
      if (nRow > nMaxRow - 1) return;

      bool bChanged = false;
#if true
      /* param modify start */
      switch (m_nCurrentTab)
			{
				case (int)eTab.system:
					switch(ParamSys.m_st[nRow].type)
					{
						case (int)Param.eType.int_:
						case (int)Param.eType.byte_:
							bChanged = ParamSys.NumPadInt(nRow);
							break;
						case (int)Param.eType.double_:
							bChanged = ParamSys.NumPadDbl(nRow);
							break;
						case (int)Param.eType.string_:
							bChanged = ParamSys.EditPad(nRow);
							break;
						case (int)Param.eType.check:
						case (int)Param.eType.combo:
							break;
						case (int)Param.eType.dir:
    					bChanged = ParamSys.Dir(nRow);
							break;
						case (int)Param.eType.file:
    					bChanged = ParamSys.File(nRow);
							break;
					}
          if(bChanged) dataGridView1.Rows[nRow].Cells[(int)eCol.Data].Value = ParamSys.m_o[nRow].ToString();
          if (bChanged) dataGridView1.Invalidate();
					break;
				case (int)eTab.function:
					switch(ParamFunc.m_st[nRow].type)
					{
						case (int)Param.eType.int_:
						case (int)Param.eType.byte_:
							bChanged = ParamFunc.NumPadInt(nRow);
							break;
						case (int)Param.eType.double_:
							bChanged = ParamFunc.NumPadDbl(nRow);
							break;
						case (int)Param.eType.string_:
							break;
						case (int)Param.eType.check:
						case (int)Param.eType.combo:
							break;
					}
          if (bChanged) dataGridView1.Rows[nRow].Cells[(int)eCol.Data].Value = ParamFunc.m_o[nRow].ToString();
          if (bChanged) dataGridView1.Invalidate();
          break;
				default:
					return;
			}
      /* param modify end */

#endif
#if false
      if (bChanged)
      {
        SetTab(m_nCurrentTab, true);
        dataGridView1.Rows[nRow].Selected = true;
      }
#endif
    }

    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) 
    {
      string str1, str2;

			Param.ST[] pSt;

		  /* param modify start */	
      switch (m_nCurrentTab)
      {
        case (int)eTab.system:
          pSt = ParamSys.m_st;
          break;
        case (int)eTab.function:
          pSt = ParamFunc.m_st;
          break;
        default:
          return;
      }
		  /* param modify end */	

      foreach(DataGridViewRow row in dataGridView1.Rows)
			{
        int nRow = row.Index;
			
        switch (pSt[nRow].level)
        {
          case (int)Param.eLevel.user:
            row.DefaultCellStyle.BackColor = Color.White;
            break;
          case (int)Param.eLevel.supervisor:
            row.DefaultCellStyle.BackColor = Color.Yellow;
            break;
          case (int)Param.eLevel.read_only:
            row.DefaultCellStyle.BackColor = Color.Gray;
            break;
        }

        str1 = row.Cells[(int)eCol.Default].Value.ToString();
				str2 = row.Cells[(int)eCol.Data].Value.ToString();

        if (string.Compare(str1, str2) != 0) //data가 default가 아니면
        {
          row.Cells[(int)eCol.Data].Style.ForeColor = Color.FromArgb(238, 52, 49);
          row.Cells[(int)eCol.Data].Style.SelectionForeColor = Color.FromArgb(238, 52, 49);

          //row.DefaultCellStyle.BackColor = Color.LightCoral;
        } 
        else
        {
          row.Cells[(int)eCol.Data].Style.ForeColor = Color.Black;
          row.Cells[(int)eCol.Data].Style.SelectionForeColor = Color.White;
        }
      }
    }

    private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
      if (dataGridView1.IsCurrentCellDirty)
      {
        // This fires the cell value changed handler below
        dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
      }
    }

    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      int nRow = e.RowIndex;
      int nCol = e.ColumnIndex;
      int nMaxRow = dataGridView1.Rows.Count;
			bool bChanged = false;
			int n = 0;

      string str = string.Format("ParamTestForm : dataGridView1_CellValueChanged({0}, {1})", nRow, nCol);
      Logs.Log.trace(str);

      if (nRow < 0) return;
      if (nRow > nMaxRow - 1) return;

      if ((nCol != (int)eCol.Data) == true) return;

      if (dataGridView1.Rows[nRow].Cells[nCol].GetType() == typeof(DataGridViewComboBoxCell))
      {
        // My combobox column is the second one so I hard coded a 1, flavor to taste

                
        DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dataGridView1.Rows[nRow].Cells[nCol];
        if (cb.Value != null)
        {
					bChanged = true;
          n = Convert.ToInt32(cb.Value);
        }
      }

                

      if (dataGridView1.Rows[nRow].Cells[nCol].GetType() == typeof(DataGridViewCheckBoxCell))
      {
        // My combobox column is the second one so I hard coded a 1, flavor to taste
        DataGridViewCheckBoxCell c = (DataGridViewCheckBoxCell)dataGridView1.Rows[nRow].Cells[nCol];
        if (c.Value != null)
        {
					bChanged = true;
          n = Convert.ToInt32(c.Value);
        }
      }

			if(bChanged)
			{
				/* param modify start */
				switch (m_nCurrentTab)
				{
					case (int)eTab.system:
						ParamSys.SaveInt(nRow, n);

            switch(nRow)
            {
              case (int)ParamSys.e.serial_comport_master:
                  
              case (int)ParamSys.e.serial_baudrate_master:
                if(View.m_pMasterComDrv.m_comm.comm.IsOpen)
                  View.m_pMasterComDrv.m_comm.Disconnect();
                View.m_pView.MasterConnect();
                break;
                  
              case (int)ParamSys.e.serial_comport_slave:
              case (int)ParamSys.e.serial_baudrate_slave:
                if(View.m_pSlaveComDrv.m_comm.comm.IsOpen)
                  View.m_pSlaveComDrv.m_comm.Disconnect();
                View.m_pView.SlaveConnect();
                break;
            }
						break;
					case (int)eTab.function:
						ParamFunc.SaveInt(nRow, n);
						break;
					default:
						return;
				}
				/* param modify end */

				dataGridView1.Invalidate();
			}
    }
  }
}
