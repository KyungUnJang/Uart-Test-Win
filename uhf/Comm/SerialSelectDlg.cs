using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Management;

namespace uhf.Comm
{
  public partial class SerialSelectDlg : Form
  {
    DataTable table;

    public int m_nReturn { get; set; }

    public SerialSelectDlg()
    {
      InitializeComponent();
      kFunc.Func.SetBtnAntialiasDisable(this);
      Init();
      m_nReturn = -1;
    }

    public void Init()
    {
      table = new DataTable();

      // column 추가
      table.Columns.Add("Port", typeof(string));

      dataGridView1.DataSource = table;

      //column 폭 비율 조정
      double size = (double)dataGridView1.Size.Width * 0.97;
      dataGridView1.Columns[0].Width = (int)(size * 1.0);

      //셀 내부 글자 정렬
      //dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

      //첫 row 제거
      dataGridView1.RowHeadersVisible = false;
      dataGridView1.AllowUserToAddRows = false;

      //dataGridView1에 UI에서 값을 직접 입력못하도록 함
      dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

      //전체 컬러 변경
      //this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.Bisque;

      //row height 사이즈 조정 안되게
      dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
      dataGridView1.AllowUserToResizeRows = false;

      // 전체적으로 폰트 적용하기
      dataGridView1.Font = new Font("굴림", 12, FontStyle.Bold);
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

      //("SELECT * FROM WIN32_SerialPort"))
#if true
      using (var searcher = new ManagementObjectSearcher
        ("root\\cimv2", "SELECT * FROM Win32_PnPEntity WHERE ClassGuid=\"{4d36e978-e325-11ce-bfc1-08002be10318}\""))
      {
        foreach (ManagementObject queryObj in searcher.Get())
        {
          string str;
          str = queryObj["Name"].ToString();
          if (str.Contains("COM"))
            AddRow(str);
        }

#if false
        string[] portnames = SerialPort.GetPortNames();
        var ports = searcher.Get().Cast<ManagementBaseObject>().ToList();
        var tList = (from n in portnames
                     join p in ports on n equals p["DeviceID"].ToString()
                     select n + " - " + p["Caption"]).ToList();

        string[] the_array = tList.Select(i => i.ToString()).ToArray();

        foreach (string str in the_array)
        {
          AddRow(str, "");
        }
#endif
      }
#endif
    }

    private void AddRow(string str)
    {
      table.Rows.Add(str);
    }

    private void SetData(int nRow, int nCol, string str)
    {
      dataGridView1.Rows[nRow].Cells[nCol].Value = str;
    }

    private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      int nRow = e.RowIndex;
      int nCol = e.ColumnIndex;
      int nMaxRow = dataGridView1.Rows.Count;

      if (nRow < 0) return;
      if (nRow > nMaxRow) return;

      int n;
      int nPort;
      string str;

      str = dataGridView1.Rows[nRow].Cells[nCol].Value.ToString();
      n = str.LastIndexOf("COM");

      str = str.Substring(n + 3);
      str = str.Remove(str.Length - 1);
      nPort = Int32.Parse(str);

      string s = string.Format("Would you like to reconnect to the COM{0} port?", nPort);
      if (MessageBox.Show(s, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        m_nReturn = nPort - 1;
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }
  }
}
