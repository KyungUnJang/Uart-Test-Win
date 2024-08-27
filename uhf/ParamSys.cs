using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uhf
{
  class ParamSys
  {
    /* param modify start */
    public enum e
		{
			//섹션_키 : section_key 
			serial_comport_master,
			serial_baudrate_master,
			serial_comport_slave,
			serial_baudrate_slave,
			log_sys_trace,
			log_serial,
			max,
		}

    //for combobox
    public enum SERIAL_COMPORT
		{
			COM1,
			COM2,
			COM3,
			COM4,
			COM5,
			COM6,
			COM7,
			COM8,
			COM9,
			COM10,
			COM11,
			COM12,
			COM13,
			COM14,
			COM15,
			COM16,
			COM17,
			COM18,
			COM19,
			COM20,
			COM21,
			COM22,
			COM23,
			COM24,
			COM25,
			COM26,
			COM27,
			COM28,
			COM29,
			COM30,
            COM31,
            COM32,
            COM33,
            COM34,
            COM35,
            //MAX,
        }

		//for combobox
    public enum SERIAL_BAUDRATE
		{
			_9600,
			_19200,
			_28800,
			_38400,
			_57600,
			_76800,
			_115200,
			_230400,
			_460800,
			_576000,
			_921600,
      //MAX,
		}

    //ini 경로 
    static public string m_sPathIni = kFunc.Dir.GetRootDir() + "param\\paramSys.ini";
    static public string m_sPathCsv = kFunc.Dir.GetRootDir() + "param\\paramSys.csv";
    /* param modify end */

    //파라메터 변수
    public static object[] m_o = new object[(int)e.max];
    public static Param.ST[] m_st;


		static public void Init()
		{
			Param.LoadFromCsv(ref m_st, (int)e.max, m_sPathCsv);
			LoadFromIni();
		}

		static public void SaveToIni(bool bNew = false)
    {
			Param.SaveToIni(m_st, m_o, m_sPathIni, bNew);
    }

    static public void LoadFromIni()
    {
      if (!kFunc.Dir.FileExist(m_sPathIni))
      {
        SaveToIni(true);
      }
      Param.LoadFromIni(m_st, ref m_o, m_sPathIni);
    }

		//numpad 호출 - int type
		static public bool NumPadInt(int e) //numpad + eep save + save
		{
			int n, min, max;
			n = (int)m_o[e];
			min = Convert.ToInt32(m_st[e].min);
			max = Convert.ToInt32(m_st[e].max);

			if(Pad.NumPadFunc.ShowInt(min, max, ref n))
			{
				m_o[e] = n;
				SaveToIni();

				return true;
			}
			return false;
		}

    static public bool NumPadDbl(int e) //dotnum 0 ~ 8 //numpad + eep save + save
		{
			int ptnum;
			double min, max;
			double d;
			double dd;

			d = Convert.ToDouble(m_o[e]);
			ptnum = Convert.ToInt32(m_st[e].ptnum);
			min = Convert.ToDouble(m_st[e].min);
			max = Convert.ToDouble(m_st[e].max);

			dd = 1.0;
			for(int i = 0; i < ptnum; i++)
			{
				dd *= 10.0;
			}

			if(Pad.NumPadFunc.ShowDouble(min, max, ptnum, ref d))
			{
				m_o[e] = Math.Truncate(d * dd) / dd;
				SaveToIni();
				return true;
			}
			return false;
		}

    static public bool EditPad(int e)
		{
			string s;

			s = m_o[e].ToString();
			
      Pad.EditPadDlg dlg = new Pad.EditPadDlg(s);

      dlg.StartPosition = FormStartPosition.CenterParent;
      if (dlg.ShowDialog() == DialogResult.OK)
      {
				m_o[e] = dlg.m_sReturn;

				SaveToIni();

        return true;
      }
      return false;
    }

    static public bool Dir(int e)
		{
			string path = "";
			if(kFunc.Dir.OpenDir(out path))
			{
        m_o[e] = path;
				SaveToIni();
				return true;
			}
	
			return false;
		}

    static public bool File(int e)
		{
      string path;

      if (kFunc.Dir.OpenFile("c:\\", "*", out path))
      {
        m_o[e] = path;
				SaveToIni();
        return true;
      }
      return false;
		}
			
    static public bool SaveInt(int e, int n) 
		{
			int min, max;

			min = Convert.ToInt32(m_st[e].min);
			max = Convert.ToInt32(m_st[e].max);

			if(!(n >= min && n <= max)) return false;

			m_o[e] = n;
			SaveToIni();

			return true;
		}

    static public bool SaveDbl(int e, double d) 
		{
			int ptnum;
			double min, max;
			double dd;

			ptnum = Convert.ToInt32(m_st[e].ptnum);
			min = Convert.ToDouble(m_st[e].min);
			max = Convert.ToDouble(m_st[e].max);

			if(!(d >= min && d <= max)) return false;

			dd = 1.0;
			for(int i = 0; i < ptnum; i++)
			{
				dd *= 10.0;
			}

			m_o[e] = Math.Truncate(d * dd) / dd;
			SaveToIni();

			return true;
		}
  }
}
