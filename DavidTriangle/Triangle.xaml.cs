using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        double triangleHeight = 270.0;
        double triangleWidth = 300.0;
        /// <summary>
        /// 初始化标尺
        /// </summary>
        private void InitiRuler()
        {
            double h = triangleHeight;
            double w = triangleWidth;
            SolidColorBrush brush  = new SolidColorBrush(Colors.Black);
            int rulerNumber = 10;
            for (int i = 1; i < 10; i++)
            {
               
                double x =  (w * i / 20);
                double y = h * i / 10;
                Line lineCH4 = new Line();
                lineCH4.Stroke = brush;
                lineCH4.X1 = (w / 2) - x;
                lineCH4.Y1 = y;
                lineCH4.X2 = (w / 2) - x + 5;
                lineCH4.Y2 = y;
                if (i % 2 == 0)
                {
                    rulerNumber =100- rulerNumber * i;
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
                this.rootCanvas.Children.Add(lineC2H4);

                Line lineC2H2 = new Line();
                lineC2H2.Stroke = brush;
                lineC2H2.X1 = w * i / 10;
                lineC2H2.Y1 = h;
                lineC2H2.X2 = lineC2H2.X1 + 3;
                lineC2H2.Y2 = lineC2H2.Y1 - 5;
                this.rootCanvas.Children.Add(lineC2H2);
                rulerNumber = 10;
            }
        }
    }
}
