using CommunityToolkit.Mvvm.ComponentModel;
using IM_Wc.Constants;
using IM_Wc.Models;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM_Wc.ViewModels
{
    public partial class ChatsListViewModel : ObservableObject, INavigationAware
    {
        private IRegionNavigationService _contentNavigationService;

        [ObservableProperty]
        ObservableCollection<ChatListItem> chats = [];

        [ObservableProperty]
        ChatListItem selectedChatListItem;

        public ChatsListViewModel(IRegionManager regionManager)
        {
            _contentNavigationService = regionManager.Regions[Regions.MainRegion].NavigationService;
        }

        partial void OnSelectedChatListItemChanging(ChatListItem? oldValue, ChatListItem newValue)
        {
            if (newValue == null)
            {
                _contentNavigationService.RequestNavigate(ContentPageKeys.Empty);
            }
            else
            {
                var param = new NavigationParameters();
                param.Add("chat", newValue);
                _contentNavigationService.RequestNavigate(ContentPageKeys.Chats, param);
            }
        }
        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            InitChats();
        }

        void InitChats()
        {
            Chats.Clear();
            Chats.Add(new() { Image = "/Assets/friendA.jpg", Datetime = DateTime.Now.AddDays(-20).ToShortDateString(), Name = "Friend A", LastMessage = "hello" });
            Chats.Add(new() { Image = "/Assets/friendB.jpg", Datetime = DateTime.Now.AddMinutes(-20).ToShortTimeString(), Name = "Friend B", LastMessage = "ok" });
            Chats.Add(new() { Image = "/Assets/groupA.jpg", Datetime = DateTime.Now.AddYears(-1).ToShortDateString(), Name = "Group A", LastMessage = "test message." });
            Chats.Add(new() { Image = "/Assets/groupB.jpg", Datetime = DateTime.Now.AddSeconds(-20).ToShortTimeString(), Name = "Group B", LastMessage = "[4 records] Friend A: good job." });
        }
    }
}
