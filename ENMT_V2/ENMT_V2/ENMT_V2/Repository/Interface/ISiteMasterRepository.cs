using ENMT_V2.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ENMT_V2.Repository.Interface
{
    public interface ISiteMasterRepository
    {
        string[] GetFilesFromPath();
        IEnumerable<SiteMaster> GetListSiteMaster(string filename);
    }
}
