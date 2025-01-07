using IM_Wc.Constants;
using Prism.Regions;
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

namespace IM_Wc.Views
{
    /// <summary>
    /// ChatFilesView.xaml 的交互逻辑
    /// </summary>
    public partial class ChatFilesView : UserControl
    {
        public ChatFilesView(IRegionManager regionManager)
        {
          
            InitializeComponent();
            RegionManager.SetRegionManager(cc, regionManager);
            RegionManager.SetRegionName(cc, Regions.ChatsFilesRegion);
        }
    }
}
