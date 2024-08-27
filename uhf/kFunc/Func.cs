using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics; //for Process
using System.Net; //for WebClient

namespace uhf.kFunc
{
	static public class Func
  {
    public const double m_pi90 = Math.PI / 2.0;
    public const double m_pi = Math.PI;
    public const double m_pi270 = Math.PI / 2.0 * 3.0;
    public const double m_pi360 = Math.PI * 2.0;

    //degree to radian
    static public double Deg2Rad(double deg)
    {
      return Math.PI * deg / 180.0;
    }

    //radian to degree
    static public double Rad2Deg(double rad)
    {
      return 180.0 * rad / Math.PI;
    }

    //sin(deg)
    static public double sin_(double deg)
    {
      return Math.Sin(Deg2Rad(deg));
    }

    //cos(deg)
    static public double cos_(double deg)
    {
      return Math.Cos(Deg2Rad(deg));
    }


    /* 0 ~ 360 deg*/
    static public double Atan2(double y, double x) //y / x
    {
      double th;

      if (x == 0.0)
      {
        if (y >= 0.0) th = m_pi90;  /* 90 deg */
        else th = m_pi270;  /* 270 deg */
      }
      else if (y == 0.0)
      {
        if (x >= 0.0) th = 0;       /* 0 deg */
        else th = m_pi;   /* -180 deg */
      }
      else
      {
        th = Math.Atan(y / x);
        if (x > 0.0)
        {
          if (y < 0.0)
          {
            th = th + m_pi360; /*360deg*/
          }
        }
        else /*if(x < 0.0)*/
        {
          th = th + m_pi;     /*180deg*/
        }
      }

      return th;
    }


    //센터 제로
    static public void rotDeg(double x, double y, double deg, out double xx, out double yy)
    {
      ////xx = cos_(deg) * (px-ox) - sin(theta) * (py-oy) + ox
      ////////yy = sin_(deg) * (px-ox) + cos(theta) * (py-oy) + oy
      xx = cos_(deg) * (x) - sin_(deg) * (y);
      yy = sin_(deg) * (x) + cos_(deg) * (y);
    }

    //센터 포함
    static public void rotDeg(double x, double y, double cenX, double cenY, double deg, out double xx, out double yy)
    {
      xx = cos_(deg) * (x - cenX) - sin_(deg) * (y - cenY) + cenX;
      yy = sin_(deg) * (x - cenX) + cos_(deg) * (y - cenY) + cenY;
    }

    //센터 제로 
    static public void rotXYZ(double x, double y, double z,
        double deg1, double deg2, double deg3,
        out double xx, out double yy, out double zz)
    {
      xx = (cos_(deg3) * cos_(deg2)) * x +
        (cos_(deg3) * sin_(deg2) * sin_(deg1) - sin_(deg3) * cos_(deg1)) * y +
        (cos_(deg3) * sin_(deg2) * cos_(deg1) + sin_(deg3) * sin_(deg1)) * z;

      yy = (sin_(deg3) * cos_(deg2)) * x +
        (sin_(deg3) * sin_(deg2) * sin_(deg1) + cos_(deg3) * cos_(deg1)) * y +
        (sin_(deg3) * sin_(deg2) * cos_(deg1) - cos_(deg3) * sin_(deg1)) * z;

      zz = (-sin_(deg2)) * x +
        (cos_(deg2) * sin_(deg1)) * y +
        (cos_(deg2) * cos_(deg1)) * z;
    }

    //센터 포함
    static public void rotXYZ(double x, double y, double z, double cenX, double cenY, double cenZ,
        double deg1, double deg2, double deg3,
        out double xx, out double yy, out double zz)
    {
      xx = (cos_(deg3) * cos_(deg2)) * (x - cenX) +
        (cos_(deg3) * sin_(deg2) * sin_(deg1) - sin_(deg3) * cos_(deg1)) * (y - cenY) +
        (cos_(deg3) * sin_(deg2) * cos_(deg1) + sin_(deg3) * sin_(deg1)) * (z - cenZ) + cenX;

      yy = (sin_(deg3) * cos_(deg2)) * (x - cenX) +
        (sin_(deg3) * sin_(deg2) * sin_(deg1) + cos_(deg3) * cos_(deg1)) * (y - cenY) +
        (sin_(deg3) * sin_(deg2) * cos_(deg1) - cos_(deg3) * sin_(deg1)) * (z - cenZ) + cenY;

      zz = (-sin_(deg2)) * (x - cenX) +
        (cos_(deg2) * sin_(deg1)) * (y - cenY) +
        (cos_(deg2) * cos_(deg1)) * (z - cenZ) + cenZ;
    }

    //센터 제로
    static public void rotZ(double x, double y, double z, double deg,
        out double xx, out double yy, out double zz)
    {
      xx = cos_(deg) * x - sin_(deg) * y;
      yy = sin_(deg) * x + cos_(deg) * y;
      zz = z;
    }

    //센터 제로
    static public void rotY(double x, double y, double z, double deg,
        out double xx, out double yy, out double zz)
    {
      xx = cos_(deg) * x + sin_(deg) * z;
      yy = y;
      zz = -sin_(deg) * x + cos_(deg) * z;
    }

    //센터 제로
    static public void rotX(double x, double y, double z, double deg,
        out double xx, out double yy, out double zz)
    {
      xx = x;
      yy = cos_(deg) * y - sin_(deg) * z;
      zz = sin_(deg) * y + cos_(deg) * z;
    }

    //센터 포함
    static public void rotZ(double x, double y, double z, double cenX, double cenY,
        double deg, out double xx, out double yy, out double zz)
    {
      xx = cos_(deg) * (x - cenX) - sin_(deg) * (y - cenY) + cenX;
      yy = sin_(deg) * (x - cenX) + cos_(deg) * (y - cenY) + cenY;
      zz = z;
    }

    //센터 포함
    static public void rotY(double x, double y, double z, double cenX, double cenZ, double deg,
        out double xx, out double yy, out double zz)
    {
      xx = cos_(deg) * (x - cenX) + sin_(deg) * (z - cenZ) + cenX;
      yy = y;
      zz = -sin_(deg) * (x - cenX) + cos_(deg) * (z - cenZ) + cenZ;
    }

    //센터 포함
    static public void rotX(double x, double y, double z, double cenY, double cenZ, double deg,
        out double xx, out double yy, out double zz)
    {
      xx = x;
      yy = cos_(deg) * (y - cenY) - sin_(deg) * (z - cenZ) + cenY;
      zz = sin_(deg) * (y - cenY) + cos_(deg) * (z - cenZ) + cenZ;
    }

    //주파수에 따른 현재시간에 대한 sin값 리턴 
    static public double SinAtTime(int freq, double time)
    {
      double t = 1.0 / (double)freq;
      double deg = time * 360.0 / t;

      return sin_(deg);
    }



    //좌표 변환하기 (값, 기존 레인지 중에서 최소값, 기존 레인지 중에서 최대값, 목표 레인지의 최소값, 목표 레인지의 최대값)
    static public double ChangeCoor(double srcPos, double srcMin, double srcMax, double destMin, double destMax)
    {
      double min;
      double max;
      double pos;
      double src;
      double ret;

      if (srcPos > srcMax) srcPos = srcMax;
      if (srcPos < srcMin) srcPos = srcMin;

      min = srcMin - srcMin;
      max = srcMax - srcMin;
      pos = srcPos - srcMin;
      src = pos / (max - min);

      min = srcMax - srcMin;

      ret = destMin + src * (destMax - destMin);

      if (destMin < destMax)
        SetMinMax(ref ret, destMin, destMax);
      else
        SetMinMax(ref ret, destMax, destMin);

      return ret;
    }

    //좌표 변환하기 U-Curb 
    static public double ChangeCoorUCurb(double srcPos, double srcMin, double srcMax)
    {
      double dDeg = ChangeCoor(srcPos, srcMin, srcMax, 0.0, 180.0);
      double dRet = 0.0;

      if (dDeg > 90.0)
      {
        dDeg = 180.0 - dDeg;
      }

      if (dDeg < 45.0)
      {
        dDeg = dDeg / 45.0 * 60.0;
        dRet = 1.0 - cos_(dDeg);
      }
      else
      {
        dDeg = (dDeg - 45.0) / 45.0 * 60.0 + 30.0;
        dRet = sin_(dDeg);
      }

      return (1.0 - dRet);
    }

    //좌표 변환하기 U-Curb의 왼쪽
    static public double ChangeCoorUCurbL(double srcPos, double srcMin, double srcMax)
    {
      double dDeg = ChangeCoor(srcPos, srcMin, srcMax, 0.0, 90.0);
      double dRet = 0.0;

      if (dDeg > 90.0)
      {
        dDeg = 180.0 - dDeg;
      }

      if (dDeg < 45.0)
      {
        dDeg = dDeg / 45.0 * 60.0;
        dRet = 1.0 - cos_(dDeg);
      }
      else
      {
        dDeg = (dDeg - 45.0) / 45.0 * 60.0 + 30.0;
        dRet = sin_(dDeg);
      }

      return (1.0 - dRet);
    }

    //좌표 변환하기 U-Curb의 오른쪽
    static public double ChangeCoorUCurbR(double srcPos, double srcMin, double srcMax)
    {
      double dDeg = ChangeCoor(srcPos, srcMin, srcMax, 90.0, 180.0);
      double dRet = 0.0;

      if (dDeg > 90.0)
      {
        dDeg = 180.0 - dDeg;
      }

      if (dDeg < 45.0)
      {
        dDeg = dDeg / 45.0 * 60.0;
        dRet = 1.0 - cos_(dDeg);
      }
      else
      {
        dDeg = (dDeg - 45.0) / 45.0 * 60.0 + 30.0;
        dRet = sin_(dDeg);
      }

      return (1.0 - dRet);
    }

    //좌표 변환하기 x^n 승 값.. 
    static public double ChangeCoorXn(double srcPos, double srcMin, double srcMax, int n)
    {
      double d = ChangeCoor(srcPos, srcMin, srcMax, 0.0, 1.0);
      double dRet = 1.0;
      int i;

      for (i = 0; i < n; i++)
      {
        dRet *= d;
      }

      return dRet;
    }

    //좌표 변환하기 x^n 승 값..  반대..root 값
    static public double ChangeCoorXnReverse(double srcPos, double srcMin, double srcMax, int n)
    {
      double d = ChangeCoor(srcPos, srcMin, srcMax, 1.0, 0.0);
      double dRet = 1.0;
      int i;

      for (i = 0; i < n; i++)
      {
        dRet *= d;
      }

      dRet = 1.0 - dRet;

      return dRet;
    }

    static public bool SetMinMax(ref double d, double min, double max)
    {
      bool b = true;
      if (d < (min))
      {
        d = min;
        b = false;
      }
      else if (d > (max))
      {
        d = max;
        b = false;
      }
      return b;
    }

    static public bool SetMinMax(ref int n, int min, int max)
    {
      bool b = true;
      if (n < (min))
      {
        n = min;
        b = false;
      }
      else if (n > (max))
      {
        n = max;
        b = false;
      }
      return b;
    }

    static public bool SetMinMax(ref float f, float min, float max)
    {
      bool b = true;
      if (f < (min))
      {
        f = min;
        b = false;
      }
      else if (f > (max))
      {
        f = max;
        b = false;
      }
      return b;
    }

    static public int RingCnt(int n, int min, int max)
    {
      int nMin = min - min; //0
      int nMax = max - min;
      int nDef = max - min + 1;

      n -= min;

      while (n < 0)
      {
        n += nDef;
      }

      n %= nDef;
      n += min;

      return n;
    }

    static public void mean_filter(double[] p, out double[] p2, int cou, int weight)
    {
      int i;
      int w = weight / 2;
      double dSum;
      p2 = new double[cou];

      dSum = 0;
      for (i = 0; i < weight - 1; i++) dSum += p[i];
      for (i = w; i < (cou - w); i++)
      {
        dSum += p[i + w];
        p2[i] = dSum / (double)weight;
        dSum -= p[i - w];
      }

      for (i = 0; i < w; i++)
      {
        p2[i] = p[i];
        p2[cou - i - 1] = p[cou - i - 1];
      }
    }

#if false
		//평균 필터.. p -> p2 cou 만큼.. 가중치 만큼..
		static public void mean_filter(int[] p, out int[] p2, int cou, int weight)
		{
			int i;

			int w = weight / 2;
			int nSum;

			nSum = 0;
			for(i = 0; i < weight - 1; i++) nSum += p[i];
			for(i = w; i < (cou - w); i++)
			{
				nSum += p[i + w];
				p2[i] = nSum / weight;
				nSum -= p[i - w];
			}

			for(i = 0; i < w; i++)
			{
				p2[i] = p[i];
				p2[cou - i - 1] = p[cou - i - 1];
			}
		}
#endif

    static public int GetPosEdge(int nPre, int nCurr)
    {
      return (~nPre & nCurr);
    }

    static public int GetNegEdge(int nPre, int nCurr)
    {
      return (nPre & ~nCurr);
    }

    //data shift
    static public void DataShift(ref int[] p, int data, int count)
    {
      for (int i = 0; i < count - 1; i++)
      {
        p[i] = p[i + 1];
      }
      p[count - 1] = data;
    }

    static public void DataShift(ref double[] p, double data, int count)
    {
      for (int i = 0; i < count - 1; i++)
      {
        p[i] = p[i + 1];
      }
      p[count - 1] = data;
    }

    static public void DataShift(ref float[] p, float data, int count)
    {
      for (int i = 0; i < count - 1; i++)
      {
        p[i] = p[i + 1];
      }
      p[count - 1] = data;
    }

    static public void DataShift(ref string[] p, string data, int count)
    {
      for (int i = 0; i < count - 1; i++)
      {
        p[i] = p[i + 1];
      }
      p[count - 1] = data;
    }

    ////비디오 영상 fps가 정해진 상태에서 연산
    //time(msec) to frame
    static public int Time2Frame(int time_msec, int fps)
    {
      if (fps <= 0) return 0;

      int n = time_msec % (1000 / fps);
      if (n < (1000 / fps / 2))
      {
        time_msec -= n;
      }
      else
      {
        time_msec -= n;
        time_msec += (1000 / fps);
      }

      return (int)((double)time_msec / 1000.0 * (double)fps) + 1;
    }

    //frame to time(sec)
    static public double Frame2Time(int frame, int fps)
    {
      double time_sec = (double)(frame - 1) / (double)fps;
      return time_sec;
    }

    //frame to time(msec)
    static public int Frame2TimeMs(int frame, int fps)
    {
      int time_msec = (int)((double)(frame - 1) / (double)fps * 1000.0);
      return time_msec;
    }

    public struct xyz
    {
      public double x;
      public double y;
      public double z;
      public xyz(double xx, double yy, double zz)
      {
        x = xx;
        y = yy;
        z = zz;
      }
    };

    public struct xy
    {
      public double x;
      public double y;
      public xy(double xx, double yy)
      {
        x = xx;
        y = yy;
      }
    };

    //두 점 사이 거리 xyz 좌표계
    static public double DistanceToPoint(xyz a, xyz b)
    {
      return Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2) + Math.Pow(a.z - b.z, 2));
    }

    //두 점 사이 거리 xy 좌표계
    static public double DistanceToPoint(xy a, xy b)
    {
      return Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2));
    }

    //폼의 모든 컨트롤 얻기
    static public IEnumerable<Control> GetAll(Control control, Type type)
    {
      var controls = control.Controls.Cast<Control>();

      return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                .Concat(controls)
                                .Where(c => c.GetType() == type);
    }

    //폼의 모든 3d버튼 antialias 끄기
    static public void SetBtnAntialiasDisable(Control control)
    {
      var allBtn = kFunc.Func.GetAll(control, typeof(AxBTNENHLib4.AxBtnEnh));
      foreach (Control c in allBtn)
      {
        AxBTNENHLib4.AxBtnEnh btn = (AxBTNENHLib4.AxBtnEnh)c;
        btn.UseAntialias = false;
      }
    }

    //폼의 모든 3d버튼 tabstop false
    static public void SetBtnTabStop(Control control)
    {
      var allBtn = kFunc.Func.GetAll(control, typeof(AxBTNENHLib4.AxBtnEnh));
      foreach (Control c in allBtn)
      {
        AxBTNENHLib4.AxBtnEnh btn = (AxBTNENHLib4.AxBtnEnh)c;
        btn.TabStop = false;
      }
    }

    static public void StartProgram(string path, string file = null)
    {
      if (file == null)
        Process.Start(path);
      else
        Process.Start(path, file);
    }

    static public void ExitProgram(string processName)
    {
      foreach (Process process in Process.GetProcesses())
      {
        if (process.ProcessName.StartsWith(processName))
        {
          process.Kill();
          break;
        }
      }
    }
    static public bool GetProcess(string processName, out IntPtr hWnd)
    {
      Process[] processes = Process.GetProcessesByName(processName);

      hWnd = (IntPtr)0;

      foreach (Process p in processes)
      {
        hWnd = p.MainWindowHandle;
        return true;
      }

      return false;
    }

    //인터넷 연결 체크
    public static bool CheckForInternetConnection()
    {
      try
      {
        using (var client = new WebClient())
        using (client.OpenRead("http://google.com/generate_204"))
          return true;
      }
      catch
      {
        return false;
      }
    }
  }
}

