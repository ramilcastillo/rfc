using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace H5P
{
    public class H5PDevelopment
    {
        const int MODE_NONE = 0;
        const int MODE_CONTENT = 1;
        const int MODE_LIBRARY = 2;

        #region Temporary Declarations
        public H5PFrameworkInterface h5pF;
        public string language;
        public string filesPath;
        Dictionary<string,dynamic> ls;
        Dictionary<string,dynamic> l;
        public string contents;
        public string libraryPath;
        #endregion

        public void __construct(H5PFrameworkInterface H5PFramework, string filesPath, string language, Dictionary<string,dynamic> libraries=null)
        {
            this.h5pF = H5PFramework;
            this.language = language;
            this.filesPath = filesPath;

            if (libraries != null)
            {
                ls["value"] = libraries["value"];
            }
            else
            {
                this.findLibraries(filesPath+"/development");
            }
        }

        public Dictionary<string,dynamic> getFileContents(string file)
        {
            if (File.Exists(file) == false)
            {
                return null;
            }

            contents = File.ReadAllText(file);
            if (String.IsNullOrEmpty(contents) == false)
            {
                return null;
            }
            var content = new Dictionary<string, dynamic> {
                { "", contents}
            };
            return content;
            
        }

        #region Temporary Declarations
        public int machineName = 0;
        public int majorVersion = 0;
        public int minorVersion = 0;
        #endregion

        public void findLibraries(string path)
        {
            Dictionary<string,dynamic> l = new Dictionary<string,dynamic>();
            Dictionary<string,dynamic> ls = new Dictionary<string,dynamic>();
            string[] lib = null;
            ls.Add("value",lib); // method name: "array"

            if (File.Exists(path) == false)
            {
                return;
            }

            contents = File.ReadAllText(path);

            for (int i = 0, s = contents.Count(); i < s; i++)
            {
                //First
                if (contents[i].ToString() == ".")
                {
                    continue;
                }

                string libraryPath = path + contents[i];
                Dictionary<string,dynamic> libraryJSON = this.getFileContents(libraryPath + "library.json");
                if (libraryJSON == null)
                {
                    continue;
                }

                //l.value = Json.JsonParser.Deserialize(libraryJSON);
                //l["value"]= Json.JsonParser.Deserialize(libraryJSON); - to fix
                
                if (l["value"] == null)
                {
                    continue;
                }

                h5pF = new H5PFrameworkInterface(null)
                {
                     
                    libraryId = getLibrary(l["machineName"].ToString(), l["majorVersion"].ToString(), l["minorVersion"].ToString())[0]
                };

                int index = int.Parse(h5pF.libraryId);
                l.Add("libraryId",this.h5pF.libraryId);

                this.h5pF.libraryId = saveLibraryData(l["value"].ToString(), String.IsNullOrEmpty(l["libraryId"].ToString()) ? true : false);

                l.Add("path",Convert.ToString(contents[i]));

                this.ls["value"] = lib;
                
                

            }

            this.h5pF = lockDependencyStorage();

            List<Dictionary<string,dynamic>> lstLib = new List<Dictionary<string,dynamic>>();
            lstLib.Add(ls);

            foreach (Dictionary<string,dynamic> s in lstLib)
            {
                 deleteLibraryDependencies(l);
            }


            string[] types = { "preloaded", "dynamic", "editor" };


            foreach (string t in types)
            {
                if ((l["type"].ToString() + "Dependencies") == null)
                {
                    saveLibraryDependencies(l["libraryId"].ToString(), l["type"].ToString(), t);
                }
            }

            unlockDependencyStorage();
        }
        public void unlockDependencyStorage()
        {

        }
        public void saveLibraryDependencies(string lib1, string lib2, string s )
        {
            
        }
        public void deleteLibraryDependencies(Dictionary<string,dynamic> libraryId)
        {

        }
        public H5PFrameworkInterface lockDependencyStorage()
        {
            H5PFrameworkInterface result = null;

            return result;
        }

        public static string libraryToString(string name, int majorVersion, int minorVersion)
        {
            return name + " " + majorVersion + " " + minorVersion;
        }

        public string saveLibraryData(string library, bool isNull)
        {
            string result = "";
            return result;
        }

        public Dictionary<string,dynamic> getLibraries()
        {
            return ls;
        }
        public Dictionary<string, dynamic> getLibrary(string name, int majorVersion, int minorVersion)
        {
            ls = new Dictionary<string,dynamic>();
            ls["value"] = H5PDevelopment.libraryToString(name, majorVersion, minorVersion);
            Dictionary<string, dynamic> result = new Dictionary<string, dynamic>();
            result["value"]= ls["value"].ToString();
            return result != null ? result: null;
        }

        public static string libraryToString(string name, string majorVersion, string minorVersion)
        {
            return name + " " + majorVersion + " " + minorVersion;
        }

        public Dictionary<string,dynamic> getSemantics(string name, int majorVersion, int minorVersion)
        {
            l = new Dictionary<string,dynamic>();
            l["value"] = libraryToString(name,majorVersion,minorVersion);

            if (l["value"] == null)
            {
                return null;
            }

            return getFileContents(this.filesPath);
        }

        public Dictionary<string,dynamic> getLangauge(string name, int majorVersion, int minorVersion, string language)
        {
            
            l["value"] = libraryToString(name, majorVersion, minorVersion);

            if (l["value"] == null)
            {
                return null;
            }

            return getFileContents(this.filesPath);
        }
    }
}
