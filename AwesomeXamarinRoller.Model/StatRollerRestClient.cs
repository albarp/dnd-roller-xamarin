using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeXamarinAndroidRoller.Model
{
    public class StatRollerRestClient
    {
        private static readonly String BASE_URL = "https://stat-roller-express.herokuapp.com/";

        private HttpHelper _httpHelper;

        public async Task<Design> GetDndDesign()
        {
            _httpHelper = new HttpHelper();

            string requestUrl = BASE_URL + "dnd/design";

            Design resp = await _httpHelper.GetAsync<Design>(requestUrl, new { });

            return resp;
        }

        public async Task<ApplicationStat[]> RollDndDefault()
        {
            _httpHelper = new HttpHelper();

            string requestUrl = BASE_URL + "roll/dnd/default";

            ApplicationStat[] resp = await _httpHelper.GetAsync<ApplicationStat[]>(requestUrl, new { });

            return resp;
        }
    }
}
