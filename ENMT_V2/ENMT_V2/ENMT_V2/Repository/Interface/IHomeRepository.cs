using ENMT_V2.Core.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ENMT_V2.Repository.Interface
{
    public interface IHomeRepository
    {
        // DataTable ExcelUpload(string _fileName, string _worksheet);
        IEnumerable<CI004_RFDS_NOT_IN_CSS> ExcelUploadReference_CI004_NOT_IN_CSS(string _fileName);
        void Save_CI004_NOT_IN_CSS(DataTable dt);
        DataTable ObtainDataTableFromIEnumerable(IEnumerable<CI004_RFDS_NOT_IN_CSS> items);
    }
}
