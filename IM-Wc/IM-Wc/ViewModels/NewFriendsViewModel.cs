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
   public partial class NewFriendsViewModel:ObservableObject,INavigationAware
    {
        [ObservableProperty]
        ObservableCollection<NewFriendsItem> newFriendsItems;

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //retrieve new friends
            GetNewFriendsList();
        }

        private void GetNewFriendsList()
        {
            ObservableCollection<NewFriendsItem> newFriends = [
               new(){Icon="/Assets/banli.jpg",IsAccepted=false,Name="banli"},
               new(){Icon="/Assets/friendA.jpg",IsAccepted=true,Name="friendA"},
               new(){Icon="/Assets/friendB.jpg",IsAccepted=false,Name="friendB"},
               new(){Icon="/Assets/groupA.jpg",IsAccepted=true,Name="groupA"},
               new(){Icon="/Assets/groupB.jpg",IsAccepted=false,Name="groupB"},
                ];
            NewFriendsItems = newFriends;
        }
    }
}
