using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IM_Wc.Constants;
using IM_Wc.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace IM_Wc.ViewModels
{
    public partial class ContactsListViewModel : ObservableObject, INavigationAware
    {
        private IRegionNavigationService _contentNavigationService;

        [ObservableProperty]
        ObservableCollection<Contactor> contactors=[];

        [ObservableProperty]
        ObservableCollection<Contactor> searchContacts = [];

        [ObservableProperty]
        Contactor selectedContactor;

        [ObservableProperty]
        Visibility searchContactsVisibility=Visibility.Collapsed;

        partial void OnSelectedContactorChanged(Contactor value)
        {
            if (value==null)
            {
                _contentNavigationService.RequestNavigate(ContentPageKeys.Empty);
            }
            else
            {
                switch (value.Type)
                {
                    case ContactorType.NewFriends:
                        _contentNavigationService.RequestNavigate(ContentPageKeys.NewFriends);
                        break;
                    case ContactorType.OfficalAccount:
                        break;
                    case ContactorType.Friend:
                        var param = new NavigationParameters();
                        param.Add("contact", value);
                        _contentNavigationService.RequestNavigate(ContentPageKeys.Contacts,param);
                        break;
                    case ContactorType.Group:
                        var gparam = new NavigationParameters();
                        gparam.Add("contact", value);
                        break;
                    default:
                        break;
                }
            }
        }


        public ContactsListViewModel(IRegionManager regionManager)
        {
            _contentNavigationService = regionManager.Regions[Regions.MainRegion].NavigationService;
            Init();
        }

        [RelayCommand]
        async Task StartSeachContacts()
        {
            SearchContactsVisibility = Visibility.Visible;
            await ShowAllUsers();
        }

        async Task ShowAllUsers()
        {
            HubConnection hubConnection = new HubConnectionBuilder()
               .WithUrl("http://localhost:8888/UserHub")
               .WithAutomaticReconnect()
               .WithServerTimeout(TimeSpan.FromSeconds(30)).Build();

            hubConnection.On<IEnumerable<Entities.User>>("GetAllUsersCallback", users =>
            {
                SearchContacts = new(users.Select(n => new Contactor
                {
                    Name=n.Name,
                    Id=n.Id,
                }));
            });
            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("GetAllUsers");
        }

        [RelayCommand]
        async Task BackToContactors()
        {
            SearchContactsVisibility = Visibility.Collapsed;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
           
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
           
        }

        void Init()
        {
            Contactors.Clear();
            Contactors.Add(new() { Name = "New Friends", GroupName = "New Friends", Image = "/Assets/newFriends.png", Type = ContactorType.NewFriends });
            Contactors.Add(new() { Name = "Offical Account", GroupName = "Offical Account", Image = "/Assets/officalAccount.png", Type = ContactorType.OfficalAccount });

            Contactors.Add(new() { Name = "friendA", GroupName = "F", Image = "/Assets/friendA.jpg", Type = ContactorType.Friend });
            Contactors.Add(new() { Name = "colleagueB", GroupName = "C", Image = "/Assets/friendB.jpg", Type = ContactorType.Friend });
            Contactors.Add(new() { Name = "groupA", GroupName = "Group", Image = "/Assets/groupA.jpg", Type = ContactorType.Group });
            Contactors.Add(new() { Name = "groupB", GroupName = "Group", Image = "/Assets/groupB.jpg", Type = ContactorType.Group });
            var cvs = CollectionViewSource.GetDefaultView(Contactors);
            cvs.GroupDescriptions.Add(new PropertyGroupDescription("GroupName"));
        }
    }
}
