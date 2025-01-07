using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace IM_Wc.Attaches
{
   public class GeometryButtonHelper
    {


        public static Geometry GetIcon(DependencyObject obj)
        {
            return (Geometry)obj.GetValue(IconProperty);
        }

        public static void SetIcon(DependencyObject obj, Geometry value)
        {
            obj.SetValue(IconProperty, value);
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(Geometry), typeof(GeometryButtonHelper), new PropertyMetadata(Geometry.Empty));

      

    }
}
