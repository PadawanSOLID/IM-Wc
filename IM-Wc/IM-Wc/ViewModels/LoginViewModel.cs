using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IM_Wc.ViewModels
{
    public partial class LoginViewModel:ObservableObject
    {
        Window window;
        public string Name { get; set; } = "Test";
        [ObservableProperty]
        Visibility tdCodeVisibility=Visibility.Collapsed;
        [ObservableProperty]
        string tdCode="/Assets/tdcode.png";
        [RelayCommand]
        void Loaded(Window win)
        {
            window = win;
        }
        [RelayCommand]
        void SwitchAccount()
        {
            TdCodeVisibility = Visibility.Visible;
        }
        [RelayCommand]
        async Task Login()
        {

            var r = await PendingLogin();
            if (r)
            {
                window.DialogResult = true;
                window.Close();
            }
            else
            {
                MessageBox.Show("登录失败！");
            }
        }

        async Task<bool> PendingLogin()
        {
            /*
           *loginRequest
           */
            return  true;
        }
    }
}
