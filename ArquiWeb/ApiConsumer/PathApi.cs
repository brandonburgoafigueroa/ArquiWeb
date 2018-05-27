using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArquiWeb.ApiConsumer
{
    public class PathApi
    {
        public string UrlApi { set; get; }
        private static PathApi api;
        public static PathApi Instance {
            get {
                if (api == null)
                {
                    api = new PathApi();
                }
                return api;
            }
        }
    }
}
