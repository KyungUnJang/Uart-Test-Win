using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uhf
{
  class Define
	{
		public const byte STX = 0x02;
		public const byte ETX = 0x03;
		public const byte LF  = 0x0a;
		public const byte CR  = 0x0d;

		public enum eAlarmCode
		{
			sys_on = 1,
			sys_off,
			connected_master = 10,
			connected_slave,
			not_connected_master = 20,
			not_connected_slave,
			comm_err_master = 30,
			comm_err_slave,
		}

		public enum eAlarmServo //for firmware
		{
			ERR_EMG,
			ERR_ALARM,
			ERR_LMTP,
			ERR_LMTM,
			TIMEOUT_HOMESRCH,
			TIMEOUT_MOVE,
			SERVO_OFF,
			MAX,
		}

    public enum eSysSts
    {
      not_init,
			initing,
      inited,
      run,
      stopping,
      alarm,
			max,
    }
	}
}
