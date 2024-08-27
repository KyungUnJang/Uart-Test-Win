//#define ST32
//#define WMX

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace uhf
{
  class kIo
  {
    static public int m_nErrorCount;
    /* System */

    static public bool Init()
    {
			m_nErrorCount = 0;
#if (ST32)
#elif (WMX)
#endif
      return true;
    }

    static public void Destroy()
    {
#if (ST32)
#elif (WMX)
#endif
    }

    static public bool GetModuleExist()
    {
#if (ST32)
      if (!View.m_pComDrv.m_comm.comm.IsOpen) return false;
#elif (WMX)
#endif
      return true;
    }

    /* ETC */
    static public int GetIn16()
    {
      int n = 0;
      if (!GetModuleExist()) return 0;
#if (ST32)
      View.m_pComDrv.GetIn8(out n);
#elif (WMX)
			n = WMX.GetIn8(0) | (WMX.GetIn8(1) << 8);
#endif
      return n;
    }

    static public int GetOut16()
    {
      int n = 0;
      if (!GetModuleExist()) return 0;
#if (ST32)
      View.m_pComDrv.GetOut8(out n);
#elif (WMX)
			n = WMX.GetOut8(0) | (WMX.GetOut8(1) << 8);
#endif
      return n;
    }

    static public bool GetIn(int n)
    {
      int ret = 0;
      if (!GetModuleExist()) return false;
#if (ST32)
      View.m_pComDrv.GetIn(n, out ret);
#elif (WMX)
			ret = WMX.GetIn(n);
#endif
      if (ret == 0) return false;
      return true;
    }

    static public bool GetOut(int n)
    {
      int ret = 0;
      if (!GetModuleExist()) return false;
#if (ST32)
      View.m_pComDrv.GetOut(n, out ret);
#elif (WMX)
			ret = WMX.GetOut(n);
#endif
      if (ret == 0) return false;
      return true;
    }

    static public void SetOut16(int n)
    {
      if (!GetModuleExist()) return;
#if (ST32)
      View.m_pComDrv.SetOut8(n);
#elif (WMX)
			WMX.SetOut8(0, n & 0x00ff);
			WMX.SetOut8(1, (n & 0xff00) >> 8);
#endif
    }

    static public void SetOut(int n)
    {
      if (!GetModuleExist()) return;
#if (ST32)
			View.m_pComDrv.SetOut(n);
#elif (WMX)
			WMX.SetOut(n, 1);
#endif
    }

    static public void ResetOut(int n)
    {
      if (!GetModuleExist()) return;
#if (ST32)
			View.m_pComDrv.ResetOut(n);
#elif (WMX)
			WMX.SetOut(n, 0);
#endif
    }

    static public void SetResetOut(int nSet, int nReset)
    {
      if (!GetModuleExist()) return;
#if (ST32)
      View.m_pComDrv.SetResetOut(nSet, nReset);
#elif (WMX)
#endif
    }

    ////////////////////Get By Var//////////////////////////
    static public bool GetIn16ByVar()
    {
      return false;
    }

    static public bool GetOut16ByVar()
    {
      return false;
    }
  }
}
