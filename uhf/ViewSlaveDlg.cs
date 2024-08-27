using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection; //for grid double buffer

namespace uhf
{
  public partial class ViewSlaveDlg : UserControl
  {
    //post message
    public const int msg_trace = 1;

    public enum eCol
    {
      Name,
      Param1,
      Param2,
      Protocol,
      Send,
      Return,
      MAX,
    }

    public enum eType
    {
      set,
      get,
    }

    public enum eParamType
    {
      D, //decimal
      X, //hexa
      ID_COMBO, //ID COMBOBOX 8개 콤보박스
      SENSOR_DATA, //sensor data +/-XX.X
      N, //none
    }

    public enum eIdCombo
    {
      NTC_SEN_ID,
      PHASE_3_VOL_ID,
      PHASE_2_VOL_ID,
      PREASURE_ID,
      WATER_LEAK_ID,
      VIB_ID,
      UL_SONIC_ID,
      PHASE_3_CUR_ID,
      PHASE_2_CUR_ID,
      max,
    }

    public struct ST_GRID
    {
      public int type;
      public string name;
      public string protocol;
      public bool param1;
      public int param1_len;
      public int param1_type;
      public ulong param1_limit;
      public bool param2;
      public int param2_len;
      public ulong param2_limit;
      public int param2_type;

      public ST_GRID(int type, string name, string protocol,
        bool param1, int param1_len, int param1_type, ulong param1_limit,
        bool param2, int param2_len, int param2_type, ulong param2_limit)
      {

        this.type = type;
        this.name = name;
        this.protocol = protocol;
        this.param1 = param1;
        this.param1_len = param1_len;
        this.param1_type = param1_type;
        this.param1_limit = param1_limit;
        this.param2 = param2;
        this.param2_len = param2_len;
        this.param2_limit = param2_limit;
        this.param2_type = param2_type;
      }
    }

    public ST_GRID[] m_st =
    {
      new ST_GRID((int)eType.set, "CH_A_GO_STOP", "LR ", true, 1, (int)eParamType.D, 9999, false, 0, (int)eParamType.N, 0),
      new ST_GRID((int)eType.set, "CH_A_GO_START", "LC ", true, 1, (int)eParamType.D, 9999, false, 0, (int)eParamType.N, 0),
      new ST_GRID((int)eType.set, "CH_C_GO_STOP", "RR ", true, 1, (int)eParamType.D, 9999, false, 0, (int)eParamType.N, 0),
      new ST_GRID((int)eType.set, "CH_C_GO_START", "RC ", true, 1, (int)eParamType.D, 9999, false, 0, (int)eParamType.N, 0),
      new ST_GRID((int)eType.set, "EMG_STOP", "ES", false, 0, (int)eParamType.D, 0, false, 0, (int)eParamType.N, 0),
      new ST_GRID((int)eType.set, "CH_A_START_SET", "LS", false, 0, (int)eParamType.D, 0, false, 0, (int)eParamType.N, 0),
      new ST_GRID((int)eType.set, "CH_A_END_SET", "LE", false, 0, (int)eParamType.D, 0, false, 0, (int)eParamType.N, 0),
      new ST_GRID((int)eType.set, "CH_C_START_SET", "RS", false, 0, (int)eParamType.D, 0, false, 0, (int)eParamType.N, 0),
      new ST_GRID((int)eType.set, "CH_C_END_SET", "RE", false, 0, (int)eParamType.D, 0, false, 0, (int)eParamType.N, 0),
      new ST_GRID((int)eType.set, "INIT_SET", "RI", false, 0, (int)eParamType.D, 0, false, 0, (int)eParamType.N, 0),
      new ST_GRID((int)eType.set, "EEP_TEST", "RT", false, 0, (int)eParamType.D, 0, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.set, "Volt_Ctrl", "SV ", true, 1, (int)eParamType.D, 24, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.set, "Duty_Ctrl", "SD ", true, 1, (int)eParamType.D, 100, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.get, "PULSET_state", "GP", false, 0, (int)eParamType.N, 0, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.get, "LED_state", "GL", false, 0, (int)eParamType.N, 0, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.get, "Buzz_state", "GB", false, 0, (int)eParamType.N, 0, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.get, "Sol_state", "GS", false, 0, (int)eParamType.N, 0, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.get, "Freq_value", "GF", false, 0, (int)eParamType.N, 0, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.get, "Volt_val", "GV", false, 0, (int)eParamType.N, 0, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.get, "Duty_value", "GD", false, 0, (int)eParamType.N, 0, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.get, "GET_pressure", "GR", false, 0, (int)eParamType.N, 0, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.get, "Hand_det", "GH", false, 0, (int)eParamType.N, 0, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.get, "Emg_state", "GK", false, 0, (int)eParamType.N, 0, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.get, "V_sen", "GC", false, 0, (int)eParamType.N, 0, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.get, "Sol_value", "GO", false, 0, (int)eParamType.N, 0, false, 0, (int)eParamType.N, 0),

      //new ST_GRID((int)eType.get, "Group-Get", "GG", false, 0, (int)eParamType.N, 0, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.set, "Node-Set", "SN", true, 2, (int)eParamType.D, 9, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.get, "Node-Get", "GN", false, 0, (int)eParamType.N, 0, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.set, "Channel-Set", "SC", true, 2, (int)eParamType.D, 10, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.get, "Channel-Get", "GC", false, 0, (int)eParamType.N,  0, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.set, "TxPower-Set", "SP", true, 2, (int)eParamType.D, 18, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.get, "TxPower-Get", "GP", false, 0, (int)eParamType.N, 0, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.set, "TxTime-Set", "ST", true, 2, (int)eParamType.D, 59, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.get, "TxTime-Get", "GT", false, 0, (int)eParamType.N, 0, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.set, "RfCal-Set", "SR", true, 4, (int)eParamType.X, 0xffff, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.get, "RfCal-Get", "GR", false, 0, (int)eParamType.N, 0, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.get, "Sleep-Get", "GJ", false, 0, (int)eParamType.N, 0, false, 0, (int)eParamType.N, 0), //추가 220516
      //new ST_GRID((int)eType.set, "ContTx-Set", "CT", true, 2, (int)eParamType.D, 10, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.set, "Reset-Set", "RS", false, 0, (int)eParamType.N, 0, false, 0, (int)eParamType.N, 0), //삭제 220516
      //new ST_GRID((int)eType.set, "SensorData-Set", "SD", true, 2, (int)eParamType.ID_COMBO, 0, true, 4, (int)eParamType.SENSOR_DATA, 0),
      //new ST_GRID((int)eType.set, "SensorData-Set", "SD", true, 2, (int)eParamType.D, 9, true, 4, (int)eParamType.SENSOR_DATA, 0),
      //new ST_GRID((int)eType.get, "SensorData-Get", "GD", false, 0, (int)eParamType.N, 0, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.set, "SN-Set", "SS", true, 16, (int)eParamType.X, 0xffffffffffffffff, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.get, "SN-Get", "GS", false, 0, (int)eParamType.N, 0, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.set, "LED-Set", "SL", true, 2, (int)eParamType.D, 1, false, 0, (int)eParamType.N, 0),
      //new ST_GRID((int)eType.get, "LED-Get", "GL", false, 0, (int)eParamType.N, 0, false, 0, (int)eParamType.N, 0),
    };


    public ViewSlaveDlg()
    {
      InitializeComponent();
    }

    private void ViewSlaveDlg_Load(object sender, EventArgs e)
    {
      tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      InitGrid();
      SetGrid();
    }

		public void UpdateProtocol(int row)
    {
      string protocol = m_st[row].protocol;

      if (m_st[row].param1)
      {
        protocol += Param2Str(row, (int)eCol.Param1, dataGridView1.Rows[row].Cells[(int)eCol.Param1].Value);
      }
      if (m_st[row].param2)
      {
        protocol += Param2Str(row, (int)eCol.Param2, dataGridView1.Rows[row].Cells[(int)eCol.Param2].Value);
      }
      protocol = protocol.Replace(".", "");
      //var x = Regex.Replace(tags, @"(\[|""|\])", "");

      dataGridView1.Rows[row].Cells[(int)eCol.Protocol].Value = protocol;
    }

    public string Param2Str(int row, int col, object obj)
    {
      int type;
      int len;
      int n = 0;
      double d = 0.0;

      if (col == (int)eCol.Param1)
      {
        type = m_st[row].param1_type;
        len = m_st[row].param1_len;
      } else if (col == (int)eCol.Param2) {
        type = m_st[row].param2_type;
        len = m_st[row].param2_len;
      } else {
        return "";
      }

      string sType = "";
      string sReturn = "";
      switch(type)
      {
        case (int)eParamType.D:
          sType = string.Format("{0}{1}", Enum.GetName(typeof(eParamType), type), len);
          n = Int32.Parse(obj.ToString());
          sReturn = n.ToString(sType);
          break;
        case (int)eParamType.X:
          sType = string.Format("{0}{1}", Enum.GetName(typeof(eParamType), type), len);
          n = kFunc.Parsing.hexstr2int(obj.ToString());
          sReturn = n.ToString(sType);
          break;
        case (int)eParamType.SENSOR_DATA:
          sType = "0";
          d = double.Parse(obj.ToString());
          if (d >= 0.0)
            sReturn = "+";
          sReturn = d.ToString(sType);
          break;
        case (int)eParamType.ID_COMBO:
          return "";
        case (int)eParamType.N:
          return "";
      }
      dataGridView1.Rows[row].Cells[col].Value = sReturn;

      return sReturn;
    }

    public void InitGrid()
    {
      int i;

      if (dataGridView1.Rows.Count > 0)
      {
        dataGridView1.Rows.Clear();
        dataGridView1.Refresh();
      }

      //column 갯수
      dataGridView1.ColumnCount = (int)eCol.MAX;

      //타이틀  column 추가
      i = 0;
      foreach (eCol col in Enum.GetValues(typeof(eCol)))
      {
        dataGridView1.Columns[i].HeaderText = col.ToString();
        i++;
        if ((i == dataGridView1.ColumnCount) == true) break;
      }

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
      dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 70); //배경색
      dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White; //글자색

      //column 폭 dock 사이즈에 맞게 증가
      dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

      //row 높이 
      dataGridView1.RowTemplate.Height = 60;

      //첫 row 제거
      dataGridView1.RowHeadersVisible = false;
      dataGridView1.AllowUserToAddRows = false;

      //dataGridView1에 에디트모드
      dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;  //프로그램으로만 입력되게 //UI에서 값을 직접 입력못하도록 함
                                                                           //dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;  //combobox 원클릭 시
                                                                           //if(nRow > 0) return;

      //전체 컬러 변경
      dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;

      //row height 사이즈 조정 안되게
      dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
      dataGridView1.AllowUserToResizeRows = false;

      // 전체적으로 폰트 적용하기
      dataGridView1.Font = new Font("맑은고딕", 13, FontStyle.Bold);
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

      //버벅거릴때
#if true
      if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
      {
        Type dgvType = dataGridView1.GetType();

        PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
        pi.SetValue(dataGridView1, true, null);
      }
#endif
			
      //타이틀 column 폭 비율 조정
      double size = (double)dataGridView1.Size.Width * 0.97;
      //비율에 맞게 자동 지정
      double[] colSize;
      double colSum = 0.0;
      colSize = new double[(int)eCol.MAX];
      colSize[(int)eCol.Name] = 1.0;
      colSize[(int)eCol.Param1] = 1.5;
      colSize[(int)eCol.Param2] = 1.5;
      colSize[(int)eCol.Protocol] = 2.0;
      colSize[(int)eCol.Send] = 0.5;
      colSize[(int)eCol.Return] = 2.0;

      for (i = 0; i < (int)eCol.MAX; i++)
        colSum += (int)colSize[i];

      for (i = 0; i < (int)eCol.MAX; i++)
        dataGridView1.Columns[i].Width = (int)(size * colSize[i] / colSum);

      //셀 선택 안함
      //dataGridView1.Enabled = false;
      //dataGridView1.ClearSelection();
    }

		public void SetGrid()
    {
      string[] pStr;
      for(int i = 0; i < m_st.Length; i++)
      {
        string protocol;

        pStr = new string[(int)eCol.MAX];

        pStr[(int)eCol.Name] = m_st[i].name;
        pStr[(int)eCol.Param1] = "-";
        pStr[(int)eCol.Param2] = "-";

        protocol = m_st[i].protocol;

        if (m_st[i].param1)
        {
          //protocol += pStr[(int)eCol.Param1] = ("0").ToString("D" + m_st[i].param1_len.ToString());
        }

        AddRow(pStr);

        //button add
        if (m_st[i].param1)
        {
          if (m_st[i].type == (int)eType.set)
          {
            if (m_st[i].param1_type == (int)eParamType.ID_COMBO)
            {
							DataGridViewComboBoxCell cb = new DataGridViewComboBoxCell();
              //dataGridView1.Rows[i].Cells[(int)eCol.Param1] = new DataGridViewComboBoxCell();

              cb.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
              cb.ValueType = typeof(eIdCombo);
              cb.DataSource = Enum.GetValues(typeof(eIdCombo));
              cb.Value = eIdCombo.NTC_SEN_ID;
							dataGridView1.Rows[i].Cells[(int)eCol.Param1] = cb;
            } else {
              dataGridView1.Rows[i].Cells[(int)eCol.Param1] = new DataGridViewButtonCell();
              dataGridView1.Rows[i].Cells[(int)eCol.Param1].Value = Param2Str(i, (int)eCol.Param1, "0");
            }
          }
        }

        if (m_st[i].param2)
        {
          if (m_st[i].type == (int)eType.set)
          {
            if (m_st[i].param2_type == (int)eParamType.ID_COMBO)
            {
              DataGridViewComboBoxCell cb = new DataGridViewComboBoxCell();
              //dataGridView1.Rows[i].Cells[(int)eCol.Param2] = new DataGridViewComboBoxCell();
              dataGridView1.Rows[i].Cells[(int)eCol.Param2].Value = eIdCombo.NTC_SEN_ID;
              cb.ValueType = typeof(eIdCombo);
              cb.DataSource = Enum.GetValues(typeof(eIdCombo));
              cb.Value = eIdCombo.NTC_SEN_ID;
              dataGridView1.Rows[i].Cells[(int)eCol.Param2] = cb;
            } else {
              dataGridView1.Rows[i].Cells[(int)eCol.Param2] = new DataGridViewButtonCell();
              dataGridView1.Rows[i].Cells[(int)eCol.Param2].Value = Param2Str(i, (int)eCol.Param2, "0");
            }
          }
        }

        dataGridView1.Rows[i].Cells[(int)eCol.Send] = new DataGridViewButtonCell();
        dataGridView1.Rows[i].Cells[(int)eCol.Send].Value = "Send";

        UpdateProtocol(i);
      }
    }

    public void AddRow(string[] pStr)
    {
      dataGridView1.Rows.Add(pStr);
    }

    public void GridButtonClick(int row, int col)
    {
      switch (col)
      {
        case (int)eCol.Param1:
          if (m_st[row].param1_type == (int)eParamType.D)
          {
            int n = Int32.Parse(dataGridView1.Rows[row].Cells[col].Value.ToString());
            if (Pad.NumPadFunc.ShowInt(0, (int)m_st[row].param1_limit, ref n))
            {
              dataGridView1.Rows[row].Cells[col].Value = n;
              UpdateProtocol(row);
            }
          }
          else if (m_st[row].param1_type == (int)eParamType.X)
          {
            string s = dataGridView1.Rows[row].Cells[col].Value.ToString();
            if (Pad.EditPadFunc.ShowPad(ref s))
            {
              if (CheckStringHexaLength(s, m_st[row].param1_len))
              {
                dataGridView1.Rows[row].Cells[col].Value = s;
                UpdateProtocol(row);
              } else {
                Point pt = new Point();
                pt.X = Location.X + Size.Width / 2;
                pt.Y = Location.Y + Size.Height / 2;
                View.m_pMsgDlg.ShowMsgTimeout(pt, "Range Over!", 1000, Color.OrangeRed);
              }
            }
          }
          else if (m_st[row].param1_type == (int)eParamType.SENSOR_DATA)
          {
            double d = double.Parse(dataGridView1.Rows[row].Cells[col].Value.ToString());
            if (Pad.NumPadFunc.ShowDouble(0, 100, 2, ref d))
            {
              dataGridView1.Rows[row].Cells[col].Value = d;
              UpdateProtocol(row);
            }
          }
          break;
        case (int)eCol.Param2:
          if (m_st[row].param2_type == (int)eParamType.D)
          {
            int n = Int32.Parse(dataGridView1.Rows[row].Cells[col].Value.ToString());
            if (Pad.NumPadFunc.ShowInt(0, (int)m_st[row].param2_limit, ref n))
            {
              dataGridView1.Rows[row].Cells[col].Value = n;
              UpdateProtocol(row);
            }
          }
          if (m_st[row].param2_type == (int)eParamType.X)
          {
            string s = dataGridView1.Rows[row].Cells[col].Value.ToString();
            if (Pad.EditPadFunc.ShowPad(ref s))
            {
              if (CheckStringHexaLength(s, m_st[row].param2_len))
              {
                dataGridView1.Rows[row].Cells[col].Value = s;
                UpdateProtocol(row);
              } else {
                Point pt = new Point();
                pt.X = Location.X + Size.Width / 2;
                pt.Y = Location.Y + Size.Height / 2;
                View.m_pMsgDlg.ShowMsgTimeout(pt, "Range Over!", 1000, Color.OrangeRed);
              }
            }
          } else if (m_st[row].param2_type == (int)eParamType.SENSOR_DATA) {
            double d = double.Parse(dataGridView1.Rows[row].Cells[col].Value.ToString());
            if (Pad.NumPadFunc.ShowDouble(-99.9, 99.0, 1, ref d))
            {
              dataGridView1.Rows[row].Cells[col].Value = d;
              UpdateProtocol(row);
            }
          }
          break;
        case (int)eCol.Send:
          break;
      }
    }

    public bool CheckStringHexaLength(string str, int length) 
    {
      if (str.Length != length) return false;

      return System.Text.RegularExpressions.Regex.IsMatch(str, @"\A\b[0-9a-fA-F]+\b\Z");
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      var senderGrid = (DataGridView)sender;
      int row = e.RowIndex;
      int col = e.ColumnIndex;

      if (row < 0) return;
      if (row >= dataGridView1.RowCount) return;
      if (col < 0) return;
      if (col >= dataGridView1.ColumnCount) return;






        if (dataGridView1.Rows[row].Cells[col] is DataGridViewButtonCell)
        {
          if (col != (int)eCol.Send) 
          {
            GridButtonClick(e.RowIndex, e.ColumnIndex);
          } else { //if send
          dataGridView1.Rows[row].Cells[(int)eCol.Return].Value = "Wait...";

          string send = dataGridView1.Rows[row].Cells[(int)eCol.Protocol].Value.ToString();

                    string ret;
          if(View.m_pSlaveComDrv.Send(send, out ret))
          {
            dataGridView1.Rows[row].Cells[(int)eCol.Return].Value = ret;
						
						this.Invoke(new MethodInvoker(delegate ()
            {
							MsgBox.MsgFunc.OnPostStr(this.Handle, (IntPtr)msg_trace, ret);
            }));

          } else {
            dataGridView1.Rows[row].Cells[(int)eCol.Return].Value = "ERROR";
          }
        }
      }

      if (dataGridView1.Rows[row].Cells[col] is DataGridViewComboBoxCell)
      {
        if (col != (int)eCol.Send) 
        {
          //GridComboClick(e.RowIndex, e.ColumnIndex);
        } else {

        }
      }
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
            
        
    }

			
		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
			string str = "";
			if (m.Msg == MsgBox.MsgFunc.WM_MSG)
			{
				Point pt = new Point();
				pt.X = Location.X + Size.Width / 2;
				pt.Y = Location.Y + Size.Height / 2;

				switch ((int)m.WParam)
				{
					case msg_trace:
            DateTime datetime = DateTime.Now; ;
						str = string.Format("{0} : {1}", datetime.ToString("yyyyMMdd HH:mm:ss.fff"), kFunc.Parsing.intptr2str(m.LParam));

						m_listboxTrace.Items.Add(str);
						m_listboxTrace.SelectedIndex = m_listboxTrace.Items.Count - 1;
						break;
				}
			}

			base.WndProc(ref m);
		}

    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {

    }

    private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {

    }

    private void m_btnSleepOn_ClickEvent(object sender, EventArgs e)
		{
			AxBTNENHLib4.AxBtnEnh btn = (AxBTNENHLib4.AxBtnEnh)sender;
      string ret;

			switch(btn.Name)
			{

                case "m_btnSleepOn":
          btn.TextDescrCaption.Text = "Sleep On\nWait...";
          if(View.m_pSlaveComDrv.Send("SJ01", out ret))
					{
						btn.TextDescrCaption.Text = string.Format("TEMP\n{0}", ret);
					} else {
						btn.TextDescrCaption.Text = string.Format("TEMP\nERROR");
					}
					break;
				case "m_btnSleepOff":
          btn.TextDescrCaption.Text = "Sleep Off\nWait...";
          if(View.m_pSlaveComDrv.Send("SJ00", out ret))
					{
						btn.TextDescrCaption.Text = string.Format("TEMP\n{0}", ret);
					} else {
						btn.TextDescrCaption.Text = string.Format("TEMP\nERROR");
					}
					break;

				case "m_btnBoardReset":
          btn.TextDescrCaption.Text = "Board Reset\nWait...";
          if(View.m_pSlaveComDrv.Send("RS", out ret))
					{
						btn.TextDescrCaption.Text = string.Format("Board Reset\n{0}", ret);
					} else {
						btn.TextDescrCaption.Text = string.Format("Board Reset\nERROR");
					}
					break;
			}
		}
  }
}
