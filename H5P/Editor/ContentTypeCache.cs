using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5P.Editor
{
    public class ContentTypeCache
    {
           public bool outdated { get; set; }
            public string libraries { get; set; }
            public string[] recentlyUsed { get; set; }
            public H5PCore apiVersion { get; set; }
            public string details { get; set; }
    }
}
