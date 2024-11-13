using MahApps.Metro.Controls;
using Prism.Services.Dialogs;
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
using System.Windows.Shapes;

namespace IM_Wc.Views
{
    /// <summary>
    /// CustomDialogWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CustomDialogWindow : MetroWindow,IDialogWindow
    {
        public CustomDialogWindow()
        {
            InitializeComponent();
        }

        public IDialogResult Result { get; set; }
    }
}
