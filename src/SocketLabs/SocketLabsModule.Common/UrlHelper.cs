using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketLabsModule.Common
{
    public class UrlHelper
    {
        public static string AddQueryStrings(string url, Dictionary<string, string> keyValuePairs)
        {
            var sb = new StringBuilder(url);

            bool containsParams = url.LastIndexOf('?') > 0;

            foreach (var item in keyValuePairs)
            {
                if (String.IsNullOrWhiteSpace(item.Key)) continue;
                if (String.IsNullOrWhiteSpace(item.Value)) continue;

                if (containsParams)
                {
                    sb.AppendFormat("&{0}={1}", item.Key, item.Value);
                }
                else
                {
                    sb.AppendFormat("?{0}={1}", item.Key, item.Value);
                }

                containsParams = true;
            }

            return sb.ToString();
        }
    }
}
