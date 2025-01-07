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
using System.Windows.Controls;

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
                new() { Icon = "Chat", View = ContentPageKeys.Chats,List=ListPageKeys.ChatsList},
                new() { Icon = "UserList", View =ContentPageKeys.Contacts,List=ListPageKeys.ContactsList},
                new() { Icon = "Favorite", View = ContentPageKeys.Favorites,List=ListPageKeys.FavoritesList },
            ];

        [ObservableProperty]
        ObservableCollection<NaviBarItem> dialogItems =
           [
               new() { Icon = "ChatFiles", View = ContentPageKeys.Chats,List=DialogKeys.ChatFiles},
                new() { Icon = "Moments", View =ContentPageKeys.Contacts,List=DialogKeys.Moments},
                new() { Icon = "Channels", View = ContentPageKeys.Favorites,List=DialogKeys.Channels },
                new() { Icon = "TopStories", View = ContentPageKeys.Favorites,List=DialogKeys.TopStories },
           ];

        public List<object> Extras { get; set; } =
            [
               "ChatFiles",
               "Moments",
                null,
                "Channels",
                "Channels",
                null,
                "Channels",
            ];

        [ObservableProperty]
        NaviBarItem selectedNaviItem;
        partial void OnSelectedNaviItemChanged(NaviBarItem value)
        {
            _listNavigationService.RequestNavigate(value.List);
            _contentNavigationService.RequestNavigate(ContentPageKeys.Empty);
        }

        private NaviBarItem selectedDialog;
        public NaviBarItem SelectedDialog
        {
            get { return selectedDialog; }
            set
            {
                SetProperty(ref selectedDialog, value);
                if (value != null)
                {
                    _dialogService.Show(value.List);
                }
            }
        }

        [RelayCommand]
        void Loaded()
        {
            try
            {
                _listNavigationService = _regionManager.Regions[Regions.ListRegion].NavigationService;
                _contentNavigationService = _regionManager.Regions[Regions.MainRegion].NavigationService;
                SelectedNaviItem = NaviBarItems.First();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        [RelayCommand]
        void ShowDialog(NaviBarItem dialog)
        {
            _dialogService.Show(dialog.List);
        }

        public ShellViewModel()
        {

        }

        public ShellViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;
        }
    }
}
