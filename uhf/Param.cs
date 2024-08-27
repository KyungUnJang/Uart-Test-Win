using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //for MessageBox

namespace uhf
{
  class Param
  {
		//유저 레벨
		public enum eLevel
    {
      user, //아무나
      maintenance, //메인터넌스, 슈퍼바이저
      supervisor, //슈퍼바이저
      read_only, //읽을수만 있는 변수
      TEMP,
    }

		//파라메터의 타입
    public enum eType
    {
      int_,
      byte_,
      double_,
      string_,
      check, //bool
      combo, //int
      TEMP,
      dir, 
      file, //file 경로
    }

		//csv 파일 구조체
    public struct ST
    {
      public string section; //ini 섹션
      public string key; //ini 키
      public int type; //변수 타입, 자료형
      public int level; //유저 레벨
      public string unit; //변수의 단위
      public int ptnum; //변수가 double일 경우 소수점 자리수
      public string min; //변수의 최소값
      public string max; //변수의 최대값
      public string default_; //변수의 초기 기본 디폴트 값
      public string explain; //변수의 설명
    }

		//변수를 Ini파일로 저장
		static public void SaveToIni(ST[] pSt, object[] pObj, string sIniPath, bool bNew = false)
    {
      object data;

      for (int i = 0; i < pSt.Length; i++)
      {
        if (bNew)
        {
#if false
					switch(pSt[i].type)
          {
            case (int)eType.int_:
            case (int)eType.check:
            case (int)eType.combo:
              data = Convert.ToInt32(pSt[i].default_);
              break;
            case (int)eType.byte_:
              data = Convert.ToByte(pSt[i].default_);
              break;
            case (int)eType.double_:
              data = Convert.ToDouble(pSt[i].default_);
              break;
            default:
            case (int)eType.string_:
              data = Convert.ToString(pSt[i].default_);
              break;
          }
#else
          data = pSt[i].default_;
#endif
				} else {
#if false
					switch(pSt[i].type)
					{
						case (int)eType.int_:
						case (int)eType.combo:
							data = Convert.ToInt32(pObj[i]);
							break;
						case (int)eType.byte_:
							data = Convert.ToByte(pObj[i]);
							break;
						case (int)eType.double_:
							data = Convert.ToDouble(pObj[i]);
							break;
						default:
						case (int)eType.string_:
							data = Convert.ToString(pObj[i]);
							break;
						case (int)eType.check:
							data = Convert.ToBoolean(pObj[i]);
							break;
					}
#else
					data = pObj[i];
#endif
				}
        kFunc.IniFile.Save(pSt[i].section, pSt[i].key, data, sIniPath);
      }
    }

		//Ini파일 데이터를 변수로 로드
		static public void LoadFromIni(ST[] pSt, ref object[] pObj, string sIniPath)
    {
      for (int i = 0; i < pSt.Length; i++)
      {
        kFunc.IniFile.Load(pSt[i].section, pSt[i].key, pSt[i].default_, out pObj[i], sIniPath);
      }
    }

		//csv 파일 형태의 파라메터 정보를 로드하여 ST 구조체에 저장
    static public void LoadFromCsv(ref ST[] p, int nObjLength, string sCsvPath)
    {
      if (!kFunc.Dir.FileExist(sCsvPath))
			{
				MessageBox.Show(string.Format("{0} : FILE NOT EXIST!", sCsvPath));
				return;
			}
      if (kFunc.Dir.IsFileOpen(sCsvPath))
      {
        MessageBox.Show(string.Format(sCsvPath + " : File Already Open!\n이제 프로그램 죽습니다"));
      }

      string[] lines = System.IO.File.ReadAllLines(sCsvPath);
			int nCsvLength = lines.Length - 1;

			if(nCsvLength != nObjLength)
			{
				MessageBox.Show(string.Format("{0} : SIZE MATCHING ERROR!(CSV {1}, OBJ{2})", sCsvPath, nCsvLength, nObjLength));
				return;
			}
      
      p = new ST[nCsvLength];

      for (int i = 0; i < nCsvLength; i++)
      {
        string[] words = lines[i + 1].Split(',');

        for (int j = 0; j < words.Length; j++)
        {
          switch (j)
          {
            case  0: p[i].section  = words[j]; break;
            case  1: p[i].key 		 = words[j]; break;
            case  2: p[i].type     = (int)Enum.Parse(typeof(eType), words[j]); break;
            case  3: p[i].level    = (int)Enum.Parse(typeof(eLevel), words[j]); break;
            case  4: p[i].unit 		 = words[j]; break;
            case  5: p[i].ptnum 	 = Convert.ToInt32(words[j]); break;
            case  6: p[i].min 		 = words[j]; break;
            case  7: p[i].max			 = words[j]; break;
            case  8: p[i].default_ = words[j]; break;
            case  9: p[i].explain  = words[j]; break;
          }
        }
      }
    }

  }
}
