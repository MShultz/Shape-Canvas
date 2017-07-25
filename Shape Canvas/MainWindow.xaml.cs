using ShultzM_ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shape_Canvas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BasicShapeFactory factory;
        public MainWindow()
        {
            InitializeComponent();
            factory = new BasicShapeFactory(MyCanvas);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyCanvas.Children.RemoveRange(0, MyCanvas.Children.Count);
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mouseLoc = e.GetPosition(MyCanvas);
            String option = (1.Random() == 0 ? "Ellipses" : "Rectangle");
            Shape current = factory.CreateShape(option);
            MyCanvas.Children.Add(current);
            Canvas.SetTop(current, mouseLoc.Y - current.Height/2);
            Canvas.SetLeft(current, mouseLoc.X - current.Width/2);
        }
    }
}
