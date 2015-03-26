using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace DavidTriangle
{
    public class CH4Converter : IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(value==null)return value;
            double ch4Value = double.Parse(value.ToString());
            double y = (100 - ch4Value) * Triangle.triangleHeight / 100;
            double x = Triangle.triangleWidth/2-Triangle.triangleWidth * y / (2*Triangle.triangleHeight);
            if (parameter.ToString() == "Left")
            {
                return x-3;
            }
            else if (parameter.ToString() == "Top")
            {
                return y-3;
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
