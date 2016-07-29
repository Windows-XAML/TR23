using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace App11
{
    class MyRectangle: Grid
    {
        static int counter = 0;
        public MyRectangle()
        {
            Debug.WriteLine($"Created MyRectangle {counter++}");
            Loaded += MyRectangle_Loaded;
        }

        private void MyRectangle_Loaded(object sender, RoutedEventArgs e)
        {
            Height = 100;
            Width = 100;
            Margin = new Thickness(12);
            Background = new SolidColorBrush(Colors.SteelBlue);
        }
    }
}
