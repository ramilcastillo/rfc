using ENMT_V2.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENMT_V2.Repository.Interface
{
    public interface IWaterfallRepository
    {
        string[] GetFilesFromPath();
        IEnumerable<Waterfall_Imp_Data> GetListWaterfall_Imp_Data(string filename);
        IEnumerable<Waterfall_NSB_Data> GetListWaterfall_NSB_Data(string filename);
    }
}
