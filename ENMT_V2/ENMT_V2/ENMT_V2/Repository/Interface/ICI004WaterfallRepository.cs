using ENMT_V2.Core.Model;
using System.Collections.Generic;

namespace ENMT_V2.Repository.Interface
{
    public interface ICI004WaterfallRepository
    {
        string[] GetFilesFromPath();
        IEnumerable<CI004_Waterfall> GetListCI004Waterfall(string filename);
    }
}
