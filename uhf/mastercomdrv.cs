using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace uhf
{
  public class MasterComDrv
  {
    public Comm.SerialMaster m_comm;
    private static object m_lock = new object(); //critical section
    public bool m_bDebugPrint;

    public int m_nErrorCount;

    public bool Init(bool bAuto)
    {


      m_bDebugPrint = true;

      m_comm = new Comm.SerialMaster();

      m_nErrorCount = 0;

      int nPort = 0;
      int nBaudRate;
      string str = ((ParamSys.SERIAL_BAUDRATE)ParamSys.m_o[(int)ParamSys.e.serial_baudrate_master]).ToString();
      str = str.Substring(1, str.Length - 1);
      Int32.TryParse(str, out nBaudRate);

      if (!bAuto)
      {
        nPort = (int)ParamSys.m_o[(int)ParamSys.e.serial_comport_master] + 1;
        if (!m_comm.Connect(nPort, nBaudRate, false))
        {
          return false;
          //fail
        } else {
        }
      } else { //auto search 
				kFunc.UsbInfo.Win32DeviceMgmt();
				List<kFunc.UsbInfo.DeviceInfo> usbinfo = kFunc.UsbInfo.GetAllCOMPorts();

				foreach (kFunc.UsbInfo.DeviceInfo info in usbinfo)
				{
          if(info.bus_description.ToLower() == "Master_usb")
          {
            string s = info.name.Substring(3);
            nPort = Convert.ToInt32(s);
            break;
          }
				}

        if (!m_comm.Connect(nPort, nBaudRate, false))
        {
          return false;
          //fail
        } else {
        }
      }

      return true;
    }

    public bool WaitRx(out byte[] pData)
    {
      string str;

      long clock;
      kFunc.Clock.setclock(out clock);

      if (m_comm.m_bUseEventWatiHandle)
      {
        bool b = m_comm.waitRcv.WaitOne(2000);
        if (!b)
        {
          m_nErrorCount++;
          pData = null;

          str = string.Format("MasterComDrv = RX : Timeout");
          if (m_bDebugPrint) { Debug.WriteLine(str); }

          if ((int)ParamSys.m_o[(int)ParamSys.e.log_serial] == 1)
          {
            Logs.Log.WriteDebugLog("MasterComDrv", str);
          }

          return false;
        }
      } else {
        while (!m_comm.m_bReceived)
        {
          if (kFunc.Clock.calclock2ms(clock) >= 2000)
          {
            m_nErrorCount++;
            pData = null;

            str = string.Format("MasterComDrv = RX : Timeout(" + kFunc.Clock.calclock2ms(clock) + "ms)");
            if (m_bDebugPrint) { Debug.WriteLine(str); }

            if ((int)ParamSys.m_o[(int)ParamSys.e.log_serial] == 1)
            {
              Logs.Log.WriteDebugLog("MasterComDrv", str);
            }

            return false;
          }
          System.Threading.Thread.Sleep(1);
        }
      }

      pData = (byte[])m_comm.m_pBuffer.Clone();
      str = string.Format("MasterComDrv = RX : " + kFunc.Parsing.byte2str(pData) + " (" +
            kFunc.Clock.calclock2ms(clock) + "ms)");
      if (m_bDebugPrint) { Debug.WriteLine(str); }

      if ((int)ParamSys.m_o[(int)ParamSys.e.log_serial] == 1)
      {
        Logs.Log.WriteDebugLog("MasterComDrv", str);
      }

      return true;
    }

    public bool SleepTime(string str)
    {
      if (!m_comm.comm.IsOpen) return false;

      lock (m_lock)
      {
        byte[] pData = new byte[Comm.Serial.MAX_BUFFER];
        m_comm.ResetBuffer();
				//string s = string.Format("{0:c}{1}{2:c}", 0x02, str, 0x03);
				string s = string.Format("{0:c}{1}{2:c}", 0x02, str, 0x03);

        m_comm.WriteAscii(Define.STX);
        m_comm.Write(str);
        m_comm.WriteAscii(Define.ETX);

				string sLog;
				sLog = string.Format("MasterComDrv = TX : {0}", s);
        if (m_bDebugPrint) { Debug.WriteLine(sLog); }

				if ((int)ParamSys.m_o[(int)ParamSys.e.log_serial] == 1)
				{
					Logs.Log.WriteDebugLog("MasterComDrv", sLog);
				}
      }
      return true;
    }
  }
}

