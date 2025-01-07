using CommunityToolkit.Mvvm.ComponentModel;
using IM_Wc.Constants;
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
    public partial class FavoritesListViewModel : ObservableObject, INavigationAware
    {
        [ObservableProperty]
        ObservableCollection<FavoritesItem> favoritesItems = [
            new(){Icon="Grid",Name="All Favorites",Type=FavoritesType.All},
            new(){Icon="Clock",Name="Recents",Type=FavoritesType.Image},
            new(){Icon="Image",Name="Images and Videos",Type=FavoritesType.Image},
            new(){Icon="Folder",Name="Files",Type=FavoritesType.File},
            ];

        [ObservableProperty]
        ObservableCollection<FavoritesItem> tags = [];

        [ObservableProperty]
        FavoritesItem selectedFavority;
        private IRegionNavigationService _contentNavigationService;

        partial void OnSelectedFavorityChanged(FavoritesItem value)
        {
            if (value==null)
            {
                _contentNavigationService.RequestNavigate(ContentPageKeys.Empty);   
            }
        }

        public FavoritesListViewModel()
        {
            
        }
        public FavoritesListViewModel(IRegionManager regionManager)
        {
            _contentNavigationService = regionManager.Regions[Regions.MainRegion].NavigationService;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }
    }
}
