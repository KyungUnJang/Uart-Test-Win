using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace uhf.Comm
{
  public class SerialSlave
  {
    public SerialPort comm;
    //private Thread threadRead;
    private bool bThreadRead = false;

    public const int MAX_BUFFER = 1024;

    public byte[] m_pBuffer = new byte[MAX_BUFFER];
    public int m_nBufferCnt;
    public bool m_bReceived;
    public bool m_bReceived2;
    public bool m_bUseEventWatiHandle;
    public EventWaitHandle waitRcv;


    public string m_sReceived;

    /* COM 포트 연결 */
    public bool Connect(int nPort, int nBaudRate, bool bWait = false)
    {
      if (comm != null)
      {
        Disconnect();
      }
      comm = new SerialPort();

      comm.PortName = "COM" + nPort;
      comm.BaudRate = nBaudRate;
      comm.Parity = Parity.None;
      comm.DataBits = 8;
      comm.StopBits = StopBits.One;
      comm.Handshake = Handshake.None;
      comm.ReadTimeout = -1;
      comm.WriteTimeout = -1;

      comm.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

      m_pBuffer = new byte[1024];
      m_nBufferCnt = 0;

      try
      {
        comm.Open();
      }
      catch
      {
        Console.WriteLine("COM{0} : not connected!", nPort);
        return false;
      }
      Console.WriteLine("COM{0} : connected! BaudRate({1})", nPort, nBaudRate);

      //threadRead = null;
      //threadRead = new Thread(Read);
      //bThreadRead = true;
      //threadRead.Start();
      m_bUseEventWatiHandle = bWait;
      if (m_bUseEventWatiHandle)
      {
        waitRcv = new EventWaitHandle(false, EventResetMode.AutoReset);
      }

      return true;
    }

    public bool Search(out string[] list)
    {
      list = null;
      string[] comlist = System.IO.Ports.SerialPort.GetPortNames();

      if (comlist.Length < 1) return false;

      list = (string[])comlist.Clone();

      return true;
    }

    private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
      SerialPort sp = (SerialPort)sender;

      //string str = sp.ReadExisting();
      if (comm == null || comm.IsOpen == false)
      {
        return;
      }

      while (comm.BytesToRead > 0)
      {
        if (m_nBufferCnt >= MAX_BUFFER)
        {
          System.Array.Clear(m_pBuffer, 0, MAX_BUFFER);
          m_nBufferCnt = 0;
          return;
        }

        byte readbyte = (byte)comm.ReadByte();

        switch (readbyte)
        {
          default:
            m_pBuffer[m_nBufferCnt++] = readbyte;
            break;
          case Define.CR:
            m_bReceived = true;

            m_pBuffer[m_nBufferCnt] = 0x00;
            m_sReceived = kFunc.Parsing.byte2str(m_pBuffer);
            Console.WriteLine("Slave RX : {0}", m_sReceived);

            if (m_bUseEventWatiHandle)
            {
              waitRcv.Set();
            }

            break;
        }
      }
    }

    public void Disconnect()
    {
      //bThreadRead = false;
      //threadRead.Join();
      comm.Close();
    }

    public void Read()
    {
      while (bThreadRead)
      {
#if false
				try
				{
					string message = comm.ReadLine();
					Console.WriteLine("RX : {0}", message);
				}
				catch (TimeoutException) { }
#endif
      }
    }

    public void ResetBuffer()
    {
      System.Array.Clear(m_pBuffer, 0, MAX_BUFFER);
      m_nBufferCnt = 0;
      m_sReceived = "";
      m_bReceived = false;
    }

    public void Write(string str)
    {
      if (comm == null || comm.IsOpen == false) return;

      comm.Write(str);
    }

    public void WriteAscii(byte data)
    {
      if (comm == null || comm.IsOpen == false) return;
      byte[] b;
      b = new byte[10];

      b[0] = data; //STX
      comm.Write(b, 0, 1);
    }

    public void Test()
    {
      byte[] b;

      string str;
      str = String.Format("{0:c}{1:c}{2:c}", 0x02, 0x74, 0x03);
      b = new byte[10];

      b[0] = 0x02;
      b[1] = 0x74;
      b[2] = 0x03;
      comm.Write(b, 0, 3);

      //comm.Write(str);
      //comm.Write()
    }
  }
}

