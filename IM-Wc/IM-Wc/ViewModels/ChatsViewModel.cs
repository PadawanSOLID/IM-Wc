using CommunityToolkit.Mvvm.ComponentModel;
using IM_Wc.Models;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM_Wc.ViewModels
{
    public partial class ChatsViewModel : ObservableObject, INavigationAware
    {
        [ObservableProperty]
        string name;

        [ObservableProperty]
        ObservableCollection<ChartRecord> chatRecords;
        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var chatListItem = navigationContext.Parameters.GetValue<ChatListItem>("chat");
            Name = chatListItem.Name;
            
        }
    }
}
