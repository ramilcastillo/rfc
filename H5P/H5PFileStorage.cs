using System.Collections;
using System.Collections.Generic;

namespace H5P
{
    public interface H5PFileStorage
    {
        void saveLibrary(Dictionary<string,dynamic> library);
        void saveContent(Dictionary<string,dynamic> source, string[] content);
        void deleteContent(string[] content);
        void cloneContent(string id, int newId);
        string getTmpPath();
        void exportContent(int id, string target);
        void exportLibrary(Dictionary<string,dynamic> library, string target, string developmentPath = null);
        void saveExport(string source, string filename);
        void deleteExport(string filename);
        bool hasExport(string filename);
        void cacheAssets(string[] files, string key);
        Dictionary<string,dynamic> getCachedAssets(string key);
        void deleteCachedAssets(string[] keys);
        string getContent(string file_path);
        void saveFile(H5peditorFile file, int contentId);
        void cloneContentFile(string file, string fromId, int toId);
        object moveContentDirectory(string source, string contentId =null);
        string getContentFile(string file, int contentId);
        void remoteContentFile(string file, int contentId);
        bool hasWriteAccess();
    }
}
