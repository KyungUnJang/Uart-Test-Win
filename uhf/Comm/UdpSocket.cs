using System;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics; //debug log

namespace uhf.Comm
{
  public class UdpSocket
	{
    public struct UdpState
    {
      public UdpClient u;
      public IPEndPoint e;
    }

    public UdpState m_udp;

    public bool m_bDebugPrint = false;
    public bool messageReceived = false;

    public string ReceiveCallback(IAsyncResult ar)
    {
      UdpClient u = ((UdpState)(ar.AsyncState)).u;
      IPEndPoint e = ((UdpState)(ar.AsyncState)).e;

      byte[] receiveBytes = u.EndReceive(ar, ref e);
      string receiveString = Encoding.ASCII.GetString(receiveBytes);

      if (m_bDebugPrint)
      {
        Console.WriteLine($"Received: {receiveString}");
      }

      return receiveString;
    }

    public void Init(string ip, int port)
		{
			IPEndPoint e;
			if(ip == "")
			{
				e = new IPEndPoint(IPAddress.Any, port);
			} else {
				e = new IPEndPoint(IPAddress.Parse(ip), port);
			}
			
      UdpClient u = new UdpClient(e);
			m_udp = new UdpState();

      m_udp.e = e;
      m_udp.u = u;
		}

		public void Send(string str)
		{
			byte[] p;
			byte n;

			p = kFunc.Parsing.str2byte(str);
			n = (byte)p.Length;

			m_udp.u.Send(p, n, m_udp.e);
		}

		
		public void Send(string ip, int port, string str)
		{
			byte[] p;
			byte n;

			p = kFunc.Parsing.str2byte(str);
			n = (byte)p.Length;

			UdpClient udpSend;
      udpSend = new UdpClient();

      IPEndPoint ipEndPoint;
			if(ip == "")
				ipEndPoint = new IPEndPoint(IPAddress.Any, port) ;
			else
				ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), port) ;
			udpSend.Send(p, n, ipEndPoint);
		}
  }
}
