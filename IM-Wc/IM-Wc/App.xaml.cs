using IM_Wc.Models;
using IM_Wc.ViewModels;
using IM_Wc.Views;
using Prism.Ioc;
using Prism.Unity;
using System.Configuration;
using System.Data;
using System.Windows;

namespace IM_Wc
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        public App()
        {
            LoadConfig();
        }
        //将上次登录的用户信息读到静态User属性
        void LoadConfig()
        {

        }
        public static User User { get; set; }
        protected override Window CreateShell()
        {
            var login = Container.Resolve<LoginView>().ShowDialog();
            if (login.Value)
            {
                return Container.Resolve<ShellWindow>();
            }
            else { Shutdown();return null; }

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginView, LoginViewModel>();
        }
    }

}
