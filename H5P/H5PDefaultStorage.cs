using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace H5P
{
    public class H5PDefaultStorage : H5PFileStorage
    {

        #region Temporary Declaration
        private string path;
        private string alteditorpath;
        #endregion
        public  H5PDefaultStorage(string path, string alteditorpath=null)
        {
            this.path = path;
            this.alteditorpath = alteditorpath;
        }
        public string content = "";
        public string assetContent = "";
        string cssRelPath = "";
        public string type = "";
        public void cacheAssets(string[] files, string key)
        {
          
        List<Dictionary<string,dynamic>> lst = new List<Dictionary<string,dynamic>>();
            foreach (Dictionary<string,dynamic> a in lst)
            {
                if(a == null)
                {
                    continue;
                }
            }

            content = String.Empty;

            foreach (Dictionary<string,dynamic> a in lst)
            {
                if (a.Keys == (object)lst[0])
                {
                    assetContent = File.ReadAllText(this.path);
                    cssRelPath = ""; // Regex.Replace("","");

                    if (type == "scripts")
                    {
                        content = assetContent + ";\n";

                    }
                    else
                    {

                        content = ""; /*preg_replace_callback(
              '/url\([\'"]?([^"\')]+)[\'"]?\)/i',
              function ($matches) use ($cssRelPath) {
                  if (preg_match("/^(data:|([a-z0-9]+:)?\/)/i", $matches[1]) === 1) {
                    return $matches[0]; // Not relative, skip
                  }
                  return 'url("../' . $cssRelPath . $matches[1] . '")';
              },
              $assetContent) . "\n";*/
                    }
                }

                /*self::dirReady("{$this->path}/cachedassets");
          $ext = ($type === 'scripts' ? 'js' : 'css');
          $outputfile = "/cachedassets/{$key}.{$ext}";
          file_put_contents($this->path . $outputfile, $content);
          $files[$type] = array((object) array(
            'path' => $outputfile,
            'version' => ''*/
            }
        }
         
        public void cloneContent(string id, int newId)
        {
            //Library l = new Library();

            Dictionary<string,dynamic> l = new Dictionary<string,dynamic>();
            l.Add("path",this.path);
            string path;
            path = this.path;

            if (File.Exists(path))
            {
                copyFileTree(l, id);
            }
        }

        public void cloneContentFile(string file, string fromId, int toId)
        {
            throw new NotImplementedException();
        }

        public void deleteCachedAssets(string[] keys)
        {
            string[] array = {"js", "css"};
            foreach (string k in keys)
            {
                foreach (string j in array)
                {
                    if (File.Exists(path))
                    {
                        path = null;
                    }
                }

            }
        }

        public void deleteContent(string[] content)
        {
            deleteFileTree(this.path);
        }
        public string target = "";

        public void deleteExport(string filename)
        {
            target = this.path;

            if (File.Exists(target))
            {
                target = null;
            }
        }

        public string source = "";
        public void exportContent(int id, string target)
        {
            //Library l = new Library();
            Dictionary<string,dynamic> ht = new Dictionary<string,dynamic>();
            source = this.path;
            ht.Add("path", source);
            if (File.Exists(source))
            {
                copyFileTree(ht, target);
            }
            else
            {
                File.Exists(target);
            }
        }
        public string folder = "";
        public string srcPath = "";
        public void exportLibrary(Dictionary<string,dynamic> library, string target, string developmentPath = null)
        {
            folder = libraryToString(library, true);
            srcPath = developmentPath == null ? "libraries/" + folder : developmentPath;
            copyFileTree(library, target);
           
        }

        public string libraryToString(Dictionary<string,dynamic> lib, bool s = true)
        {
            return "";
        }

        public string css = "";
        public Dictionary<string,dynamic> getCachedAssets(string key)
        {
            //Files f = new Files();
            Dictionary<string,dynamic> f = new Dictionary<string,dynamic>();
            Dictionary<string,dynamic> files = null;

            string js = "";

            js = "/cachedassets/"+key +".js";

            if (File.Exists(this.path + js))
            {
                f.Add("path",js);
                f.Add("version", "");
            }

            css = "/cachedassets/" + key + ".css";

            if (File.Exists(this.path + css))
            {
                f.Add("path", css);
                f.Add("version", "");

            }
            return String.IsNullOrEmpty(f["value"].ToString())? null : files;
        }

        public string getContent(string file_path)
        {
            return file_get_contents(file_path);
        }

        public string getContentFile(string file, int contentId)
        {
            string path = "";
            path = this.path;

            return File.Exists(path) ? path : null;
        }
        public string file_get_contents(string path)
        {
            return "";
        }
        public string temp;
        public string getTmpPath()
        {
            temp = this.path;
            if (File.Exists(temp))
            {
                return temp + Guid.NewGuid();
            }

            return temp + Guid.NewGuid();
        }

        public bool hasExport(string filename)
        {
            target = this.path;
            return File.Exists(target);
        }

        public bool hasWriteAccess()
        {
            if (File.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object moveContentDirectory(string source, string contentId = null)
        {
            var result = "";
            if (source == null)
            {
                result = null;
            }
            return result;  
        }

        public void remoteContentFile(string file, int contentId)
        {
            throw new NotImplementedException();
        }

        public void saveContent(Dictionary<string,dynamic> source, string[] content)
        {
            dest = this.path;

            deleteFileTree(dest);

            copyFileTree(source, dest);
        }

        public void saveExport(string source, string filename)
        {
            this.deleteExport(filename);

            if (!File.Exists(this.path))
            {
                throw new Exception("Unable to create directory for H5P export file.");
            }
        }

        public void saveFile(H5peditorFile file, int contentId)
        {
            throw new NotImplementedException();
        }

        public string dest;

        public void saveLibrary(Dictionary<string,dynamic> library)
        {
            dest = this.path;

            deleteFileTree(dest);

            copyFileTree(library, dest);
           
        }
        public void deleteFileTree(string dest)
        {

        }
        public void copyFileTree(Dictionary<string,dynamic> lib, string dest)
        {
            if (!File.Exists(path))
            {
                throw new Exception("unabletocopy");
            }
        }

    }
}
