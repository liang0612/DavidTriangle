using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Expression.Controls;

namespace DavidTriangle
{
    /// <summary>
    /// Triangle.xaml 的交互逻辑
    /// </summary>
    public partial class Triangle : UserControl
    {
        public Triangle()
        {
            InitializeComponent();
            InitiRuler();
        }

        public static double triangleHeight = 443;
        public static double triangleWidth = 512;
        /// <summary>
        /// 初始化标尺
        /// </summary>
        private void InitiRuler()
        {
            double h = triangleHeight;
            double w = triangleWidth;
            SolidColorBrush brush = new SolidColorBrush(Colors.Black);
            int rulerNumber = 10;
            for (int i = 1; i < 10; i++)
            {

                double x = (w * i / 20);
                double y = h * i / 10;
                Line lineCH4 = new Line();
                lineCH4.Stroke = brush;
                lineCH4.X1 = (w / 2) - x;
                lineCH4.Y1 = y;
                lineCH4.X2 = (w / 2) - x + 5;
                lineCH4.Y2 = y;
                if (i % 2 == 0)
                {
                    rulerNumber = 100 - 10 * i;
                    TextBlock txt = new TextBlock();
                    txt.Text = rulerNumber.ToString();
                    this.rootCanvas.Children.Add(txt);
                    Canvas.SetLeft(txt, lineCH4.X1 - 10 - 10);
                    Canvas.SetTop(txt, y - 10);
                }
                this.rootCanvas.Children.Add(lineCH4);

                Line lineC2H4 = new Line();
                lineC2H4.Stroke = brush;
                lineC2H4.X2 = (w / 2) + x;
                lineC2H4.Y2 = y;
                lineC2H4.X1 = (w / 2) + x - 5;
                lineC2H4.Y1 = y + 3;

                if (i % 2 == 0)
                {
                    rulerNumber = 10 * i;
                    TextBlock txt = new TextBlock();
                    txt.Text = rulerNumber.ToString();
                    this.rootCanvas.Children.Add(txt);
                    Canvas.SetLeft(txt, lineC2H4.X2 + 5);
                    Canvas.SetTop(txt, lineC2H4.Y2 - 10);
                }
                this.rootCanvas.Children.Add(lineC2H4);

                Line lineC2H2 = new Line();
                lineC2H2.Stroke = brush;
                lineC2H2.X1 = w * i / 10;
                lineC2H2.Y1 = h;
                lineC2H2.X2 = lineC2H2.X1 + 3;
                lineC2H2.Y2 = lineC2H2.Y1 - 5;
                if (i % 2 == 0)
                {
                    rulerNumber = 100 - 10 * i;
                    TextBlock txt = new TextBlock();
                    txt.Text = rulerNumber.ToString();
                    this.rootCanvas.Children.Add(txt);
                    Canvas.SetLeft(txt, lineC2H2.X1 - 5);
                    Canvas.SetTop(txt, lineC2H2.Y1);
                }
                this.rootCanvas.Children.Add(lineC2H2);
            }
        }

        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Canvas.SetLeft(thumb1, Canvas.GetLeft(thumb1) + e.HorizontalChange);
            Canvas.SetTop(thumb1, Canvas.GetTop(thumb1) + e.VerticalChange);
            //lineH.Y1 = Canvas.GetTop(thumb1) + e.VerticalChange;
            //lineH.Y2 = Canvas.GetTop(thumb1) + e.VerticalChange;
        }

        private void thumb1_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            double x = Canvas.GetLeft(thumb1) + thumb1.Width;
            double y = Canvas.GetTop(thumb1) + thumb1.Height;
            double c2h2 = CoordinateConverterHelp.PointConvertCH(new Point(x, y), EnumGas.C2H2);
            double c2h4 = CoordinateConverterHelp.PointConvertCH(new Point(x, y), EnumGas.C2H4);
            double ch4 = CoordinateConverterHelp.PointConvertCH(new Point(x, y), EnumGas.CH4);
            thumb1.ToolTip = string.Format("X:{0},Y{1},C2H2:{2},C2H4:{3},Ch4:{4}", x, y, c2h2, c2h4, ch4);
        }

    }
}
