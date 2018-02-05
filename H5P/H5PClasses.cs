using H5P.Editor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace H5P
{

    /**
    * This class is used for exporting zips
*/
    public class H5PExport
    {
        public H5PFrameworkInterface h5pF;
        public H5PCore h5pC;
        public H5PDevelopment h5pD;
        /**
         * Constructor for the H5PExport
         *
         * @param H5PFrameworkInterface|object $H5PFramework
         *  The frameworks implementation of the H5PFrameworkInterface
         * @param H5PCore $H5PCore
         *  Reference to an instance of H5PCore
         */
        public H5PExport(H5PFrameworkInterface H5PFramework, H5PCore H5PCore)
        {
            this.h5pF = H5PFramework;
            this.h5pC = H5PCore;
        }

        /**
         * Return path to h5p package.
         *
         * Creates package if not already created
         *
         * @param array $content
         * @return string
         */
        public void createExportFile(Dictionary<string, dynamic> content)
        {

            // Get path to temporary folder, where export will be contained
            string tmpPath = this.h5pC.fs.getTmpPath();
            System.IO.Directory.CreateDirectory(tmpPath);

            try
            {
                // Create content folder and populate with files
                //this.h5pC.exportContent(content["id"], "{$tmpPath}/content");
            }
            catch (Exception e)
            {
                this.h5pF.setErrorMessage(this.h5pF.t(e.Message), "failed-creating-export-file");
                //H5PCore::deleteFileTree(tmpPath);
                //return false;
            }

            // Update content.json with content from database            
            System.IO.File.WriteAllText(tmpPath + "/content/content.json", content["params"].ToString());
            // Make embedType into an array            
            string[] embedTypes = content["embedType"].ToString().Split(new char[] { ',' });

            //Build h5p.json
            var h5pJson = new Dictionary<string, dynamic>(); //Dictionary<string,dynamic> h5pJson = new Dictionary<string,dynamic>();
            h5pJson.Add("title", content["title"]);//h5pJson.Add("title", content["title"]);
            h5pJson.Add("language", (content["language"] != null && !string.IsNullOrEmpty((string)content["language"])));//h5pJson.Add("language", (content["language"] != null && !String.IsNullOrEmpty(content["language"].ToString())) ? content["language"] : "und");
            h5pJson.Add("", ((Dictionary<string, dynamic>)content["library"])["name"]);//h5pJson.Add("mainLibrary", ((Dictionary<string,dynamic>)content["library"])["name"]);
            h5pJson.Add("embedTypes", embedTypes);//h5pJson.Add("embedTypes", embedTypes);

            //// Add dependencies to h5p
            foreach (KeyValuePair<string, dynamic> dependency in ((Dictionary<string, dynamic>)content["dependencies"]))//foreach (Dictionary<string,dynamic> dependency in ((Dictionary<string,dynamic>)content["dependencies"]))
            {//{
                var library = dependency.Value["library"];//    library = dependency["library"];

                try//    try
                {//    {
                    string exportFolder = null;//    $exportFolder = NULL;

                    //        // Determine path of export library
                    if ((this.h5pC != null) && (this.h5pC.h5pD != null))//        if (isset($this->h5pC) && isset($this->h5pC->h5pD))
                    {//        {

                        //      // Tries to find library in development folder
                        var isDevLibrary = this.h5pC.h5pD.getLibrary(//      $isDevLibrary = $this->h5pC->h5pD->getLibrary(
                        library["machineName"],//          $library['machineName'],
                        library["majorVersion"],//          $library['majorVersion'],
                        library["minorVersion"]//          $library['minorVersion']
                        );//      );

                        if (isDevLibrary != null)//            if ($isDevLibrary !== NULL) {
                        {
                            exportFolder = "/" + library["path"];//        $exportFolder = "/". $library['path'];

                        }//            }
                    }//        }

                    //    // Export required libraries
                    this.h5pC.fs.exportLibrary(library, tmpPath, exportFolder); //    $this->h5pC->fs->exportLibrary($library, $tmpPath, $exportFolder);
                }//    }
                catch (Exception ex)//    catch (Exception $e) {
                {
                    this.h5pF.setErrorMessage(this.h5pF.t(ex.Message, new Dictionary<string, dynamic> { { "", "failed-creating-export-file" } }));//    $this->h5pF->setErrorMessage($this->h5pF->t($e->getMessage()), 'failed-creating-export-file');
                    H5PCore.deleteFileTree(tmpPath);//        H5PCore::deleteFileTree($tmpPath);
                                                    //        return FALSE;
                }//    }

                //    // Do not add editor dependencies to h5p json.
                if (dependency.Value["type"] == "editor")//    if ($dependency['type'] === 'editor') {
                {
                    continue;//        continue;
                }//    }

                //  // Add to h5p.json dependencies
                h5pJson[(string)dependency.Value["type"] + "Dependencies"][""] = new Dictionary<string, dynamic> {
                    { "machineName",library["machineName"]},
                    { "majorVersion",library["majorVersion"]},
                    { "minorVersion",library["minorVersion"]}
                };//  $h5pJson[$dependency['type']. 'Dependencies'][] = array(
                  //    'machineName' => $library['machineName'],
                  //    'majorVersion' => $library['majorVersion'],
                  //    'minorVersion' => $library['minorVersion']
                  //  );
            }//    }

            //// Save h5p.json
            var results = h5pJson; //$results = print_r(json_encode($h5pJson), true);
            if (File.Exists("{$tmpPath}/h5p.json"))
            {
                File.WriteAllLines("{$tmpPath}/h5p.json", results[""].Value, Encoding.UTF8);
            }//    file_put_contents("{$tmpPath}/h5p.json", $results);


            //// Get a complete file list from our tmp dir
            var files = new Dictionary<string, dynamic>();   //$files = array();
            this.populateFileList(tmpPath, files);  //    self::populateFileList($tmpPath, $files);

            //// Get path to temporary export target file
            var tmpFile = this.h5pC.fs.getTmpPath(); //$tmpFile = $this->h5pC->fs->getTmpPath();

            //// Create new zip instance.
            //$zip = new ZipArchive();
            //$zip->open($tmpFile, ZipArchive::CREATE | ZipArchive::OVERWRITE);

            //    // Add all the files from the tmp dir.
            //    foreach ($files as $file) {
            //        // Please note that the zip format has no concept of folders, we must
            //        // use forward slashes to separate our directories.
            //        if (file_exists(realpath($file->absolutePath)))
            //        {
            //    $zip->addFile(realpath($file->absolutePath), $file->relativePath);
            //        }
            //    }

            //// Close zip and remove tmp dir
            //$zip->close();
            //    H5PCore::deleteFileTree($tmpPath);

            //$filename = $content['slug']. '-'. $content['id']. '.h5p';
            //    try
            //    {
            //  // Save export
            //  $this->h5pC->fs->saveExport($tmpFile, $filename);
            //    }
            //    catch (Exception $e) {
            //  $this->h5pF->setErrorMessage($this->h5pF->t($e->getMessage()), 'failed-creating-export-file');
            //        return false;
            //    }

            //    unlink($tmpFile);
            //$this->h5pF->afterExportCreated($content, $filename);

            //    return true;
        }
        public void populateFileList(string input1, Dictionary<string, dynamic> input2)
        {

        }
    }
    /**
* Functions and storage shared by the other H5P classes
*/
    public class H5PCore
    {
        public bool updateContentTypeCache()
        {
            bool result = true;
            return result;
        }
        public bool hasPermission(int permission)
        {
            bool result = true;
            return result;
        }
        public bool getOption(string sResult, bool bResult)
        {
            bool result = true;

            return result;

        }
        public string contentJson()
        {
            return string.Empty;
        }

        public string h5pJson()
        {
            return string.Empty;
        }
        public string getUploadedH5pFolderPath()
        {
            return string.Empty;
        }

        public H5PCore moveContentDirectory(string[] data, string[] contentId)
        {
            H5PCore core = null;
            return core;

        }
        public string getMessages(string message)
        {
            string result = string.Empty;

            return result;
        }
        public string saveFile(H5peditorFile input1, int input2)
        {
            return string.Empty;
        }
        public string t(string str1)
        {
            string result = string.Empty;
            return result;
        }
        public bool fetchExternalData(string input1, string[] input2, bool input3, string input4)
        {
            return true;
        }
        public string getUploadedH5pPath()
        {
            string result = string.Empty;

            return result;
        }
        public Dictionary<string, dynamic> findLibraryDependencies(Dictionary<string, dynamic> input1, Dictionary<string, dynamic> input2, object input3)
        {
            return null;
        }
        public static Dictionary<string, dynamic> libraryFromString(Dictionary<string, dynamic> input)
        {
            Dictionary<string, dynamic> result = null;

            return result;
        }
        public static Dictionary<string, dynamic> coreApi
        {
            get
            {
                Dictionary<string, dynamic> returnValue = new Dictionary<string, dynamic>();
                returnValue.Add("majorVersion", "1");
                returnValue.Add("minorVersion", "14");
                return returnValue;
            }
        }
        public static string[] styles = new string[] { "styles/h5p.css", "styles/h5p-confirmation-dialog.css", "styles/h5p-core-button.css" };
        public static string[] scripts = new string[] {"js/jquery.js",
          "js/h5p.js",
          "js/h5p-event-dispatcher.js",
          "js/h5p-x-api-event.js",
          "js/h5p-x-api.js",
          "js/h5p-content-type.js",
          "js/h5p-confirmation-dialog.js",
          "js/h5p-action-bar.js"};
        public static string[] adminScripts = new string[] { "js/jquery.js", "js/h5p-utils.js" };

        public static string defaultContentWhitelist = "json png jpg jpeg gif bmp tif tiff svg eot ttf woff woff2 otf webm mp4 ogg mp3 wav txt pdf rtf doc docx xls xlsx ppt pptx odt ods odp xml csv diff patch swf md textile vtt webvtt";
        public static string defaultLibraryWhitelistExtras = "js css";
        public string librariesJsonData, contentJsonData, mainJsonData, url, fullPluginPath;
        public Regex relativePathRegExp;
        public H5PDefaultStorage fs = new H5PDefaultStorage("");
        public H5PFrameworkInterface h5pF;
        public H5PDevelopment h5pD;
        public H5PCore h5pC;

        public bool exportEnabled, aggregateAssets, disableFileCheck;
        H5PDevelopment development_mode;
        const int SECONDS_IN_WEEK = 604800;
        // Disable flags
        public const string DISABLE_NONE = "0";
        public const string DISABLE_FRAME = "1";
        public const string DISABLE_DOWNLOAD = "2";
        public const string DISABLE_EMBED = "4";
        public const string DISABLE_COPYRIGHT = "8";
        public const string DISABLE_ABOUT = "16";
        public const string DISPLAY_OPTION_FRAME = "frame";
        public const string DISPLAY_OPTION_DOWNLOAD = "export";
        public const string DISPLAY_OPTION_EMBED = "embed";
        public const string DISPLAY_OPTION_COPYRIGHT = "copyright";
        public const string DISPLAY_OPTION_ABOUT = "icon";

        // Map flags to string
        public static Dictionary<string, dynamic> disable
        {
            get
            {
                Dictionary<string, dynamic> returnValue = new Dictionary<string, dynamic>();
                returnValue.Add(DISABLE_FRAME, DISPLAY_OPTION_FRAME);
                returnValue.Add(DISABLE_DOWNLOAD, DISPLAY_OPTION_DOWNLOAD);
                returnValue.Add(DISABLE_EMBED, DISPLAY_OPTION_EMBED);
                returnValue.Add(DISABLE_COPYRIGHT, DISPLAY_OPTION_COPYRIGHT);
                return returnValue;
            }
        }
        public H5PCore(H5PFrameworkInterface H5PFramework, string path, string url, string language = "en", bool export = false)
        {
            this.h5pF = H5PFramework;
            //this.fs = (path instanceof \H5PFileStorage ? path: new \H5PDefaultStorage(path));
            this.url = url;
            this.exportEnabled = export;
            this.development_mode = new H5PDevelopment(); //mode MODE_NONE           
            this.aggregateAssets = false; // Off by default.. for now
            this.detectSiteType();
            //this.fullPluginPath = preg_replace("/\/[^\/]+[\/]?/", "", dirname(__FILE__));
            this.fullPluginPath = path;
            // Standard regex for converting copied files paths
            this.relativePathRegExp = new Regex(@"/^((\.\.\/){1,2})(.*content\/)?(\d+|editor)\/(.+)/");
        }

        /**
         * Save content and clear cache.
         *
         * @param array $content
         * @param null|int $contentMainId
         * @return int Content ID
         */
        public int saveContent(Dictionary<string, dynamic> content, int? contentMainId = null)
        {
            if (content != null)
            {
                this.h5pF.updateContent(content, contentMainId);
            }
            else
            {
                content["id"] = this.h5pF.insertContent(content, contentMainId).ToString();
            }
            // Some user data for content has to be reset when the content changes.
            this.h5pF.resetContentUserData(contentMainId.HasValue ? contentMainId.Value : Convert.ToInt32(content["id"]));
            return Convert.ToInt32(content["id"]);
        }
        /**
         * Load content.
         *
         * @param int $id for content.
         * @return object
         */
        public Dictionary<string, dynamic> loadContent(int id)
        {
            Dictionary<string, dynamic> content = this.h5pF.loadContent(id);
            if (content != null)
            {
                Dictionary<string, dynamic> library = new Dictionary<string, dynamic>();
                library["id"] = content["libraryId"];
                library["name"] = content["libraryName"];
                library["majorVersion"] = content["libraryMajorVersion"];
                library["minorVersion"] = content["libraryMinorVersion"];
                library["embedTypes"] = content["libraryEmbedTypes"];
                library["fullscreen"] = content["libraryFullscreen"];
                //   content["library"] = library;

                content["libraryId"] = null;
                content["libraryName"] = null;
                content["libraryEmbedTypes"] = null;
                content["libraryFullscreen"] = null;
            }
            return content;
        }
        /**
        * Detects if the site was accessed from localhost,
        * through a local network or from the internet.
        */
        public void detectSiteType()
        {
            object type = this.h5pF.getOption("site_type", "local");
            var _SERVER = new Dictionary<string, dynamic>();
            //// Determine remote/visitor origin
            if (type == "network" || (type == "local" && ((_SERVER["REMOTE_ADDR"] != null) && !Regex.Match(_SERVER["REMOTE_ADDR"], @"/^localhost$|^127(?:\.[0-9]+){0,2}\.[0-9]+$|^(?:0*\:)*?:?0*1$/i")))) //if (type === "network" ||
            { //    (type === "local" &&
              //     isset($_SERVER["REMOTE_ADDR"]) &&
              //     !preg_match("/^localhost$|^127(?:\.[0-9]+){0,2}\.[0-9]+$|^(?:0*\:)*?:?0*1$/i", $_SERVER["REMOTE_ADDR"]))) {
                if ((_SERVER["REMOTE_ADDR"] != null) && filter_var(_SERVER["REMOTE_ADDR"], "FILTER_VALIDATE_IP", "FILTER_FLAG_NO_PRIV_RANGE")) //    if (isset($_SERVER["REMOTE_ADDR"]) && filter_var($_SERVER["REMOTE_ADDR"], FILTER_VALIDATE_IP, FILTER_FLAG_NO_PRIV_RANGE))
                {//    {
                 //    // Internet
                    this.h5pF.setOption("site_type", "internet");//    this.h5pF.setOption("site_type", "internet");
                }//    }
                else if ((string)type == "local")//    elseif($type === "local") {
                {//    // Local network
                    this.h5pF.setOption("site_type", "network");//    this.h5pF.setOption("site_type", "network");
                } //    }
            }//}
            this.h5pF.setOption("site_type", "network");
        }
        public bool filter_var(string input1, string input2, string input3)
        {
            return true;
        }
        /**
         * Filter content run parameters, rebuild content dependency cache and export file.
         *
         * @param Object|array $content
         * @return Object NULL on failure.
         */
        public object filterParameters(Dictionary<string, dynamic> content)
        {
            var jsonSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            if ((content["filtered"] != null) && (!this.exportEnabled || (content["slug"] != null && this.fs.hasExport(content["slug"] + "-" + content["id"] + ".h5p"))))
            {
                return content["filtered"];
            }
            // Validate and filter against main library semantics.
            // H5PContentValidator validator = new H5PContentValidator(this.h5pF, this);
            Dictionary<string, dynamic> _params = new Dictionary<string, dynamic>();
            _params.Add("library", content["library"].ToString());
            string des = jsonSerializer.Deserialize(content["params"].ToString(), typeof(string)).ToString();
            _params.Add("params", des);
            if (_params == null)
                return null;

            //validator.validateLibrary(_params, (object)array("options" => array($params.library)));

            string json = jsonSerializer.Serialize(_params);
            _params["params"] = json;
            // Update content dependencies.
            //      content["dependencies"] = validator.getDependencies();
            // Sometimes the parameters are filtered before content has been created
            if (content["id"] != null)
            {
                this.h5pF.deleteLibraryUsage(Convert.ToInt32(content["id"]));
                this.h5pF.saveLibraryUsage(Convert.ToInt32(content["id"]), content["dependencies"] != null);
                if (content["slug"] != null)
                {
                    content["slug"] = this.generateContentSlug(content);
                    // Remove old export file
                    this.fs.deleteExport(content["id"] + ".h5p");
                }
                if (this.exportEnabled)
                {
                    //// Recreate export file
                    var exporter = new H5PExport(this.h5pF, this);//exporter = new H5PExport($this.h5pF, $this);
                    exporter.createExportFile(content);//exporter.createExportFile(content);
                }
                // Cache.
                this.h5pF.updateContentFields(content["id"], new Dictionary<string, dynamic> {
                        { _params[""] ,"filtered"},
                        { content["slug"], "slug"}
                    });//$this.h5pF.updateContentFields($content["id"], array(
                       //  "filtered" => $params,
                       //  "slug" => $content["slug"]
                       //));
            }
            return _params;
        }

        //************************************************
        //added by nate
        private string GenerateSlug(string phrase)
        {
            string str = this.RemoveAccent(phrase).ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        private string RemoveAccent(string txt)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
        //************************************************
        /**
         * Generate content slug
         *
         * @param array $content object
         * @return string unique content slug
         */
        private string generateContentSlug(Dictionary<string, dynamic> content)
        {
            string slug = GenerateSlug(content["title"].ToString());
            bool available = true;
            while (!available)
            {
                if (available == false)
                {
                    //If not available, add number suffix.
                    List<string> matches = new List<string>();
                    //if (preg_match("/(.+-)([0-9]+)$/", $slug, $matches))
                    if (Regex.IsMatch(slug, "/(.+-)([0-9]+)$/"))
                    {
                        slug = matches[1] + (Convert.ToInt32(matches[2]) + 1);
                    }
                    else
                    {
                        slug += "-2";
                    }
                }
                available = this.h5pF.isContentSlugAvailable(slug);
            }
            return slug;
        }
        ///**
        // * Find the files required for this content to work.
        // *
        // * @param int $id for content.
        // * @param null $type
        // * @return array
        // */
        public Dictionary<string, dynamic> loadContentDependencies(int id, int? type)//public void loadContentDependencies(int id, int? type)
        {//{
            string key = null;
            Dictionary<string, dynamic> dependencies = this.loadContentDependencies(id, type);//    object dependencies = this.h5pF.loadContentDependencies(id, type);
            if (this.h5pD != null)//    if (this.h5pD != null)
            {//    {
                Dictionary<string, dynamic> developmentLibraries = this.h5pD.getLibraries();//        Dictionary<string,dynamic> developmentLibraries = this.h5pD.getLibraries();
                foreach (KeyValuePair<string, dynamic> dependency in dependencies)//        foreach (dependencies as key.dependency)
                {//        {
                    var libraryString = libraryToString(dependency.Value);//            string libraryString = libraryToString(dependency);
                    if (developmentLibraries[libraryString] != null)//            if (developmentLibraries[libraryString] != null)
                    {//            {
                        developmentLibraries[libraryString]["dependencyType"] = dependencies[key]["dependencyType"];//                developmentLibraries[libraryString]["dependencyType"] = dependencies[$key]["dependencyType"];
                                                                                                                    //                dependencies[key] = developmentLibraries[libraryString];
                    }//            }
                } //        }
            }//    }
            return dependencies;//    return dependencies;
        }//}  
         ///**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
        // * Get all dependency assets of the given type
        // *
        // * @param array $dependency
        // * @param string $type
        // * @param array $assets
        // * @param string $prefix Optional. Make paths relative to another dir.
        // */
        public void getDependencyAssets(Dictionary<string, dynamic> dependency, string type, Dictionary<string, dynamic> assets)//private void getDependencyAssets($dependency, $type, &$assets, $prefix = "")
        {//{
         //    Check if dependency has any files of this type
            if (string.IsNullOrEmpty(dependency[""])) //    if (empty($dependency[$type]) || $dependency[$type][0] === "") {
            {
                return;//        return;
            }//    }
             //    Check if we should skip CSS.
            if (type == "preloadedCss" && ((dependency["dropCss"] != null) && dependency["dropCss"] == 1))//    if ($type === "preloadedCss" && (isset($dependency["dropCss"]) && $dependency["dropCss"] === "1")) {
            {
                return;//        return;
            }//    }
            foreach (KeyValuePair<string, dynamic> file in dependency["type"])//    foreach ($dependency[$type] as $file) {
            {
                string prefix = null;
                assets = new Dictionary<string, dynamic>() {
                        { "path", prefix+"/"+ dependency["path"] + "/" +file.GetType() == typeof(string[])?file.Value["path"]:file },
                        { "version", dependency["version"] } };//      $assets[] = (object)array(
                                                               //        "path" => $prefix. "/". $dependency["path"]. "/".trim(is_array($file) ? $file["path"] : $file),
                                                               //        "version" => $dependency["version"]
                                                               //              );
            } //    }
        }//}
         ///**
        // * Combines path with cache buster / version.
        // *
        // * @param array $assets
        // * @return array
        // */
        public Dictionary<string, dynamic> getAssetUrls(Dictionary<string, dynamic> assets)//public void getAssetsUrls($assets)
        {//{
            var urls = new Dictionary<string, dynamic>();//    $urls = array();
            foreach (KeyValuePair<string, dynamic> asset in assets)//    foreach ($assets as $asset) {
            {
                url = asset.Value["path"];//      $url = $asset.path;
                                          //        Add URL prefix if not external
                if (((string)asset.Value["path"]).Contains("://") == false)//        if (strpos($asset.path, "://") === FALSE)
                {//        {
                    url = this.url + url; //        $url = $this.url. $url;
                }//        }
                 //        Add version/ cache buster if set
                if (asset.Value["version"] != null)//        if (isset($asset.version))
                {//            {
                    url = asset.Value["version"];//        $url.= $asset.version;
                }//            }

                urls[""] = url; ;//      $urls[] = $url;} //    }
            }
            return urls;//    return $urls;
        } //}
          ///**
        // * Return file paths for all dependencies files.
        // *
        // * @param array $dependencies
        // * @param string $prefix Optional. Make paths relative to another dir.
        // * @return array files.
        // */
        public Dictionary<string, dynamic> getDependenciesFiles(Dictionary<string, dynamic> dependencies, string prefix = null)//public void getDependenciesFiles($dependencies, $prefix = "")
        {//{
         //    Build files list for assets
            var files = new Dictionary<string, dynamic> {//    $files = array(
                    { "scripts",new Dictionary<string,dynamic>()},//     "scripts" => array(),
                    { "styles",new Dictionary<string,dynamic>()}//     "styles" => array()
                };//   );
            var result = new Dictionary<string, dynamic>();
            string key = null;//    $key = null;
                              //    Avoid caching empty files
            if (dependencies == null)//    if (empty($dependencies))
            {//    {
                return files;//        return $files;
            }//    }
            if (this.aggregateAssets)//    if ($this.aggregateAssets) {
            {//        Get aggregated files for assets
                key = getDependenciesHash(dependencies);//      $key = self::getDependenciesHash($dependencies);
                var cachedAssets = this.fs.getCachedAssets(key);//       $cachedAssets = $this.fs.getCachedAssets($key);
                if (cachedAssets != null)//        if ($cachedAssets !== NULL) {
                {

                    return files.Union(cachedAssets).ToDictionary(d => d.Key, d => d.Value);//            return array_merge($files, $cachedAssets); // Using cached assets
                } //        }

            }//    }
             //    Using content dependencies
            foreach (KeyValuePair<string, dynamic> dependency in dependencies)//    foreach ($dependencies as $dependency) {
            {
                if (string.IsNullOrEmpty(dependency.Value["path"]) == false)//        if (isset($dependency["path"]) === FALSE)
                {//        {
                    dependency.Value["path"] = "libraries/" + H5PCore.libraryToString(dependency.Value, true);//        $dependency["path"] = "libraries/".H5PCore::libraryToString($dependency, TRUE);
                    dependency.Value["preloadedJs"] = ((string)dependency.Value["preloadedJs"]).Split(',');               //        $dependency["preloadedJs"] = explode(",", $dependency["preloadedJs"]);
                    dependency.Value["preloadedCss"] = ((string)dependency.Value["preloadedCss"]).Split(','); //        $dependency["preloadedCss"] = explode(",", $dependency["preloadedCss"]);
                }//        }
                dependency.Value["version"] = "?ver={" + dependency.Value["majorVersion"] + "}{" + dependency.Value["minorVersion"] + "}{" + dependency.Value["patchVersion"] + "}";//      $dependency["version"] = "?ver={$dependency["majorVersion"]}.{$dependency["minorVersion"]}.{$dependency["patchVersion"]}";
                                                                                                                                                                                    //      $this.getDependencyAssets($dependency, "preloadedJs", $files["scripts"], $prefix);
                                                                                                                                                                                    //      $this.getDependencyAssets($dependency, "preloadedCss", $files["styles"], $prefix);
            }//    }
             //    if ($this.aggregateAssets) {
             //        Aggregate and store assets
             //      $this.fs.cacheAssets($files, $key);
             //        Keep track of which libraries have been cached in case they are updated
             //      $this.h5pF.saveCachedAssets($key, $dependencies);

            return files;//    return $files;
        } //    }

        //}
        public static string getDependenciesHash(Dictionary<string, dynamic> dependencies)//private static void getDependenciesHash(&$dependencies)
        {//{
         //    Build hash of dependencies
            var toHash = new Dictionary<string, dynamic>();//    $toHash = array();
                                                           //    Use unique identifier for each library version
            foreach (KeyValuePair<string, dynamic> dep in dependencies)//    foreach ($dependencies as $dep) {
            {
                toHash.Add("", dep.Value["machineName"] + "-" + dep.Value["majorVersion"]);//      $toHash[] = "{$dep["machineName"]}-{$dep["majorVersion"]}.{$dep["minorVersion"]}.{$dep["patchVersion"]}";
            }  //    }
               //    Sort in case the same dependencies comes in a different order
            toHash.Values.OrderBy(x => x);//    sort($toHash);
                                          //    Calculate hash sum
            return string.Join("", toHash);//return   string.Join("", p //    return hash("sha1", implode("", $toHash));
        }//}
         ///**
        // * Load library semantics.
        // *
        // * @param $name
        // * @param $majorVersion
        // * @param $minorVersion
        // * @return string
        // */
        public Dictionary<string,dynamic> loadLibrarySemantics(string name, int majorVersion, int minorVersion)//public void loadLibrarySemantics($name, $majorVersion, $minorVersion)
        {//{
            Dictionary<string,dynamic> semantics = null;//    $semantics = NULL;
            if (this.h5pD != null)//    if (isset($this.h5pD))
            {//    {
             //        Try to load from dev lib
                semantics = this.h5pD.getSemantics(name, majorVersion, minorVersion);//      $semantics = $this.h5pD.getSemantics($name, $majorVersion, $minorVersion);
            }//    }
            if (semantics == null)//    if ($semantics === NULL) {
            {//        Try to load from DB.
                semantics = this.h5pF.loadLibrarySemantics(name, majorVersion, minorVersion);//      $semantics = $this.h5pF.loadLibrarySemantics($name, $majorVersion, $minorVersion);
            }//    }
            if (semantics != null)//    if ($semantics !== NULL) {
            {
                //      $semantics = json_decode($semantics);
                this.h5pF.alterLibrarySemantics(semantics, name, majorVersion, minorVersion); //      $this.h5pF.alterLibrarySemantics($semantics, $name, $majorVersion, $minorVersion);
            }//    }
            return semantics; //    return $semantics;
        }//}
         ///**
        // * Load library.
        // *
        // * @param $name
        // * @param $majorVersion
        // * @param $minorVersion
        // * @return array or null.
        // */
        public Dictionary<string, dynamic> dependencyLibrary = new Dictionary<string, dynamic>();
        public Dictionary<string, dynamic> library;
        public Dictionary<string, dynamic> dependencyKey;
        public string type;
        public Dictionary<string, dynamic> loadLibrary(string name, int majorVersion, int minorVersion)//public void loadLibrary(string name, int majorVersion, int minorVersion)
        {//{
         //   Dictionary<string,dynamic> library = new Dictionary<string,dynamic>();
            if (this.h5pD != null)//    if (this.h5pD != null)
            {//    {
             //        Try to load from dev
                library = this.h5pD.getLibrary(name, majorVersion, minorVersion);//       library = this.h5pD.getLibrary($name, $majorVersion, $minorVersion);
                if (library != null)                                                                //        if ($library !== NULL) {
                {
                    library["semantics"] = this.h5pD.getSemantics(name, majorVersion, minorVersion);//        $library["semantics"] = $this.h5pD.getSemantics($name, $majorVersion, $minorVersion);
                }//        }
            }//    }
            if (library == null)//    if ($library === NULL) {
            {//        Try to load from DB.
                library = this.h5pF.loadLibrary(name, majorVersion, minorVersion);//      $library = $this.h5pF.loadLibrary($name, $majorVersion, $minorVersion);
            }//    }
            return library;//    return $library;
        }//}
         ///**
        // * Deletes a library
        // *
        // * @param stdClass $libraryId
        // */
        public void deleteLibrary(Dictionary<string,dynamic> libraryId)//public void deleteLibrary($libraryId)
        {//{
            this.h5pF.deleteLibrary(libraryId);//    $this.h5pF.deleteLibrary($libraryId);
        }//}
         ///**
        // * Recursive. Goes through the dependency tree for the given library and
        // * adds all the dependencies to the given array in a flat format.
        // *
        // * @param $dependencies
        // * @param array $library To find all dependencies for.
        // * @param int $nextWeight An integer determining the order of the libraries
        // *  when they are loaded
        // * @param bool $editor Used internally to force all preloaded sub dependencies
        // *  of an editor dependency to be editor dependencies.
        // * @return int
        // */
        public int findLibraryDependecies(Dictionary<string, dynamic> dependencies, Dictionary<string, dynamic> library, int nextWeight = 1, bool editor = false)//public void findLibraryDependencies(&$dependencies, $library, $nextWeight = 1, $editor = FALSE)
        {//{
            var result = new Dictionary<string, dynamic> {
                    { "type", "dynamic"},
                    { "type", "preloaded"},
                    { "type", "editor"}
                };
            foreach (KeyValuePair<string, dynamic> s in result)//    foreach (array("dynamic", "preloaded", "editor") as $type) {
            {
                var property = result["type"] + "Dependencies";//      $property = $type. "Dependencies";

                if (!(library["property"] != null))//        if (!isset($library[$property]))
                { //        {
                    continue;  //            continue; // Skip, no such dependencies.
                }//        }
                if (type == "preloaded" && editor == true)//        if ($type === "preloaded" && $editor === TRUE) {
                {//            All preloaded dependencies of an editor library is set to editor.
                    type = "editor";//        $type = "editor";
                }        //        }
                foreach (KeyValuePair<string, dynamic> dependency in library["property"])     //        foreach ($library[$property] as $dependency) {
                {
                    dependencyKey = type + "-" + dependency.Value["machineName"];//        $dependencyKey = $type. "-". $dependency["machineName"];
                    if (dependencies[dependencyKey.Values.ToString()])                                                             //            if (isset($dependencies[$dependencyKey]) === TRUE)
                    {                                                        //            {
                        continue;                                                        //                continue; // Skip, already have this.
                    }                                                            //            }
                    dependencyLibrary = this.loadLibrary(dependency.Value["machineName"], dependency.Value["majorVersion"], dependency.Value["minorVersion"]);                                                          //        $dependencyLibrary = $this.loadLibrary($dependency["machineName"], $dependency["majorVersion"], $dependency["minorVersion"]);
                    if (dependencyLibrary != null)                                                            //            if ($dependencyLibrary) {
                    {                                                           //          $dependencies[$dependencyKey] = array(
                        dependencies[dependencyKey.Keys.ToString()] = new Dictionary<string, dynamic> {
                            {"dependency", dependencyLibrary},
                            { "type", type}
                        };                                                           //            "library" => $dependencyLibrary,
                                                                                     //            "type" => $type
                                                                                     //          );
                        nextWeight = this.findLibraryDependecies(dependencies, dependencyLibrary, nextWeight, type == "editor" ? true : false); //          $nextWeight = $this.findLibraryDependencies($dependencies, $dependencyLibrary, $nextWeight, $type === "editor");
                                                                                                                                                //          $dependencies[$dependencyKey]["weight"] = $nextWeight++;
                    }                                                            //            }
                    else
                    {               //        else {
                                    //           This site is missing a dependency!
                        this.h5pF.setErrorMessage(this.h5pF.t("Missing dependency @dep required by @lib.", new Dictionary<string, dynamic> {// $this.h5pF.setErrorMessage($this.h5pF.t("Missing dependency @dep required by @lib.",
                             { "dep", H5PCore.libraryToString(dependency.Value)}, //  array("@dep" => H5PCore::libraryToString($dependency),
                             { "lib" , H5PCore.libraryToString(library)},// "@lib" => H5PCore::libraryToString($library))), 
                             { "", "missing-library-dependency"}//        "missing-library-dependency");
                         }));
                    }          //            }
                }    //        }
            }//    }
            return nextWeight; //    return $nextWeight;
        } //  }
          ///**
        // * Check if a library is of the version we"re looking for
        // *
        // * Same version means that the majorVersion and minorVersion is the same
        // *
        // * @param array $library
        // *  Data from library.json
        // * @param array $dependency
        // *  Definition of what library we"re looking for
        // * @return boolean
        // *  TRUE if the library is the same version as the dependency
        // *  FALSE otherwise
        // */
        public bool isSameVersion(Dictionary<string, dynamic> library, Dictionary<string, dynamic> dependency)//public void isSameVersion($library, $dependency)
        {//{
            if (library["machineName"] != dependency["machineName"])//    if ($library["machineName"] != $dependency["machineName"]) {
            {
                return false;//        return FALSE;
            }//    }
            if (library["majorVersion"] != dependency["mayjorVersion"]) //    if ($library["majorVersion"] != $dependency["majorVersion"]) {
            {
                return false;//        return FALSE;
            }//    }
            if (library["minorVersion"] != dependency["minorVersion"])//    if ($library["minorVersion"] != $dependency["minorVersion"]) {
            {
                return false;//        return FALSE;
            }//    }
            return true;//    return TRUE;
        } //}
          ///**
        // * Recursive void for removing directories.
        // *
        // * @param string $dir
        // *  Path to the directory we"ll be deleting
        // * @return boolean
        // *  Indicates if the directory existed.
        // */
        public static bool is_link(string input)
        {
            return true;
        }

        public static bool deleteFileTree(string dir)//public static void deleteFileTree($dir)
        {//{
            if (!(File.Exists(dir)))//    if (!is_dir($dir))
            {//    {
                return false;//        return false;
            }//    }
            if (is_link(dir))//    if (is_link($dir))
            {//    {
             //        // Do not traverse and delete linked content, simply unlink.
             //        unlink($dir);
                return false;//        return;
            } //    }
            string[] contentPaths = new string[1];
            contentPaths[0] = dir;
            string[] array = { ".", ".." };
            var files = array.Except(contentPaths);   //    $files = array_diff(scandir($dir), array(".", ".."));
            foreach (string file in files)//    foreach ($files as $file) {
            {
                var filepath = dir + "/" + file;//      $filepath = "$dir/$file";
                                                //        // Note that links may resolve as directories
                if (!(File.Exists(filepath)) || is_link(filepath))//        if (!is_dir($filepath) || is_link($filepath))
                {//        {
                 //            // Unlink files and links
                    File.Delete(filepath);//            unlink($filepath);
                }//        }
                else//        else
                {//        {
                 //            // Traverse subdir and delete files
                    deleteFileTree(filepath);//            self::deleteFileTree($filepath);
                }//        }
            } //    }
            Directory.Delete(dir);
            return File.Exists(dir);//    return rmdir($dir);
        }//}
         ///**
        // * Writes library data as string on the form {machineName} {majorVersion}.{minorVersion}
        // *
        // * @param array $library
        // *  With keys machineName, majorVersion and minorVersion
        // * @param boolean $folderName
        // *  Use hyphen instead of space in returned string.
        // * @return string
        // *  On the form {machineName} {majorVersion}.{minorVersion}
        // */
        public static string libraryToString(Dictionary<string, dynamic> library, bool folderName = false)//public static void libraryToString($library, $folderName = FALSE)
        {//{
            return (library["machineName"] != null ? library["machineName"] : library["name"] + (folderName ? "-" : " ")) + library["majorVersion"] + "." + library["minorVersion"];//    return (isset($library["machineName"]) ? $library["machineName"] : $library["name"]) . ($folderName ? "-" : " ") . $library["majorVersion"]. ".". $library["minorVersion"];
        }//}
         ///**
        // * Parses library data from a string on the form {machineName} {majorVersion}.{minorVersion}
        // *
        // * @param string $libraryString
        // *  On the form {machineName} {majorVersion}.{minorVersion}
        // * @return array|FALSE
        // *  With keys machineName, majorVersion and minorVersion.
        // *  Returns FALSE only if string is not parsable in the normal library
        // *  string formats "Lib.Name-x.y" or "Lib.Name x.y"
        // */
        public bool extension_loaded(string input)
        {
            return true;
        }
        public bool preg_match(Regex pattern, Dictionary<string, dynamic> subject)
        {
            return true;
        }
        public bool preg_match(Regex pattern, Dictionary<string, dynamic> subject, Dictionary<string, dynamic> matches)
        {
            return true;
        }
        public Dictionary<string, dynamic> libraryFromString(string input) //public static void libraryFromString($libraryString)
        {//{
            Dictionary<string, dynamic> libraryString = null;
            string re = @"/^([\w0-9\-\.]{1,255})[\-\ ]([0-9]{1,5})\.([0-9]{1,5})$/i";//    $re = "/^([\w0-9\-\.]{1,255})[\-\ ]([0-9]{1,5})\.([0-9]{1,5})$/i";
            var matches = new Dictionary<string, dynamic>();//    $matches = array();
            var res = preg_match(new Regex(@re), libraryString, matches);                                            //    $res = preg_match($re, $libraryString, $matches);
            if (res)                                            //    if ($res) {
            {                                       //        return array(
                                                    //          "machineName" => $matches[1],
                return new Dictionary<string, dynamic> {
                    { "machineName", matches["1"]},
                    { "majorVersion", matches["2"]},
                    { "minorVersion", matches["3"]},
                };                                  //          "majorVersion" => $matches[2],
                                                    //          "minorVersion" => $matches[3]
                                                    //        );
            }                                               //    }
            return null;//    return FALSE;
        }      //}
               ///**
        // * Determine the correct embed type to use.
        // *
        // * @param $contentEmbedType
        // * @param $libraryEmbedTypes
        // * @return string "div" or "iframe".
        // */
        public static string determineEmbedType(string contentEmbedType, string libraryEmbedTypes)//public static void determineEmbedType($contentEmbedType, $libraryEmbedTypes)
        {//{
         //    // Detect content embed type
            var embedType = contentEmbedType.ToLower().IndexOf("div") != 0 ? "div" : "iframe";//    $embedType = strpos(strtolower($contentEmbedType), "div") !== FALSE ? "div" : "iframe";
            if (libraryEmbedTypes != null && libraryEmbedTypes != "")//    if ($libraryEmbedTypes !== NULL && $libraryEmbedTypes !== "") {
            {//      // Check that embed type is available for library
                var embedTypes = libraryEmbedTypes.ToLower();//      $embedTypes = strtolower($libraryEmbedTypes);
                if ((embedTypes.IndexOf(embedType)) != 0)//        if (strpos($embedTypes, $embedType) === FALSE)
                {//        {
                 //        // Not available, pick default.
                    embedType = embedTypes.IndexOf("div") != 0 ? "div" : "iframe";//        $embedType = strpos($embedTypes, "div") !== FALSE ? "div" : "iframe";
                }//        }
            } //    }
            return embedType;//    return $embedType;
        }   //}
            ///**
        // * Get the absolute version for the library as a human readable string.
        // *
        // * @param object $library
        // * @return string
        // */
        public static string libraryVersion(Dictionary<string, dynamic> library)//public static void libraryVersion($library)
        {//{
            return library["major_version"] + "." + library["minor_version"] + "." + library["path_version"];//    return $library.major_version. ".". $library.minor_version. ".". $library.patch_version;
        }   //}
            ///**
        // * Determine which versions content with the given library can be upgraded to.
        // *
        // * @param object $library
        // * @param array $versions
        // * @return array
        // */
        public Dictionary<string, dynamic> getUpgrades(Dictionary<string, dynamic> library, Dictionary<string, dynamic> versions) //public void getUpgrades($library, $versions)
        { //{

            var upgrades = new Dictionary<string, dynamic>();//   $upgrades = array();
            foreach (KeyValuePair<string, dynamic> upgrade in versions)//    foreach ($versions as $upgrade) {
            {
                if (upgrade.Value["major_version"] > library["major_version"] || upgrade.Value["major_version"] == library["major_version"] && upgrade.Value["minor_version"] == library["minor_version"])//        if ($upgrade.major_version > $library.major_version || $upgrade.major_version === $library.major_version && $upgrade.minor_version > $library.minor_version) {
                {
                    upgrades["upgrade.id"] = H5PCore.libraryVersion(upgrade.Value);//       $upgrades[$upgrade.id] = H5PCore::libraryVersion($upgrade);

                }//        }
            }   //    }
            return upgrades;   //    return $upgrades;
        }  //}
           ///**
        // * Converts all the properties of the given object or array from
        // * snake_case to camelCase. Useful after fetching data from the database.
        // *
        // * Note that some databases does not support camelCase.
        // *
        // * @param mixed $arr input
        // * @param boolean $obj return object
        // * @return mixed object or array
        // */
        public static Dictionary<string, dynamic> snakeToCamel(Dictionary<string, dynamic> arr, bool obj = false)//public static void snakeToCamel($arr, $obj = false)
        {//{
            string val = string.Empty;
            var newArr = new Dictionary<string, dynamic>();//    $newArr = array();
            foreach (KeyValuePair<string, dynamic> key in arr)//    foreach ($arr as $key => $val) {
            {
                int next = -1;//      $next = -1;
                while ((next = ((string)key.Value["val"]).IndexOf("_") + 1) != 1)//        while (($next = strpos($key, "_", $next + 1)) !== FALSE) {
                {
                    key.Value[""] = ((string)key.Value[""]).Replace((key.Value[""]), key.Key[next + 1]);//        $key = substr_replace($key, strtoupper($key{$next + 1}), $next, 2);
                }//        }
                newArr[key.Value] = val;//      $newArr[$key] = $val;
            }//    }
            return obj ? newArr : newArr;//    return $obj ? (object) $newArr: $newArr;
        }   //}

        ///**
        // * Get a list of installed libraries, different minor versions will
        // * return separate entries.
        // *
        // * @return array
        // *  A distinct array of installed libraries
        // */
        public Dictionary<string, dynamic> getLibrariesInstalled()          //public void getLibrariesInstalled()
        {//{
            var librariesInstalled = new Dictionary<string, dynamic>();//    $librariesInstalled = array();
            var libs = this.h5pF.loadLibraries();//    $libs = $this.h5pF.loadLibraries();
            foreach (KeyValuePair<string, dynamic> libName in libs)//    foreach ($libs as $libName => $library) {
            {
                foreach (KeyValuePair<string, dynamic> libVersion in library)//        foreach ($library as $libVersion) {
                {
                    librariesInstalled[libName.Value[library] + " " + libVersion.Value["major_version"] + " " + libVersion.Value["minor_version"]] = libVersion.Value["patch_version"];//        $librariesInstalled[$libName." ".$libVersion.major_version.".".$libVersion.minor_version] = $libVersion.patch_version;
                }//        }
            } //    }
            return librariesInstalled;//    return $librariesInstalled;
        }   //}
            ///**
        // * Easy way to combine similar data sets.
        // *
        // * @param array $inputs Multiple arrays with data
        // * @return array
        // */
        public Dictionary<string, dynamic> combineArrayValues(Dictionary<string, dynamic> inputs) //public void combineArrayValues($inputs)
        {//{
            var values = new Dictionary<string, dynamic>();
            var results = new Dictionary<string, dynamic>();//    $results = array();
            foreach (KeyValuePair<string, dynamic> index in inputs)//    foreach ($inputs as $index => $values) {
            {
                foreach (KeyValuePair<string, dynamic> key in values)//        foreach ($values as $key => $value) {
                {
                    results[key.Value["value"]] = key.Value["value"];//        $results[$key][$index] = $value;

                }//        }
            }//    }
            return results;//    return $results;
        }//}
         ///**
        // * Communicate with H5P.org and get content type cache. Each platform
        // * implementation is responsible for invoking this, eg using cron
        // *
        // * @param bool $fetchingDisabled
        // *
        // * @return bool|object Returns endpoint data if found, otherwise FALSE
        // */
        public string hash(string input1, string input2)
        {
            return string.Empty;
        }
        public Dictionary<string, dynamic> json_decode(object input1)
        {
            return null;
        }
        public Dictionary<string, dynamic> updateContentTypeCache(Dictionary<string, dynamic> input)
        {
            return null;
        }
        public Dictionary<string, dynamic> fetchLibrariesMetadata(bool fetchingDisabled = false)//public void fetchLibrariesMetadata($fetchingDisabled = FALSE)
        {//{
         //    // Gather data
            var siteData = new Dictionary<string, dynamic>();
            var uuid = this.h5pF.getOption("site_uuid", "");//    $uuid = $this.h5pF.getOption("site_uuid", "");
            var platform = this.h5pF.getPlatformInfo();//    $platform = $this.h5pF.getPlatformInfo();
            var registrationData = new Dictionary<string, dynamic> {//    $registrationData = array(
                { "uuid", uuid},         //      "uuid" => $uuid,
                { "platform_name", platform["name"]},         //      "platform_name" => $platform["name"],
                { "platform_version", platform["version"]},         //      "platform_version" => $platform["version"],
                { "h5p_version", platform["h5pVersion"]}, //      "h5p_version" => $platform["h5pVersion"],
                { "disabled", fetchingDisabled?1:0},//      "disabled" => $fetchingDisabled ? 1 : 0,
                { "local_id", hash("crc32", this.fullPluginPath)},         //      "local_id" => hash("crc32", $this.fullPluginPath),
                { "type", this.h5pF.getOption("site_type","local")},//      "type" => $this.h5pF.getOption("site_type", "local"),
                { "core_api_version",H5PCore.coreApi["majorVersion"]+"."+H5PCore.coreApi["minorVersion"]}// "core_api_version" => H5PCore::$coreApi["majorVersion"]. ".".
                                                                                                              //   H5PCore::$coreApi["minorVersion"]
            };         //    );

            //    // Register site if it is not registered
            if (uuid)//    if (empty($uuid))
            {//    {
                var registration = this.h5pF.fetchExternalData(H5PHubEndpoints.createURL(H5PHubEndpoints.SITES), registrationData);//      $registration = $this.h5pF.fetchExternalData(H5PHubEndpoints::createURL(H5PHubEndpoints::SITES), $registrationData);
                                                                                                                                   //        // Failed retrieving uuid
                if (!(registration != null))//        if (!$registration) {
                {
                    var errorMessage = this.h5pF.t("Site could not be registered with the hub. Please contact your site administrator.");//        $errorMessage = $this.h5pF.t("Site could not be registered with the hub. Please contact your site administrator.");
                    this.h5pF.setErrorMessage(errorMessage);//        $this.h5pF.setErrorMessage($errorMessage);
                    this.h5pF.setErrorMessage(this.h5pF.t("The H5P Hub has been disabled until this problem can be resolved. You may still upload libraries through the H5P Libraries page."), "registration-failed-hub-disabled");//        $this.h5pF.setErrorMessage(
                                                                                                                                                                                                                                   //          $this.h5pF.t("The H5P Hub has been disabled until this problem can be resolved. You may still upload libraries through the "H5P Libraries" page."),
                                                                                                                                                                                                                                   //          "registration-failed-hub-disabled"
                                                                                                                                                                                                                                   //        );
                                                                                                                                                                                                                                   // return false;//            return FALSE;
                }//        }
                 //      // Successfully retrieved new uuid
                var json = json_decode(registration);//      $json = json_decode($registration);
                                                     //      $reJsonConvert.SerializeObject(product);
                registrationData["uuid"] = json["uuid"];  //gistrationData["uuid"] = $json.uuid;
                this.h5pF.setOption("", json["uuid"]);//      $this.h5pF.setOption("site_uuid", $json.uuid);
                this.h5pF.setInfoMessage(this.h5pF.t("Your site was successfully registered with the H5P Hub."));//      $this.h5pF.setInfoMessage(
                //        $this.h5pF.t("Your site was successfully registered with the H5P Hub.")
                //      );
                //        // TODO: Uncomment when key is once again available in H5P Settings
                this.h5pF.setInfoMessage(this.h5pF.t("You have been provided a unique key that identifies you with the Hub when receiving new updates. The key is available for viewing in the H5P Settings page."));//        //      $this.h5pF.setInfoMessage(
                //        //        $this.h5pF.t("You have been provided a unique key that identifies you with the Hub when receiving new updates. The key is available for viewing in the "H5P Settings" page.")
                //        //      );
            }//    }
            if (this.h5pF.getOption("send_usage_statistics", true))//    if ($this.h5pF.getOption("send_usage_statistics", TRUE)) {
            {

                siteData = registrationData.Union((new Dictionary<string, dynamic> {
                    { "num_authors" ,this.h5pF.getNumAuthors()},
                    {"libraries" , this.combineArrayValues(new Dictionary<string, dynamic>{
                        { "patch" ,this.getLibrariesInstalled()},
                        { "content" ,this.h5pF.getLibraryContentCount()},
                        { "loaded" ,this.h5pF.getLibraryStats("library")},
                        {"created" ,this.h5pF.getLibraryStats("content create") },
                        { "createdUpload" ,this.h5pF.getLibraryStats("content create upload")},
                        {"deleted",this.h5pF.getLibraryStats("content delete") },
                        { "resultViews" ,this.h5pF.getLibraryStats("results content")},
                        { "shortcodeInserts",this.h5pF.getLibraryStats("content shortcode insert")},
                    }) }
                })).ToDictionary(pair => pair.Key, pair => pair.Value); //      $siteData = array_merge(
                                                                        //        $registrationData,
                                                                        //        array(
                                                                        //          "num_authors" => $this.h5pF.getNumAuthors(),
                                                                        //          "libraries"   => json_encode($this.combineArrayValues(array(
                                                                        //            "patch"            => $this.getLibrariesInstalled(),
                                                                        //            "content"          => $this.h5pF.getLibraryContentCount(),
                                                                        //            "loaded"           => $this.h5pF.getLibraryStats("library"),
                                                                        //            "created"          => $this.h5pF.getLibraryStats("content create"),
                                                                        //            "createdUpload"    => $this.h5pF.getLibraryStats("content create upload"),
                                                                        //            "deleted"          => $this.h5pF.getLibraryStats("content delete"),
                                                                        //            "resultViews"      => $this.h5pF.getLibraryStats("results content"),
                                                                        //            "shortcodeInserts" => $this.h5pF.getLibraryStats("content shortcode insert")
                                                                        //          )))
                                                                        //        )
                                                                        //      );
            }//    }
            else//    else {
            {
                siteData = registrationData;//      $siteData = $registrationData;
            }//    }
            var result = this.updateContentTypeCache(siteData);//    $result = $this.updateContentTypeCache($siteData);
            //    // No data received
            if (!(result != null) || (result == null))//    if (!$result || empty($result)) {
            {
                //return false;//      return FALSE;
            }//    }
            //    // Handle libraries metadata
            if (result["libraries"] != null)//    if (isset($result.libraries)) {
            {
                foreach (KeyValuePair<string, dynamic> library in result)//      foreach ($result.libraries as $library) {
                {
                    if ((library.Value["tutorialUrl"] != null) && (library.Value["machineName"] != null))//        if (isset($library.tutorialUrl) && isset($library.machineName)) {
                    {
                        this.h5pF.setLibraryTutorialUrl(library.Value["machineName"], library.Value["tutorialUrl"]);//          $this.h5pF.setLibraryTutorialUrl($library.machineNamee, $library.tutorialUrl);
                    }//        }
                }//      }
            } //    }
            return result;//    return $result;
        }//  }
         //  /**
         //   * Create representation of display options as int
         //   *
         //   * @param array $sources
         //   * @param int $current
         //   * @return int
         //   */
        public int getStorableDisplayOptions(Dictionary<string, dynamic> sources, int current) //  public void getStorableDisplayOptions(&$sources, $current) {
        {//    // Download - force setting it if always on or always off
            var download = this.h5pF.getOption(DISPLAY_OPTION_DOWNLOAD, H5PDisplayOptionBehaviour.ALWAYS_SHOW);//    $download = $this.h5pF.getOption(self::DISPLAY_OPTION_DOWNLOAD, H5PDisplayOptionBehaviour::ALWAYS_SHOW);
            if (download == H5PDisplayOptionBehaviour.ALWAYS_SHOW || download == H5PDisplayOptionBehaviour.NEVER_SHOW)//    if ($download == H5PDisplayOptionBehaviour::ALWAYS_SHOW ||//        $download == H5PDisplayOptionBehaviour::NEVER_SHOW) {
            {
                sources[DISPLAY_OPTION_DOWNLOAD] = download == H5PDisplayOptionBehaviour.ALWAYS_SHOW;//      $sources[self::DISPLAY_OPTION_DOWNLOAD] = ($download == H5PDisplayOptionBehaviour::ALWAYS_SHOW);
            }//    }
             //    // Embed - force setting it if always on or always off
            var embed = this.h5pF.getOption(DISPLAY_OPTION_EMBED, H5PDisplayOptionBehaviour.ALWAYS_SHOW);//    $embed = $this.h5pF.getOption(self::DISPLAY_OPTION_EMBED, H5PDisplayOptionBehaviour::ALWAYS_SHOW);
            if (embed == H5PDisplayOptionBehaviour.ALWAYS_SHOW ||//    if ($embed == H5PDisplayOptionBehaviour::ALWAYS_SHOW ||
            embed == H5PDisplayOptionBehaviour.NEVER_SHOW)//        $embed == H5PDisplayOptionBehaviour::NEVER_SHOW) {
            {
                sources[DISPLAY_OPTION_EMBED] = embed == H5PDisplayOptionBehaviour.ALWAYS_SHOW;//      $sources[self::DISPLAY_OPTION_EMBED] = ($embed == H5PDisplayOptionBehaviour::ALWAYS_SHOW);
            }//    }
            foreach (KeyValuePair<string, dynamic> bit in H5PCore.disable)//    foreach (H5PCore::$disable as $bit => $option) {
            {
                if (!(sources["option"] != null) || !(sources["option"] != null))//      if (!isset($sources[$option]) || !$sources[$option]) {
                {
                    current = current == 0 || bit.Value;//        $current |= $bit; // Disable
                }//      }
                else//      else {
                {
                    current = current == 1 && bit.Value;//        $current &= ~$bit; // Enable
                }//      }
            } //    }
            return current; //    return $current;
        } //  }
          //  /**
          //   * Determine display options visibility and value on edit
          //   *
          //   * @param int $disable
          //   * @return array
          //   */
        public Dictionary<string, dynamic> getDisplayOptionsAsArray(int input)
        {
            return null;
        }
        public Dictionary<string, dynamic> getDisplayOptionsForEdit(int disable = 0) //  public void getDisplayOptionsForEdit($disable = NULL) {
        {
            var display_options = new Dictionary<string, dynamic>();//    $display_options = array();
            var current_display_options = disable == 0 ? new Dictionary<string, dynamic>() : this.getDisplayOptionsAsArray(disable);//    $current_display_options = $disable === NULL ? array() : $this.getDisplayOptionsAsArray($disable);
            if (this.h5pF.getOption(DISPLAY_OPTION_FRAME, true))//    if ($this.h5pF.getOption(self::DISPLAY_OPTION_FRAME, TRUE)) {
            {
                display_options[DISPLAY_OPTION_FRAME] = current_display_options[DISPLAY_OPTION_FRAME] ? current_display_options[DISPLAY_OPTION_FRAME] : true; //      $display_options[self::DISPLAY_OPTION_FRAME] =
                                                                                                                                                              //        isset($current_display_options[self::DISPLAY_OPTION_FRAME]) ?
                                                                                                                                                              //        $current_display_options[self::DISPLAY_OPTION_FRAME] :
                                                                                                                                                              //        TRUE;
                                                                                                                                                              //      // Download
                var export = this.h5pF.getOption(DISPLAY_OPTION_DOWNLOAD, H5PDisplayOptionBehaviour.ALWAYS_SHOW);//      $export = $this.h5pF.getOption(self::DISPLAY_OPTION_DOWNLOAD, H5PDisplayOptionBehaviour::ALWAYS_SHOW);
                if (export == H5PDisplayOptionBehaviour.CONTROLLED_BY_AUTHOR_DEFAULT_ON ||//      if ($export == H5PDisplayOptionBehaviour::CONTROLLED_BY_AUTHOR_DEFAULT_ON ||
             export == H5PDisplayOptionBehaviour.CONTROLLED_BY_AUTHOR_DEFAULT_OFF)//          $export == H5PDisplayOptionBehaviour::CONTROLLED_BY_AUTHOR_DEFAULT_OFF) {
                {
                    display_options[DISPLAY_OPTION_DOWNLOAD] = current_display_options[DISPLAY_OPTION_DOWNLOAD] != null ? current_display_options[DISPLAY_OPTION_DOWNLOAD] : (export == H5PDisplayOptionBehaviour.CONTROLLED_BY_AUTHOR_DEFAULT_ON);//        $display_options[self::DISPLAY_OPTION_DOWNLOAD] =
                                                                                                                                                                                                                                                   //          isset($current_display_options[self::DISPLAY_OPTION_DOWNLOAD]) ?
                                                                                                                                                                                                                                                   //          $current_display_options[self::DISPLAY_OPTION_DOWNLOAD] :
                                                                                                                                                                                                                                                   //          ($export == H5PDisplayOptionBehaviour::CONTROLLED_BY_AUTHOR_DEFAULT_ON);
                }//      }
                 //      // Embed
                var embed = this.h5pF.getOption(DISPLAY_OPTION_EMBED, H5PDisplayOptionBehaviour.ALWAYS_SHOW);//      $embed = $this.h5pF.getOption(self::DISPLAY_OPTION_EMBED, H5PDisplayOptionBehaviour::ALWAYS_SHOW);
                if (embed == H5PDisplayOptionBehaviour.CONTROLLED_BY_AUTHOR_DEFAULT_ON || embed == H5PDisplayOptionBehaviour.CONTROLLED_BY_AUTHOR_DEFAULT_OFF)//      if ($embed == H5PDisplayOptionBehaviour::CONTROLLED_BY_AUTHOR_DEFAULT_ON ||//          $embed == H5PDisplayOptionBehaviour::CONTROLLED_BY_AUTHOR_DEFAULT_OFF) {
                {
                    display_options[DISPLAY_OPTION_EMBED] = current_display_options[DISPLAY_OPTION_EMBED] != null ? current_display_options[DISPLAY_OPTION_EMBED] : embed == H5PDisplayOptionBehaviour.CONTROLLED_BY_AUTHOR_DEFAULT_ON;//        $display_options[self::DISPLAY_OPTION_EMBED] =
                                                                                                                                                                                                                                       //          isset($current_display_options[self::DISPLAY_OPTION_EMBED]) ?
                                                                                                                                                                                                                                       //          $current_display_options[self::DISPLAY_OPTION_EMBED] :
                                                                                                                                                                                                                                       //          ($embed == H5PDisplayOptionBehaviour::CONTROLLED_BY_AUTHOR_DEFAULT_ON);
                }             //      }
                              //      // Copyright
                if (this.h5pF.getOption(DISPLAY_OPTION_COPYRIGHT, true)) //      if ($this.h5pF.getOption(self::DISPLAY_OPTION_COPYRIGHT, TRUE)) {
                {
                    display_options[DISPLAY_OPTION_COPYRIGHT] = current_display_options[DISPLAY_OPTION_COPYRIGHT] != null ? current_display_options[DISPLAY_OPTION_COPYRIGHT] : true;//        $display_options[self::DISPLAY_OPTION_COPYRIGHT] =
                                                                                                                                                                                     //          isset($current_display_options[self::DISPLAY_OPTION_COPYRIGHT]) ?
                                                                                                                                                                                     //          $current_display_options[self::DISPLAY_OPTION_COPYRIGHT] :
                                                                                                                                                                                     //          TRUE;
                }//      }
            }//    }
            return display_options;//    return $display_options;
        }//  }
        //  /**
        //   * Helper void used to figure out embed & download behaviour
        //   *
        //   * @param string $option_name
        //   * @param H5PPermission $permission
        //   * @param int $id
        //   * @param bool &$value
        //   */
        public void setDisplayOptionOverrides(string option_name, int permission, int id, bool value)//  private void setDisplayOptionOverrides($option_name, $permission, $id, &$value) {
        {
            var behaviour = this.h5pF.getOption(option_name, H5PDisplayOptionBehaviour.ALWAYS_SHOW);//    $behaviour = $this.h5pF.getOption($option_name, H5PDisplayOptionBehaviour::ALWAYS_SHOW);
                                                                                                    //    // If never show globally, force hide
            if (behaviour == H5PDisplayOptionBehaviour.NEVER_SHOW)//    if ($behaviour == H5PDisplayOptionBehaviour::NEVER_SHOW) {
            {
                value = false;//      $value = false;
            }//    }
            else if (behaviour == H5PDisplayOptionBehaviour.ALWAYS_SHOW)//    elseif ($behaviour == H5PDisplayOptionBehaviour::ALWAYS_SHOW) {
            {//      // If always show or permissions say so, force show
                value = true;//      $value = true;
            }//    }
            else if (behaviour == H5PDisplayOptionBehaviour.CONTROLLED_BY_PERMISSIONS)//    elseif ($behaviour == H5PDisplayOptionBehaviour::CONTROLLED_BY_PERMISSIONS) {
            {
                value = this.h5pF.hasPermission(permission, id);//      $value = $this.h5pF.hasPermission($permission, $id);
            }//    }
        }//  }
        //  /**
        //   * Determine display option visibility when viewing H5P
        //   *
        //   * @param int $display_options
        //   * @param int  $id Might be content id or user id.
        //   * Depends on what the platform needs to be able to determine permissions.
        //   * @return array
        //   */
        public Dictionary<string, dynamic> getDisplayOptionsForView(int disable, int id)//  public void getDisplayOptionsForView($disable, $id) {
        {
            var display_options = this.getDisplayOptionsAsArray(disable);//    $display_options = $this.getDisplayOptionsAsArray($disable);
            if (this.h5pF.getOption(DISPLAY_OPTION_FRAME, true) == false)//    if ($this.h5pF.getOption(self::DISPLAY_OPTION_FRAME, TRUE) == FALSE) {
            {
                display_options[DISPLAY_OPTION_FRAME] = false;//      $display_options[self::DISPLAY_OPTION_FRAME] = false;
            }//    }
            else //    else {
            {
                this.setDisplayOptionOverrides(DISPLAY_OPTION_DOWNLOAD, H5PPermission.DOWNLOAD_H5P, id, display_options[DISPLAY_OPTION_DOWNLOAD]);//      $this.setDisplayOptionOverrides(self::DISPLAY_OPTION_DOWNLOAD, H5PPermission::DOWNLOAD_H5P, $id, $display_options[self::DISPLAY_OPTION_DOWNLOAD]);
                this.setDisplayOptionOverrides(DISPLAY_OPTION_EMBED, H5PPermission.EMBED_H5P, id, display_options[DISPLAY_OPTION_EMBED]);//      $this.setDisplayOptionOverrides(self::DISPLAY_OPTION_EMBED, H5PPermission::EMBED_H5P, $id, $display_options[self::DISPLAY_OPTION_EMBED]);
                if (this.h5pF.getOption(DISPLAY_OPTION_COPYRIGHT, true) == false)//      if ($this.h5pF.getOption(self::DISPLAY_OPTION_COPYRIGHT, TRUE) == FALSE) {
                {
                    display_options[DISPLAY_OPTION_COPYRIGHT] = false;//        $display_options[self::DISPLAY_OPTION_COPYRIGHT] = false;
                }  //      }
            }//    }
            return display_options; //    return $display_options;
        }//  }
        //  /**
        //   * Convert display options as single byte to array
        //   *
        //   * @param int $disable
        //   * @return array
        //   */
        public Dictionary<string, dynamic> getDisplayOptions()//  private void getDisplayOptionsAsArray($disable) {
        {
            return new Dictionary<string, dynamic> { //    return array(
                { DISPLAY_OPTION_FRAME, !(disable[""] && H5PCore.DISABLE_FRAME!=null)},//      self::DISPLAY_OPTION_FRAME => !($disable & H5PCore::DISABLE_FRAME),
                { DISPLAY_OPTION_DOWNLOAD, !(disable[""] && H5PCore.DISABLE_DOWNLOAD!=null)},//      self::DISPLAY_OPTION_DOWNLOAD => !($disable & H5PCore::DISABLE_DOWNLOAD),     
                 { DISPLAY_OPTION_EMBED, !(disable[""] && H5PCore.DISPLAY_OPTION_EMBED!=null)},//      self::DISPLAY_OPTION_EMBED => !($disable & H5PCore::DISABLE_EMBED),
                 { DISPLAY_OPTION_COPYRIGHT, !(disable[""] && H5PCore.DISPLAY_OPTION_COPYRIGHT!=null)},//      self::DISPLAY_OPTION_COPYRIGHT => !($disable & H5PCore::DISABLE_COPYRIGHT),
                 { DISPLAY_OPTION_ABOUT, !(!(this.h5pF.getOption(DISPLAY_OPTION_ABOUT, true)))} //      self::DISPLAY_OPTION_ABOUT => !!$this.h5pF.getOption(self::DISPLAY_OPTION_ABOUT, TRUE)
            };        //    );
        }//  }
        //  /**
        //   * Small helper for getting the library"s ID.
        //   *
        //   * @param array $library
        //   * @param string [$libString]
        //   * @return int Identifier, or FALSE if non-existent
        //   */
        public bool getLibirary(Dictionary<string, dynamic> library, string libString = null)//  public void getLibraryId($library, $libString = NULL) {
        {
            var libraryIdMap = new Dictionary<string, dynamic>();
            if (!(libString == null))//    if (!$libString) {
            {
                libString = libraryToString(library);//      $libString = self::libraryToString($library);
            }//    }
            if (!(libraryIdMap[libString] != null))//    if (!isset($libraryIdMap[$libString])) {
            {
                libraryIdMap[libString] = this.h5pF.getLibraryId(library["machineName"], library["majorVersion"], library["minorVersion"]);//      $libraryIdMap[$libString] = $this.h5pF.getLibraryId($library["machineName"], $library["majorVersion"], $library["minorVersion"]);
            }//    }
            return libraryIdMap[libString];//    return $libraryIdMap[$libString];
        }//  }
        //  /**
        //   * Convert strings of text into simple kebab case slugs.
        //   * Very useful for readable urls etc.
        //   *
        //   * @param string $input
        //   * @return string
        //   */
        public static string slugify(string input)//  public static string slugify(string input) {
        {//    // Down low
            input = input.ToLower();//    input = strtolower($input);
                                    //    // Replace common chars
            var originalChar = new List<string> { "æ", "ø", "ö", "ó", "ô", "Ò", "Õ", "Ý", "ý", "ÿ", "ā", "ă", "ą", "œ", "å", "ä", "á", "à", "â", "ã", "ç", "ć", "ĉ", "ċ", "č", "é", "è", "ê", "ë", "í", "ì", "î", "ï", "ú", "ñ", "ü", "ù", "û", "ß", "ď", "đ", "ē", "ĕ", "ė", "ę", "ě", "ĝ", "ğ", "ġ", "ģ", "ĥ", "ħ", "ĩ", "ī", "ĭ", "į", "ı", "ĳ", "ĵ", "ķ", "ĺ", "ļ", "ľ", "ŀ", "ł", "ń", "ņ", "ň", "ŉ", "ō", "ŏ", "ő", "ŕ", "ŗ", "ř", "ś", "ŝ", "ş", "š", "ţ", "ť", "ŧ", "ũ", "ū", "ŭ", "ů", "ű", "ų", "ŵ", "ŷ", "ź", "ż", "ž", "ſ", "ƒ", "ơ", "ư", "ǎ", "ǐ", "ǒ", "ǔ", "ǖ", "ǘ", "ǚ", "ǜ", "ǻ", "ǽ", "ǿ" };
            var replaceWith = new List<string> { "ae", "oe", "o", "o", "o", "oe", "o", "o", "y", "y", "y", "a", "a", "a", "a", "a", "a", "a", "a", "a", "c", "c", "c", "c", "c", "e", "e", "e", "e", "i", "i", "i", "i", "u", "n", "u", "u", "u", "es", "d", "d", "e", "e", "e", "e", "e", "g", "g", "g", "g", "h", "h", "i", "i", "i", "i", "i", "ij", "j", "k", "l", "l", "l", "l", "l", "n", "n", "n", "n", "o", "o", "o", "r", "r", "r", "s", "s", "s", "s", "t", "t", "t", "u", "u", "u", "u", "u", "u", "w", "y", "z", "z", "z", "s", "f", "o", "u", "a", "i", "o", "u", "u", "u", "u", "u", "a", "ae", "oe" };
            originalChar.ForEach(x => input = input.Replace(x, replaceWith[originalChar.IndexOf(x)]));
            //    input = str_replace(
            //      array("æ",  "ø",  "ö", "ó", "ô", "Ò",  "Õ", "Ý", "ý", "ÿ", "ā", "ă", "ą", "œ", "å", "ä", "á", "à", "â", "ã", "ç", "ć", "ĉ", "ċ", "č", "é", "è", "ê", "ë", "í", "ì", "î", "ï", "ú", "ñ", "ü", "ù", "û", "ß",  "ď", "đ", "ē", "ĕ", "ė", "ę", "ě", "ĝ", "ğ", "ġ", "ģ", "ĥ", "ħ", "ĩ", "ī", "ĭ", "į", "ı", "ĳ",  "ĵ", "ķ", "ĺ", "ļ", "ľ", "ŀ", "ł", "ń", "ņ", "ň", "ŉ", "ō", "ŏ", "ő", "ŕ", "ŗ", "ř", "ś", "ŝ", "ş", "š", "ţ", "ť", "ŧ", "ũ", "ū", "ŭ", "ů", "ű", "ų", "ŵ", "ŷ", "ź", "ż", "ž", "ſ", "ƒ", "ơ", "ư", "ǎ", "ǐ", "ǒ", "ǔ", "ǖ", "ǘ", "ǚ", "ǜ", "ǻ", "ǽ",  "ǿ"),
            //      array("ae", "oe", "o", "o", "o", "oe", "o", "o", "y", "y", "y", "a", "a", "a", "a", "a", "a", "a", "a", "a", "c", "c", "c", "c", "c", "e", "e", "e", "e", "i", "i", "i", "i", "u", "n", "u", "u", "u", "es", "d", "d", "e", "e", "e", "e", "e", "g", "g", "g", "g", "h", "h", "i", "i", "i", "i", "i", "ij", "j", "k", "l", "l", "l", "l", "l", "n", "n", "n", "n", "o", "o", "o", "r", "r", "r", "s", "s", "s", "s", "t", "t", "t", "u", "u", "u", "u", "u", "u", "w", "y", "z", "z", "z", "s", "f", "o", "u", "a", "i", "o", "u", "u", "u", "u", "u", "a", "ae", "oe"),
            //      $input);
            //    // Replace everything else

            input = Regex.Replace(input, @"/[^a-z0-9]/", "-");//    $input = preg_replace("/[^a-z0-9]/", "-", $input);
                                                              //    // Prevent double hyphen
            input = Regex.Replace(input, @"/-{2,}/", "-");//    $input = preg_replace("/-{2,}/", "-", $input);
                                                          //    // Prevent hyphen in beginning or end
            input = input.Trim();//    $input = trim($input, "-");
                                 //    // Prevent to long slug
            if (input.Length > 91)//    if (strlen($input) > 91) {
            {
                input = input.Substring(0, 92);//      $input = substr($input, 0, 92);
            }//    }
             //    // Prevent empty slug
            if (input == "") //    if ($input === "") {
            {
                input = "interactive";//      $input = "interactive";
            }//    }
            return input;//    return $input;
        }//  }
         //  /**
         //   * Makes it easier to print response when AJAX request succeeds.
         //   *
         //   * @param mixed $data
         //   * @since 1.6.0
         //   */
        public static void ajaxSuccess(string data = null, bool only_data = false)//  public static void ajaxSuccess($data = NULL, $only_data = FALSE) {
        {
            var response = new Dictionary<string, dynamic>();
            response = new Dictionary<string, dynamic> {//    $response = array(
                { "success", true}//      "success" => TRUE
            };//    );

            if (data != null)//    if ($data !== NULL) {
            {
                response["data"] = data;//      $response["data"] = $data;
                                        //      // Pass data flatly to support old methods
                if (only_data) //      if ($only_data) {
                {
                    response["data"] = data;//        $response = $data;
                }//      }
            }//    }
            printJson(response);//    self::printJson($response);
        }//  }

        //  /**
        //   * Makes it easier to print response when AJAX request fails.
        //   * Will exit after printing error.
        //   *
        //   * @param string $message A human readable error message
        //   * @param string $error_code An machine readable error code that a client
        //   * should be able to interpret
        //   * @param null|int $status_code Http response code
        //   * @param array [$details=null] Better description of the error and possible which action to take
        //   * @since 1.6.0
        //   */
        public static void ajaxError(string message = null, string error_code = null, string status_code = null, Dictionary<string, dynamic> details = null)//  public static void ajaxError($message = NULL, $error_code = NULL, $status_code = NULL, $details = NULL) {
        {
            var response = new Dictionary<string, dynamic>();

            response = new Dictionary<string, dynamic>{//    $response = array(
                { "success" , false}//      "success" => FALSE
            };//    );

            if (message != null)//    if ($message !== NULL) {
            {
                response["message"] = message;//      $response["message"] = $message;
            }//    }
            if (error_code != null)//    if ($error_code !== NULL) {
            {
                response["errorCode"] = error_code;//      $response["errorCode"] = $error_code;
            }//    }
            if (details != null)//    if ($details !== NULL) {
            {
                response["details"] = details;//      $response["details"] = $details;
            }//    }
            printJson(response, status_code);//    self::printJson($response, $status_code);
        }//  }
        //  /**
        //   * Print JSON headers with UTF-8 charset and json encode response data.
        //   * Makes it easier to respond using JSON.
        //   *
        //   * @param mixed $data
        //   * @param null|int $status_code Http response code
        //   */
        public static void printJson(Dictionary<string, dynamic> data, string status_code = null)//  private static void printJson($data, $status_code = NULL) {
        {
            //    header("Cache-Control: no-cache");
            //    header("Content-type: application/json; charset=utf-8");
            printJson(data);//    print json_encode($data);
        }//  }
        //  /**
        //   * Get a new H5P security token for the given action.
        //   *
        //   * @param string $action
        //   * @return string token
        //   */
        public static string createToken(string action)//  public static void createToken($action) {
        {//    // Create and return token
            return hashToken(action, getTimeFactor());//    return self::hashToken($action, self::getTimeFactor());
        }//  }
        //  /**
        //   * Create a time based number which is unique for each 12 hour.
        //   * @return int
        //   */
        public static int getTimeFactor()//  private static void getTimeFactor() {
        {
            return (int)(((TimeSpan)DateTime.Now.TimeOfDay).TotalHours / (86400 / 2));//    return ceil(time() / (86400 / 2));
        }//  }
        //  /**
        //   * Generate a unique hash string based on action, time and token
        //   *
        //   * @param string $action
        //   * @param int $time_factor
        //   * @return string
        //   */
        public static bool function_exist(string input)
        {
            return true;
        }
        public static string random_bytes(int input)
        {
            return null;
        }
        public static string openssl_random_pseudo_bytes(int input)
        {
            return null;
        }
        public static string base64_encode(string input)
        {
            return null;
        }
        public static string hashToken(string action, int time_factor)//  private static void hashToken($action, $time_factor) {
        {
            var _SESSION = new Dictionary<string, dynamic>();
            if (!(_SESSION["h5p_token"] != null))//    if (!isset($_SESSION["h5p_token"])) {
            {
                //      // Create an unique key which is used to create action tokens for this session.
                if (function_exist("random_bytes"))//      if (function_exists("random_bytes")) {
                {
                    _SESSION["h5p_token"] = base64_encode(random_bytes(15));//        $_SESSION["h5p_token"] = base64_encode(random_bytes(15));
                }//      }
                else if (function_exist("openssl_random_pseudo_bytes"))//      else if (function_exists("openssl_random_pseudo_bytes")) {
                {
                    _SESSION["h5p_token"] = base64_encode(openssl_random_pseudo_bytes(15));//        $_SESSION["h5p_token"] = base64_encode(openssl_random_pseudo_bytes(15));
                }//      }
                else
                {//      else {
                    _SESSION["h5p_token"] = Guid.NewGuid();//        $_SESSION["h5p_token"] = uniqid("", TRUE);
                }//      }
            }//    }
             //    // Create hash and return
            return ((string)_SESSION["h5p_token"]).Substring(-16, 13); //    return substr(hash("md5", $action . $time_factor . $_SESSION["h5p_token"]), -16, 13);
        }//  }
        //  /**
        //   * Verify if the given token is valid for the given action.
        //   *
        //   * @param string $action
        //   * @param string $token
        //   * @return boolean valid token
        //   */
        public static bool validToken(string action, string token)//  public static void validToken($action, $token) {
        {//    // Get the timefactor
            var time_factor = getTimeFactor();//    $time_factor = self::getTimeFactor();
                                              //    // Check token to see if it"s valid
            return token == hashToken(action, time_factor) || token == hashToken(action, time_factor - 1);                                      //    return $token === self::hashToken($action, $time_factor) || // Under 12 hours
                                                                                                                                                //           $token === self::hashToken($action, $time_factor - 1); // Between 12-24 hours
        }//  }
        //  /**
        //   * Update content type cache
        //   *
        //   * @param object $postData Data sent to the hub
        //   *
        //   * @return bool|object Returns endpoint data if found, otherwise FALSE
        //   */
        public Dictionary<string, dynamic> updateContent(Dictionary<string, dynamic> postData = null)//  public void updateContentTypeCache($postData = NULL) {
        {
            var _interface = this.h5pF; //    $interface = $this.h5pF;
                                        //    // Make sure data is sent!
            if (!(postData != null) || !(postData["uuid"]))//    if (!isset($postData) || !isset($postData["uuid"])) {
            {
                return this.fetchLibrariesMetadata();//      return $this.fetchLibrariesMetadata();
            }//    }
            postData["current_cache"] = this.h5pF.getOption("content_type_cache_updated_at", false);//    $postData["current_cache"] = $this.h5pF.getOption("content_type_cache_updated_at", 0);
            var data = _interface.fetchExternalData(H5PHubEndpoints.createURL(H5PHubEndpoints.CONTENT_TYPES), postData);//    $data = $interface.fetchExternalData(H5PHubEndpoints::createURL(H5PHubEndpoints::CONTENT_TYPES), $postData);
            if (!(this.h5pF.getOption("hub_is_enabled", true)))//    if (! $this.h5pF.getOption("hub_is_enabled", TRUE)) {
            {
                return null;//      return TRUE;
            }//    }
             //    // No data received
            if (!(data != null))//    if (!$data) {
            {
                _interface.setErrorMessage(_interface.t("Couldnt communicate with the H5P Hub.Please try again later."), "failed-communicationg-with-hub");//      $interface.setErrorMessage(
                                                                                                                                                           //        $interface.t("Couldn"t communicate with the H5P Hub. Please try again later."),
                                                                                                                                                           //        "failed-communicationg-with-hub"
                                                                                                                                                           //      );
                return null;//      return FALSE;
            }//    }
            var json = json_decode(data);    //    $json = json_decode($data);
                                             //    // No libraries received
            if (!(json["contentTypes"]) || (string.IsNullOrEmpty(json["contentTypes"])))  //    if (!isset($json.contentTypes) || empty($json.contentTypes)) {
            {
                _interface.setErrorMessage(_interface.t("No content types were received from the H5P Hub. Please try again later."), "no-content-types-from-hub");//      $interface.setErrorMessage(
                                                                                                                                                                  //        $interface.t("No content types were received from the H5P Hub. Please try again later."),
                                                                                                                                                                  //        "no-content-types-from-hub"
                                                                                                                                                                  //      );
                return null;//      return FALSE;
            }      //    }
                   //    // Replace content type cache
                   //    $interface.replaceContentTypeCache($json);
                   //    // Inform of the changes and update timestamp
                   //    $interface.setInfoMessage($interface.t("Library cache was successfully updated!"));
                   //    $interface.setOption("content_type_cache_updated_at", time());
            return data;          //    return $data;
        }//  }
        //  /**
        //   * Check if the current server setup is valid and set error messages
        //   *
        //   * @return object Setup object with errors and disable hub properties
        //   */

        public string ini_get(string input)
        {
            return string.Empty;
        }
        public Dictionary<string, dynamic> checkSetupErrorMessage()//  public void checkSetupErrorMessage() {
        {
            var setup = new Dictionary<string, dynamic> { //    $setup = (object) array(
                { "errors", new Dictionary<string,dynamic>()},//      "errors" => array(),
                { "disable_hub", false}//      "disable_hub" => FALSE
            }; //    );

            if (!(Type.GetType("ZipArchive", false, true) != null))//    if (!class_exists("ZipArchive")) {
            {
                setup["errors"][""] = this.h5pF.t("Your PHP version does not support ZipArchive."); //      $setup.errors[] = $this.h5pF.t("Your PHP version does not support ZipArchive.");
                setup["disable_hub"] = true;//      $setup.disable_hub = TRUE;
            }//    }
            if (!(extension_loaded("mbstring")))//    if (!extension_loaded("mbstring")) {
            {
                setup["errors"][""] = this.h5pF.t("The mbstring PHP extension is not loaded. H5P needs this to void properly");//      $setup.errors[] = $this.h5pF.t(
                                                                                                                               //        "The mbstring PHP extension is not loaded. H5P needs this to void properly"
                                                                                                                               //      );
                setup["disable_hub"] = true;//      $setup.disable_hub = TRUE;
            }//    }
             //    // Check php version >= 5.2
             //    $php_version = explode(".", phpversion());
             //    if ($php_version[0] < 5 || ($php_version[0] === 5 && $php_version[1] < 2)) {
             //      $setup.errors[] = $this.h5pF.t("Your PHP version is outdated. H5P requires version 5.2 to void properly. Version 5.6 or later is recommended.");
             //      $setup.disable_hub = TRUE;
             //    }

            //    // Check write access
            if (!(this.fs.hasWriteAccess()))//    if (!$this.fs.hasWriteAccess()) {
            {
                setup["errors"][""] = this.h5pF.t("A problem with the server write access was detected. Please make sure that your server can write to your data folder.");//      $setup.errors[] = $this.h5pF.t("A problem with the server write access was detected. Please make sure that your server can write to your data folder.");
                setup["disable_hub"] = true;//      $setup.disable_hub = TRUE;
            }//    }
            var max_upload_size = returnBytes(ini_get("upload_max_filesize"));//    $max_upload_size = self::returnBytes(ini_get("upload_max_filesize"));
            var max_post_size = returnBytes(ini_get("post_max_size"));//    $max_post_size   = self::returnBytes(ini_get("post_max_size"));
            int byte_threshold = 5000000;                                             //    $byte_threshold  = 5000000; // 5MB
            if (max_upload_size < byte_threshold)                                                         //    if ($max_upload_size < $byte_threshold) {
            {
                setup["errors"][""] = this.h5pF.t("Your PHP max upload size is quite small. With your current setup, you may not upload files larger than %number MB. This might be a problem when trying to upload H5Ps, images and videos. Please consider to increase it to more than 5MB."
                    , new Dictionary<string, dynamic> {
                        {"%number", Convert.ToDouble(max_upload_size/1024/1024)}
                    });//      $setup.errors[] = //        $this.h5pF.t("Your PHP max upload size is quite small. With your current setup, you may not upload files larger than %number MB. This might be a problem when trying to upload H5Ps, images and videos. Please consider to increase it to more than 5MB.", array("%number" => number_format($max_upload_size / 1024 / 1024, 2, ".", " ")));
            }                                                          //    }
            if (max_post_size < byte_threshold)                                                          //    if ($max_post_size < $byte_threshold) {
            {
                setup["error"][""] = this.h5pF.t("Your PHP max post size is quite small. With your current setup, you may not upload files larger than %number MB. This might be a problem when trying to upload H5Ps, images and videos. Please consider to increase it to more than 5MB", new Dictionary<string, dynamic> {
                    { "%number", Convert.ToDouble(max_upload_size/1024/1024)}
                });//      $setup.errors[] =
                   //        $this.h5pF.t("Your PHP max post size is quite small. With your current setup, you may not upload files larger than %number MB. This might be a problem when trying to upload H5Ps, images and videos. Please consider to increase it to more than 5MB", array("%number" => number_format($max_upload_size / 1024 / 1024, 2, ".", " ")));
            }                                                          //    }
            if (max_upload_size > max_post_size)                                                         //    if ($max_upload_size > $max_post_size) {
            {                                                         //      $setup.errors[] =
                this.h5pF.t("Your PHP max upload size is bigger than your max post size. This is known to cause issues in some installations.");                                                         //        $this.h5pF.t("Your PHP max upload size is bigger than your max post size. This is known to cause issues in some installations.");
            }                                                          //    }
                                                                       //    // Check SSL
            if (!(extension_loaded("openssl")))                                                  //    if (!extension_loaded("openssl")) {
            {
                setup["errors"][""] = this.h5pF.t("Your server does not have SSL enabled. SSL should be enabled to ensure a secure connection with the H5P hub.");
                setup["disable_hub"] = true;
            }                                                   //      $setup.errors[] =
                                                                //        $this.h5pF.t("Your server does not have SSL enabled. SSL should be enabled to ensure a secure connection with the H5P hub.");
                                                                //      $setup.disable_hub = TRUE;
                                                                //    }
            return setup;//    return $setup;
        }//  }
        //  /**
        //   * Check that all H5P requirements for the server setup is met.
        //   */
        public void checkSetupForRequirements()//  public void checkSetupForRequirements() {
        {
            var setup = this.checkSetupErrorMessage();//    $setup = $this.checkSetupErrorMessage();
            this.h5pF.setOption("hub_is_enabled", !(setup["disable_hub"]));//    $this.h5pF.setOption("hub_is_enabled", !$setup.disable_hub);
            if (!(setup["errors"] == null))//    if (!empty($setup.errors)) {
            {
                foreach (KeyValuePair<string, dynamic> err in setup["errors"])//      foreach ($setup.errors as $err) {
                {
                    this.h5pF.setErrorMessage(err.Value);//        $this.h5pF.setErrorMessage($err);
                }//      }
            }//    }
            if (setup["diable_hub"])//    if ($setup.disable_hub) {
            {
                //      // Inform how to re-enable hub
                this.h5pF.setErrorMessage(this.h5pF.t("H5P hub communication has been disabled because one or more H5P requirements failed."));//      $this.h5pF.setErrorMessage(
                                                                                                                                               //        $this.h5pF.t("H5P hub communication has been disabled because one or more H5P requirements failed.")
                                                                                                                                               //      );
                this.h5pF.setErrorMessage(this.h5pF.t("When you have revised your server setup you may re-enable H5P hub communication in H5P Settings."));//      $this.h5pF.setErrorMessage(
                                                                                                                                                           //        $this.h5pF.t("When you have revised your server setup you may re-enable H5P hub communication in H5P Settings.")
                                                                                                                                                           //      );
            }//    }
        }//  }
        //  /**
        //   * Return bytes from php_ini string value
        //   *
        //   * @param string $val
        //   *
        //   * @return int|string
        //   */
        public static int returnBytes(string val)//  public static void returnBytes($val) {
        {
            val = val.Trim();//    $val  = trim($val);
            var last = (val[val.Length - 1]).ToString().ToLower();//    $last = strtolower($val[strlen($val) - 1]);
            var bytes = int.Parse(val);//    $bytes = (int) $val;
            switch (last)//    switch ($last) {
            {
                case "g"://      case "g":
                    bytes *= 1024; //        $bytes *= 1024;
                    break;
                case "m":       //      case "m":
                    bytes *= 1024;//        $bytes *= 1024;
                    break;
                case "k":    //      case "k":
                    bytes *= 1024;//        $bytes *= 1024;
                    break;
            }//    }
            return bytes;//    return $bytes;
        }//  }
        //  /**
        //   * Check if the current user has permission to update and install new
        //   * libraries.
        //   *
        //   * @param bool [$set] Optional, sets the permission
        //   * @return bool
        //   */
        public bool mayUpdateLibraries(bool set = true)//  public void mayUpdateLibraries($set = null) {
        {
            bool can = false;//    static $can;
            if (set != true)//    if ($set !== null) {
            {//      // Use value set
                can = set;//      $can = $set;
            }//    }
            if (can == true)//    if ($can === null) {
            {//      // Ask our framework
                can = this.h5pF.mayUpdateLibraries();//      $can = $this.h5pF.mayUpdateLibraries();
            }//    }
            return can;//    return $can;
        }//  }
         //  /**
         //   * Provide localization for the Core JS
         //   * @return array
         //   */
        public Dictionary<string, dynamic> getLocalization()//  public void getLocalization() {
        {
            return new Dictionary<string, dynamic> {
                { "fullscreen", this.h5pF.t("Fullscreen") },
               {"disableFullscreen" ,this.h5pF.t("Disable fullscreen") },
               {"download" , this.h5pF.t("Download") },
               {"copyrights" ,this.h5pF.t("Rights of use") },
               {"embed" , this.h5pF.t("Embed") },
               {"size" , this.h5pF.t("Size") },
               {"showAdvanced" ,this.h5pF.t("Show advanced") },
               {"hideAdvanced" ,this.h5pF.t("Hide advanced") },
               {"advancedHelp", this.h5pF.t("Include this script on your website if you want dynamic sizing of the embedded content:") },
               {"copyrightInformation" , this.h5pF.t("Rights of use") },
               {"close" , this.h5pF.t("Close") },
               {"title" , this.h5pF.t("Title") },
               {"author", this.h5pF.t("Author") },
               {"year", this.h5pF.t("Year") },
               {"source" ,this.h5pF.t("Source") },
               {"license",this.h5pF.t("License") },
               {"thumbnail" ,this.h5pF.t("Thumbnail") },
               {"noCopyrights" ,this.h5pF.t("No copyright information available for this content.") },
               {"downloadDescription",this.h5pF.t("Download this content as a H5P file.") },
               {"copyrightsDescription",this.h5pF.t("View copyright information for this content.") },
               {"embedDescription" ,this.h5pF.t("View the embed code for this content.") },
               {"h5pDescription" ,this.h5pF.t("Visit H5P.org to check out more cool content.") },
               {"contentChanged" ,this.h5pF.t("This content has changed since you last used it.") },
               {"startingOver" ,this.h5pF.t("Youll be starting over.")},
               {"by" ,this.h5pF.t("by") },
               {"showMore" ,this.h5pF.t("Show more") },
               {"showLess" ,this.h5pF.t("Show less") },
               {"subLevel" ,this.h5pF.t("Sublevel") },
               {"confirmDialogHeader" ,this.h5pF.t("Confirm action") },
               {"confirmDialogBody" ,this.h5pF.t("Please confirm that you wish to proceed. This action is not reversible.") },
               {"cancelLabel" ,this.h5pF.t("Cancel") },
               {"confirmLabel" ,this.h5pF.t("Confirm") },
               {"licenseU" ,this.h5pF.t("Undisclosed") },
               {"licenseCCBY" ,this.h5pF.t("Attribution") },
               {"licenseCCBYSA" ,this.h5pF.t("Attribution-ShareAlike") },
               {"licenseCCBYND" ,this.h5pF.t("Attribution-NoDerivs") },
               {"licenseCCBYNC" ,this.h5pF.t("Attribution-NonCommercial") },
               {"licenseCCBYNCSA" ,this.h5pF.t("Attribution-NonCommercial-ShareAlike") },
               {"licenseCCBYNCND" ,this.h5pF.t("Attribution-NonCommercial-NoDerivs") },
               {"licenseCC40" ,this.h5pF.t("4.0 International") },
               {"licenseCC30" ,this.h5pF.t("3.0 Unported") },
               {"licenseCC25" ,this.h5pF.t("2.5 Generic") },
               {"licenseCC20" ,this.h5pF.t("2.0 Generic") },
               {"licenseCC10" ,this.h5pF.t("1.0 Generic") },
               {"licenseGPL" ,this.h5pF.t("General Public License") },
               {"licenseV3" ,this.h5pF.t("Version 3") },
               {"licenseV2" ,this.h5pF.t("Version 2") },
               {"licenseV1" ,this.h5pF.t("Version 1") },
               {"licensePD" ,this.h5pF.t("Public Domain") },
               {"licenseCC010" ,this.h5pF.t("CC0 1.0 Universal (CC0 1.0) Public Domain Dedication") },
               {"licensePDM" ,this.h5pF.t("Public Domain Mark") },
               {"licenseC" ,this.h5pF.t("Copyright") }
            };
            //    return array(
            //"fullscreen" => $this.h5pF.t("Fullscreen"),
            //   "disableFullscreen" => $this.h5pF.t("Disable fullscreen"),
            //   "download" => $this.h5pF.t("Download"),
            //   "copyrights" => $this.h5pF.t("Rights of use"),
            //   "embed" => $this.h5pF.t("Embed"),
            //   "size" => $this.h5pF.t("Size"),
            //   "showAdvanced" => $this.h5pF.t("Show advanced"),
            //   "hideAdvanced" => $this.h5pF.t("Hide advanced"),
            //   "advancedHelp" => $this.h5pF.t("Include this script on your website if you want dynamic sizing of the embedded content:"),
            //   "copyrightInformation" => $this.h5pF.t("Rights of use"),
            //   "close" => $this.h5pF.t("Close"),
            //   "title" => $this.h5pF.t("Title"),
            //   "author" => $this.h5pF.t("Author"),
            //   "year" => $this.h5pF.t("Year"),
            //   "source" => $this.h5pF.t("Source"),
            //   "license" => $this.h5pF.t("License"),
            //   "thumbnail" => $this.h5pF.t("Thumbnail"),
            //   "noCopyrights" => $this.h5pF.t("No copyright information available for this content."),
            //   "downloadDescription" => $this.h5pF.t("Download this content as a H5P file."),
            //   "copyrightsDescription" => $this.h5pF.t("View copyright information for this content."),
            //   "embedDescription" => $this.h5pF.t("View the embed code for this content."),
            //   "h5pDescription" => $this.h5pF.t("Visit H5P.org to check out more cool content."),
            //   "contentChanged" => $this.h5pF.t("This content has changed since you last used it."),
            //   "startingOver" => $this.h5pF.t("You"ll be starting over."),
            //   "by" => $this.h5pF.t("by"),
            //   "showMore" => $this.h5pF.t("Show more"),
            //   "showLess" => $this.h5pF.t("Show less"),
            //   "subLevel" => $this.h5pF.t("Sublevel"),
            //   "confirmDialogHeader" => $this.h5pF.t("Confirm action"),
            //   "confirmDialogBody" => $this.h5pF.t("Please confirm that you wish to proceed. This action is not reversible."),
            //   "cancelLabel" => $this.h5pF.t("Cancel"),
            //   "confirmLabel" => $this.h5pF.t("Confirm"),
            //   "licenseU" => $this.h5pF.t("Undisclosed"),
            //   "licenseCCBY" => $this.h5pF.t("Attribution"),
            //   "licenseCCBYSA" => $this.h5pF.t("Attribution-ShareAlike"),
            //   "licenseCCBYND" => $this.h5pF.t("Attribution-NoDerivs"),
            //   "licenseCCBYNC" => $this.h5pF.t("Attribution-NonCommercial"),
            //   "licenseCCBYNCSA" => $this.h5pF.t("Attribution-NonCommercial-ShareAlike"),
            //   "licenseCCBYNCND" => $this.h5pF.t("Attribution-NonCommercial-NoDerivs"),
            //   "licenseCC40" => $this.h5pF.t("4.0 International"),
            //   "licenseCC30" => $this.h5pF.t("3.0 Unported"),
            //   "licenseCC25" => $this.h5pF.t("2.5 Generic"),
            //   "licenseCC20" => $this.h5pF.t("2.0 Generic"),
            //   "licenseCC10" => $this.h5pF.t("1.0 Generic"),
            //   "licenseGPL" => $this.h5pF.t("General Public License"),
            //   "licenseV3" => $this.h5pF.t("Version 3"),
            //   "licenseV2" => $this.h5pF.t("Version 2"),
            //   "licenseV1" => $this.h5pF.t("Version 1"),
            //   "licensePD" => $this.h5pF.t("Public Domain"),
            //   "licenseCC010" => $this.h5pF.t("CC0 1.0 Universal (CC0 1.0) Public Domain Dedication"),
            //   "licensePDM" => $this.h5pF.t("Public Domain Mark"),
            //   "licenseC" => $this.h5pF.t("Copyright")
            //    );
            //  }
        }//}

        //    /**
        //    * voids for validating basic types from H5P library semantics.
        //    * @property bool allowedStyles
        //    */
        public class H5PContentValidator//    public class H5PContentValidator
        {//    {
            public H5PFrameworkInterface h5pf;//        public H5PFrameworkInterface h5pF;
            public H5PCore h5pC;//        public H5PCore h5pC;
            private object nextWeight;//        private object nextWeight;
            Dictionary<string, dynamic> typeMap, libraries, dependencies, library; //        Dictionary<string,dynamic> typeMap, libraries, dependencies;
            private static string[] allowed_styleable_tags = new string[] { "span", "p", "div", "h1", "h2", "h3", "td" }; //        private static string[] allowed_styleable_tags = new string[] { "span", "p", "div", "h1", "h2", "h3", "td" };
                                                                                                                          //        /**
                                                                                                                          //         * Constructor for the H5PContentValidator
                                                                                                                          //         *
                                                                                                                          //         * @param object H5PFramework
                                                                                                                          //         *  The frameworks implementation of the H5PFrameworkInterface
                                                                                                                          //         * @param object H5PCore
                                                                                                                          //         *  The main H5PCore instance
                                                                                                                          //         */
            public H5PContentValidator(H5PFrameworkInterface H5PFramework, H5PCore _H5PCore)//        public H5PContentValidator(H5PFrameworkInterface H5PFramework, H5PCore _H5PCore)
            {//        {
                this.h5pf = H5PFramework; //            this.h5pF = H5PFramework;
                this.h5pC = _H5PCore;//            this.h5pC = _H5PCore;
                Dictionary<string, dynamic> tm = new Dictionary<string, dynamic>();//            Dictionary<string,dynamic> tm = new Dictionary<string,dynamic>();
                tm.Add("text", "validateText");//            tm.Add("text", "validateText");
                tm.Add("number", "validateNumber");//            tm.Add("number", "validateNumber");
                tm.Add("boolean", "validateBoolean");                                 //            tm.Add("boolean", "validateBoolean");
                tm.Add("list", "validateList");                                                              //            tm.Add("list", "validateList");
                tm.Add("group", "validateGroup");//            tm.Add("group", "validateGroup");
                tm.Add("file", "validateFile");                                        //            tm.Add("file", "validateFile");
                tm.Add("image", "validateImage");                                                                       //            tm.Add("image", "validateImage");
                tm.Add("video", "validateVideo");                                                                                                        //            tm.Add("video", "validateVideo");
                tm.Add("audio", "validateAudio");                                                //            tm.Add("audio", "validateAudio");
                tm.Add("select", "validateSelect");                                                                                  //            tm.Add("select", "validateSelect");
                tm.Add("library", "validateLibrary");                                                                                                                  //            tm.Add("library", "validateLibrary");
                this.typeMap = tm;                                                                                                                                                      //            this.typeMap = tm;

                this.nextWeight = 1;//            this.nextWeight = 1;
                                    //            // Keep track of the libraries we load to avoid loading it multiple times.
                this.libraries = new Dictionary<string, dynamic>(); //            this.libraries = new Dictionary<string,dynamic>();
                //            // Keep track of all dependencies for the given content.
                this.dependencies = new Dictionary<string, dynamic>();//            this.dependencies = new Dictionary<string,dynamic>();
            }   //        }
                //        /**
                //         * Get the flat dependency tree.
                //         *
                //         * @return array
                //         */
            public Dictionary<string, dynamic> getDependencies() //        public Dictionary<string,dynamic> getDependencies()
            {//        {
                return this.dependencies;//            return this.dependencies;
            }//        }
             //        /**
             //         * Validate given text value against text semantics.
             //         * @param text
             //         * @param semantics
             //         */
            public string htmlspecialchars(string input, object flags, string character_set, bool double_encode)
            {
                return "";
            }
            public object ENT_QUOTES = null;
            public bool extension_loaded(string input)
            {
                return true;
            }
            public string filter_xss(string input1, string[] input2, Regex regex)
            {
                return "";
            }
            public void validateText(ref string text, Dictionary<string, dynamic> semantics)//        void validateText(ref string text, Dictionary<string,dynamic> semantics)
            {//        {
                if (String.IsNullOrEmpty(text))//            if (String.IsNullOrEmpty(text))
                {//            {
                    text = "";//                text = "";
                }//            }
                if (semantics["tags"] != null)//            if (semantics["tags"] != null)
                {//            {
                 //                // Not testing for empty array allows us to use the 4 defaults without
                 //                // specifying them in semantics.
                    string[] tags = new string[] { "div", "span", "p", "br" };    //                string[] tags = new string[] { "div", "span", "p", "br" };
                    tags.Concat((string[])semantics["tags"]).ToArray(); //                tags.Concat((string[])semantics["tags"]).ToArray();
                                                                        //                // Add related tags for table etc.
                    if (tags.Contains("table"))//                if (tags.Contains("table"))
                    {//                {
                        tags = tags.Concat(new string[] { "tr", "td", "th", "colgroup", "thead", "tbody", "tfoot" }).ToArray();//                    tags = tags.Concat(new string[] { "tr", "td", "th", "colgroup", "thead", "tbody", "tfoot" }).ToArray();
                    }//                }
                    if (tags.Contains("b") && !(tags.Contains("strong")))//                if (tags.Contains("b") && !tags.Contains("strong"))
                    {//                {
                        tags.Concat(new string[] { "strong" }).ToArray();//                    tags.Concat(new string[] { "strong" }).ToArray();
                    }//                }
                    if (tags.Contains("i") && !(tags.Contains("em")))//                if (tags.Contains("i") && !tags.Contains("em"))
                    {//                {
                        tags.Concat(new string[] { "m" });//                    tags.Concat(new string[] { "em" });
                    }//                }
                    if (tags.Contains("ul") || tags.Contains("ol") && !(tags.Contains("li"))) //                if (tags.Contains("ul") || tags.Contains("ol") && !tags.Contains("li"))
                    { //                {
                      //                    tags.Concat(new string[] { "li" });
                    }//                }
                    if (tags.Contains("del") || tags.Contains("strike") && !(tags.Contains("s")))//                if (tags.Contains("del") || tags.Contains("strike") && !tags.Contains("s"))
                    { //                {
                        tags.Concat(new string[] { "s" }); //                    tags.Concat(new string[] { "s" });
                    }//                }
                     //                // Determine allowed style tags
                    Regex stylePatterns;//                string[] stylePatterns;
                                        //                // All styles must be start to end patterns (^...)
                    if (semantics["font"] != null) //                if (semantics["font"] != null)
                    {//                {
                        if (semantics["font"] != null)//                    //if (semantics["font"]!=null) {
                        {
                            stylePatterns = new Regex(@"/^font-size: *[0-9.]+(em|px|%) *;?/i");//                    //stylePatterns = new string[] { "/^font-size: *[0-9.]+(em|px|%) *;?/i" };
                        }//                    //}
                        if (semantics["font"]["family"] && semantics["font"]["family"])//                    //if (semantics["font"]["family"]) && semantics.font.family) {
                        {
                            stylePatterns = new Regex(@"/^font-family: *[-a-z0-9,'' ]+;?/ i");//                    //stylePatterns = new string[] {@" /^font-family: *[-a-z0-9," ]+;?/ i"};
                        }//                    //}
                        if ((semantics["font"]["color"]) && semantics["font"]["color"])//                    //if (isset(semantics.font.color) && semantics.font.color) {
                        {
                            stylePatterns = new Regex(@"/^color: *(#[a-f0-9]{3}[a-f0-9]{3}?|rgba?\([0-9, ]+\)) *;?/i");//                    //stylePatterns[] = "/^color: *(#[a-f0-9]{3}[a-f0-9]{3}?|rgba?\([0-9, ]+\)) *;?/i";
                        }//                    //}
                        if ((semantics["font"]["background"]) && semantics["font"]["background"])//                    //if (isset(semantics.font.background) && semantics.font.background) {
                        {
                            stylePatterns = new Regex(@"/^background-color: *(#[a-f0-9]{3}[a-f0-9]{3}?|rgba?\([0-9, ]+\)) *;?/i");//                    //stylePatterns[] = "/^background-color: *(#[a-f0-9]{3}[a-f0-9]{3}?|rgba?\([0-9, ]+\)) *;?/i";
                        }//                    //}
                        if ((semantics["font"]["spacing"]) && (semantics["font"]["spacing"]))//                    //if (isset(semantics.font.spacing) && semantics.font.spacing) {
                        {
                            stylePatterns = new Regex(@"/^letter-spacing: *[0-9.]+(em|px|%) *;?/i");//                    //stylePatterns[] = "/^letter-spacing: *[0-9.]+(em|px|%) *;?/i";
                        }//                    //}
                        if ((semantics["font"]["height"]) && semantics["font"]["height"])//                    //if (isset(semantics.font.height) && semantics.font.height) {
                        {
                            stylePatterns = new Regex(@"/^letter-spacing: *[0-9.]+(em|px|%) *;?/i");//                    //stylePatterns[] = "/^letter-spacing: *[0-9.]+(em|px|%) *;?/i";
                        }  //                    //}
                    }//                    //}
                     //                    //// Alignment is allowed for all wysiwyg texts
                    stylePatterns = new Regex(@"/^text-align: *(center|left|right);?/i");//                    //stylePatterns[] = "/^text-align: *(center|left|right);?/i";
                                                                                         //                    //// Strip invalid HTML tags.
                    text = this.filter_xss(text, tags, stylePatterns);//                    //text = this.filter_xss(text, tags, stylePatterns);
                }//                    //}
                else    //                    //else
                { //                    //{
                  //                    //// Filter text to plain text.
                    text = htmlspecialchars(text, ENT_QUOTES, "UTF-8", false); //                    //text = htmlspecialchars(text, ENT_QUOTES, "UTF-8", false);
                }    //                    //}
                     //                    //// Check if string is within allowed length
                if (semantics["maxLength"] != null)     //                    //if (isset(semantics.maxLength))
                {    //                    //{
                    if (!(extension_loaded("mbstring")))    //                    //if (!extension_loaded("mbstring"))
                    { //                    //{
                        this.h5pf.setErrorMessage(this.h5pf.t("The mbstring PHP extension is not loaded. H5P need this to void properly"), "mbstring-unsupported"); //                    //this.h5pF.setErrorMessage(this.h5pF.t("The mbstring PHP extension is not loaded. H5P need this to void properly"), "mbstring-unsupported");
                    }//                    //}
                    else//                    //else
                    {//                    //{
                        text = (text.Substring(0, (int)semantics["maxLength"]));//                    //text = mb_substr(text, 0, semantics.maxLength);
                    } //                    //}
                }//                    //}
                 //                    //// Check if string is according to optional regexp in semantics
                if (!(text == "" && (semantics["optional"]) != null && semantics["optional"]) && (semantics["regexp"]))//                    //if (!(text === "" && isset(semantics.optional) && semantics.optional) && isset(semantics.regexp)) {
                {
                    //                    //// Escaping "/" found in patterns, so that it does not break regexp fencing.
                    var pattern = new Regex(" / " + semantics["regexp"]["pattern"]).Replace("/", "\\/") + "/"; //                    //pattern = " / ".str_replace("/", "\\/", semantics.regexp.pattern). "/";
                    pattern = (semantics["regexp"]["modeifiers"] != null ? semantics["regexp"]["modifiers"] : "");//                    //pattern.= isset(semantics.regexp.modifiers) ? semantics.regexp.modifiers : "";
                    if (Regex.Match(text, pattern) != null)//                    //if (preg_match(pattern, text) === 0)
                    {//                    //{
                     //                    //// Note: explicitly ignore return value false, to avoid removing text
                     //                    //// if regexp is invalid...
                        this.h5pf.setErrorMessage(this.h5pf.t("Provided string is not valid according to regexp in semantics.  (value: % value, regexp:  % regexp", new Dictionary<string, dynamic> {
                            {"%value" , text },
                            { "%regexp" , pattern}
                        }), "semantics-invalid-according-regexp");//                    //this.h5pF.setErrorMessage(this.h5pF.t("Provided string is not valid according to regexp in semantics. (value: " % value", regexp: " % regexp")", array("%value" => text, "%regexp" => pattern)), "semantics-invalid-according-regexp");
                        text = "";//                    //text = "";
                    }  //                    //}
                } //                }
                text = "";//                text = "";
            }//            }
        }//        }
         //        /**
         //         * Validates content files
         //         *
         //         * @param string contentPath
         //         *  The path containing content files to validate.
         //         * @param bool isLibrary
         //         * @return bool TRUE if all files are valid
         //         * TRUE if all files are valid
         //         * false if one or more files fail validation. Error message should be set accordingly by validator.
         //         */
        public bool validateContentFiles(string contentPath, bool isLibrary = false) //        bool validateContentFiles(string contentPath, bool isLibrary = false)
        {//        {
            string[] contentPaths = new string[1];
            contentPaths[0] = contentPath;

            if (this.h5pC.disableFileCheck == true)
            {
                return true;
            }
            //return false;

            //// Scan content directory for files, recurse into sub directories.
            string[] array = { ".", ".." };
            var files = array.Except(contentPaths);//files = array_diff(scandir(contentPath), array(".", ".."));
            var valid = true;//valid = TRUE;
            var whitelist = this.h5pF.getWhitelist(isLibrary, H5PCore.defaultContentWhitelist, H5PCore.defaultLibraryWhitelistExtras); //whitelist = this.h5pF.getWhitelist(isLibrary, H5PCore::string defaultValueContentWhitelist, H5PCore::string defaultValueLibraryWhitelistExtras);
            Regex wl_regex = new Regex(@"/\.(''.preg_replace(''/ +/i'', ''|'', preg_quote(whitelist)). '')/i"); //wl_regex = "/\.(".preg_replace("/ +/i", "|", preg_quote(whitelist)). ")/i";
            foreach (var file in files)
            {//foreach (files as file) {
                var filePath = contentPath + "/" + file;//filePath = contentPath.DIRECTORY_SEPARATOR. file;
                if (File.Exists(filePath))//if (is_dir(filePath))
                {//{
                    valid = this.validateContentFiles(filePath, isLibrary) && valid;//valid = this.validateContentFiles(filePath, isLibrary) && valid;
                }//}
                else //else
                {//{
                 //// Snipped from drupal 6 "file_validate_extensions".  Using own code
                 //// to avoid 1. creating a file-like object just to test for the known
                 //// file name, 2. testing against a returned error array that could
                 //// never be more than 1 element long anyway, 3. recreating the regex
                 //// for every file.
                    if (!extension_loaded("mbstring"))//if (!extension_loaded("mbstring"))
                    {//{
                        Dictionary<string, dynamic> replacement = new Dictionary<string, dynamic>();
                        replacement["mbstring-unsupported"] = "mbstring-unsupported";
                        this.h5pF.setErrorMessage(this.h5pF.t("The mbstring PHP extension is not loaded. H5P need this to void properly", replacement));//this.h5pF.setErrorMessage(this.h5pF.t("The mbstring PHP extension is not loaded. H5P need this to void properly"), "mbstring-unsupported");
                        valid = false;//valid = false;
                    }//}
                    else if (!preg_match(wl_regex, new Dictionary<string, dynamic> { { "", (file).ToLower() } })) //else if (!preg_match(wl_regex, mb_strtolower(file)))
                    {//{
                        string filename = "";
                        Dictionary<string, dynamic> replacement = new Dictionary<string, dynamic>();
                        replacement["not-in-whitelist"] = "not-in-whitelist";
                        this.h5pF.setErrorMessage(this.h5pF.t("File " + filename + " not allowed. Only files with the following extensions are allowed: %files-allowed.", replacement));//this.h5pF.setErrorMessage(this.h5pF.t("File " % filename" not allowed. Only files with the following extensions are allowed: %files-allowed.", array("%filename" => file, "%files-allowed" => whitelist)), "not-in-whitelist");
                        valid = false;//valid = false;
                    }//}
                }//}
            }//}
            return valid;
        }//        }
         //        /**
         //         * Validate given value against number semantics
         //         * @param number
         //         * @param semantics
         //         */
        public void validateNumber(ref int number, Dictionary<string, dynamic> semantics)
        {
            //// Validate that number is indeed a number
            if (number.GetType() != typeof(decimal))//if (!is_numeric(number))
            {//{
                number = 0;//number = 0;
            }//}
            //// Check if number is within valid bounds. Move within bounds if not.
            if (semantics["min"] != null && number < (int)semantics["min"])
            {//if (isset(semantics.min) && number < semantics.min) {
                number = (int)semantics["min"];//number = semantics.min;
            }//}
            if (semantics["max"] != null && number > (int)semantics["max"])
            {//if (isset(semantics.max) && number > semantics.max) {
                number = (int)semantics["max"];//number = semantics.max;
            }//}
            //// Check if number is within allowed bounds even if step value is set.
            if (semantics["step"] != null)//if (isset(semantics.step))
            {//{
                var testNumber = number - (semantics["min"] != null ? (int)semantics["min"] : 0);//testNumber = number - (isset(semantics.min) ? semantics.min : 0);
                var rest = testNumber % (int)semantics["step"];//rest = testNumber % semantics.step;
                if (rest != 0)
                {//if (rest !== 0) {
                    number -= rest;//number -= rest;
                }//}
            }//}
            //// Check if number has proper number of decimals.
            if (semantics["decimals"] != null)//if (isset(semantics.decimals))
            {//{
                number = round(number, (int)semantics["decimals"]);//number = round(number, semantics.decimals);
            }//}                    
        }
        public int round(decimal number, int decimals)
        {
            return 0;
        }
        //        /**
        //         * Validate given value against boolean semantics
        //         * @param bool
        //         * @return bool
        //         */
        public bool validateBoolean(object _bool)//        bool validateBoolean(object _bool)
        {//        {
            return Convert.ToBoolean(_bool);//            return Convert.ToBoolean(_bool);
        } //        }
          //        /**
          //         * Validate select values
          //         * @param select
          //         * @param semantics
          //         */
        public void validateSelect(ref string[] select, Dictionary<string, dynamic> semantics)
        {
            var optional = semantics["optional"] != null ? semantics["optional"] : String.Empty;//optional = isset(semantics.optional) && semantics.optional;
            var strict = false;//strict = false;
            Dictionary<string, Dictionary<string, dynamic>> options = null;//options = array();
            if (semantics["options"] != null)//if (isset(semantics.options) && !empty(semantics.options))
            {//{
             //// We have a strict set of options to choose from.
                strict = true;//strict = TRUE;

                foreach (KeyValuePair<string, dynamic> option in semantics)
                {//foreach (semantics.options as option) {
                    option.Value["value"] = true;//options[option.value] = TRUE;
                    option.Value["options"] = option.Value["value"];
                }//}
            }//}
            if (semantics["multiple"] != null)
            {//if (isset(semantics.multiple) && semantics.multiple) {
             //// Multi-choice generates array of values. Test each one against valid
             //// options, if we are strict.  First make sure we are working on an
             //// array.
                if (!(select.GetType() == typeof(Array)))//if (!is_array(select))
                {//{
                    select = select.ToArray();//select = array(select);
                }//}
                foreach (string key in select)
                {//foreach (select as string key => &value) {
                    if (strict && optional != null && options["value"] != null)
                    {//if (strict && !optional && !isset(options[value])) {
                        this.h5pF.setErrorMessage(this.h5pF.t("Invalid selected option in multi-select.", null));//this.h5pF.setErrorMessage(this.h5pF.t("Invalid selected option in multi-select."));
                        var keys = select;//unset(select[string key ]);
                    }//}
                    else
                    {//else {

                        select[0] = htmlspecialchars(value, ENT_QUOTES, "UTF-8", false);//select[string key ] = htmlspecialchars(value, ENT_QUOTES, "UTF-8", false);
                    }//}
                }//}
            }//}
            else
            {//else {
             //// Single mode.  If we get an array in here, we chop off the first
             //// element and use that instead.
                if (select.GetType() == typeof(Array))
                {//if (is_array(select)) {
                    select[0] = select[0];//select = select[0];
                }//}
                if (strict && optional != null && options["select"] != null)
                {//if (strict && !optional && !isset(options[select])) {
                    this.h5pF.setErrorMessage(this.h5pF.t("Invalid selected option in select.", null));//this.h5pF.setErrorMessage(this.h5pF.t("Invalid selected option in select."));
                    select[0] = (string)semantics["options"];//select = semantics.options[0].value;
                } //}
                select[0] = htmlspecialchars(select[0], ENT_QUOTES, "UTF-8", false); //select = htmlspecialchars(select, ENT_QUOTES, "UTF-8", false);
            }//}
            select = null;
        }
        public object ENT_QUOTES = null;
        public string value = String.Empty;
        public string htmlspecialchars(string input, object flags, string character_set, bool double_encode)
        {
            return "";
        }
        //        /**
        //         * Validate given list value against list semantics.
        //         * Will recurse into validating each item in the list according to the type.
        //         * @param list
        //         * @param semantics
        //         */
        Dictionary<string, dynamic> typeMap = new Dictionary<string, dynamic>();
        public void array_splice(string[] input, int input2)
        {

        }
        public void array_splice(string[] input, string input2, int input3)
        {

        }
        public void _void(string input1, object input2)
        {

        }
        public void validateList(ref string[] list, Dictionary<string, dynamic> semantics)
        {
            var field = semantics["field"];//field = semantics.field;
            var _void = this.typeMap["field"];//void = this.typeMap[field.type];
            //// Check that list is not longer than allowed length. We do this before
            //// iterating to avoid unnecessary work.
            if (semantics["max"] != null)
            {//if (isset(semantics.max)) {
                array_splice(list, (int)semantics["max"]);//  array_splice(list, semantics.max);
            }//}
            if (list.GetType() != typeof(Array))
            {//if (!is_array(list)) {
                list = list.ToArray();//  list = array();
            }//}-
            //// Validate each element in list.
            foreach (string key in list)
            {//foreach (list as string key  => &value) {
                if (key.GetType() != typeof(int))
                {//  if (!is_int(string key )) {
                    array_splice(list, key, 1);//    array_splice(list, string key , 1);
                    continue;//    continue;
                }//  }
                this._void(value, field);//  this.void(value, field);
                if (value == null)
                {//  if (value === null) {
                    array_splice(list, key, 1);//    array_splice(list, string key , 1);
                } //  }
            }//}
            if (list.Count() == 0)
            {//if (count(list) === 0) {
                list = null;//  list = null;
            }//}
        }
        //        /**
        //         * Validate a file like object, such as video, image, audio and file.
        //         * @param file
        //         * @param semantics
        //         * @param array int? typeValidKeys
        //         */
        public Dictionary<string,dynamic> validKeys = new Dictionary<string, dynamic> { { "0", "library" }, { "1", "params" }, { "2", "subContentId" } };//validKeys = array("library", "params", "subContentId");

        private void _validateFilelike(Dictionary<string, dynamic> file, Dictionary<string, dynamic> semantics, Dictionary<string, dynamic> typeValidKeys)
        {
            //// Do not allow to use files from other content folders.
            Dictionary<string,dynamic> matches = null;//matches = array();

            if (preg_match(this.h5pC.relativePathRegExp, file, matches))//if (preg_match(this.h5pC.relativePathRegExp, file.path, matches))
            {// {
                file["path"] = matches[""][5];//  file.path = matches[5];
            } //}
            //// Remove temporary files suffix
            if (((string)file["path"]).ToString().Substring(-4, 4) == "#tmp")//if (substr(file.path, -4, 4) === "#tmp")
            {// {
                file["path"] = ((string)file["path"]).ToString().Substring(0, ((string)file["path"]).Length - 4);//  file.path = substr(file.path, 0, strlen(file.path) - 4);
            }//}
            //// Make sure path and mime does not have any special chars
            file["path"] = htmlspecialchars(file["path"], ENT_QUOTES, "UTF-8", false);//file.path = htmlspecialchars(file.path, ENT_QUOTES, "UTF-8", false);
            if (file["mime"] != null)//if (isset(file.mime))
            {// {
                file["mime"] = htmlspecialchars(file["mime"], ENT_QUOTES, "UTF-8", false);//  file.mime = htmlspecialchars(file.mime, ENT_QUOTES, "UTF-8", false);
            }//}
             //// Remove attributes that should not exist, they may contain JSON escape
             //// code.

            var validKeys = array_merge(new Dictionary<string, dynamic> { { "0", "path" }, { "1", "mime" }, { "2", "copyright" } }, typeValidKeys);//validKeys = array_merge(array("path", "mime", "copyright"), int? typeValidKeys);
            if (semantics["extraAttributes"] != null)//if (isset(semantics.extraAttributes)) 
            {//{
                validKeys = array_merge(validKeys, semantics["extraAttributes"]);//  validKeys = array_merge(validKeys, semantics.extraAttributes); // TODO: Validate extraAttributes
            }//}
            this.filterParams(file, validKeys);//this.filterParams(file, validKeys);
            if (file["width"] != null)//if (isset(file.width))
            {//{
                file["width"] = Convert.ToInt32(file["width"]);//  file.width = intval(file.width);
            }//}
            if (file["height"] != null)//if (isset(file.height))
            {// {
                file["height"] = Convert.ToInt32(file["height"]);//  file.height = intval(file.height);
            }//}
            if (file["codecs"] != null)//if (isset(file.codecs))
            {// {
                file["codecs"] = htmlspecialchars(file["codecs"], ENT_QUOTES, "UTF-8", false);//  file.codecs = htmlspecialchars(file.codecs, ENT_QUOTES, "UTF-8", false);
            }//}
            if (file["quality"] != null)//if (isset(file.quality)) 
            {//{
                if (!(((object)file["quality"]).GetType() == typeof(object)))//  if (!is_object(file.quality) || !isset(file.quality.level) || !isset(file.quality.label))
                {// {
                    file["quality"] = null;//    unset(file.quality);

                }//  }
                else//  else
                {//{
                    this.filterParams(file["quality"], new Dictionary<string, dynamic> { { "", "level" },{ "", "label" } });//    this.filterParams(file.quality, array("level", "label"));
                    file["quality.level"] = Convert.ToInt32(file["quantity.level"]);//    file.quality.level = intval(file.quality.level);
                    file["quality.label"] = htmlspecialchars(file["quality.label"], ENT_QUOTES, "UTF-8", false);//    file.quality.label = htmlspecialchars(file.quality.label, ENT_QUOTES, "UTF-8", false);
                }//  }
            }//}
            if (file["copyright"])//if (isset(file.copyright))
            { // {
                this.validateGroup(file["copyright"], this.getCopyrightSemantics(), false); //  this.validateGroup(file.copyright, this.getCopyrightSemantics());
            }
        }//}

        public void validateGroup(Dictionary<string, dynamic> group, Dictionary<string, dynamic> semantics, bool flatten)
        {
            // Groups with just one field are compressed in the editor to only output
            // the child content. (Exemption for fake groups created by
            // "validateBySemantics" above)
            string subContentId = null;
            bool _void = true;//object _void = null;
            bool found = true;

            bool isSubContent = (semantics["isSubContent"] != null) && Convert.ToBoolean(semantics["isSubContent"]);//bool isSubContent = (semantics["isSubContent"]!=null )&& Convert.ToBoolean(semantics["isSubContent"]);

            if (((Dictionary<string, dynamic>)semantics["fields"]).Count == 1 && flatten && !isSubContent)//if (((Hashtable)semantics["fields"]).Count==1 && flatten && !isSubContent)
            {//{
                Dictionary<string, dynamic> field = null;//Hashtable field = null;
                Dictionary<string, dynamic> fields = (Dictionary<string, dynamic>)semantics["fields"];//    Hashtable fields = (Hashtable)semantics["fields"];
                field = (Dictionary<string, dynamic>)fields[""]; //    field = (Hashtable)fields[0];
                string type = field["type"].ToString();//    string type = field["type"].ToString();
                _void = (bool)this.typeMap["type"];//    _void = this.typeMap[type];
                validateGroup(group, field, false);//    validateGroup(group, field, false);
            }//}
            else//else
            {//{
                foreach (KeyValuePair<string, dynamic> key in group)//    foreach (group as string key => &value)
                {//    {
                    subContentId = subContentId != null ? subContentId : string.Empty; //        // If subContentId is set, keep value
                    if (isSubContent && (key.Value == "subContentId"))
                    {//        if (isSubContent && (string key == "subContentId")){
                        continue;//            continue;
                    }//        }
                     //        // Find semantics for name=string key 
                    found = false;//        found = false;

                    foreach (KeyValuePair<string, dynamic> field in (Dictionary<string, dynamic>)semantics["fields"])//        foreach (semantics.fields as field)
                    {//        {
                        if (field.Key == key.Key)
                        {//            if (field.name == string key ) {
                            if (semantics["optional"] != null && String.IsNullOrEmpty((string)semantics["optional"]))//                if (isset(semantics.optional) && semantics.optional)
                            {//                {
                                field.Value["optional"] = true;//                    field.optional = TRUE;
                            }//                }
                            _void = (bool)this.typeMap["field.type"];//                void = this.typeMap[field.type];
                            found = true; //                found = TRUE;
                            break;//                break;
                        }//            }
                    } //        }
                    if (found)//        if (found)
                    { //        {
                        if (_void)//            if (void)
                        {//            {
                            this._void(value, "");//                this.void(value, field);
                            if (value == null)//                if (value === null)
                            {//                {
                             //                    unset(group.string key);
                            }//                }
                        }//            }
                        else//            else
                        {//            {
                         //                // We have a field type in semantics for which we don"t have a
                         //                // known validator.
                            string type = null;
                            this.h5pF.setErrorMessage(this.h5pF.t("H5P internal error: unknown content type " + type + " in semantics. Removing content!", null), "semantics-unknown-type"); //                this.h5pF.setErrorMessage(this.h5pF.t("H5P internal error: unknown content type "@type" in semantics. Removing content!", array("@type" => field.type)), "semantics-unknown-type");
                                                                                                                                                                                             //                unset(group.string key);
                        }//            }
                    }//        }
                    else//        else
                    {//        {
                     //            // If validator is not found, something exists in content that does
                     //            // not have a corresponding semantics field. Remove it.
                     //            // this.h5pF.setErrorMessage(this.h5pF.t("H5P internal error: no validator exists for @key", array("@key" => string key )));
                        group[""] = key;//            unset(group.string key);
                    }//        }
                }//    }
            }//}
            if (!((semantics["optional"] != null) && string.IsNullOrEmpty((string)semantics["optional"])))//if (!(isset(semantics.optional) && semantics.optional))
            {//{
                if (group == null)//    if (group === null)
                {//    {
                 //        // Error no value. Errors aren"t printed...
                    return;//        return;
                }//    }
                foreach (KeyValuePair<string, dynamic> field in (Dictionary<string, dynamic>)semantics["fields"])//    foreach (semantics.fields as field)
                {  //    {
                    if (!((field.Value["optional"] != null) && (string.IsNullOrEmpty((string)field.Value["optional"]))))//        if (!(isset(field.optional) && field.optional))
                    {//        {
                     //            // Check if field is in group.
                        if (!property_exists(group, (string)field.Value["name"]))//            if (!property_exists(group, field.name))
                        {//            {
                            this.h5pF.setErrorMessage(this.h5pF.t("No value given for mandatory field ", (Dictionary<string, dynamic>)field.Value["name"])); //                //this.h5pF.setErrorMessage(this.h5pF.t("No value given for mandatory field " . field.name));
                        } //            }
                    }//        }
                }//    }
            }  //}
        }
        public bool property_exists(Dictionary<string, dynamic> input1, string input2)
        {
            return true;
        }
        public bool in_array(string input1, Dictionary<string, dynamic> input2)
        {
            return true;
        }
        public void filterParams(Dictionary<string, dynamic> _params, Dictionary<string, dynamic> whitelist)
        {
            foreach (KeyValuePair<string, dynamic> key in _params)//foreach (params as string key => value)
            {// {
                if (!in_array(key.Key, whitelist))//    if (!in_array(string key, whitelist))
                {//    {
                    _params = null;//        unset(params.{ string key });
                }//    }
            }//}

            // XSS filters copied from drupal 7 common.inc. Some modifications done to
            // replace Drupal one-liner voids with corresponding flat PHP.
            /**
             * Filters HTML to prevent cross-site-scripting (XSS) vulnerabilities.
             *
             * Based on kses by Ulf Harnhammar, see http://sourceforge.net/projects/kses.
             * For examples of various XSS attacks, see: http://ha.ckers.org/xss.html.
             *
             * This code does four things:
             * - Removes characters and constructs that can trick browsers.
             * - Makes sure all HTML entities are well-formed.
             * - Makes sure all HTML tags and attributes are well-formed.
             * - Makes sure no HTML tags contain URLs with a disallowed protocol (e.g.
             *   javascript:).
             *
             * @param string
             *   The string with raw HTML in it. It will be stripped of everything that can
             *   cause an XSS attack.
             * @param array allowed_tags
             *   An array of allowed tags.
             *
             * @param bool allowedStyles
             * @return mixed|string An XSS safe version of string, or an empty string if string is not
             * An XSS safe version of string, or an empty string if string is not
             * valid UTF-8.
             * @ingroup sanitation
             */
        }
        public Dictionary<string, dynamic> array_merge(Dictionary<string, dynamic> array1, Dictionary<string, dynamic> array2)
        {

            return null;
        }
        //        /**
        //         * Validate given file data
        //         * @param file
        //         * @param semantics
        //         */
        public void validateFile(Dictionary<string, dynamic> file, Dictionary<string, dynamic> semantics)
        {
            this._validateFilelike(file, semantics, null);
        }
        //        /**
        //         * Validate given image data
        //         * @param image
        //         * @param semantics
        //         */
        public void validateImage(Dictionary<string, dynamic> image, Dictionary<string, dynamic> semantics)
        {
            this._validateFilelike(image, semantics, new Dictionary<string, dynamic> { { "0", "width" }, { "1", "height" }, { "2", "originalImage" } });
        }
        //        /**
        //         * Validate given video data
        //         * @param video
        //         * @param semantics
        //         */
        public void validateVideo(object video, Dictionary<string, dynamic> semantics)
        {
            foreach (Dictionary<string, dynamic> v in (List<object>)video)
            {
                this._validateFilelike(v, semantics, new Dictionary<string, dynamic> { { "0", "width" }, { "1", "height" }, { "2", "codecs" }, { "3", "quality" } });
            }
        }
        //        /**
        //         * Validate given audio data
        //         * @param audio
        //         * @param semantics
        //         */
        public void validateAudio(object audio, Dictionary<string, dynamic> semantics)
        {
            foreach (Dictionary<string, dynamic> a in (List<object>)audio)
            {
                this._validateFilelike(a, semantics, null);
            }
        }

        //        /**
        //         * Validate given library value against library semantics.
        //         * Check if provided library is within allowed options.
        //         *
        //         * Will recurse into validating the library"s semantics too.
        //         * @param value
        //         * @param semantics
        //         */
        Dictionary<string, dynamic> libraries, dependencies, nextWeight;
        public void validateLibrary(Dictionary<string, dynamic> value, Dictionary<string, dynamic> semantics)
        {
            if (!(value["library"] != null))//if (!isset(value.library))
            {//{
                value = null;//    value = null;
                return;//    return;
            }//}
            if (!in_array((string)value["library"], (Dictionary<string, dynamic>)semantics["options"]))//if (!in_array(value.library, semantics.options))
            {//{
                string message = null;//    message = null;
                                      //    // Create an understandable error message:
                var machineName = ((string)value["library"]).ToString().Split(new char[] { ',' }); //    string machineName Array = explode(" ", value.library);
                string _machineName = machineName[0];//    string machineName = string machineName Array[0];
                foreach (KeyValuePair<string, dynamic> semanticsLibrary in semantics["options"])//    foreach (semantics.options as semanticsLibrary)
                {//    {
                    var semanticsMachineNameArray = semanticsLibrary.ToString().Split(new char[] { ',' });//        semanticsMachineNameArray = explode(" ", semanticsLibrary);
                    var semanticsMachineName = semanticsMachineNameArray[0];//        semanticsMachineName = semanticsMachineNameArray[0];
                    if (_machineName == semanticsMachineName)
                    {//        if (string machineName === semanticsMachineName) {
                     //            // Using the wrong version of the library in the content
                        message = this.h5pF.t("The version of the H5P library %machineName used in this content is not valid. Content contains %contentLibrary, but it should be %semanticsLibrary.", new Dictionary<string, dynamic> {                                          //message = this.h5pF.t("The version of the H5P library %machineName used in this content is not valid. Content contains %contentLibrary, but it should be %semanticsLibrary.", array(
                                                                                                                                                                                                                                        { "%machineName", machineName}          //"%machineName" => string machineName,
                                                                                                                                                                                                                                        ,{ "%contentLibrary",value["library"]}   //"%contentLibrary" => value.library,
                                                                                                                                                                                                                                        ,{ "%semanticsLibrary", semanticsLibrary}});//"%semanticsLibrary" => semanticsLibrary));
                        break; //break;
                    }//}
                }  //}
                // Using a library in content that is not present at all in semantics
                if (message == null)//    if (message === null)
                {//    {
                    message = this.h5pF.t("The H5P library %library used in the content is not valid", new Dictionary<string, dynamic> { { "%library", value["library"] } });//        message = this.h5pF.t("The H5P library %library used in the content is not valid", array("%library" => value.library));
                }//    }
                this.h5pF.setErrorMessage(message);            //    this.h5pF.setErrorMessage(message);
                value = null;//    value = null;
                return;         //    return;
            }                //}
            if ((this.libraries["value.library"]))                         //if (!isset(this.libraries[value.library]))
            {//{
                var libSpec = H5PCore.libraryFromString(value["library"]);//    libSpec = H5PCore::libraryFromString(value.library);
                                                                          //    object library = this.h5pC.loadLibrary(libSpec["machineName"], libSpec["majorVersion"], libSpec["minorVersion"]);
                                                                          //    object library["semantics"] = this.h5pC.loadLibrarySemantics(libSpec["machineName"], libSpec["majorVersion"], libSpec["minorVersion"]);
                                                                          //    this.libraries[value.library] = object library;
            }                         //}
            else                      //else
            {                      //{
                library = this.libraries["value.library"];                //    object library = this.libraries[value.library];
            }               //}

            this.validateGroup(value["params"], new Dictionary<string, dynamic>() { { "type", "group" }, { "fields", (object)library["semantics"] } }, false);//this.validateGroup(value.params, (object)array("type" => "group","fields" => object library["semantics"],), false);


            var validKeys = new Dictionary<string, dynamic> { { "0", "library" }, { "1", "params" }, { "2", "subContentId" } };//validKeys = array("library", "params", "subContentId");
            if (semantics["extraAttributes"] != null)//if (isset(semantics.extraAttributes))
            {//{
                validKeys = array_merge(validKeys, semantics[""]);//    validKeys = array_merge(validKeys, semantics.extraAttributes);
            }//}
            this.filterParams(value, validKeys);//this.filterParams(value, validKeys);
            if ((value["subContentId"] != null) && (!(preg_match(new Regex(@"/^\{?[a-f0-9]{8}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{12}\}?/"), value["subContentId"]))))//if (isset(value.subContentId) && !preg_match("/^\{?[a-f0-9]{8}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{12}\}?/", value.subContentId))
            {//{
                value["subContentId"] = null;//    unset(value.subContentId);
            }//}
            //// Find all dependencies for this library
            var depKey = "preloaded-" + library["machineName"];//depKey = "preloaded-". object library["machineName"];
            if (!(this.dependencies["depKey"] != null))//if (!isset(this.dependencies[depKey]))
            {//{
                this.dependencies["depKey"] = new Dictionary<string, dynamic> {//    this.dependencies[depKey] = array(
                    {"library",library},  //      "library" => object library,
                    { "type", "preloaded"}//      "type" => "preloaded"
                }; //    );

                this.nextWeight = this.h5pC.findLibraryDependencies(this.dependencies, library, this.nextWeight);//    this.nextWeight = this.h5pC.findLibraryDependencies(this.dependencies, object library, this.nextWeight);
                //    this.dependencies[depKey]["weight"] = this.nextWeight++;
            }//}
        }
        //        /**

        //        //private void filter_xss(string, allowed_tags = array("a", "em", "strong", "cite", "blockquote", "code", "ul", "ol", "li", "dl", "dt", "dd"), allowedStyles = false) {
        //        //  if (strlen(string) == 0) {
        //        //    return string;
        //        //  }
        //        //  // Only operate on valid UTF-8 strings. This is necessary to prevent cross
        //        //  // site scripting issues on Internet Explorer 6. (Line copied from
        //        //  // drupal_validate_utf8)
        //        //  if (preg_match("/^./us", string) != 1) {
        //        //    return "";
        //        //  }
        //        //  this.allowedStyles = allowedStyles;
        //        //  // Store the text format.
        //        //  this._filter_xss_split(allowed_tags, TRUE);
        //        //  // Remove null characters (ignored by some browsers).
        //        //  string = str_replace(chr(0), "", string);
        //        //  // Remove Netscape 4 JS entities.
        //        //  string = preg_replace("%&\s*\{[^}]*(\}\s*;?|)%", "", string);
        //        //  // Defuse all HTML entities.
        //        //  string = str_replace("&", "&amp;", string);
        //        //  // Change back only well-formed entities in our whitelist:
        //        //  // Decimal numeric entities.
        //        //  string = preg_replace("/&amp;#([0-9]+;)/", "&#\1", string);
        //        //  // Hexadecimal numeric entities.
        //        //  string = preg_replace("/&amp;#[Xx]0*((?:[0-9A-Fa-f]{2})+;)/", "&#x\1", string);
        //        //  // Named entities.
        //        //  string = preg_replace("/&amp;([A-Za-z][A-Za-z0-9]*;)/", "&\1", string);
        //        //  return preg_replace_callback("%
        //        //    (
        //        //    <(?=[^a-zA-Z!/])  # a lone <
        //        //    |                 # or
        //        //    <!--.*?-.        # a comment
        //        //    |                 # or
        //        //    <[^>]*(>|)       # a string that starts with a <, up until the > or the end of the string
        //        //    |                 # or
        //        //    >                 # just a >
        //        //    )%x", array(this, "_filter_xss_split"), string);
        //        //}
        //        /**
        //         * Processes an HTML tag.
        //         *
        //         * @param m
        //         *   An array with various meaning depending on the value of store.
        //         *   If store is TRUE then the array contains the allowed tags.
        //         *   If store is false then the array has one element, the HTML tag to process.
        //         * @param bool store
        //         *   Whether to store m.
        //         * @return string If the element isn"t allowed, an empty string. Otherwise, the cleaned up
        //         * If the element isn"t allowed, an empty string. Otherwise, the cleaned up
        //         * version of the HTML element.
        //         */
        //        //private void _filter_xss_split(m, store = false) {
        //        //  static allowed_html;
        //        //  if (store) {
        //        //    allowed_html = array_flip(m);
        //        //    return allowed_html;
        //        //  }
        //        //  string = m[1];
        //        //  if (substr(string, 0, 1) != "<") {
        //        //    // We matched a lone ">" character.
        //        //    return "&gt;";
        //        //  }
        //        //  elseif (strlen(string) == 1) {
        //        //    // We matched a lone "<" character.
        //        //    return "&lt;";
        //        //  }
        //        //  if (!preg_match("%^<\s*(/\s*)?([a-zA-Z0-9\-]+)([^>]*)>?|(<!--.*?-.)%", string, matches)) {
        //        //    // Seriously malformed.
        //        //    return "";
        //        //  }
        //        //  slash = trim(matches[1]);
        //        //  elem = &matches[2];
        //        //  attrList = &matches[3];
        //        //  comment = &matches[4];
        //        //  if (comment) {
        //        //    elem = "!--";
        //        //  }
        //        //  if (!isset(allowed_html[strtolower(elem)])) {
        //        //    // Disallowed HTML element.
        //        //    return "";
        //        //  }
        //        //  if (comment) {
        //        //    return comment;
        //        //  }
        //        //  if (slash != "") {
        //        //    return "</elem>";
        //        //  }
        //        //  // Is there a closing XHTML slash at the end of the attributes?
        //        //  attrList = preg_replace("%(\s?)/\s*%", "\1", attrList, -1, count);
        //        //  xhtml_slash = count ? " /" : "";
        //        //  // Clean up attributes.
        //        //  attr2 = implode(" ", this._filter_xss_attributes(attrList, (in_array(elem, self::allowed_styleable_tags) ? this.allowedStyles : false)));
        //        //  attr2 = preg_replace("/[<>]/", "", attr2);
        //        //  attr2 = strlen(attr2) ? " " . attr2 : "";
        //        //  return "<elemattr2xhtml_slash>";
        //        //}
        //        /**
        //         * Processes a string of HTML attributes.
        //         *
        //         * @param attr
        //         * @param array|bool|object allowedStyles
        //         * @return array Cleaned up version of the HTML attributes.
        //         * Cleaned up version of the HTML attributes.
        //         */
        //        //private void _filter_xss_attributes(attr, allowedStyles = false) {
        //        //  attrArr = array();
        //        //  mode = 0;
        //        //  attrName = "";
        //        //  skip = false;
        //        //  while (strlen(attr) != 0) {
        //        //    // Was the last operation successful?
        //        //    working = 0;
        //        //    switch (mode) {
        //        //      case 0:
        //        //        // Attribute name, href for instance.
        //        //        if (preg_match("/^([-a-zA-Z]+)/", attr, match)) {
        //        //          attrName = strtolower(match[1]);
        //        //          skip = (attrName == "style" || substr(attrName, 0, 2) == "on");
        //        //          working = mode = 1;
        //        //          attr = preg_replace("/^[-a-zA-Z]+/", "", attr);
        //        //        }
        //        //        break;
        //        //      case 1:
        //        //        // Equals sign or valueless ("selected").
        //        //        if (preg_match("/^\s*=\s*/", attr)) {
        //        //          working = 1; mode = 2;
        //        //          attr = preg_replace("/^\s*=\s*/", "", attr);
        //        //          break;
        //        //        }
        //        //        if (preg_match("/^\s+/", attr)) {
        //        //          working = 1; mode = 0;
        //        //          if (!skip) {
        //        //            attrArr[] = attrName;
        //        //          }
        //        //          attr = preg_replace("/^\s+/", "", attr);
        //        //        }
        //        //        break;
        //        //      case 2:
        //        //        // Attribute value, a URL after href= for instance.
        //        //        if (preg_match("/^"([^"]*)"(\s+|)/", attr, match)) {
        //        //          if (allowedStyles && attrName === "style") {
        //        //            // Allow certain styles
        //        //            foreach (allowedStyles as pattern) {
        //        //              if (preg_match(pattern, match[1])) {
        //        //                // All patterns are start to end patterns, and CKEditor adds one span per style
        //        //                attrArr[] = "style="" . match[1] . """;
        //        //                break;
        //        //              }
        //        //            }
        //        //            break;
        //        //          }
        //        //          thisVal = this.filter_xss_bad_protocol(match[1]);
        //        //          if (!skip) {
        //        //            attrArr[] = "attrName=\"thisVal\"";
        //        //          }
        //        //          working = 1;
        //        //          mode = 0;
        //        //          attr = preg_replace("/^"[^"]*"(\s+|)/", "", attr);
        //        //          break;
        //        //        }
        //        //        if (preg_match("/^"([^"]*)"(\s+|)/", attr, match)) {
        //        //          thisVal = this.filter_xss_bad_protocol(match[1]);
        //        //          if (!skip) {
        //        //            attrArr[] = "attrName="thisVal"";
        //        //          }
        //        //          working = 1; mode = 0;
        //        //          attr = preg_replace("/^"[^"]*"(\s+|)/", "", attr);
        //        //          break;
        //        //        }
        //        //        if (preg_match("%^([^\s\""]+)(\s+|)%", attr, match)) {
        //        //          thisVal = this.filter_xss_bad_protocol(match[1]);
        //        //          if (!skip) {
        //        //            attrArr[] = "attrName=\"thisVal\"";
        //        //          }
        //        //          working = 1; mode = 0;
        //        //          attr = preg_replace("%^[^\s\""]+(\s+|)%", "", attr);
        //        //        }
        //        //        break;
        //        //    }
        //        //    if (working == 0) {
        //        //      // Not well formed; remove and try again.
        //        //      attr = preg_replace("/
        //        //        ^
        //        //        (
        //        //        "[^"]*("|)     # - a string that starts with a double quote, up until the next double quote or the end of the string
        //        //        |               # or
        //        //        \"[^\"]*(\"|)| # - a string that starts with a quote, up until the next quote or the end of the string
        //        //        |               # or
        //        //        \S              # - a non-whitespace character
        //        //        )*              # any number of the above three
        //        //        \s*             # any number of whitespaces
        //        //        /x", "", attr);
        //        //      mode = 0;
        //        //    }
        //        //  }
        //        //  // The attribute list ends with a valueless attribute like "selected".
        //        //  if (mode == 1 && !skip) {
        //        //    attrArr[] = attrName;
        //        //  }
        //        //  return attrArr;
        //        //}
        //        // TODO: Remove Drupal related stuff in docs.
        //        /**
        //         * Processes an HTML attribute value and strips dangerous protocols from URLs.
        //         *
        //         * @param string
        //         *   The string with the attribute value.
        //         * @param bool decode
        //         *   (deprecated) Whether to decode entities in the string. Set to false if the
        //         *   string is in plain text, TRUE otherwise. Defaults to TRUE. This parameter
        //         *   is deprecated and will be removed in Drupal 8. To process a plain-text URI,
        //         *   call _strip_dangerous_protocols() or check_url() instead.
        //         * @return string Cleaned up and HTML-escaped version of string.
        //         * Cleaned up and HTML-escaped version of string.
        //         */
        public string filter_xss_bad_protocol(string input1, bool decode = true)//private void filter_xss_bad_protocol(string, decode = TRUE)
        {// {
         //  // Get the plain text representation of the attribute value (i.e. its meaning).
         //  // @todo Remove the decode parameter in Drupal 8, and always assume an HTML
         //  //   string that needs decoding.
            string _string = null;
            if (decode)//  if (decode) {
            {

                _string = html_entity_decode(_string, ENT_QUOTES, "UTF-8");//    string = html_entity_decode(string, ENT_QUOTES, "UTF-8");

            }//  }
            return htmlspecialchars(this._strip_dangerous_protocols(_string), ENT_QUOTES, "UTF-8", false);//  return htmlspecialchars(this._strip_dangerous_protocols(string), ENT_QUOTES, "UTF-8", false);
        }//}
        public string html_entity_decode(string _input, object input2, string input3)
        {
            return "";
        }
        public string _strip_dangerous_protocols(string uri)//private void _strip_dangerous_protocols(uri)
        { //{
            var allowed_protocols = new Dictionary<string, dynamic>();//  static allowed_protocols;
            string before = null;
            int colonPos = 0;
            if (!(allowed_protocols != null))//  if (!isset(allowed_protocols)) 
            {//{
                var array = new Dictionary<string, dynamic> {
                    { "ftp","http"},
                    { "https","mailto"}
                };
                allowed_protocols = array_flip(array);//    allowed_protocols = array_flip(array("ftp", "http", "https", "mailto"));
            }//  }
             //  // Iteratively remove any invalid protocol found.
            do//  do 
            {//{
                before = uri;//    before = uri;
                colonPos = uri.IndexOf(":");//    colonPos = strpos(uri, ":");
                if (colonPos > 0)//    if (colonPos > 0)
                {// {
                 // We found a colon, possibly a protocol. Verify.
                    var protocol = uri.Substring(colonPos);//      protocol = substr(uri, 0, colonPos);
                                                           //      // If a colon is preceded by a slash, question mark or hash, it cannot
                                                           //      // possibly be part of the URL scheme. This must be a relative URL, which
                                                           //      // inherits the (safe) protocol of the base document.
                    if (preg_match(new Regex(@"![/?#]!"), new Dictionary<string, dynamic> { { "", protocol } }))//      if (preg_match("![/?#]!", protocol)) {
                    {
                        break;//        break;
                    }//      }
                     //      // Check if this is a disallowed protocol. Per RFC2616, section 3.2.3
                     //      // (URI Comparison) scheme comparison must be case-insensitive.
                    if (!(allowed_protocols[protocol.ToLower()]))//      if (!isset(allowed_protocols[strtolower(protocol)])) {
                    {
                        uri = uri.Substring(colonPos + 1);//        uri = substr(uri, colonPos + 1);

                    }//      }
                }//    }
            } while (before != uri);//  } while (before != uri);
            return uri;//  return uri;
        }//}
        public Dictionary<string, dynamic> array_flip(Dictionary<string, dynamic> array)
        {
            return null;
        }
        //        ///**
        //        // * Strips dangerous protocols (e.g. "javascript:") from a URI.
        //        // *
        //        // * This void must be called for all URIs within user-entered input prior
        //        // * to being output to an HTML attribute value. It is often called as part of
        //        // * check_url() or filter_xss(), but those voids return an HTML-encoded
        //        // * string, so this void can be called independently when the output needs to
        //        // * be a plain-text string for passing to t(), l(), drupal_attributes(), or
        //        // * another void that will call check_plain() separately.
        //        // *
        //        // * @param uri
        //        // *   A plain-text URI that might contain dangerous protocols.
        //        // * @return string A plain-text URI stripped of dangerous protocols. As with all plain-text
        //        // * A plain-text URI stripped of dangerous protocols. As with all plain-text
        //        // * strings, this return value must not be output to an HTML page without
        //        // * check_plain() being called on it. However, it can be passed to voids
        //        // * expecting plain-text strings.
        //        // * @see check_url()
        //        // */
    
        public Dictionary<string,dynamic> getCopyrightSemantics() //        //void getCopyrightSemantics() {
        {
            var semantics = new Dictionary<string, dynamic>();//        //  static semantics;
            if (semantics == null) //        //  if (semantics === null) {
            {
                var cc_versions = new Dictionary<string, dynamic>
                {//        //    cc_versions = array(
                    {
                        "", new Dictionary<string,dynamic>{
                        { "value","4.0"},
                        { "label",this.h5pF.t("4.0 International")
                    },
                    {"", new Dictionary<string,dynamic>
                    {
                        { "value","3.0"},
                        { "label",this.h5pF.t("3.0 Unported") }
                    }},
                    {"", new Dictionary<string,dynamic>
                    {
                        { "value","2.5"},
                        { "label",this.h5pF.t("2.5 Generic") }
                    }},
                    {
                         "", new Dictionary<string,dynamic>
                    {

                        { "value","2.0"},
                        { "label",this.h5pF.t("2.0 Generic") }
                    }
                    },//endpoint
                    {
                         "", new Dictionary<string,dynamic>
                    {

                        { "value","1.0"},
                        { "label",this.h5pF.t("1.0 Generic") }
                    }
                    }//endpoint
                    }
                    }
                };
                //        //      (object) array(
                //        //        "value" => "4.0",
                //        //        "label" => this.h5pF.t("4.0 International")
                //        //      ),
                //        //      (object) array(
                //        //        "value" => "3.0",
                //        //        "label" => this.h5pF.t("3.0 Unported")
                //        //      ),
                //        //      (object) array(
                //        //        "value" => "2.5",
                //        //        "label" => this.h5pF.t("2.5 Generic")
                //        //      ),
                //        //      (object) array(
                //        //        "value" => "2.0",
                //        //        "label" => this.h5pF.t("2.0 Generic")
                //        //      ),
                //        //      (object) array(
                //        //        "value" => "1.0",
                //        //        "label" => this.h5pF.t("1.0 Generic")
                //        //      )
                //        //    );
                semantics = new Dictionary<string, dynamic> {
                    { "",new Dictionary<string,dynamic>{
                        {"name", "copyright"},
                        {"type", "group"},
                        {"label", this.h5pF.t("Copyright information")},
                        {"fields", new Dictionary<string,dynamic>{
                            { "name","title"},
                            { "type", "text"},
                            { "label",this.h5pF.t("Title")},
                            {"placeholder", "La Gioconda" },
                            { "optional", true}
                        }},
                        {"fields", new Dictionary<string,dynamic>{
                            { "name","author"},
                            { "type", "text"},
                            { "label",this.h5pF.t("Author")},
                            {"placeholder", "Leonardo da Vinci" },
                            { "optional", true}
                        }},
                        {"fields", new Dictionary<string,dynamic>{
                            { "name","year"},
                            { "type", "text"},
                            { "label",this.h5pF.t("Year(s)")},
                            {"placeholder", "1503 - 1517" },
                            { "optional", true}
                        }},
                        {"fields", new Dictionary<string,dynamic>{
                            { "name","source"},
                            { "type", "text"},
                            { "label",this.h5pF.t("Source")},
                            {"placeholder", "http://en.wikipedia.org/wiki/Mona_Lisa"},
                            { "optional", true},
                            {  "regexp", new Dictionary<string,dynamic>{
                                {"pattern", "^http[s]?://.+"},
                                { "modifiers", "i"}
                            }}
                        }},
                        {"fields", new Dictionary<string,dynamic>{
                            { "name","license"},
                            { "type", "select"},
                            { "label",this.h5pF.t("License")},
                            { "default", "U"},
                            {  "options", new Dictionary<string,dynamic>{
                                {"value", "U"},
                                { "label", this.h5pF.t("Undisclosed")}
                            }},
                            {  "options", new Dictionary<string,dynamic>{
                                {"value", "CC BY"},
                                { "label", this.h5pF.t("Attribution")},
                                { "versions", cc_versions}
                            }},
                            {  "options", new Dictionary<string,dynamic>{
                                {"value", "CC BY-SA"},
                                { "label", this.h5pF.t("Attribution-ShareAlike")},
                                { "versions", cc_versions}
                            }},
                            {  "options", new Dictionary<string,dynamic>{
                                {"value", "CC BY-ND"},
                                { "label", this.h5pF.t("Attribution-NoDerivs")},
                                { "versions", cc_versions}
                            }},
                            {  "options", new Dictionary<string,dynamic>{
                                {"value", "CC BY-NC"},
                                { "label", this.h5pF.t("Attribution-NonCommercial")},
                                { "versions", cc_versions}
                            }},
                            {  "options", new Dictionary<string,dynamic>{
                                {"value", "CC BY-NC-SA"},
                                { "label", this.h5pF.t("Attribution-NonCommercial-ShareAlike")},
                                { "versions", cc_versions}
                            }},
                            {  "options", new Dictionary<string,dynamic>{
                                {"value", "CC BY-NC-ND"},
                                { "label", this.h5pF.t("Attribution-NonCommercial-NoDerivs")},
                                { "versions", cc_versions}
                            }},
                            {  "options", new Dictionary<string,dynamic>{
                                {"value", "GNU GPL"},
                                { "label", this.h5pF.t("General Public License")},
                                { "versions", new Dictionary<string,dynamic>{
                                    {"value","v3"},
                                    { "label",this.h5pF.t("Version 3")}
                                }},
                                { "versions", new Dictionary<string,dynamic>{
                                    {"value","v2"},
                                    { "label",this.h5pF.t("Version 2")}
                                }},
                                { "versions", new Dictionary<string,dynamic>{
                                    {"value","v1"},
                                    { "label",this.h5pF.t("Version 1")}
                                }}
                            }},
                            {  "options", new Dictionary<string,dynamic>{
                                {"value", "PD"},
                                { "label", this.h5pF.t("Public Domain") },
                                { "versions", new Dictionary<string,dynamic>{
                                    {"value","-"},
                                    { "label","-"}
                                }},
                                { "versions", new Dictionary<string,dynamic>{
                                    {"value","CC0 1.0"},
                                    { "label",this.h5pF.t("CC0 1.0 Universal")}
                                }},
                                { "versions", new Dictionary<string,dynamic>{
                                    {"value","CC PDM"},
                                    { "label",this.h5pF.t("Public Domain Mark")}
                                }}
                            }},
                            {  "options", new Dictionary<string,dynamic>{
                                {"value", "C"},
                                { "label", this.h5pF.t("Copyright")}                         
                            }},
                        }},
                        {"fields", new Dictionary<string,dynamic>{
                            { "name","version"},
                            { "type", "select"},
                            { "label",this.h5pF.t("License Version") },
                            { "optional", new Dictionary<string,dynamic>()}
                        }},
                    }},
                };                                        //        //    semantics = (object) array(
                                                                      //        //      "name" => "copyright",
                                                                      //        //      "type" => "group",
                                                                      //        //      "label" => this.h5pF.t("Copyright information"),
                                                                      //        //      "fields" => array(
                                                                      //        //        (object) array(
                                                                      //        //          "name" => "title",
                                                                      //        //          "type" => "text",
                                                                      //        //          "label" => this.h5pF.t("Title"),
                                                                      //        //          "placeholder" => "La Gioconda",
                                                                      //        //          "optional" => TRUE
                                                                      //        //        ),
                                                                      //        //        (object) array(
                                                                      //        //          "name" => "author",
                                                                      //        //          "type" => "text",
                                                                      //        //          "label" => this.h5pF.t("Author"),
                                                                      //        //          "placeholder" => "Leonardo da Vinci",
                                                                      //        //          "optional" => TRUE
                                                                      //        //        ),
                                                                      //        //        (object) array(
                                                                      //        //          "name" => "year",
                                                                      //        //          "type" => "text",
                                                                      //        //          "label" => this.h5pF.t("Year(s)"),
                                                                      //        //          "placeholder" => "1503 - 1517",
                                                                      //        //          "optional" => TRUE
                                                                      //        //        ),
                                                                      //        //        (object) array(
                                                                      //        //          "name" => "source",
                                                                      //        //          "type" => "text",
                                                                      //        //          "label" => this.h5pF.t("Source"),
                                                                      //        //          "placeholder" => "http://en.wikipedia.org/wiki/Mona_Lisa",
                                                                      //        //          "optional" => true,
                                                                      //        //          "regexp" => (object) array(
                                                                      //        //            "pattern" => "^http[s]?://.+",
                                                                      //        //            "modifiers" => "i"
                                                                      //        //          )
                                                                      //        //        ),
                                                                      //        //        (object) array(
                                                                      //        //          "name" => "license",
                                                                      //        //          "type" => "select",
                                                                      //        //          "label" => this.h5pF.t("License"),
                                                                      //        //          "default" => "U",
                                                                      //        //          "options" => array(
                                                                      //        //            (object) array(
                                                                      //        //              "value" => "U",
                                                                      //        //              "label" => this.h5pF.t("Undisclosed")
                                                                      //        //            ),
                                                                      //        //            (object) array(
                                                                      //        //              "value" => "CC BY",
                                                                      //        //              "label" => this.h5pF.t("Attribution"),
                                                                      //        //              "versions" => cc_versions
                                                                      //        //            ),
                                                                      //        //            (object) array(
                                                                      //        //              "value" => "CC BY-SA",
                                                                      //        //              "label" => this.h5pF.t("Attribution-ShareAlike"),
                                                                      //        //              "versions" => cc_versions
                                                                      //        //            ),
                                                                      //        //            (object) array(
                                                                      //        //              "value" => "CC BY-ND",
                                                                      //        //              "label" => this.h5pF.t("Attribution-NoDerivs"),
                                                                      //        //              "versions" => cc_versions
                                                                      //        //            ),
                                                                      //        //            (object) array(
                                                                      //        //              "value" => "CC BY-NC",
                                                                      //        //              "label" => this.h5pF.t("Attribution-NonCommercial"),
                                                                      //        //              "versions" => cc_versions
                                                                      //        //            ),
                                                                      //        //            (object) array(
                                                                      //        //              "value" => "CC BY-NC-SA",
                                                                      //        //              "label" => this.h5pF.t("Attribution-NonCommercial-ShareAlike"),
                                                                      //        //              "versions" => cc_versions
                                                                      //        //            ),
                                                                      //        //            (object) array(
                                                                      //        //              "value" => "CC BY-NC-ND",
                                                                      //        //              "label" => this.h5pF.t("Attribution-NonCommercial-NoDerivs"),
                                                                      //        //              "versions" => cc_versions
                                                                      //        //            ),
                                                                      //        //            (object) array(
                                                                      //        //              "value" => "GNU GPL",
                                                                      //        //              "label" => this.h5pF.t("General Public License"),
                                                                      //        //              "versions" => array(
                                                                      //        //                (object) array(
                                                                      //        //                  "value" => "v3",
                                                                      //        //                  "label" => this.h5pF.t("Version 3")
                                                                      //        //                ),
                                                                      //        //                (object) array(
                                                                      //        //                  "value" => "v2",
                                                                      //        //                  "label" => this.h5pF.t("Version 2")
                                                                      //        //                ),
                                                                      //        //                (object) array(
                                                                      //        //                  "value" => "v1",
                                                                      //        //                  "label" => this.h5pF.t("Version 1")
                                                                      //        //                )
                                                                      //        //              )
                                                                      //        //            ),
                                                                      //        //            (object) array(
                                                                      //        //              "value" => "PD",
                                                                      //        //              "label" => this.h5pF.t("Public Domain"),
                                                                      //        //              "versions" => array(
                                                                      //        //                (object) array(
                                                                      //        //                  "value" => "-",
                                                                      //        //                  "label" => "-"
                                                                      //        //                ),
                                                                      //        //                (object) array(
                                                                      //        //                  "value" => "CC0 1.0",
                                                                      //        //                  "label" => this.h5pF.t("CC0 1.0 Universal")
                                                                      //        //                ),
                                                                      //        //                (object) array(
                                                                      //        //                  "value" => "CC PDM",
                                                                      //        //                  "label" => this.h5pF.t("Public Domain Mark")
                                                                      //        //                )
                                                                      //        //              )
                                                                      //        //            ),
                                                                      //        //            (object) array(
                                                                      //        //              "value" => "C",
                                                                      //        //              "label" => this.h5pF.t("Copyright")
                                                                      //        //            )
                                                                      //        //          )
                                                                      //        //        ),
                                                   
                                                                      //        //      )
                                                                      //        //    );
            }//        //  } 
            return semantics;//        //  return semantics;
        }//    }
    }
    public class H5PDisplayOptionBehaviour
    {
        public static bool ALWAYS_SHOW;
        public static bool NEVER_SHOW;
        public static bool CONTROLLED_BY_AUTHOR_DEFAULT_ON;
        public static bool CONTROLLED_BY_AUTHOR_DEFAULT_OFF;
        public static bool CONTROLLED_BY_PERMISSIONS;
    }

}


