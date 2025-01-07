using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM_Wc.Models
{
    public enum ContactorType
    {
        NewFriends,
        OfficalAccount,
        Friend,
        Group
    }
    public partial class Contactor : ObservableObject
    {
        public long Id { get; set; }
        [ObservableProperty]
        string name;

        [ObservableProperty]
        string image;

        [ObservableProperty]
        ContactorType type;

        [ObservableProperty]
        string groupName;
    }
}
