using ENMT_V2.Core.Model;
using System.Collections.Generic;

namespace ENMT_V2.Repository.Interface
{
    public interface ILALTERepository
    {
        string[] GetFilesFromPath();
        IEnumerable<LALTE> GetListLALTE(string filename);
    }
}
