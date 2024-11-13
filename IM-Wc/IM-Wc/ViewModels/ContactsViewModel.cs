using CommunityToolkit.Mvvm.ComponentModel;
using IM_Wc.Models;
using Prism.Common;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM_Wc.ViewModels
{
    public partial class ContactsViewModel : ObservableObject, INavigationAware
    {
        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
           
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var param = navigationContext.Parameters.GetValue<Contactor>("contact");
            switch (param.Type)
            {
                case ContactorType.NewFriends:

                    break;
                case ContactorType.OfficalAccount:
                    break;
                case ContactorType.Friend:
                    break;
                case ContactorType.Group:
                    break;
                default:
                    break;
            }
        }
    }
}
