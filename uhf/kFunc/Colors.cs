using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace uhf.kFunc
{
  static public class Colors
  {
    static public uint blue = Convert.ToUInt32(ColorTranslator.ToWin32(Color.Blue));
    static public uint red = Convert.ToUInt32(ColorTranslator.ToWin32(Color.Red));
    static public uint green = Convert.ToUInt32(ColorTranslator.ToWin32(Color.Green));
    static public uint white = Convert.ToUInt32(ColorTranslator.ToWin32(Color.White));
    static public uint black = Convert.ToUInt32(ColorTranslator.ToWin32(Color.Black));
    static public uint lime = Convert.ToUInt32(ColorTranslator.ToWin32(Color.Lime));
    static public uint gray = Convert.ToUInt32(ColorTranslator.ToWin32(Color.Gray));
    static public uint royalblue = Convert.ToUInt32(ColorTranslator.ToWin32(Color.RoyalBlue));
    static public uint crimson = Convert.ToUInt32(ColorTranslator.ToWin32(Color.Crimson));
    static public uint lightcoral = Convert.ToUInt32(ColorTranslator.ToWin32(Color.LightCoral));
    static public uint greenyellow = Convert.ToUInt32(ColorTranslator.ToWin32(Color.GreenYellow));

    static public uint Color2Uint(Color col)
    {
      return Convert.ToUInt32(ColorTranslator.ToWin32(col));
    }

    static public Color Uint2Color(uint col)
    {
      return ColorTranslator.FromWin32((int)col);
    }
  }
}
