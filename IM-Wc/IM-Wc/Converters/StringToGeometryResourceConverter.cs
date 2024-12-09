using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace IM_Wc.Converters
{
    public class StringToGeometryResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str=value as string;
            var resourceKey = str + "Geometry";
            if( App.Current.FindResource(resourceKey) is Geometry geo)
            {
                return geo;
            }
            else
            {
                throw new ResourceReferenceKeyNotFoundException();
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
