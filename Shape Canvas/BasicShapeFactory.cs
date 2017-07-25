using ShultzM_ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Drawing;
using System.Windows.Input;
using System.Windows.Controls;

namespace Shape_Canvas
{
    class BasicShapeFactory : ShapeFactory
    {
        private const int MAX_SIZE = 255;
        private const int MAX_COLOR_NUM = 255;
        private SolidColorBrush blackBrush;

        public Canvas CurrentCanvas { get; set; }
        public BasicShapeFactory(Canvas canvas)
        {
            blackBrush = new SolidColorBrush(Colors.Black);
            CurrentCanvas = canvas;

        }
        public override Shape CreateShape(string shapeType)
        {
            Shape currentShape;
            switch (shapeType)
            { 
                case "Ellipses":
                    currentShape = new Ellipse();
                    break;
                case "Rectangle":
                    currentShape = new Rectangle();
                    break;
                default:
                    throw new InvalidOperationException();
            }
            SetValues(currentShape);
            return currentShape;
        }

        public void SetValues(Shape currentShape)
        {
            currentShape.Height = MAX_SIZE.Random(1);
            currentShape.Width = MAX_SIZE.Random(1);
            currentShape.StrokeThickness = 1;
            currentShape.Stroke = blackBrush;
            currentShape.Fill = new SolidColorBrush(Color.FromArgb(MAX_COLOR_NUM, (byte)MAX_COLOR_NUM.Random(), (byte)MAX_COLOR_NUM.Random(), (byte)MAX_COLOR_NUM.Random()));

            currentShape.MouseRightButtonDown += Shape_MouseRightButtonDown;

            
        }

        private void Shape_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            CurrentCanvas.Children.Remove((Shape)sender);
        }
    }
}
