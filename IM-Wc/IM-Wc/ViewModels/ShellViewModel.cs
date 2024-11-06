using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
using System.Windows;

namespace IM_Wc.ViewModels
{
    public partial class ShellViewModel : ObservableObject
    {
        IRegionManager _regionManager;
        IDialogService _dialogService;
        IRegionNavigationService _listNavigationService;
        IRegionNavigationService _contentNavigationService;

        [ObservableProperty]
        ObservableCollection<NaviBarItem> naviBarItems =
            [
                new() { Icon = "CommentRegular", View = ContentPageKeys.Chats,List=ListPageKeys.ChatsList},
                new() { Icon = "AddressBookRegular", View =ContentPageKeys.Contacts,List=ListPageKeys.ContactsList},
                new() { Icon = "StarRegular", View = ContentPageKeys.Favorites,List=ListPageKeys.FavoritesList },
            ];

        [ObservableProperty]
        NaviBarItem selectedNaviItem;

        partial void OnSelectedNaviItemChanged(NaviBarItem value)
        {
           _listNavigationService.RequestNavigate(value.List);
            _contentNavigationService.RequestNavigate(ContentPageKeys.Empty);
        }

        [RelayCommand]
        void Loaded()
        {
            try
            {
              _listNavigationService=  _regionManager.Regions[Regions.ListRegion].NavigationService;
                _contentNavigationService = _regionManager.Regions[Regions.MainRegion].NavigationService;
                SelectedNaviItem=NaviBarItems.First();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message); 
            }
        }

        [RelayCommand]
        void ShowDialog(string dialogName)
        {
            _dialogService.Show(dialogName);
        }

        public ShellViewModel(IRegionManager regionManager,IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;
        }
    }
}
