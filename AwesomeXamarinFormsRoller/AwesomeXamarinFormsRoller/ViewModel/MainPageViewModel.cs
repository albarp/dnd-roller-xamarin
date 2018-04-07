using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AwesomeXamarinFormsRoller.Models;

namespace AwesomeXamarinFormsRoller.ViewModel
{
    public class MainPageViewModel
    {
        public List<MenuItemDefinition> MenuItems { get; set; }

        public MainPageViewModel()
        {
            MenuItems = new List<MenuItemDefinition>();

            MenuItems.Add(new MenuItemDefinition ("Basic Roller", "A roller with some nice preset."));
            MenuItems.Add(new MenuItemDefinition ("Advanced Roller", "Fine tune your hero with fine tuned stats." ));
            MenuItems.Add(new MenuItemDefinition ( "Class Roller", "Choose a job, roll your stats." ));
            MenuItems.Add(new MenuItemDefinition ("Star Roller", "Let the stars decide."));
        }
    }
}
