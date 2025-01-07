using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM_Wc.Models
{
   public partial class ChatListItem:ObservableObject
    {
        [ObservableProperty]
        string name;
        [ObservableProperty]
        string lastMessage;
        [ObservableProperty]
        string image;
        [ObservableProperty]
        string datetime;
        [ObservableProperty]
        string state;
    }
}
