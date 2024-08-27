using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel;


namespace uhf.kFunc
{
  static internal class Clock
  {
    [DllImport("Kernel32.dll")]
    private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

    [DllImport("Kernel32.dll")]
    private static extern bool QueryPerformanceFrequency(out long lpFrequency);

    private static long m_lFreq;
    private static double m_dsFreq;   //sec
    private static double m_dMsFreq; //msec
    private static double m_dUsFreq; //usec


    static public void Init()
    {
      QueryPerformanceFrequency(out m_lFreq);
      m_dsFreq = m_lFreq;
      m_dMsFreq = m_lFreq / 1000.0;
      m_dUsFreq = m_lFreq / 1000000.0;
    }

    static public void setclock(out long t)
    {
      QueryPerformanceCounter(out t);
    }

    static public double clock2s(long t)
    {
      return (double)(t) / m_dsFreq;
    }

    static public int clock2ms(long t)
    {
      return (int)((double)(t) / m_dMsFreq);
    }

    static public int clock2us(long t)
    {
      return (int)((double)(t) / m_dUsFreq);
    }

    static public double calclock2s(long t)
    {
      long l;
      setclock(out l);
      return clock2s(l - t);
    }

    static public int calclock2ms(long t)
    {
      long l;
      setclock(out l);
      return clock2ms(l - t);
    }

    static public int calclock2us(long t)
    {
      long l;
      setclock(out l);
      return clock2us(l - t);
    }

    static public void sleep(int n)
    {
      System.Threading.Thread.Sleep(n);
    }
    
  }
}
