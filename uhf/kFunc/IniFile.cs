using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices; //for dll import
using System.IO;

namespace uhf.kFunc
{
  /// <summary>
  /// 레지스트리 형태의 INI 파일 데이터를 접근 하는 Win32함수를 C# 계층에서 사용 할 수 있도록 wrapping한 클래스입니다.
  /// </summary>

#if false
  struct stIni
  {
    public int nSel;
    public string sSection;
    public string sKey;
    public string sDefault;
  }
#endif

  internal static class IniFile
	{
    private static object lockIni= new object();

		/// <summary>
		/// INI 파일에 섹션과 키로 검색하여 값을 저장합니다.
		/// </summary>
		/// <param name="IpAppName">섹션명입니다.</param>
		/// <param name="IpKeyName">키값명입니다.</param>
		/// <param name="IpString">저장 할 문자열입니다.</param>
		/// <param name="IpFileName">파일 이름입니다.</param>
		/// <returns>값을 얻은 성공 여부입니다.</returns>
		[DllImport("kernel32.dll")]
			public static extern bool WritePrivateProfileString(string IpAppName, string IpKeyName, string IpString, string IpFileName);

		/// <summary>
		/// INI 파일에 섹션을 저장합니다.
		/// </summary>
		/// <param name="IpAppName">섹션명입니다.</param>
		/// <param name="IpString">키=값으로 되어 있는 문자열 데이터입니다.</param>
		/// <param name="IpFileName">파일 이름입니다.</param>
		/// <returns></returns>
		[DllImport("kernel32.dll")]
			public static extern uint WritePrivateProfileSection(string IpAppName, string IpString, string IpFileName);

		/// <summary>
		/// INI 파일에 섹션과 키로 검색하여 값을 Interger형으로 읽어 옵니다.
		/// </summary>
		/// <param name="IpAppName">섹션명입니다.</param>
		/// <param name="IpKeyName">키값명입니다.</param>
		/// <param name="nDefalut">기본값입니다.</param>
		/// <param name="IpFileName">파일 이름입니다.</param>
		/// <returns>입력된 값입니다. 만약 해당 키로 검색 실패시 기본 값으로 대체 됩니다.</returns>
		[DllImport("kernel32.dll")]
			public static extern uint GetPrivateProfileInt(string IpAppName, string IpKeyName, int nDefalut, string IpFileName);

		/// <summary>
		/// INI 파일에 섹션과 키로 검색하여 값을 문자열형으로 읽어 옵니다.
		/// </summary>
		/// <param name="IpAppName">섹션명입니다.</param>
		/// <param name="IpKeyName">키값명입니다.</param>
		/// <param name="IpDefault">기본 문자열입니다.</param>
		/// <param name="IpReturnString">가져온 문자열입니다.</param>
		/// <param name="nSize">문자열 버퍼의 크기입니다.</param>
		/// <param name="IpFileName">파일 이름입니다.</param>
		/// <returns>가져온 문자열 크기입니다.</returns>
		[DllImport("kernel32.dll")]
			public static extern uint GetPrivateProfileString(string IpAppName, string IpKeyName, string IpDefault, StringBuilder IpReturnString, uint nSize, string IpFileName);

		/// <summary>
		/// INI 파일에 섹션으로 검색하여 키와 값을 Pair형태로 가져옵니다.
		/// </summary>
		/// <param name="IpAppName">섹션명입니다.</param>
		/// <param name="IpPairVaules">Pair한 키와 값을 담을 배열입니다.</param>
		/// <param name="nSize">배열의 크기입니다.</param>
		/// <param name="IpFileName">파일 이름입니다.</param>
		/// <returns>읽어온 바이트 수 입니다.</returns>
		[DllImport("kernel32.dll")]
			public static extern uint GetPrivateProfileSection(string IpAppName, byte[] IpPairVaules, uint nSize, string IpFileName);

		/// <summary>
		/// INI 파일의 섹션을 가져옵니다.
		/// </summary>
		/// <param name="IpSections">섹션의 리스트를 직렬화하여 담을 배열입니다.</param>
		/// <param name="nSize">배열의 크기입니다.</param>
		/// <param name="IpFileName">파일 이름입니다.</param>
		/// <returns>읽어온 바이트 수 입니다.</returns>
		[DllImport("kernel32.dll")]
			public static extern uint GetPrivateProfileSectionNames(byte[] IpSections, uint nSize, string IpFileName);

    /* INI 파일 저장 */
		public static void Save(string section, string key, object data, string path)
		{
			string buf = data.ToString();
      if (!Dir.FileExist(path)) Dir.FileMake(path);

			lock (lockIni)
			{
				IniFile.WritePrivateProfileString(section, key, buf, path);
			}
		}

    public static bool Load(string section, string key, string Default, out object data, string path)
		{
			data = 0;
			if (!Dir.FileExist(path)) return false;

			StringBuilder buf = new StringBuilder(255);
			lock (lockIni) { IniFile.GetPrivateProfileString(section, key, Default, buf, 255, path); }

      string str = buf.ToString();
      int n;

			if(Int32.TryParse(str, out n))
      {
        if(str.Contains("."))
        {
          data = Convert.ToDouble(buf.ToString());
        }
        else
        {
          data = Convert.ToInt32(buf.ToString());
        }
      } else
      {

        data = str;
      }

#if false
			Type t = data.GetType();

			if(t == typeof(Int32)) 
			{ 
				data = Convert.ToInt32(buf.ToString()); 
			}
			else if(t == typeof(double)) 
			{ 
				data = Convert.ToDouble(buf.ToString());
			}
			else if(t == typeof(string)) 
			{ 
				data = buf.ToString();
			}
			else if(t == typeof(byte)) 
			{ 
				data = Convert.ToByte(buf.ToString());
			}
			else if(t == typeof(bool)) 
			{ 
				data = Convert.ToBoolean(buf.ToString());
			}
#endif

			return true;
		}

#if false
    /* INI 파일 로드 : int type */
    public static bool  Load(string section, string key, string Default, out int data, string path)
		{
      data = 0;
      if (!Dir.FileExist(path)) return false;

			StringBuilder buf = new StringBuilder(255);
			lock (lockIni) { IniFile.GetPrivateProfileString(section, key, Default, buf, 255, path); }
			data = Convert.ToInt32(buf.ToString());

      return true;
		}

    /* INI 파일 로드 : double type */
    public static bool Load(string section, string key, string Default, out double data, string path)
    {
      data = 0.0;
      if (!Dir.FileExist(path)) return false;

      StringBuilder buf = new StringBuilder(255);
			lock (lockIni) { IniFile.GetPrivateProfileString(section, key, Default, buf, 255, path); }
			data = Convert.ToDouble(buf.ToString());

      return true;
    }

    /* INI 파일 로드 : string type */
    public static bool Load(string section, string key, string Default, out string data, string path)
    {
      data = "";
      if (!Dir.FileExist(path)) return false;

      StringBuilder buf = new StringBuilder(255);
			lock (lockIni) { IniFile.GetPrivateProfileString(section, key, Default, buf, 255, path); }
			data = buf.ToString();

      return true;
    }

    /* INI 파일 로드 : byte type */
    public static bool Load(string section, string key, string Default, out byte data, string path)
    {
      data = 0x00;
      if (!Dir.FileExist(path)) return false;

      StringBuilder buf = new StringBuilder(255);
			lock (lockIni) { IniFile.GetPrivateProfileString(section, key, Default, buf, 255, path); }
			data = Convert.ToByte(buf.ToString());

      return true;
    }

    /* INI 파일 로드 : bool type */
    public static bool Load(string section, string key, string Default, out bool data, string path)
    {
      data = false;
      if (!Dir.FileExist(path)) return false;

      StringBuilder buf = new StringBuilder(255);
			lock (lockIni) { IniFile.GetPrivateProfileString(section, key, Default, buf, 255, path); }
      data = Convert.ToBoolean(buf.ToString());
      return true;
    }
#endif
	}
}

