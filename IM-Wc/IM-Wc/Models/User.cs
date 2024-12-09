using CommunityToolkit.Mvvm.ComponentModel;
using IM_Wc.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM_Wc.Models
{
    public partial class User:ObservableObject
    {
        [ObservableProperty]
        long id;
        [ObservableProperty]
        string name;
        [ObservableProperty]
        string avatar;
        [ObservableProperty]
        Activity activity;
    }
}
