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

namespace IM_Wc.ViewModels
{
    public partial class ChatFilesViewModel : ObservableObject, IDialogAware
    {
        private IRegionNavigationService _chatsFilesNavigationService;

        [ObservableProperty]
        ObservableCollection<FavoritesItem> favoritesItems = [
           new(){Icon="Folder",Name="All Files",Type=FavoritesType.All},
            new(){Icon="Clock",Name="Recents",Type=FavoritesType.Image},
            ];

        [ObservableProperty]
        ObservableCollection<FavoritesItem> chatFileTypes = [
            new(){Icon="User",Name="Sender"},
            new(){Icon="MessageCircle",Name="Chat"},
            new(){Icon="FileText",Name="Type"},
            ];

        private FavoritesItem selectedFavoritesItem;

        public FavoritesItem SelectedFavoritesItem
        {
            get { return selectedFavoritesItem; }
            set
            {
                if (value==null)
                {
                    SetProperty(ref selectedFavoritesItem, value);
                }
                else
                {
                    if (selectedFavoritesItem != null)
                    {
                        SelectedFavoritesItem = null;
                        
                    }
                    SetProperty(ref selectedFavoritesItem, value);
                }
            }
        }

        [RelayCommand]
        void Loaded()
        {
        }


        public ChatFilesViewModel()
        {

        }

        public ChatFilesViewModel(IRegionManager regionManager)
        {
            _chatsFilesNavigationService = regionManager.Regions[Regions.ChatsFilesRegion].NavigationService;
        }
        public string Title => "Chat Files";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }
    }
}
