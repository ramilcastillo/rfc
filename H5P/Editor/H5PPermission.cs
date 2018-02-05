using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5P.Editor
{
    public class H5PPermission
    { 
        public const int  INSTALL_RECOMMENDED = 0;
        public const int  UPDATE_LIBRARIES = 1;
        public const int DOWNLOAD_H5P  = 2;
        public const int EMBED_H5P =3;
        public const int CREATE_RESTRICTED= 4;
    }
}
