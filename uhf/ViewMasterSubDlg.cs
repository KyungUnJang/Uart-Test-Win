using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uhf
{
  public partial class ViewMasterSubDlg : UserControl
  {
    public int m_nIndex;
    public const int DATA_LEN_OFFSET = 0;
    public const int ID_OFFSET = 2;
    public const int ADC_TYPE_OFFSET = 3;
    public const int ADC_OFFSET = 4;

    public const int NTC = 4;
    public const int TWO_PHASE_VOL = 4;
    public const int THREE_PHASE_VOL = 4; //12인데 3개라 R S T
    public const int PREASURE = 4;
    public const int WATER_LEAKAGE = 1; //4인데 뒤 3자리 don't care
    public const int GYRO = 4; //12인데 3개라 x y z
    public const int ULTRA_SONIC = 4;
    public const int THREE_PHASE_CURRENT = 4; //12인데 3개라 R S T
    public const int TWO_PHASE_CURRENT = 4;

    public const int DATA_LEN = 2;
    public const int BATTERY = 2;
    public const int RSSI= 2; 

    public enum eAdcType
    {
      NTC = 1,
      THREE_PHASE_VOL,
      TWO_PHASE_VOL,
      PREASURE,
      WATER_LEAKAGE,
      GYRO,
      ULTRA_SONIC,
      THREE_PHASE_CURRENT,
      TWO_PHASE_CURRENT,
    }

    public ViewMasterSubDlg(int index)
    {
      m_nIndex = index;
      InitializeComponent();
    }

    private void ViewMasterSubDlg_Load(object sender, EventArgs e)
    {
      m_btnData.TextDescrCaption.Text = string.Format("DATA_LEN\n = {0}\nADC_TYPE\n = {1}", "NONE", "NONE");
      m_btnIndex.TextDescrCaption.Text = (m_nIndex + 1).ToString();
      m_btnAdc.TextDescrCaption.Text = "0";

      m_btnProgressBattery.ProgressBarMin = 0;
      m_btnProgressBattery.ProgressBarMax = 99;
      m_btnProgressBattery.ProgressBarValue = 0;
      m_btnProgressBattery.TextDescrCaption.Text = string.Format("{0}%", m_btnProgressBattery.ProgressBarValue);
      m_btnProgressRssi.ProgressBarMin = 0;
      m_btnProgressRssi.ProgressBarMax = 99;
      m_btnProgressRssi.ProgressBarValue = 0;
      m_btnProgressRssi.TextDescrCaption.Text = string.Format("-{0}", m_btnProgressRssi.ProgressBarValue);

      tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
    }

    public bool UpdateData(string str)
    {
      int length = str.Length;
      int data_len;
      int id;
      int adc_type;
      int battery_offset;
      int rssi_offset;

      string s;
      int n = 0;
      double d = 0.0;

      string adc = "";
      int battery = 0;
      int rssi = 0;

      bool bErr = false;

      data_len = kFunc.Parsing.str2int(str, DATA_LEN_OFFSET, 2);

      if (length != (data_len + 2))
      {
        bErr = true;
        return bErr;
      }

      id = kFunc.Parsing.str2int(str, ID_OFFSET, 1);
      adc_type = kFunc.Parsing.str2int(str, ADC_TYPE_OFFSET, 1);
      battery_offset = data_len + DATA_LEN-  BATTERY - RSSI;
      rssi_offset = data_len + DATA_LEN - RSSI;

      switch(adc_type)
      {
        case (int)eAdcType.NTC:
          {
            s = str.Substring(ADC_OFFSET, NTC);
            if (Int32.TryParse(s, out n))
            {
              if (n >= 0) adc = string.Format("+{0}℃", n);
              else adc = string.Format("{0}℃", n);
            } else {
              bErr = true;
            }
          }
          break;
        case (int)eAdcType.TWO_PHASE_VOL:
          {
            s = str.Substring(ADC_OFFSET, TWO_PHASE_VOL);
            if (double.TryParse(s, out d))
						{
							d /= 10.0;
              adc = string.Format("{0:F1}V", d);
						} 
						else
              bErr = true;
          }
          break;
        case (int)eAdcType.THREE_PHASE_VOL:
#if false
          {
            s = str.Substring(ADC_OFFSET, THREE_PHASE_VOL);
            d = double.Parse(s);
            adc = string.Format("{0:F1}V", d);
          }
#else //kkb 220425
          {
            string r_, s_, t_;
            r_ = str.Substring(ADC_OFFSET + 0, THREE_PHASE_VOL);
            s_ = str.Substring(ADC_OFFSET + 4, THREE_PHASE_VOL);
            t_ = str.Substring(ADC_OFFSET + 8, THREE_PHASE_VOL);

            if (double.TryParse(r_, out d))
						{
							d /= 10.0;
              adc = string.Format("R = {0:F1}V\n", d);
						}
            else
              bErr = true;
            if(double.TryParse(s_, out d))
						{
							d /= 10.0;
              adc += string.Format("S = {0:F1}V\n", d);
						}
            else
              bErr = true;
            if(double.TryParse(t_, out d))
						{
							d /= 10.0;
              adc += string.Format("T = {0:F1}V", d);
						}
            else
              bErr = true;
          }
#endif
          break;
        case (int)eAdcType.PREASURE:
          {
            s = str.Substring(ADC_OFFSET, PREASURE);
            if(double.TryParse(s, out d))
						{
							d /= 100.0;
              adc = string.Format("{0:F2}㎫", d);
						}
            else
              bErr = true;
          }
          break;
        case (int)eAdcType.WATER_LEAKAGE:
          {
            s = str.Substring(ADC_OFFSET, WATER_LEAKAGE);
            if(s == "D") adc = "Detect";
            else         adc = "None";
          }
          break;
        case (int)eAdcType.GYRO:
          {
            string x, y, z;
            x = str.Substring(ADC_OFFSET + 0, GYRO);
            y = str.Substring(ADC_OFFSET + 4, GYRO);
            z = str.Substring(ADC_OFFSET + 8, GYRO);

            if (double.TryParse(x, out d))
            {
              d /= 10.0;
              if (d >= 0.0) adc = string.Format("X = +{0:F1}㎨\n", d);
              else adc = string.Format("X = {0:F1}㎨\n", d);
            }
            else
              bErr = true;
            if (double.TryParse(y, out d))
            {
              d /= 10.0;
              if (d >= 0.0) adc += string.Format("Y = +{0:F1}㎨\n", d);
              else adc += string.Format("Y = {0:F1}㎨\n", d);
            }
            else
              bErr = true;
            if (double.TryParse(z, out d))
            {
              d /= 10.0;
              if (d >= 0.0) adc += string.Format("Z = +{0:F1}㎨", d);
              else adc += string.Format("Z = {0:F1}㎨", d);
            }
            else
              bErr = true;
          }
          break;
        case (int)eAdcType.ULTRA_SONIC:
          {
            s = str.Substring(ADC_OFFSET, ULTRA_SONIC);
            if (double.TryParse(s, out d))
						{
							d /= 10.0;
              adc = string.Format("{0:F1}㎝", d);
						}
            else
              bErr = true;
          }
          break;
        case (int)eAdcType.THREE_PHASE_CURRENT:
#if false
          {
            s = str.Substring(ADC_OFFSET, THREE_PHASE_CURRENT);
            d = double.Parse(s);
            adc = string.Format("{0:F1}A", d);
          }
#else //kkb 220425
          {
            string r_, s_, t_;
            r_ = str.Substring(ADC_OFFSET + 0, THREE_PHASE_CURRENT);
            s_ = str.Substring(ADC_OFFSET + 4, THREE_PHASE_CURRENT);
            t_ = str.Substring(ADC_OFFSET + 8, THREE_PHASE_CURRENT);

            if(double.TryParse(r_, out d))
						{
							d /= 10.0;
              adc = string.Format("R = {0:F1}A\n", d);
						}
            else
              bErr = true;
            if(double.TryParse(s_, out d))
						{
							d /= 10.0;
              adc += string.Format("S = {0:F1}A\n", d);
						}
            else
              bErr = true;
            if(double.TryParse(t_, out d))
						{
							d /= 10.0;
              adc += string.Format("T = {0:F1}A", d);
						}
            else
              bErr = true;
          }
#endif
          break;
        case (int)eAdcType.TWO_PHASE_CURRENT:
          {
            s = str.Substring(ADC_OFFSET, TWO_PHASE_CURRENT);
            if(double.TryParse(s, out d))
						{
							d /= 10.0;
              adc = string.Format("{0:F1}A", d);
						}
            else
              bErr = true;
          }
          break;
      }

      s = str.Substring(battery_offset, BATTERY);
      if (!Int32.TryParse(s, out battery))
        bErr = true;

      s = str.Substring(rssi_offset, RSSI);
      if(!Int32.TryParse(s, out rssi))
        bErr = true;

      m_btnIndex.TextDescrCaption.Text = (m_nIndex + 1).ToString();
      m_btnData.TextDescrCaption.Text = string.Format("DATA_LEN\n = {0}\nADC_TYPE\n = {1}",
					data_len, Enum.GetName(typeof(eAdcType), adc_type));
      m_btnData.Invalidate(false);

      m_btnAdc.TextDescrCaption.Text = adc;
      m_btnAdc.Invalidate(false);

      m_btnProgressBattery.ProgressBarMin = 0;
      m_btnProgressBattery.ProgressBarMax = 99;
      m_btnProgressBattery.ProgressBarValue = battery;
      m_btnProgressBattery.TextDescrCaption.Text = string.Format("{0}%", m_btnProgressBattery.ProgressBarValue);
      m_btnProgressRssi.ProgressBarMin = 0;
      m_btnProgressRssi.ProgressBarMax = 99;
      m_btnProgressRssi.ProgressBarValue = rssi;
      m_btnProgressRssi.TextDescrCaption.Text = string.Format("-{0}", m_btnProgressRssi.ProgressBarValue);
      //Invalidate(false);

      return bErr;
    }
  }
}
