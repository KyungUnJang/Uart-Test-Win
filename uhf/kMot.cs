//#define ST32
//#define WMX

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace uhf
{
  class kMot
  {
    /* System */

    static public bool Init(int slaveNumber)
    {
#if (ST32)
#elif (WMX)
      WMX.Init(slaveNumber);
#endif
      return true;
    }

    static public void Destroy()
    {
#if (ST32)
#elif (WMX)
      WMX.Close();
#endif
    }

    static public bool GetModuleExist()
    {
#if (ST32)
      if (!View.m_pComDrv.m_comm.comm.IsOpen) return false;
#elif (WMX)
      return true;//if(!WMX.IsLive()) return false;
#endif
      return false;
    }

    static public void SetGearRatio(int axis, double numerator, double denominator)
    {
      if (!GetModuleExist()) return;
#if (ST32)
#elif (WMX)
      WMX.SetGearRatio(axis, numerator, denominator);
#endif
    }

    static public void SetLimitPoloarity(int axis, bool bActiveLow)
    {
      if (!GetModuleExist()) return;
#if (ST32)
#elif (WMX)
      WMX.SetLimitPoloarity(axis, bActiveLow);
#endif
    }

    /* Sensor and Status */

    static public void ServoOn(int axis, bool bOn)
    {
      if (!GetModuleExist()) return;
#if (ST32)
			View.m_pComDrv.SetSerovoOn(axis, Convert.ToInt32(bOn));
#elif (WMX)
      WMX.ServoOn(axis, bOn);
#endif
    }

    static public bool GetServoOn(int axis)
    {
      if (!GetModuleExist()) return false;
#if (ST32)
#elif (WMX)
      return WMX.GetServoOn(axis);
#endif
      return false;
    }

    static public bool GetAlarm(int axis)
    {
      if (!GetModuleExist()) return false;
#if (ST32)
#elif (WMX)
      return WMX.GetAlarm(axis);
#endif
      return false;
    }

    static public void AlarmReset(int axis, int nOn)
    {
      if (!GetModuleExist()) return;
#if (ST32)
    	View.m_pComDrv.SetAlarmReset(axis, nOn);
#elif (WMX)
      WMX.AlarmReset(axis);
#endif
    }

    static public bool GetLimitSensor(int axis, bool bPlus)
    {
      if (!GetModuleExist()) return false;
#if (ST32)
#elif (WMX)
      return WMX.GetLimitSensor(axis, bPlus);
#endif
      return false;
    }

    static public bool GetSoftLimitSensor(int axis, bool bPlus)
    {
      if (!GetModuleExist()) return false;
#if (ST32)
#elif (WMX)
      return WMX.GetSoftLimitSensor(axis, bPlus);
#endif
      return false;
    }

    static public bool GetHomeSensor(int axis)
    {
      if (!GetModuleExist()) return false;
#if (ST32)
#elif (WMX)
      return WMX.GetHomeSensor(axis);
#endif
      return false;
    }

    void GetAllStatus(int axis)
    {
#if (ST32)
#elif (WMX)
#endif

    }

    static public void SetPos(int axis, double pos)
    {
      if (!GetModuleExist()) return;
#if (ST32)
		View.m_pComDrv.SetCmdPos(axis, pos);
		View.m_pComDrv.SetEncPos(axis, pos);
#elif (WMX)
      WMX.SetCmdPos(axis, pos);
      WMX.SetEncPos(axis, pos);
#endif
    }

    //set encoder position
    static public void SetEncPos(int axis, double pos)
    {
      if (!GetModuleExist()) return;
#if (ST32)
		View.m_pComDrv.SetEncPos(axis, pos);
#elif (WMX)
      WMX.SetEncPos(axis, pos);
#endif
    }

    //set command position
    static public void SetCmdPos(int axis, double pos)
    {
      if (!GetModuleExist()) return;
#if (ST32)
		View.m_pComDrv.SetCmdPos(axis, pos);
#elif (WMX)
      WMX.SetCmdPos(axis, pos);
#endif
    }

    static public double GetEncPos(int axis)
    {
      if (!GetModuleExist()) return 0.0;
#if (ST32)
#elif (WMX)
      return WMX.GetEncPos(axis);
#endif
      return 0.0;
    }

    static public double GetCmdPos(int axis)
    {
      if (!GetModuleExist()) return 0.0;
#if (ST32)
#elif (WMX)
      return WMX.GetCmdPos(axis);
#endif
      return 0.0;
    }

    static public void HomeSearch(int axis, double fastV, double slowV, int acc_dec, int type, int dir_p0_n1)
    {
      /* direction, postive 0, negative 1 */
      if (!GetModuleExist()) return;
#if (ST32)
#elif (WMX)
#endif
    }

    static public bool GetHomeSearchDone(int axis)
    {
      if (!GetModuleExist()) return false;
#if (ST32)
#elif (WMX)
      return WMX.GetHomeSearchDone(axis);
#endif
      return false;
    }

    static public bool GetHomeSearchError(int axis, out int code)
    {
      code = 0;
      if (!GetModuleExist()) return false;
#if (ST32)
#elif (WMX)
      return WMX.GetHomeSearchError(axis, out code);
#endif
      return false;
    }
    //relative move
    static public void RelMove(int axis, double pos, double v, int a, int d)
    {
      if (!GetModuleExist()) return;
#if (ST32)
#elif (WMX)
      WMX.RelMove(axis, pos, v, a, d);
#endif
    }

    //absolute move
    static public void AbsMove(int axis, double pos, double v, int a, int d)
    {
      if (!GetModuleExist()) return;
#if (ST32)
#elif (WMX)
      WMX.AbsMove(axis, pos, v, a, d);
#endif
    }
    static public void AbsMoveArray(int[] axis, double[] pos, double v, int accel, int decel)
    {
      if (!GetModuleExist()) return;
#if (ST32)
#elif (WMX)
      WMX.AbsMoveArray(axis, pos, v, accel, decel);
#endif
    }

    //continuous move
    static public void ContMove(int axis, double v, int a, int d, bool bPlus)
    {
			if (!GetModuleExist()) return;
#if (ST32)
    View.m_pComDrv.ContMove(axis, v, a, d, dir);
#elif (WMX)
      WMX.ContMove(axis, v, a, d, bPlus);
#endif
    }

    static public void ContMoveArray(int[] axis, double v, int a, int d, int dir)
    {
			if (!GetModuleExist()) return;
#if (ST32)
    View.m_pComDrv.ContMove(axis, v, a, d, dir);
#elif (WMX)
#endif
    }

    //velocity override
    static public void VOverride(int axis, double v)
    {
			if (!GetModuleExist()) return;
#if (ST32)
      View.m_pComDrv.SetV(axis, v);
#elif (WMX)
#endif
    }

    static public void SetSpeed(int axis, double v, int a)
    {
			if (!GetModuleExist()) return;
#if (ST32)
      View.m_pComDrv.SetSpeed(axis, v, a);
#elif (WMX)
#endif
    }

    static public void Stop(int axis, bool emg = false)
    {
			if (!GetModuleExist()) return;
#if (ST32)
      View.m_pComDrv.Stop(axis, emg);
#elif (WMX)
      WMX.Stop(axis, emg);
#endif
    }

    static public void AllStop(bool emg = false)
		{
      if (!GetModuleExist()) return;
#if (ST32)
#elif (WMX)
#endif
    }

    static public bool GetMotDone(int axis, bool bUseInpos = false)
    {
			if (!GetModuleExist()) return false;
#if (ST32)
			int nDone = 0;
			if(View.m_pComDrv.GetMotDone(axis, out nDone))
			{
				if(nDone != 0) return true;
			}
#elif (WMX)
      if(bUseInpos)
        return WMX.GetMotDone(axis) && WMX.GetInpos(axis);
      return WMX.GetMotDone(axis);
#endif
      return false;
    }

    static public bool GetMotPaused(int axis)
    {
			if (!GetModuleExist()) return false;
#if (ST32)
#elif (WMX)
      return WMX.GetMotPaused(axis);
#endif
      return false;
    }

    static public bool GetMotStopped(int axis)
    {
			if (!GetModuleExist()) return false;
#if (ST32)
#elif (WMX)
      return WMX.GetMotStopped(axis);
#endif
      return false;
    }

    static public bool GetInpos(int axis)
    {
			if (!GetModuleExist()) return false;
#if (ST32)
#elif (WMX)
      return WMX.GetInpos(axis);
#endif

      return false;
    }

    ////////////////////Get By Var//////////////////////////
    static public bool GetSvOnByVar(int axis)
    {
#if (ST32)
#elif (WMX)
#endif
      return false;
    }

    static public void SetSyncAxis(int masterAxis, int[] slaveAxis)
    {
#if (ST32)
#elif (WMX)
      WMX.SetSyncAxis(masterAxis, slaveAxis);
#endif
    }

    static public void GetSyncAxis(int masterAxis, int[] slaveAxis)
    {
#if (ST32)
#elif (WMX)
#endif
    }

    static public void ResetSyncAxis(int id, int[] slaveAxis)
    {
#if (ST32)
#elif (WMX)
      WMX.ResetSyncAxis(id, slaveAxis);
#endif
    }
  }
}
