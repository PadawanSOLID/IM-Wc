using CommunityToolkit.Mvvm.ComponentModel;
using IM_Wc.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM_Wc.ViewModels
{
    public partial class ShellViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<NaviBarItem> naviBarItems =
            [
                new() { Icon = "CommentRegular", Tooltip = "Chats" },
                new() { Icon = "AddressBookRegular", Tooltip = "Contacts" },
                new() { Icon = "StarRegular", Tooltip = "Favorites" },
                new() { Icon = "FolderClosedRegular", Tooltip = "Chat Files" },
                new() { Icon = "SunRegular", Tooltip = "Moments" },
                new() { Icon = "AirbnbBrands", Tooltip = "Channels" },
                new() { Icon = "BellRegular", Tooltip = "Top Stories" },
                new() { Icon = "MagnifyingGlassSolid", Tooltip = "Search" },
            ];
    }
}
