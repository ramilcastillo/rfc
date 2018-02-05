using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5P.Editor
{
    public interface H5PEditorAjaxInterface
    {
        string[] getLatestLibraryVersions();
        string getContentTypeCache(string machineName = null);
        string[] getAuthorsRecentlyUsedLibraries(); // sorter by most recently used.
        bool validateEditorToken(string token);
    }
}
