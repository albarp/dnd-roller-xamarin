using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Flurl;

namespace AwesomeXamarinAndroidRoller.Model
{
    internal static class HttpParamaters
    {

        internal static string _separator = ":";
        /*
         * services/design/v01/:lang/taskmodel/:taskTypeId
         */

        internal static string ToQuery(this string url, object parameters = null)
        {
            if (parameters == null)
                return url;

            var resUrl = url;
            var queryParams = new Dictionary<string, string>();

            var pars = parameters.GetType().GetRuntimeProperties();
            foreach (var item in pars)
            {
                var name = item.Name;
                var value = item.GetValue(parameters).ToString();

                if (value == null)
                    value = string.Empty;

                var par = _separator + name;

                if (url.Contains(par))
                {
                    resUrl = resUrl.Replace(par, value);
                }
                else
                {
                    queryParams.Add(name, value);
                }

            }

            var res = resUrl.SetQueryParams(queryParams).ToString();
            return res;
        }

    }
}
