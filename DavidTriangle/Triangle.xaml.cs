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
            DrawingPoint();
            InitiRuler();

        }

        public static double triangleHeight = 270.0;
        public static double triangleWidth = 300.0;

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
                    rulerNumber = 100 - rulerNumber * i;
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
        private void DrawingPoint()
        {
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(167, 202, 240));
            Path path = new Path();
            path.StrokeThickness = 0; 
            //path.Opacity = 0.8;
            path.Fill = brush;
            path.Stroke = brush;
            PathGeometry geo = new PathGeometry();
            PathFigure figure = new PathFigure();
            figure.StartPoint = CoordinateConverterHelp.CoordinateConverter(87, EnumGas.CH4);
            figure.IsClosed = false;
            double lineX = CoordinateConverterHelp.CoordinateConverter(45, EnumGas.C2H2).X;
            double lineY = CoordinateConverterHelp.CoordinateConverter(65, EnumGas.CH4).Y;
            LineSegment line = new LineSegment(new Point(lineX,lineY),false);

            double line1X = CoordinateConverterHelp.CoordinateConverter(78, EnumGas.C2H2).X;
            double line1Y = CoordinateConverterHelp.CoordinateConverter(0, EnumGas.CH4).Y;
            LineSegment line1 = new LineSegment(new Point(line1X, line1Y), false);

            LineSegment line2 = new LineSegment(new Point(0, 270), false);

            figure.Segments.Add(line);
            figure.Segments.Add(line1);
            figure.Segments.Add(line2);
            geo.Figures.Add(figure);
            path.Data = geo;
            this.rootCanvas.Children.Add(path);
        }

    }
}
