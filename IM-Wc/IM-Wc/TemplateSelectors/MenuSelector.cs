using IM_Wc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace IM_Wc.TemplateSelectors
{
    public class MenuSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (item == null) return SeparatorTemplate;
            return base.SelectStyle(item, container);
        }
        public Style MenuItemTemplate { get; set; }
        public Style SeparatorTemplate { get; set; }
    }
}
