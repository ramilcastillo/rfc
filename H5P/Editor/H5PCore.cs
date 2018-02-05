using System.Collections;
using System.Collections.Generic;

namespace H5P.Editor
{
    public class H5PCore
    {
        public string major { get; set; }
        public string minor { get; set; }
        public bool aggregateAssets = true;

        public H5PCore(H5PFrameworkInterface H5PFramework, string path, string url, string language = "en", bool export = false)
        {
            //this.h5pF = H5PFramework;
            ////this.fs = (path instanceof \H5PFileStorage ? path: new \H5PDefaultStorage(path));
            //this.url = url;
            //this.exportEnabled = export;
            //this.development_mode = new H5PDevelopment(); //mode MODE_NONE           
            //this.aggregateAssets = false; // Off by default.. for now
            //this.detectSiteType();
            ////this.fullPluginPath = preg_replace("/\/[^\/]+[\/]?/", "", dirname(__FILE__));
            //this.fullPluginPath = path;
            //// Standard regex for converting copied files paths
            //this.relativePathRegExp = new Regex(@"/^((\.\.\/){1,2})(.*content\/)?(\d+|editor)\/(.+)/");
        }

        public static void deleteFileTree(string path)
        {

        }


       

        public H5PFrameworkInterface h5pF()
        {
            H5PFrameworkInterface result = null;
            return result;
        }



        public static void ajaxSuccess(Dictionary<string,dynamic> libraries, bool result)
        {
            
        }

        public static void ajaxSuccess(Dictionary<string,dynamic> ht)
        {

        }

      

        public static void ajaxError(string str1, string str2, int num)
        {

        }
        public static void ajaxError(string str1, string str2)
        {

        }
        public static void ajaxError(string str1)
        {

        }
        public static void ajaxError(string str1, string str2, object str3, string str4)
        {

        }
       


     
    }
}