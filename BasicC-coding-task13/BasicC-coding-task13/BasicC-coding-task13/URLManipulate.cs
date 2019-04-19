using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicC_coding_task13
{
    public class URLManipulate
    {
        public string AddOrChangeUrlParameter(string url, string keyValueParameter)
        {
            if (url.IndexOf('=') == -1 && keyValueParameter != "")
            {
                url = url + '?' + keyValueParameter;
                return url;
            }
            if (keyValueParameter == "")
            {
                return url;
            }

            var newParameter = keyValueParameter.Split('=');
            if (url.IndexOf(newParameter[0]) != -1)
            {
                var newUrl = url.Split('=');
                url = newUrl[0] + '=' + newParameter[1];
                return url;
            }

            var result = url + '&' + keyValueParameter;
            return result;
        }
    }
}
