using ENMT_V2.Core.Model;
using System.Collections.Generic;

namespace ENMT_V2.Repository.Interface
{
    public interface ICI004RFDSRepository
    {
        string[] GetFilesFromPath();
        IEnumerable<CI004_RFDS_NOT_IN_CSS> GetListCI004_RFDS_NOT_IN_CSS(string filename);
        IEnumerable<CI004_RFDS_SECTOR_IN_CSS> GetListCI004_RFDS_SECTOR_IN_CSS(string filename);
        IEnumerable<CI004_RFDS_MISSING_COORDINATES> GetListCI004_RFDS_MISSING_COORDINATES(string filename);
        IEnumerable<CI004_RFDS_DETAILS> GetListCI004_RFDS_DETAILS(string filename);
    }
}
