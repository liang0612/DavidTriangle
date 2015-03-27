using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DavidTriangle
{
    public static class CoordinateConverterHelp
    {
        public static Point CoordinateConverter(double value, EnumGas gas)
        {
            double x = 0;
            double y = 0;
            double w = Triangle.triangleWidth;
            double h = Triangle.triangleHeight;
            switch (gas)
            {
                case EnumGas.C2H2:
                    y = h;
                    x = w - value * w / 100;
                    break;
                case EnumGas.C2H4:
                    y = value * h / 100;
                    x = w * (y + h) / (2 * h);
                    break;
                case EnumGas.CH4:
                    y = (100 - value) * h / 100;
                    x = w / 2 - w * y / (2 * h);
                    break;
                default:
                    break;
            }
            return new Point(x, y);
        }

        public static double PointConvertCH(Point point, EnumGas gas)
        {
            double w = Triangle.triangleWidth;
            double h = Triangle.triangleHeight;
            switch (gas)
            {
                case EnumGas.C2H2:
                    return 100 * (w - point.X) / w;
                case EnumGas.C2H4:
                    return 100 * point.Y / h;
                case EnumGas.CH4:
                    return 100- 100 * point.Y / h;
                default:
                    break;
            }
            return 0;
        }
    }
}
