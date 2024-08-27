using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //for path
using System.Runtime.InteropServices;

namespace uhf.kFunc
{
  internal static class Parsing
  {
    public static string str2hex(string strData)
    {
      string resultHex = string.Empty;
      byte[] arr_byteStr = Encoding.Default.GetBytes(strData);

      foreach (byte byteStr in arr_byteStr)
        resultHex += string.Format("{0:X2}", byteStr);

      return resultHex;
    }

    public static int hexstr2int(string hexstr)
    {
      if(hexstr == "") hexstr = "0";
      return Int32.Parse(hexstr, System.Globalization.NumberStyles.HexNumber);
    }

    public static int str2int(string str, int start, int length)
    {
      return Int32.Parse(str.Substring(start, length));
    }

    public static string byte2str(byte[] strByte)
    {
      string str = Encoding.Default.GetString(strByte).TrimEnd('\0');
      return str;
    }

    // String을 바이트 배열로 변환 
    public static byte[] str2byte(string str)
    {
      byte[] strByte = Encoding.UTF8.GetBytes(str);
      return strByte;
    }

    public static IntPtr str2intptr(string str)
		{
			return System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(str);
		}

    public static string intptr2str(IntPtr ptr)
		{
      return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(ptr);
		}
 

		/* enum to string */
    //Enum.GetName(typeof(enum), i):

      //c++ function
    [DllImport("msvcrt.dll")]
    public static extern int printf(string format, __arglist);
    public static int printf(string format) => printf(format, __arglist());

    [DllImport("msvcrt.dll")]
    public static extern int scanf(string format, __arglist);
    public static int scanf(string format) => scanf(format, __arglist());

    [DllImport("msvcrt.dll")]
    static extern int _getch();

    /*
    static void Main()
    {
      int a = 0, b = 0, n;
      var s = new StringBuilder();

      n = printf("정수 정수 문자열 입력:\n");
      n = scanf("%d %d %s", __arglist(ref a, ref b, s));
      n = printf("(%d 개 입력됨)\n%d %d %s\n", __arglist(n, a, b, s));

      _getch();
    } */

  }
}
