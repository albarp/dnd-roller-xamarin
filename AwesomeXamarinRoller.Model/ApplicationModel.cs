using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeXamarinAndroidRoller.Model
{
    public class ApplicationModel
    {
        private static ApplicationModel _instance;

        private static StatRollerRestClient _statRollerRestClient;

        private List<MenuItemDefinition> _menuItems;
        public List<MenuItemDefinition> MenuItems
        {
            get
            {
                return _menuItems;
            }
        }

        public Design Design { get; private set; }

        public ApplicationStat[] Stats { get; private set; }

        private ApplicationModel() 
        {
            _statRollerRestClient = new StatRollerRestClient();

            _menuItems = new List<MenuItemDefinition>();

            _menuItems.Add(new MenuItemDefinition("Basic Roller", "A roller with some nice preset."));
            _menuItems.Add(new MenuItemDefinition("Advanced Roller", "Fine tune your hero with fine tuned stats."));
            _menuItems.Add(new MenuItemDefinition("Class Roller", "Choose a job, roll your stats."));
            _menuItems.Add(new MenuItemDefinition("Star Roller", "Let the stars decide."));
        }

        public async Task GetDndDesign()
        {
            Design = await _statRollerRestClient.GetDndDesign();

            Stats = new ApplicationStat[Design.Stats.Length];

            for (int i = 0; i < Design.Stats.Length; i++ )
            {
                Stats[i] = new ApplicationStat { Name = Design.Stats[i] };
            }
        }

        public async Task RollDndDefault()
        {
            ApplicationStat[] applicationsServerStats = await _statRollerRestClient.RollDndDefault();

            for (int i = 0; i < applicationsServerStats.Length; i++)
            {
                Stats[i] = applicationsServerStats[i];
            }
        }

        public static ApplicationModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ApplicationModel();
                }
                return _instance;
            }
        }
    }
}
