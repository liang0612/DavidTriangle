using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace DavidTriangle
{
    class C2H2Converter : IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return value;
            
            double c2h2Value = double.Parse(value.ToString());
            //double y = (100 - c2h2Value) * Triangle.triangleHeight / 100;
            //double x = Triangle.triangleWidth - c2h2Value * Triangle.triangleWidth/100;
            double x = CoordinateConverterHelp.CoordinateConverter(c2h2Value, EnumGas.C2H2).X;
            if (parameter.ToString() == "Left")
            {
                return x - 3;
            }
            else if (parameter.ToString() == "Top")
            {
                return Triangle.triangleHeight - 3;
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
