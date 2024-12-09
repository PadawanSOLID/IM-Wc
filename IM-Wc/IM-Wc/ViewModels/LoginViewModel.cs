using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IM_Wc.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IM_Wc.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        Window window;

        /// <summary>
        /// 登录名
        /// </summary>
        [ObservableProperty]
        public string name = "Test";

        /// <summary>
        /// 扫码登录界面可见性
        /// </summary>
        [ObservableProperty]
        Visibility tdCodeVisibility = Visibility.Collapsed;

        /// <summary>
        /// 是否正在请求二维码图片
        /// </summary>
        [ObservableProperty]
        double imageOpacity=0.5;

        [ObservableProperty]
        bool isProcessBarActive;
        /// <summary>
        /// 二维码图片url，默认先读取本地资源文件，可更改为网络url
        /// </summary>
        [ObservableProperty]
        string tdCode = "/Assets/tdcode.png";

        /// <summary>
        /// 登录窗口加载完后将窗体对象传给this.window字段，用于控制窗体返回结果和关闭
        /// </summary>
        /// <param name="win"></param>
        [RelayCommand]
        void Loaded(Window win)
        {
            window = win;
        }

        /// <summary>
        /// 切换账号按钮命令：使扫码登录和二维码可见，并请求后端发送二维码图片
        /// </summary>
        [RelayCommand]
        async Task SwitchAccount()
        {
            IsProcessBarActive = true;
            TdCodeVisibility = Visibility.Visible;
            TdCode = await PendingTDCode();
            ImageOpacity = 1;
            IsProcessBarActive = false;
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
        async Task<string> PendingTDCode()
        {
            /*
        *pending code Request
        */
            return "/Assets/tdcode.png";
        }
        async Task<bool> PendingLogin()
        {
            /*
           *loginRequest
           */
            await HubConnect();
          
            return true;
        }
        async Task HubConnect()
        {
            HubConnection hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:8888/UserHub")
                .WithAutomaticReconnect()
                .WithServerTimeout(TimeSpan.FromSeconds(30)).Build();
            
            hubConnection.On<Entities.User>("LoginCallback", user =>
            {
             
            });
            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("Login",1);
        }
    }
}
