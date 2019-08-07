using System;
using System.Collections.Generic;
using System.Text;

namespace WinesWorld.Web.ViewModels.Wine.All
{
    public class WineAllViewModel
    {
        public WineAllViewModel()
        {
            this.wineViewModels = new List<WineViewModel>();
            this.ColourList = new List<Colour>();

        }

        public string Type { get; set; }
        public List<Colour> ColourList { get; set; }
        public string Country { get; set; }

        public List<WineViewModel> wineViewModels { get; set; }
    }
}
