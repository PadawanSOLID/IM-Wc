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
using System.Windows.Data;

namespace IM_Wc.ViewModels
{
    public partial class ContactsListViewModel : ObservableObject, INavigationAware
    {
        private IRegionNavigationService _contentNavigationService;

        [ObservableProperty]
        ObservableCollection<Contactor> contactors=[];

        [ObservableProperty]
        Contactor selectedContactor;

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
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
           
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Init();
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
