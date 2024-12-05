using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM_Wc.Models
{
    public partial class NewFriendsItem:ObservableObject
    {
        [ObservableProperty]
        string name;
        [ObservableProperty]
        string icon;
        [ObservableProperty]
        string description;
        [ObservableProperty]
        bool isAccepted;
    }
}
