using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM_Wc.Models
{
    public enum FavoritesType
    {
        File = 0x01,
        Image = 0x10,
        All = File | Image
    }
    public class FavoritesItem
    {
        public string Icon { get; set; }
        public string Name { get; set; }

        public FavoritesType Type { get; set; }
    }
}
