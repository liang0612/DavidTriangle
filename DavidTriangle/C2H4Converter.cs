using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace DavidTriangle
{
    public class C2H4Converter : IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return value;
            double c2h4Value = double.Parse(value.ToString());
            double w=Triangle.triangleWidth;
            double h=Triangle.triangleHeight;
            //c2h4Value = 100 - c2h4Value;
            double y =  c2h4Value * Triangle.triangleHeight / 100;
            double x = w * (y + h) / (2 * h);
            if (parameter.ToString() == "Left")
            {
                return x-3;
            }
            else if (parameter.ToString() == "Top")
            {
                return y - 3;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
