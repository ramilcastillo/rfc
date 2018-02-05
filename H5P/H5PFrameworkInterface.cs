using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using H5P.Editor;

namespace H5P
{
    public interface IH5PFrameworkInterface
    {
        /**
         * Returns info for the current platform
         *
         * @return array
         *   An associative array containing:
         *   - name: The name of the platform, for instance "Wordpress"
         *   - version: The version of the platform, for instance "4.0"
         *   - h5pVersion: The version of the H5P plugin/module
         */
        Dictionary<string, dynamic> getPlatformInfo();



        /**
         * Fetches a file from a remote server using HTTP GET
         *
         * @param string $url Where you want to get or send data.
         * @param array $data Data to post to the URL.
         * @param bool $blocking Set to 'FALSE' to instantly time out (fire and forget).
         * @param string $stream Path to where the file should be saved.
         * @return string The content (response body). NULL if something went wrong
         */
        Dictionary<string, dynamic> fetchExternalData(string url, object data = null, bool blocking = true, object stream = null);

        /**
         * Set the tutorial URL for a library. All versions of the library is set
         *
         * @param string $machineName
         * @param string $tutorialUrl
         */
        void setLibraryTutorialUrl(string machineName, string tutorialUrl);

        /**
         * Show the user an error message
         *
         * @param string $message The error message
         * @param string $code An optional code
         */
        void setErrorMessage(string message, string code = "");

        /**
         * Show the user an information message
         *
         * @param string $message
         *  The error message
         */
        void setInfoMessage(string message);

        /**
         * Return messages
         *
         * @param string $type 'info' or 'error'
         * @return string[]
         */
        Dictionary<string, dynamic> getMessages(string type);

        /**
         * Translation function
         *
         * @param string $message
         *  The english string to be translated.
         * @param array $replacements
         *   An associative array of replacements to make after translation. Incidences
         *   of any key in this array are replaced with the corresponding value. Based
         *   on the first character of the key, the value is escaped and/or themed:
         *    - !variable: inserted as is
         *    - @variable: escape plain text to HTML
         *    - %variable: escape text and theme as a placeholder for user-submitted
         *      content
         * @return string Translated string
         * Translated string
         */
        string t(string message, Dictionary<string, dynamic> replacements = null);

        /**
         * Get URL to file in the specific library
         * @param string $libraryFolderName
         * @param string $fileName
         * @return string URL to file
         */
        string getLibraryFileUrl(string libraryFolderName, string fileName);

        /**
         * Get the Path to the last uploaded h5p
         *
         * @return string
         *   Path to the folder where the last uploaded h5p for this session is located.
         */
        string getUploadedH5pFolderPath();

        /**
         * Get the path to the last uploaded h5p file
         *
         * @return string
         *   Path to the last uploaded h5p
         */
        string getUploadedH5pPath();

        /**
         * Get a list of the current installed libraries
         *
         * @return array
         *   Associative array containing one entry per machine name.
         *   For each machineName there is a list of libraries(with different versions)
         */
        Dictionary<string, dynamic> loadLibraries();

        /**
         * Returns the URL to the library admin page
         *
         * @return string
         *   URL to admin page
         */
        string getAdminUrl();

        /**
         * Get id to an existing library.
         * If version number is not specified, the newest version will be returned.
         *
         * @param string $machineName
         *   The librarys machine name
         * @param int $majorVersion
         *   Optional major version number for library
         * @param int $minorVersion
         *   Optional minor version number for library
         * @return int
         *   The id of the specified library or FALSE
         */
        int getLibraryId(string machineName, int? majorVersion = null, int? minorVersion = null);

        /**
         * Get file extension whitelist
         *
         * The default extension list is part of h5p, but admins should be allowed to modify it
         *
         * @param boolean $isLibrary
         *   TRUE if this is the whitelist for a library. FALSE if it is the whitelist
         *   for the content folder we are getting
         * @param string $defaultContentWhitelist
         *   A string of file extensions separated by whitespace
         * @param string $defaultLibraryWhitelist
         *   A string of file extensions separated by whitespace
         */
        string getWhitelist(bool isLibrary, string defaultContentWhitelist, string defaultLibraryWhitelist);

        /**
         * Is the library a patched version of an existing library?
         *
         * @param object $library
         *   An associative array containing:
         *   - machineName: The library machineName
         *   - majorVersion: The librarys majorVersion
         *   - minorVersion: The librarys minorVersion
         *   - patchVersion: The librarys patchVersion
         * @return boolean
         *   TRUE if the library is a patched version of an existing library
         *   FALSE otherwise
         */
        bool isPatchedLibrary(Dictionary<string, dynamic> library);

        /**
         * Is H5P in development mode?
         *
         * @return boolean
         *  TRUE if H5P development mode is active
         *  FALSE otherwise
         */
        bool isInDevMode();

        /**
         * Is the current user allowed to update libraries?
         *
         * @return boolean
         *  TRUE if the user is allowed to update libraries
         *  FALSE if the user is not allowed to update libraries
         */
        bool mayUpdateLibraries();

        /**
         * Store data about a library
         *
         * Also fills in the libraryId in the libraryData object if the object is new
         *
         * @param object $libraryData
         *   Associative array containing:
         *   - libraryId: The id of the library if it is an existing library.
         *   - title: The library's name
         *   - machineName: The library machineName
         *   - majorVersion: The library's majorVersion
         *   - minorVersion: The library's minorVersion
         *   - patchVersion: The library's patchVersion
         *   - runnable: 1 if the library is a content type, 0 otherwise
         *   - fullscreen(optional): 1 if the library supports fullscreen, 0 otherwise
         *   - embedTypes(optional): list of supported embed types
         *   - preloadedJs(optional): list of associative arrays containing:
         *     - path: path to a js file relative to the library root folder
         *   - preloadedCss(optional): list of associative arrays containing:
         *     - path: path to css file relative to the library root folder
         *   - dropLibraryCss(optional): list of associative arrays containing:
         *     - machineName: machine name for the librarys that are to drop their css
         *   - semantics(optional): Json describing the content structure for the library
         *   - language(optional): associative array containing:
         *     - languageCode: Translation in json format
         * @param bool $new
         * @return
         */
        void saveLibraryData(Dictionary<string, dynamic> libraryData, bool _new = true);

        /**
         * Insert new content.
         *
         * @param array $content
         *   An associative array containing:
         *   - id: The content id
         *   - params: The content in json format
         *   - library: An associative array containing:
         *     - libraryId: The id of the main library for this content
         * @param int $contentMainId
         *   Main id for the content if this is a system that supports versions
         */
        int insertContent(Dictionary<string, dynamic> content, int? contentMainId = null);

        /**
         * Update old content.
         *
         * @param array $content
         *   An associative array containing:
         *   - id: The content id
         *   - params: The content in json format
         *   - library: An associative array containing:
         *     - libraryId: The id of the main library for this content
         * @param int $contentMainId
         *   Main id for the content if this is a system that supports versions
         */
        int updateContent(Dictionary<string, dynamic> content, int? contentMainId = null);

        /**
         * Resets marked user data for the given content.
         *
         * @param int $contentId
         */
        void resetContentUserData(int contentId);

        /**
         * Save what libraries a library is depending on
         *
         * @param int $libraryId
         *   Library Id for the library we're saving dependencies for
         * @param array $dependencies
         *   List of dependencies as associative arrays containing:
         *   - machineName: The library machineName
         *   - majorVersion: The library's majorVersion
         *   - minorVersion: The library's minorVersion
         * @param string $dependency_type
         *   What type of dependency this is, the following values are allowed:
         *   - editor
         *   - preloaded
         *   - dynamic
         */
        void saveLibraryDependencies(int libraryId, Dictionary<string, dynamic> dependencies, int dependency_type);

        /**
         * Give an H5P the same library dependencies as a given H5P
         *
         * @param int $contentId
         *   Id identifying the content
         * @param int $copyFromId
         *   Id identifying the content to be copied
         * @param int $contentMainId
         *   Main id for the content, typically used in frameworks
         *   That supports versions. (In this case the content id will typically be
         *   the version id, and the contentMainId will be the frameworks content id
         */
        void copyLibraryUsage(int contentId, int copyFromId, int? contentMainId = null);

        /**
         * Deletes content data
         *
         * @param int $contentId
         *   Id identifying the content
         */
        void deleteContentData(int contentId);

        /**
         * Delete what libraries a content item is using
         *
         * @param int $contentId
         *   Content Id of the content we'll be deleting library usage for
         */
        void deleteLibraryUsage(int contentId);

        /**
         * Saves what libraries the content uses
         *
         * @param int $contentId
         *   Id identifying the content
         * @param array $librariesInUse
         *   List of libraries the content uses. Libraries consist of associative arrays with:
         *   - library: Associative array containing:
         *     - dropLibraryCss(optional): comma separated list of machineNames
         *     - machineName: Machine name for the library
         *     - libraryId: Id of the library
         *   - type: The dependency type. Allowed values:
         *     - editor
         *     - dynamic
         *     - preloaded
         */
        void saveLibraryUsage(int contentId, Dictionary<string, dynamic> librariesInUse);

        /**
         * Get number of content/nodes using a library, and the number of
         * dependencies to other libraries
         *
         * @param int $libraryId
         *   Library identifier
         * @param boolean $skipContent
         *   Flag to indicate if content usage should be skipped
         * @return array
         *   Associative array containing:
         *   - content: Number of content using the library
         *   - libraries: Number of libraries depending on the library
         */
        Dictionary<string, dynamic> getLibraryUsage(int libraryId, bool skipContent = false);

        /**
         * Loads a library
         *
         * @param string $machineName
         *   The library's machine name
         * @param int $majorVersion
         *   The library's major version
         * @param int $minorVersion
         *   The library's minor version
         * @return array|FALSE
         *   FALSE if the library does not exist.
         *   Otherwise an associative array containing:
         *   - libraryId: The id of the library if it is an existing library.
         *   - title: The library's name
         *   - machineName: The library machineName
         *   - majorVersion: The library's majorVersion
         *   - minorVersion: The library's minorVersion
         *   - patchVersion: The library's patchVersion
         *   - runnable: 1 if the library is a content type, 0 otherwise
         *   - fullscreen(optional): 1 if the library supports fullscreen, 0 otherwise
         *   - embedTypes(optional): list of supported embed types
         *   - preloadedJs(optional): comma separated string with js file paths
         *   - preloadedCss(optional): comma separated sting with css file paths
         *   - dropLibraryCss(optional): list of associative arrays containing:
         *     - machineName: machine name for the librarys that are to drop their css
         *   - semantics(optional): Json describing the content structure for the library
         *   - preloadedDependencies(optional): list of associative arrays containing:
         *     - machineName: Machine name for a library this library is depending on
         *     - majorVersion: Major version for a library this library is depending on
         *     - minorVersion: Minor for a library this library is depending on
         *   - dynamicDependencies(optional): list of associative arrays containing:
         *     - machineName: Machine name for a library this library is depending on
         *     - majorVersion: Major version for a library this library is depending on
         *     - minorVersion: Minor for a library this library is depending on
         *   - editorDependencies(optional): list of associative arrays containing:
         *     - machineName: Machine name for a library this library is depending on
         *     - majorVersion: Major version for a library this library is depending on
         *     - minorVersion: Minor for a library this library is depending on
         */
        Dictionary<string, dynamic> loadLibrary(string machineName, int majorVersion, int minorVersion);

        /**
         * Loads library semantics.
         *
         * @param string $machineName
         *   Machine name for the library
         * @param int $majorVersion
         *   The library's major version
         * @param int $minorVersion
         *   The library's minor version
         * @return string
         *   The library's semantics as json
         */
        Dictionary<string,dynamic> loadLibrarySemantics(string machineName, int majorVersion, int minorVersion);

        /**
         * Makes it possible to alter the semantics, adding custom fields, etc.
         *
         * @param array $semantics
         *   Associative array representing the semantics
         * @param string $machineName
         *   The library's machine name
         * @param int $majorVersion
         *   The library's major version
         * @param int $minorVersion
         *   The library's minor version
         */
        void alterLibrarySemantics(Dictionary<string,dynamic> semantics, string machineName, int majorVersion, int minorVersion);

        /**
         * Delete all dependencies belonging to given library
         *
         * @param int $libraryId
         *   Library identifier
         */
        void deleteLibraryDependencies(int libraryId);

        /**
         * Start an atomic operation against the dependency storage
         */
        void lockDependencyStorage();

        /**
         * Stops an atomic operation against the dependency storage
         */
        void unlockDependencyStorage();


        /**
         * Delete a library from database and file system
         *
         * @param stdClass $library
         *   Library object with id, name, major version and minor version.
         */
        void deleteLibrary(Dictionary<string,dynamic> library);

        /**
         * Load content.
         *
         * @param int $id
         *   Content identifier
         * @return array
         *   Associative array containing:
         *   - contentId: Identifier for the content
         *   - params: json content as string
         *   - embedType: csv of embed types
         *   - title: The contents title
         *   - language: Language code for the content
         *   - libraryId: Id for the main library
         *   - libraryName: The library machine name
         *   - libraryMajorVersion: The library's majorVersion
         *   - libraryMinorVersion: The library's minorVersion
         *   - libraryEmbedTypes: CSV of the main library's embed types
         *   - libraryFullscreen: 1 if fullscreen is supported. 0 otherwise.
         */
        Dictionary<string, dynamic> loadContent(int id);

        /**
         * Load dependencies for the given content of the given type.
         *
         * @param int $id
         *   Content identifier
         * @param int $type
         *   Dependency types. Allowed values:
         *   - editor
         *   - preloaded
         *   - dynamic
         * @return array
         *   List of associative arrays containing:
         *   - libraryId: The id of the library if it is an existing library.
         *   - machineName: The library machineName
         *   - majorVersion: The library's majorVersion
         *   - minorVersion: The library's minorVersion
         *   - patchVersion: The library's patchVersion
         *   - preloadedJs(optional): comma separated string with js file paths
         *   - preloadedCss(optional): comma separated sting with css file paths
         *   - dropCss(optional): csv of machine names
         */
        Dictionary<string, dynamic> loadContentDependencies(int id, int? type = null);

        /**
         * Get stored setting.
         *
         * @param string $name
         *   Identifier for the setting
         * @param string $default
         *   Optional default value if settings is not set
         * @return mixed
         *   Whatever has been stored as the setting
         */
        bool getOption(string name, bool _default);
        bool getOption(string name, string _default);
        /**
         * Stores the given setting.
         * For example when did we last check h5p.org for updates to our libraries.
         *
         * @param string $name
         *   Identifier for the setting
         * @param mixed $value Data
         *   Whatever we want to store as the setting
         */
        void setOption(string name, Dictionary<string, dynamic> value);
        void setOption(string name, string value);

        /**
         * This will update selected fields on the given content.
         *
         * @param int $id Content identifier
         * @param array $fields Content fields, e.g. filtered or slug.
         */
        void updateContentFields(int id, Dictionary<string, dynamic> fields);

        /**
         * Will clear filtered params for all the content that uses the specified
         * library. This means that the content dependencies will have to be rebuilt,
         * and the parameters re-filtered.
         *
         * @param int $library_id
         */
        void clearFilteredParameters(int library_id);

        /**
         * Get number of contents that has to get their content dependencies rebuilt
         * and parameters re-filtered.
         *
         * @return int
         */
        int getNumNotFiltered();

        /**
         * Get number of contents using library as main library.
         *
         * @param int $libraryId
         * @return int
         */
        int getNumContent(int libraryId);

        /**
         * Determines if content slug is used.
         *
         * @param string $slug
         * @return boolean
         */
        bool isContentSlugAvailable(string slug);

        /**
         * Generates statistics from the event log per library
         *
         * @param string $type Type of event to generate stats for
         * @return array Number values indexed by library name and version
         */
        Dictionary<string, dynamic> getLibraryStats(string type);

        /**
         * Aggregate the current number of H5P authors
         * @return int
         */
        int getNumAuthors();

        /**
         * Stores hash keys for cached assets, aggregated JavaScripts and
         * stylesheets, and connects it to libraries so that we know which cache file
         * to delete when a library is updated.
         *
         * @param string $key
         *  Hash key for the given libraries
         * @param array $libraries
         *  List of dependencies(libraries) used to create the key
         */
        void saveCachedAssets(int key, string[] libraries);

        /**
         * Locate hash keys for given library and delete them.
         * Used when cache file are deleted.
         *
         * @param int $library_id
         *  Library identifier
         * @return array
         *  List of hash keys removed
         */
        Dictionary<string,dynamic> deleteCachedAssets(int library_id);

        /**
         * Get the amount of content items associated to a library
         * return int
         */
        Dictionary<string, dynamic> getLibraryContentCount();

        /**
         * Will trigger after the export file is created.
         */
        void afterExportCreated(object content, string filename);

        /**
         * Check if user has permissions to an action
         *
         * @method hasPermission
         * @param  [H5PPermission] $permission Permission type, ref H5PPermission
         * @param  [int]           $id         Id need by platform to determine permission
         * @return boolean
         */
        bool hasPermission(int permission, int id = 0);

        /**
         * Replaces existing content type cache with the one passed in
         *
         * @param object $contentTypeCache Json with an array called 'libraries'
         *  containing the new content type cache that should replace the old one.
         */
        void replaceContentTypeCache(Dictionary<string, dynamic> contentTypeCache);
    }

    public class H5PFrameworkInterface : IH5PFrameworkInterface
    {
        public H5PFrameworkInterface(string h5pF)
        {

        }
        public const string CONNECTION_STRING = "User ID=sa;password=@Dm1n123;Initial Catalog=h5p;Data Source=.;;Packet Size=4096;TimeOut=0;";
        /**
         * Get type of hvp instance
         *
         * @param string $type Type of hvp instance to get
         * @return \H5PContentValidator|\H5PCore|\H5PStorage|\H5PValidator|\mod_hvp\framework|\H5peditor
         */
        public static string framework()
        {
            return string.Empty;
        }
        public static string file_storage()
        {
            return string.Empty;
        }
        public string current_language()
        {
            return string.Empty;
        }
        public string get_language()
        {
            Dictionary<string,dynamic> map = null; //    static $map;

            if (map == null)      //    if (empty($map))
            {//    {
             //    // Create mapping for "converting" language codes.
                map = new Dictionary<string,dynamic>{
                    { "no","nb"}
                };//    $map = array(
             //        'no' => 'nb'
             //    );
            }        //    }

            //// Get current language in Moodle.
            var language = (current_language().ToLower()).Replace("_","-"); //$language = str_replace('_', '-', strtolower(\current_language()));

        //    // Try to map.
        return (map[language]?map[language]:language);//    return isset($map[$language]) ? $map[$language] : $language;
        }
        public dynamic instance(string type = null)//        public static function instance($type = null)
        {//        {
         //            global $CFG;
            H5PFrameworkInterface _interface = null;
            H5PCore core = null;
            string   editor, editorinterface, editorajaxinterface;//            static $interface, $core, $editor, $editorinterface, $editorajaxinterface;
            string fs;
            if (!(_interface != null))//        if (!isset($interface)) {
            {
                _interface = new H5PFrameworkInterface(@"\mod_hvp\"+ framework());//            $interface = new \mod_hvp\framework();

                fs = @"\mod_hvp\" + file_storage(); //           $fs = new \mod_hvp\file_storage();

                var _context = context_system.instance();//            $context = \context_system::instance();
                var url = CFG.httpswwwroot + "/pluginfile.php/" + _context + "/mod_hvp";//            $url = "{$CFG->httpswwwroot}/pluginfile.php/{$context->id}/mod_hvp";

                var languange = get_language(); //            $language = self::get_language();

                var export = !((CFG.mod_hvp_export != null) && CFG.mod_hvp_export == "0");//            $export = !(isset($CFG->mod_hvp_export) && $CFG->mod_hvp_export === '0');
                 
                core = new H5PCore(_interface, fs, url, languange, export); //            $core = new \H5PCore($interface, $fs, $url, $language, $export);
                core.aggregateAssets = !(CFG.mod_hvp_aggregate_assets != null) && (CFG.mod_hvp_aggregate_assets == "0");//            $core->aggregateAssets = !(isset($CFG->mod_hvp_aggregate_assets) && $CFG->mod_hvp_aggregate_assets === '0');
            }//        }

            switch (type)//        switch ($type) {
            {
                case "validator"://            case 'validator':
                    return new H5PValidator(_interface, core); //                return new \H5PValidator($interface, $core);
                    break;
                case "storage": //            case 'storage':
                    return new H5PStorage(_interface,core);//                return new \H5PStorage($interface, $core);
             //            case 'contentvalidator':
             //                return new \H5PContentValidator($interface, $core);
             //            case 'interface':
             //                return $interface;
             //            case 'editor':
             //                if (empty($editorinterface)) {
             //                    $editorinterface = new \mod_hvp\editor_framework();
             //}

                //                if (empty($editorajaxinterface)) {
                //                    $editorajaxinterface = new editor_ajax();
                //                }

                //                if (empty($editor)) {
                //                    $editor = new \H5peditor($core, $editorinterface, $editorajaxinterface);
                //                }
                //                return $editor;
                //            case 'core':
                //            default:
                //                return $core;
            }//        }
            return null;
        }//    }

        public string libraryId { get; set; }

        public void afterExportCreated(object content, string filename)
        {
           
        }

        public void alterLibrarySemantics(Dictionary<string,dynamic> semantics, string machineName, int majorVersion, int minorVersion)
        {
            //    global $PAGE;
            PAGE.set_context(null);//$PAGE->set_context(null);
            var renderer = PAGE.get_renderer("mod_hvp");//$renderer = $PAGE->get_renderer('mod_hvp');
            renderer.hvp_alter_semantics(semantics, machineName, majorVersion, minorVersion);//$renderer->hvp_alter_semantics($semantics, $name, $majorversion, $minorversion);
        }

        public void clearFilteredParameters(int library_id)
        {
        //    global $DB;

        //$DB->execute("UPDATE {hvp} SET filtered = null WHERE main_library_id = ?", array($libraryid));
        }

        public void copyLibraryUsage(int contentId, int copyFromId, int? contentMainId = null)
        {
            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand = new SqlCommand();
            string libraryusage = null;
            m_SqlCommand = new SqlCommand(@"select * from hvp_contents_libraries where id = @id",m_SqlConnection);
            m_SqlCommand.Parameters.AddWithValue("@id", copyFromId);
            SqlDataReader reader = m_SqlCommand.ExecuteReader();
            while (reader.Read())
            {
                libraryusage = reader["id"].ToString();
            }

            m_SqlCommand = new SqlCommand("insert into hvp_contents_libraries values ('"+libraryusage+"',0,0,1)",m_SqlConnection);

            m_SqlCommand.ExecuteNonQuery();
            //    global $DB;

            //$libraryusage = $DB->get_record('hvp_contents_libraries', array(
            //    'id' => $copyfromid
            //));

            //$libraryusage->id = $contentid;
            //$DB->insert_record_raw('hvp_contents_libraries', (array)$libraryusage, false, false, true);

            //    // TODO: This must be verified at a later time.
            //    // Currently in Moodle copyLibraryUsage() will never be called.
        }

        public Dictionary<string,dynamic> deleteCachedAssets(int library_id)
        {
            //    global $DB;

            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand = new SqlCommand(@"SELECT hash
                       FROM  hvp_libraries_cachedassets
                       WHERE library_id = @library_id",m_SqlConnection);
            m_SqlCommand.Parameters.AddWithValue("@library_id", library_id);

            SqlDataReader reader = m_SqlCommand.ExecuteReader();
            var hashes = new Dictionary<string,dynamic>();
            while (reader.Read())
            {
                hashes.Add("hash",reader["hash"].ToString());
            }

            foreach (KeyValuePair<string,dynamic> s in hashes)
            {
                m_SqlCommand = new SqlCommand(@"delete from hvp_libraries_cachedassets where hash = @hash", m_SqlConnection);
                m_SqlCommand.Parameters.AddWithValue("@hash", s.Value);
                m_SqlCommand.ExecuteNonQuery();
            }

            return hashes;
            //// Get all the keys so we can remove the files.
            //$results = $DB->get_records_sql(
            //        'SELECT hash
            //           FROM { hvp_libraries_cachedassets}
            //    WHERE library_id = ? ',

            //  array($libraryid));

            //// Remove all invalid keys.
            //$hashes = array();
            //    foreach ($results as $key) {
            //    $hashes[] = $key->hash;
            //    $DB->delete_records('hvp_libraries_cachedassets', array('hash' => $key->hash));
            //    }

            //    return $hashes;
        }

        public void deleteContentData(int contentId)
        {
            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand = new SqlCommand(@"DELETE FROM hvp_contents_libraries WHERE library_id = @library_id");
            m_SqlCommand.Parameters.AddWithValue("@hvp_id", contentId);
            try
            {
                m_SqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                m_SqlConnection.Close();
            }
            //    global $DB;

            //// Remove content.
            //$DB->delete_records('hvp', array('id' => $contentid));

            //// Remove content library dependencies.
            //$this->deleteLibraryUsage($contentid);

            //// Remove user data for content.
            //$DB->delete_records('hvp_content_user_data', array('hvp_id' => $contentid));
        }
        public string getH5pPath()
        {
    
            return CFG.dirroot+ "/mod/hvp/files";
        }
        public void deleteLibrary(Dictionary<string,dynamic> library)
        {
            //    global $DB;
            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand = new SqlCommand(@"DELETE FROM hvp_libraries_libraries WHERE library_id = @library_id");
            //// Delete library files.
            var librarybase = this.getH5pPath() + "/libraries/"; //$librarybase = $this->getH5pPath(). '/libraries/';
            var libname = library["name"]+"-"+library["major_version"]+library["minor_version"];
            H5PCore.deleteFileTree(librarybase+libname);//\H5PCore::deleteFileTree("{$librarybase}{$libname}");

            //// Remove library data from database.

            m_SqlCommand = new SqlCommand(@"delete from hvp_libraries_libraries 
                                            where library_id = @library_id",m_SqlConnection);
            m_SqlCommand.Parameters.AddWithValue("@library_id",library["library_id"]);
            m_SqlCommand.ExecuteNonQuery();

            m_SqlCommand = new SqlCommand(@"delete from hvp_libraries_languages 
                                            where library_id = @library_id", m_SqlConnection);
            m_SqlCommand.Parameters.AddWithValue("@library_id", library["library_id"]);
            m_SqlCommand.ExecuteNonQuery();

            m_SqlCommand = new SqlCommand(@"delete from hvp_libraries 
                                            where id = @id", m_SqlConnection);
            m_SqlCommand.Parameters.AddWithValue("@id", library["id"]);
            m_SqlCommand.ExecuteNonQuery();

            //$DB->delete('hvp_libraries_libraries', array('library_id' => $library->id));
            //$DB->delete('hvp_libraries_languages', array('library_id' => $library->id));
            //$DB->delete('hvp_libraries', array('id' => $library->id));
        }

        public void deleteLibraryDependencies(int libraryId)
        {
            //global $DB;
            //$DB->delete_records('hvp_libraries_libraries', array('library_id' => $libraryid));
            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand = new SqlCommand(@"DELETE FROM hvp_libraries_libraries WHERE library_id = @library_id");
            m_SqlCommand.Parameters.AddWithValue("@library_id", libraryId);
            try
            {
                m_SqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                m_SqlConnection.Close();
            }
        }

        public void deleteLibraryUsage(int contentId)
        {
            //global $DB;
            //$DB->delete_records('hvp_contents_libraries', array('hvp_id' => $contentid));
            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand = new SqlCommand(@"DELETE FROM hvp_contents_libraries WHERE library_id = @library_id");
            m_SqlCommand.Parameters.AddWithValue("@hvp_id", contentId);
            try
            {
                m_SqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                m_SqlConnection.Close();
            }
        }

        public  Dictionary<string, dynamic> fetchExternalData(string url, object data = null, bool blocking = true, object stream = null)
        {

            if (stream != null)//            if (stream !== null)
            {//            {
             //                // Download file.
             //                set_time_limit(0);

                //            // Generate local tmp file path.
                var localfolder = Guid.Parse(CFG.tempdir);//            $localfolder = $CFG->tempdir.uniqid('/hvp-');
                stream = localfolder + ".h5p";//            $stream = $localfolder. '.h5p';

                //            // Add folder and file paths to H5P Core.
                var _interface = this.instance("interface");//            $interface = self::instance('interface');
                //            $interface->getUploadedH5pFolderPath($localfolder);
                //            $interface->getUploadedH5pPath($stream);
            }//    }

            //        $response = download_file_content($url, null, $data, true, 300, 20, false, $stream);

            //        if (empty($response->error)) {
            //            return $response->results;
            //        } else {
            //            $this->setErrorMessage($response->error, 'failed-fetching-external-data');
            //}
            return null;
        }
        //public string instance(string input)
        //{
        //    return string.Empty;
        //}
        public string getAdminUrl()
        {
            return "";
        }

        public Dictionary<string, dynamic> getLibraryContentCount()
        {
            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand;

            // Find dependency library.
            Dictionary<string, dynamic> ret_value = new Dictionary<string, dynamic>();
            string machine_name;
            int count, major_version, minor_version = 0;
            m_SqlCommand = new SqlCommand(@"SELECT c.main_library_id,
            l.machine_name,
            l.major_version,
            l.minor_version,
            c.count
            FROM(SELECT main_library_id,
            count(id) as count
            FROM  hvp
            GROUP BY main_library_id) c,
             hvp_libraries
            l
            WHERE c.main_library_id = l.id", m_SqlConnection);
            try
            {
                SqlDataReader m_SqlDataReader = m_SqlCommand.ExecuteReader();
                while (m_SqlDataReader.Read())
                {
                    count = Convert.ToInt32(m_SqlDataReader["count"].ToString());
                    machine_name = m_SqlDataReader["minor_version"].ToString();
                    minor_version = Convert.ToInt32(m_SqlDataReader["minor_version"].ToString());
                    major_version = Convert.ToInt32(m_SqlDataReader["major_version"].ToString());
                    ret_value.Add(machine_name + " " + major_version.ToString() + minor_version.ToString(), count);
                }
                m_SqlDataReader.Close();
            } // end try
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                m_SqlConnection.Close();
            }
            return ret_value;
        }

        public string getLibraryFileUrl(string libraryFolderName, string fileName)
        {
            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand = new SqlCommand();
            //global $CFG;
            var _context = context_system.instance();
            var basepath = CFG.httpswwwroot + "/";
            return basepath + "pluginfile.php/" + _context + "/mod_hvp/libraries" + libraryFolderName + "/" + fileName;
            //$context = \context_system::instance();
            //$basepath = $CFG->httpswwwroot. '/';
            //return "{$basepath}pluginfile.php/{$context->id}/mod_hvp/libraries/{$libraryfoldername}/{$fileName}";
        }

        public int getLibraryId(string machineName, int? majorVersion = null, int? minorVersion = null)
        {
            // Create new library and keep track of id.
            //library->id = $DB->insert_record('hvp_libraries', $library);
            //librarydata['libraryId'] = $library->id;
            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand = new SqlCommand();
            m_SqlCommand.Connection = m_SqlConnection;
            m_SqlCommand.CommandType = CommandType.Text;
            // Look for specific library.
            string sqlwhere = " WHERE machine_name = @machine_name";
            if (majorVersion != null)
            {
                // Look for major version.
                sqlwhere += " AND major_version = @major_version";
                m_SqlCommand.Parameters.AddWithValue("@major_version", majorVersion);

            }
            if (minorVersion != null)
            {
                // Look for minor version.
                sqlwhere += " AND minor_version = @minor_version";
                m_SqlCommand.Parameters.AddWithValue("@minor_version", minorVersion);
            }

            try
            {
                m_SqlCommand.CommandText = @"SELECT id
FROM  hvp_libraries                
ORDER BY major_version DESC,
minor_version DESC,
patch_version DESC" + sqlwhere;
                SqlDataReader m_SqlDataReader = m_SqlCommand.ExecuteReader();
                // Get 1st Row - true if record found -------------
                if (m_SqlDataReader.Read())
                {
                    return (int)m_SqlDataReader["id"];
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                m_SqlConnection.Close();
            }
        }

        public Dictionary<string, dynamic> getLibraryStats(string type)
        {
            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand;

            // Find dependency library.
            Dictionary<string, dynamic> ret_value = new Dictionary<string, dynamic>();
            string name;
            int version, num = 0;
            m_SqlCommand = new SqlCommand(@"SELECT id,
                                            library_name AS name,
                                            library_version AS version,
                                            num
                                            FROM  hvp_counters", m_SqlConnection);
            try
            {
                SqlDataReader m_SqlDataReader = m_SqlCommand.ExecuteReader();
                while (m_SqlDataReader.Read())
                {
                    num = Convert.ToInt32(m_SqlDataReader["num"].ToString());
                    version = Convert.ToInt32(m_SqlDataReader["version"].ToString());
                    name = m_SqlDataReader["name"].ToString();
                    ret_value.Add(name + " " + version.ToString(), num);
                }
                m_SqlDataReader.Close();
            } // end try
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                m_SqlConnection.Close();
            }
            return ret_value;
        }

        public Dictionary<string, dynamic> getLibraryUsage(int libraryId, bool skipContent = false)
        {
            int content, libraries = 0;
            Dictionary<string, dynamic> result = new Dictionary<string, dynamic>();
            SqlCommand sqlCommand;
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    if (skipContent)
                    {
                        content = -1;
                    }
                    else
                    {
                        sqlCommand = new SqlCommand(@"SELECT COUNT(distinct c.id)
                        FROM hvp_libraries
                        l
                        JOIN hvp_contents_libraries
                        cl ON l.id = cl.library_id
                        JOIN hvp
                        c ON cl.hvp_id = c.id
                        WHERE l.id =" + libraryId, sqlConnection);
                        content = (int)sqlCommand.ExecuteNonQuery();
                    }
                    sqlCommand = new SqlCommand(@"SELECT COUNT(*)
                                            FROM { hvp_libraries_libraries}
                    WHERE required_library_id = " + libraryId, sqlConnection);
                    libraries = (int)sqlCommand.ExecuteNonQuery();

                    result.Add(content.ToString(), libraries);
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return result;

        }

        public Dictionary<string, dynamic> getMessages(string type)
        {
            return messages(type);
        }

        /**
         * Store messages until they can be printed to the current user
         *
         * @param string $type Type of messages, e.g. 'info' or 'error'
         * @param string $newmessage Optional
         * @param string $code
         * @return array Array of stored messages
         */
        public static Dictionary<string, dynamic> messages(string type, string newmessage = null, string code = null)
        {
            HttpContext context = HttpContext.Current;
            string m = "mod_hvp_messages";
            Dictionary<string, dynamic> return_messages = new Dictionary<string, dynamic>();
            if (newmessage == null)
            {
                // Return and reset messages.
                if (((Dictionary<string, dynamic>)context.Session[m])[type] != null)
                    return_messages = ((Dictionary<string, dynamic>)context.Session[m])[type];

                ((Dictionary<string, dynamic>)context.Session[m])[type] = null;
                if (context.Session[m] == null)
                {
                    //unset($_SESSION[$m]);
                    context.Session[m] = null;
                }
                return return_messages;
            }

            // We expect to get out an array of strings when getting info
            // and an array of objects when getting errors for consistency across platforms.
            // This implementation should be improved for consistency across the data type returned here.
            if (type == "error")
            {
                Dictionary<string, dynamic> err = ((Dictionary<string, dynamic>)context.Session[m])[type];
                err.Add("code", newmessage);
                ((Dictionary<string, dynamic>)context.Session[m])[type] = err;
            }
            else
            {
                Dictionary<string, dynamic> val = ((Dictionary<string, dynamic>)context.Session[m])[type];
                val.Add("", newmessage);
                ((Dictionary<string, dynamic>)context.Session[m])[type] = val;
            }
            return return_messages;
        }

        public int getNumAuthors()
        {
            //global $DB;

            // Get number of unique courses using H5P.
            //return intval($DB->get_field_sql(
            //        "SELECT COUNT(DISTINCT course)
            //           FROM { hvp}"

            object result = null;
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT COUNT(DISTINCT course) FROM hvp", sqlConnection);
                    result = sqlCommand.ExecuteScalar();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return (int)result;
        }

        public int getNumContent(int libraryId)
        {
            object result = 0;
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT COUNT(id) FROM {hvp} WHERE main_library_id = " + libraryId, sqlConnection);
                    result = sqlCommand.ExecuteScalar();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return (int)result;
        }

        public int getNumNotFiltered()
        {
            object result = 0;
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(@"SELECT COUNT(id)    
                       FROM hvp
            WHERE filtered=''", sqlConnection);
                    result = sqlCommand.ExecuteScalar();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return (int)result;
        }
        public bool get_config(string input1, string input2)
        {
            return true;
        }
        public bool getOption(string name, bool _default)
        {

            var value = get_config("mod_hvp", name);//value = get_config('mod_hvp', $name);

            if (value == false)//if ($value === false) {
            {
                return _default;//    return $default;
            }//}
            return value;//return $value;
            
        }

        public bool getOption(string name, string _default)
        {
            return true;
        }

        public Dictionary<string, dynamic> getPlatformInfo()
        {
            Dictionary<string, dynamic> pi = new Dictionary<string, dynamic>();
            pi.Add("name", "Cursum");
            pi.Add("version", "1.0");
            pi.Add("h5pVersion", "2017112800");
            return pi;
        }
        public string setpath = string.Empty;
        public string getUploadedH5pFolderPath()
        {
            string path = "";

            if (setpath != null)//if ($setpath !== null) {
            {
                path = setpath;//$path = $setpath;
            }//}

            if (!(path != null))  //if (!isset($path))
            {//{
                throw new Exception("Using getUploadedH5pFolderPath() before path is set");//    throw new \coding_exception('Using getUploadedH5pFolderPath() before path is set');
            } //}

            return path;
            //throw new System.NotImplementedException();
        }

        public string getUploadedH5pPath()
        {

            string path = null; ;//static $path;

            if (setpath != null)//if ($setpath !== null) {
            {
                path = setpath;//$path = $setpath;
            }//}

            return path;//return $path;
        }

        public string getWhitelist(bool isLibrary, string defaultContentWhitelist, string defaultLibraryWhitelist)
        {
            return defaultContentWhitelist + (isLibrary ? " " + defaultLibraryWhitelist : ""); //return $defaultcontentwhitelist. ($islibrary ? ' '. $defaultlibrarywhitelist: '');
        }
        public bool has_capability(string input1, string input2)
        {
            return true;
        }

        public bool hasPermission(int permission, int cmid = 0)
        {
            switch (permission) {
            case H5PPermission.DOWNLOAD_H5P:
                  var cmcontext = context_module.instance(cmid);
                return has_capability("mod/hvp:getexport", cmcontext);
                     
            case H5PPermission.CREATE_RESTRICTED:
                return has_capability("mod/hvp:userestrictedlibraries", this.getajaxcoursecontext());
            case H5PPermission.UPDATE_LIBRARIES:
                var _context = context_system.instance();
                return has_capability("mod/hvp:updatelibraries", _context);
            case H5PPermission.INSTALL_RECOMMENDED:
                return has_capability("mod/hvp:installrecommendedh5plibraries", this.getajaxcoursecontext());
            case H5PPermission.EMBED_H5P:
                cmcontext = context_module.instance(cmid);
                return has_capability("mod/hvp:getembedcode", cmcontext);
            }
            return false;
        }
        public const string PARAM_RAW = null;
        public const string CONTEXT_COURSE = null;
        public int required_param(string input1, object input2)
        {
            return 0;
        }
        public string getajaxcoursecontext()
        {
          var _context = context.instance_by_id(required_param("contextId", PARAM_RAW));
            if (context.contextlevel() == CONTEXT_COURSE) {
                return _context;
            }

            return context.get_course_context();
        }

        public int insertContent(Dictionary<string, dynamic> content, int? contentMainId = null)
        {
            return this.updateContent(content);
        }

        public bool isContentSlugAvailable(string slug)
        {
            return !(DB.get_field_sql("SELECT slug FROM {hvp} WHERE slug = ?",new Dictionary<string, dynamic> { { "",slug} }) !=null);
        }

        public bool isInDevMode()
        {
            return false;
        }

        public bool isPatchedLibrary(Dictionary<string, dynamic> library)
        {
            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand = new SqlCommand();
            bool result = true;
            //    global $DB, $CFG;

            if ((CFG.mod_hvp_dev != null) && (CFG.mod_hvp_dev))//    if (isset($CFG->mod_hvp_dev) && $CFG->mod_hvp_dev) {
            {//        // Makes sure libraries are updated, patch version does not matter.
                return true;//        return true;
            }//    }

            var _operator = this.isInDevMode() ? "<=" : "<";//$operator = $this->isInDevMode() ? '<=' : '<';


            //SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            //SqlCommand m_SqlCommand;
            var dependencies = new Dictionary<string, dynamic> {
                { "machinename","machinename"}
                ,{ "majorVersion","majorVersion"}
                , {"minorVersion", "minorVersion"}
                ,{ "patchVersion", "patchVersion"}
            };
            foreach (Dictionary<string, dynamic> dependency in dependencies.Values)
            {
                // Find dependency library.
                int dependencyId = 0;
                m_SqlConnection = new SqlConnection(CONNECTION_STRING);
                m_SqlCommand = new SqlCommand(@"SELECT *
                                                            FROM hvp_libraries
                                                            WHERE
                                                            machine_name = @machinename AND     
                                                            major_version = @majorVersion AND
                                                            minor_version = @minorVersion AND
                                                            patch_version @patchVersion", m_SqlConnection);
                m_SqlCommand.Parameters.AddWithValue("@machinename", dependency["machineName"]);
                m_SqlCommand.Parameters.AddWithValue("@majorVersion", dependency["majorVersion"]);
                m_SqlCommand.Parameters.AddWithValue("@minorVersion", dependency["minorVersion"]);
                m_SqlCommand.Parameters.AddWithValue("@patchVersion", dependency["patchVersion"]);
                try
                {
                    SqlDataReader m_SqlDataReader = m_SqlCommand.ExecuteReader();
                    // Get 1st Row - true if record found -------------
                    if (m_SqlDataReader.Read())
                    {
                        result = Convert.ToString(m_SqlDataReader["machinename"]) != null ? true : false;
                    }
                    m_SqlDataReader.Close();
                } // end try
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    m_SqlConnection.Close();
                }

                //$library = $DB->get_record_sql(
                //        'SELECT id
                //          FROM { hvp_libraries}
                //    WHERE machine_name = ?
                //    AND major_version = ?
                //    AND minor_version = ?
                //    AND patch_version ' . $operator . ' ? ',

                //  array($library['machineName'],
                //          $library['majorVersion'],
                //          $library['minorVersion'],
                //          $library['patchVersion'])
                //);
            }
            return result;
        }

        public Dictionary<string, dynamic> loadContent(int id)
        {
            //           global $DB;
            var content = new Dictionary<string, dynamic>();

            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand = new SqlCommand();

            m_SqlCommand = new SqlCommand(@"SELECT hc.id
                                 , hc.name
                                 , hc.intro
                                 , hc.introformat
                                 , hc.json_content
                                 , hc.filtered
                                 , hc.slug
                                 , hc.embed_type
                                 , hc.disable
                                 , hl.id AS library_id
                                 , hl.machine_name
                                 , hl.major_version
                                 , hl.minor_version
                                 , hl.embed_types
                                 , hl.fullscreen
                           FROM  hvp
            hc
 LEFT JOIN hvp_libraries
            hl ON hl.id = hc.main_library_id
                           WHERE hc.id = @id", m_SqlCommand.Connection);
            m_SqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = m_SqlCommand.ExecuteReader();

            while (reader.Read())
            {
                content.Add("id", reader["id"]);
                content.Add("title", reader["name"]);
                content.Add("intro", reader["intro"]);
                content.Add("introformat", reader["introformat"]);
                content.Add("params", reader["json_content"]);
                content.Add("filtered", reader["filtered"]);
                content.Add("slug", reader["slug"]);
                content.Add("embedType", reader["embed_type"]);
                content.Add("disable", reader["disable"]);
                content.Add("libraryId", reader["library_id"]);
                content.Add("libraryName", reader["machine_name"]);
                content.Add("libraryMajorVersion", reader["major_version"]);
                content.Add("libraryMinorVersion", reader["minor_version"]);
                content.Add("libraryEmbedTypes", reader["embed_types"]);
                content.Add("libraryFullscreen", reader["fullscreen"]);
            }
            return content;
            //       $data = $DB->get_record_sql(
            //               "SELECT hc.id
            //                     , hc.name
            //                     , hc.intro
            //                     , hc.introformat
            //                     , hc.json_content
            //                     , hc.filtered
            //                     , hc.slug
            //                     , hc.embed_type
            //                     , hc.disable
            //                     , hl.id AS library_id
            //                     , hl.machine_name
            //                     , hl.major_version
            //                     , hl.minor_version
            //                     , hl.embed_types
            //                     , hl.fullscreen
            //               FROM { hvp}
            //           hc
            //JOIN { hvp_libraries}
            //           hl ON hl.id = hc.main_library_id
            //               WHERE hc.id = ? ", array($id));

            //       // Return null if not found.
            //           if ($data === false) {
            //               return null;
            //           }

            //       // Some databases do not support camelCase, so we need to manually
            //       // map the values to the camelCase names used by the H5P core.
            //       $content = array(
            //           'id' => $data->id,
            //           'title' => $data->name,
            //           'intro' => $data->intro,
            //           'introformat' => $data->introformat,
            //           'params' => $data->json_content,
            //           'filtered' => $data->filtered,
            //           'slug' => $data->slug,
            //           'embedType' => $data->embed_type,
            //           'disable' => $data->disable,
            //           'libraryId' => $data->library_id,
            //           'libraryName' => $data->machine_name,
            //           'libraryMajorVersion' => $data->major_version,
            //           'libraryMinorVersion' => $data->minor_version,
            //           'libraryEmbedTypes' => $data->embed_types,
            //           'libraryFullscreen' => $data->fullscreen,
            //       );

            //           return $content;
        }

        public Dictionary<string, dynamic> loadContentDependencies(int id, int? type)//public void loadContentDependencies(int id, int? type)
        {//{
         //            global $DB;
            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand = new SqlCommand();


            // Find dependency library.
            int dependencyId = 0;
            string machine_name = string.Empty;
            string major_version = string.Empty;
            string minor_version = string.Empty;
            string patch_version = string.Empty;
            string preloaded_css = string.Empty;
            string preloaded_js = string.Empty;
            string drop_css = string.Empty;
            string dependency_type = string.Empty;
            Dictionary<string, dynamic> result = null;

            m_SqlCommand = new SqlCommand(@"SELECT hcl.id AS unidepid
                                       , hl.id
                                       , hl.machine_name
                                       , hl.major_version
                                       , hl.minor_version
                                       , hl.patch_version
                                       , hl.preloaded_css
                                       , hl.preloaded_js
                                       , hcl.drop_css
                                       , hcl.dependency_type
                                         FROM  hvp_contents_libraries
                                        hcl
                                        LEFT JOIN  hvp_libraries 
                                        hl ON hcl.library_id = hl.id
                                              WHERE hcl.hvp_id = @id", m_SqlConnection);
            m_SqlCommand.Parameters.AddWithValue("@id", id);

            try
            {
                SqlDataReader m_SqlDataReader = m_SqlCommand.ExecuteReader();
                // Get 1st Row - true if record found -------------
                if (m_SqlDataReader.Read())
                {
                         result = new Dictionary<string, dynamic> {
                        {"id",Convert.ToInt32(m_SqlDataReader["id"].ToString()) },
                        {"machine_name",Convert.ToString(m_SqlDataReader["id"].ToString())},
                        {"major_version",Convert.ToString(m_SqlDataReader["id"].ToString())},
                        {"minor_version",Convert.ToString(m_SqlDataReader["id"].ToString())},
                        {"patch_version",Convert.ToString(m_SqlDataReader["id"].ToString())},
                        {"preloaded_css",Convert.ToString(m_SqlDataReader["id"].ToString())},
                        {"preloaded_js",Convert.ToString(m_SqlDataReader["id"].ToString())},
                        {"drop_css",Convert.ToString(m_SqlDataReader["id"].ToString())},
                        {"dependency_type",Convert.ToString(m_SqlDataReader["id"].ToString())},
                    };
                }
                m_SqlDataReader.Close();
            } // end try
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                m_SqlConnection.Close();
            }

            return result;
            //        $query = "SELECT hcl.id AS unidepid
            //                       , hl.id
            //                       , hl.machine_name
            //                       , hl.major_version
            //                       , hl.minor_version
            //                       , hl.patch_version
            //                       , hl.preloaded_css
            //                       , hl.preloaded_js
            //                       , hcl.drop_css
            //                       , hcl.dependency_type
            //                   FROM { hvp_contents_libraries}
            //            hcl
            //JOIN { hvp_libraries}
            //            hl ON hcl.library_id = hl.id
            //                  WHERE hcl.hvp_id = ? ";
            //        $queryargs = array($id);

            //            if ($type !== null) {
            //            $query.= " AND hcl.dependency_type = ?";
            //            $queryargs[] = $type;
            //            }

            //        $query.= " ORDER BY hcl.weight";
            //        $data = $DB->get_records_sql($query, $queryargs);

            //        $dependencies = array();
            //            foreach ($data as $dependency) {
            //                unset($dependency->unidepid);
            //            $dependencies[$dependency->machine_name] = \H5PCore::snakeToCamel($dependency);
            //            }

            //            return $dependencies;
        }//}  
        
        public Dictionary<string, dynamic> loadLibraries()
        {
            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand = new SqlCommand();
            var libraries = new Dictionary<string, dynamic>();


            m_SqlCommand = new SqlCommand(@"SELECT id, machine_name, title, major_version, minor_version,
                      patch_version, runnable, restricted
                 FROM hvp_libraries 
            ORDER BY title, major_version, minor_version ASC",m_SqlConnection);

            SqlDataReader reader = m_SqlCommand.ExecuteReader();


            //foreach (KeyValuePair<string, dynamic> library in results)
            //{
            while (reader.Read())
            {
                libraries.Add("machine_name", reader["machine_name"]);
            }
            //}
            return libraries;

        }

        public Dictionary<string, dynamic> loadLibrary(string machineName, int majorVersion, int minorVersion)
        {

            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand = new SqlCommand();
            var libraries = new Dictionary<string, dynamic>();
            var librarydata = new Dictionary<string, dynamic>();

            m_SqlCommand = new SqlCommand(@"select * 
                                            from hvp_libraries 
                                            where machine_name = @machinename
                                            AND major_version = @majorversion
                                            AND minor_version = @minorversion",m_SqlConnection);

            SqlDataReader reader = m_SqlCommand.ExecuteReader();

            while (reader.Read())
            {
                librarydata.Add("libraryId", reader["id"]);
                librarydata.Add("machineName", reader["machine_name"]);
                librarydata.Add("title", reader["title"]);
                librarydata.Add("majorVersion", reader["major_version"]);
                librarydata.Add("minorVersion", reader["minor_version"]);
                librarydata.Add("patchVersion", reader["patch_version"]);
                librarydata.Add("embedTypes", reader["embed_types"]);
                librarydata.Add("preloadedJs", reader["preloaded_js"]);
                librarydata.Add("preloadedCss", reader["preloaded_css"]);
                librarydata.Add("dropLibraryCss", reader["drop_library_css"]);
                librarydata.Add("fullscreen", reader["fullscreen"]);
                librarydata.Add("runnable", reader["runnable"]);
                librarydata.Add("semantics", reader["semantics"]);
                librarydata.Add("restricted", reader["restricted"]);
                librarydata.Add("hasIcon", reader["has_icon"]);
            }
            return librarydata;
            //    global $DB;

            //$library = $DB->get_record('hvp_libraries', array(
            //    'machine_name' => $machinename,
            //    'major_version' => $majorversion,
            //    'minor_version' => $minorversion
            //));

            //$librarydata = array(
            //    'libraryId' => $library->id,
            //    'machineName' => $library->machine_name,
            //    'title' => $library->title,
            //    'majorVersion' => $library->major_version,
            //    'minorVersion' => $library->minor_version,
            //    'patchVersion' => $library->patch_version,
            //    'embedTypes' => $library->embed_types,
            //    'preloadedJs' => $library->preloaded_js,
            //    'preloadedCss' => $library->preloaded_css,
            //    'dropLibraryCss' => $library->drop_library_css,
            //    'fullscreen' => $library->fullscreen,
            //    'runnable' => $library->runnable,
            //    'semantics' => $library->semantics,
            //    'restricted' => $library->restricted,
            //    'hasIcon' => $library->has_icon
        }

        public Dictionary<string,dynamic> loadLibrarySemantics(string machineName, int majorVersion, int minorVersion)
        {

            //    global $DB;
            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand = new SqlCommand();
            var result = new Dictionary<string, dynamic>();
            m_SqlCommand = new SqlCommand(@"SELECT semantics
                FROM  hvp_libraries 
            WHERE machine_name = @machineName
            AND major_version = @majorVersion
            AND minor_version = @minorVersion ", m_SqlConnection);

            m_SqlCommand.Parameters.AddWithValue("@machine_name",machineName);
            m_SqlCommand.Parameters.AddWithValue("@major_version",majorVersion);
            m_SqlCommand.Parameters.AddWithValue("@minor_version",minorVersion);

            SqlDataReader reader = m_SqlCommand.ExecuteReader();

            while (reader.Read())
            {
                result.Add("",new Dictionary<string, dynamic> {
                    {"machine_name" ,reader["machine_name"]}
                    ,{ "major_version",reader[""]}
                    ,{ "minor_version",reader["minor_version"]}
                });
            }
            return result==null ? null : result;
            //    return ($semantics === false ? null : $semantics);
        }

        public void lockDependencyStorage()
        {
            // Library development mode not supported.
        }

        public bool allow = true;
        public bool mayUpdateLibraries()
        {
            bool _override = true;//    static $override;

            //// Allow overriding the permission check. Needed when installing.
            //// since caps hasn't been set.
            if (allow)//if ($allow) {
            {
                _override = true;//    $override = true;
            }//}
            if (_override) //if ($override) {
            {
                return true;//    return true;
            }//}

            //// Check permissions.
            var _context = context_system.instance();       //$context = \context_system::instance();
            if (!(has_capability("mod/hvp:updatelibraries", _context)))//if (!has_capability('mod/hvp:updatelibraries', $context)) {
            {
                return false;//    return false;
            }//}

            return true;         //return true;
        }

        public void replaceContentTypeCache(Dictionary<string, dynamic> contentTypeCache)
        {
            //global $DB;

            // Replace existing cache.            
            //$DB->delete_records('hvp_libraries_hub_cache');
            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand = new SqlCommand(@"DELETE FROM hvp_libraries_hub_cache");
            try
            {
                m_SqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                m_SqlConnection.Close();
            }


            foreach (Dictionary<string, dynamic> ct in contentTypeCache["contentTypes"])
            {
                //$DB->insert_record('hvp_libraries_hub_cache', (object)array(
                //    'machine_name'      => $ct->id,
                //    'major_version'     => $ct->version->major,
                //    'minor_version'     => $ct->version->minor,
                //    'patch_version'     => $ct->version->patch,
                //    'h5p_major_version' => $ct->coreApiVersionNeeded->major,
                //    'h5p_minor_version' => $ct->coreApiVersionNeeded->minor,
                //    'title'             => $ct->title,
                //    'summary'           => $ct->summary,
                //    'description'       => $ct->description,
                //    'icon'              => $ct->icon,
                //    'created_at'        => (new \DateTime($ct->createdAt))->getTimestamp(),
                //    'updated_at'        => (new \DateTime($ct->updatedAt))->getTimestamp(),
                //    'is_recommended'    => $ct->isRecommended === true ? 1 : 0,
                //    'popularity'        => $ct->popularity,
                //    'screenshots'       => json_encode($ct->screenshots),
                //    'license'           => json_encode(isset($ct->license) ? $ct->license : array()),
                //    'example'           => $ct->example,
                //    'tutorial'          => isset($ct->tutorial) ? $ct->tutorial : '',
                //    'keywords'          => json_encode(isset($ct->keywords) ? $ct->keywords : array()),
                //    'categories'        => json_encode(isset($ct->categories) ? $ct->categories : array()),
                //    'owner'             => $ct->owner
                //    ), false, true);                             
                m_SqlCommand = new SqlCommand(@"
INSERT INTO[dbo].[hvp_libraries_hub_cache]
        ([machine_name]
              ,[major_version]
              ,[minor_version]
              ,[patch_version]
              ,[h5p_major_version]
              ,[h5p_minor_version]
              ,[title]
              ,[summary]
              ,[description]
              ,[icon]
              ,[created_at]
              ,[updated_at]
              ,[is_recommended]
              ,[popularity]
              ,[screenshots]
              ,[license]
              ,[example]
              ,[tutorial]
              ,[keywords]
              ,[categories]
              ,[owner])
        VALUES
              (@machine_name
              ,@major_version
              ,@minor_version
              ,@patch_version
              ,@h5p_major_version
              ,@h5p_minor_version
              ,@title
              ,@summary
              ,@description
              ,@icon
              ,@created_at
              ,@updated_at
              ,@is_recommended
              ,@popularity
              ,@screenshots
              ,@license
              ,@example
              ,@tutorial
              ,@keywords
              ,@categories
              ,@owner)
");
                var jsonSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                m_SqlCommand.Parameters.AddWithValue("@machine_name", ct["id"]);
                m_SqlCommand.Parameters.AddWithValue("@major_version", ct["version"]["major"]);
                m_SqlCommand.Parameters.AddWithValue("@minor_version", ct["version"]["minor"]);
                m_SqlCommand.Parameters.AddWithValue("@patch_version", ct["version"]["patch"]);
                m_SqlCommand.Parameters.AddWithValue("@h5p_major_version", ct["coreApiVersionNeeded"]["major"]);
                m_SqlCommand.Parameters.AddWithValue("@h5p_minor_version", ct["coreApiVersionNeeded"]["minor"]);
                m_SqlCommand.Parameters.AddWithValue("@title", ct["title"]);
                m_SqlCommand.Parameters.AddWithValue("@summary", ct["summary"]);
                m_SqlCommand.Parameters.AddWithValue("@description", ct["description"]);
                m_SqlCommand.Parameters.AddWithValue("@icon", ct["icon"]);
                m_SqlCommand.Parameters.AddWithValue("@created_at", DateTime.Now);
                m_SqlCommand.Parameters.AddWithValue("@updated_at", DateTime.Now);
                m_SqlCommand.Parameters.AddWithValue("@is_recommended", ct["isRecommended"] == "true" ? "1" : "0");
                m_SqlCommand.Parameters.AddWithValue("@popularity", ct["popularity"]);
                string screenshot = jsonSerializer.Serialize(ct["screenshots"]);
                string license = jsonSerializer.Serialize(ct["license"]);
                string keywords = jsonSerializer.Serialize(ct["keywords"]);
                string categories = jsonSerializer.Serialize(ct["categories"]);
                m_SqlCommand.Parameters.AddWithValue("@screenshots", screenshot);
                m_SqlCommand.Parameters.AddWithValue("@license", license);
                m_SqlCommand.Parameters.AddWithValue("@example", ct["id"]);
                m_SqlCommand.Parameters.AddWithValue("@tutorial", ct["tutorial"]);
                m_SqlCommand.Parameters.AddWithValue("@keywords", keywords);
                m_SqlCommand.Parameters.AddWithValue("@categories", categories);
                m_SqlCommand.Parameters.AddWithValue("@owner", ct["owner"]);
                try
                {
                    m_SqlCommand.ExecuteScalar();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    m_SqlConnection.Close();
                }
            }

        }


        public void resetContentUserData(int contentId)
        {
            //No Implementation
           // throw new System.NotImplementedException();
        }

        public void saveCachedAssets(int key, string[] libraries)
        {
            //No Implementation
            //throw new System.NotImplementedException();
        }

        public void saveLibraryData(Dictionary<string, dynamic> librarydata, bool _new = true)
        {
            //Some special properties needs some checking and converting before they can be saved.
            //preloadedjs = $this->pathsToCsv($librarydata, 'preloadedJs');
            //preloadedcss = $this->pathsToCsv($librarydata, 'preloadedCss');
            //droplibrarycss = '';
            string preloadedjs = librarydata["preloadedJs"];
            string preloadedcss = librarydata["preloadedCss"];
            string droplibrarycss = "";

            if (librarydata["dropLibraryCss"] != null)
            {
                var dropLibCss = new Dictionary<string, dynamic>();
                int cnt = 0;
                foreach (Dictionary<string, dynamic> lib in librarydata["dropLibraryCss"])
                {
                    dropLibCss.Add(cnt.ToString(), lib["machineName"]);
                    cnt++;
                }
                droplibrarycss = String.Join(", ", dropLibCss.Values);
            }

            string embedtypes = "";
            if (librarydata["embedTypes"] != null)
            {
                embedtypes = String.Join(", ", librarydata["embedTypes"].Values);
            }
            if (librarydata["semantics"] != null)
            {
                librarydata["semantics"] = "";
            }
            if (librarydata["fullscreen"] != null)
            {
                librarydata["fullscreen"] = 0;
            }
            if (librarydata["hasIcon"] != null)
            {
                librarydata["hasIcon"] = 0;
            }

            // TODO: Can we move the above code to H5PCore? It's the same for multiple
            // implementations. Perhaps core can update the data objects before calling
            // this function?
            // I think maybe it's best to do this when classes are created for
            // library, content, etc.

            var library = new Dictionary<string, dynamic>();
            library.Add("title", librarydata["title"]);
            library.Add("machine_name", librarydata["machineName"]);
            library.Add("major_version", librarydata["majorVersion"]);
            library.Add("minor_version", librarydata["minorVersion"]);
            library.Add("patch_version", librarydata["patchVersion"]);
            library.Add("runnable", librarydata["runnable"]);
            library.Add("fullscreen", librarydata["fullscreen"]);
            library.Add("embed_types", embedtypes);
            library.Add("preloaded_js", preloadedjs);
            library.Add("preloaded_css", preloadedcss);
            library.Add("drop_library_css", droplibrarycss);
            library.Add("semantics", librarydata["semantics"]);
            library.Add("has_icon", librarydata["hasIcon"]);

            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand;
            if (_new)
            {
                // Create new library and keep track of id.
                //library->id = $DB->insert_record('hvp_libraries', $library);
                //librarydata['libraryId'] = $library->id;
                m_SqlConnection = new SqlConnection(CONNECTION_STRING);
                m_SqlCommand = new SqlCommand(@"
                INSERT INTO[hvp_libraries]
                        ([machine_name]
                          ,[title]
                          ,[major_version]
                          ,[minor_version]
                          ,[patch_version]
                          ,[runnable]
                          ,[fullscreen]
                          ,[embed_types]
                          ,[preloaded_js]
                          ,[preloaded_css]
                          ,[drop_library_css]
                          ,[semantics]
                          ,[restricted]
                          ,[tutorial_url]
                          ,[has_icon])
                    VALUES
                          (@machine_name,
                           @title,
                           @major_version,
                           @minor_version,
                           @patch_version,
                           @runnable,
                           @fullscreen,
                           @embed_types,
                           @preloaded_js,
                           @preloaded_css,
                           @drop_library_css,
                           @semantics,
                           @restricted,
                           @tutorial_url,
                           @has_icon); SELECT @thisId=SCOPE_IDENTITY() FROM hvp_libraries;", m_SqlConnection);
                m_SqlCommand.CommandType = CommandType.Text;
                m_SqlCommand.Parameters.AddWithValue("@machine_name", library["machine_name"]);
                m_SqlCommand.Parameters.AddWithValue("@title", library["title"]);
                m_SqlCommand.Parameters.AddWithValue("@major_version", library["major_version"]);
                m_SqlCommand.Parameters.AddWithValue("@minor_version", library["minor_version"]);
                m_SqlCommand.Parameters.AddWithValue("@patch_version", library["patch_version"]);
                m_SqlCommand.Parameters.AddWithValue("@runnable", library["runnable"]);
                m_SqlCommand.Parameters.AddWithValue("@fullscreen", library["fullscreen"]);
                m_SqlCommand.Parameters.AddWithValue("@embed_types", library["embed_types"]);
                m_SqlCommand.Parameters.AddWithValue("@preloaded_js", library["preloaded_js"]);
                m_SqlCommand.Parameters.AddWithValue("@preloaded_css", library["preloaded_css"]);
                m_SqlCommand.Parameters.AddWithValue("@drop_library_css", library["drop_library_css"]);
                m_SqlCommand.Parameters.AddWithValue("@semantics", library["semantics"]);
                m_SqlCommand.Parameters.AddWithValue("@has_icon", library["has_icon"]);

                SqlParameter returnParam = m_SqlCommand.Parameters.Add(new SqlParameter("@thisId", SqlDbType.Int));
                returnParam.Direction = ParameterDirection.Output;

                try
                {
                    m_SqlCommand.ExecuteScalar();
                    int id = (int)m_SqlCommand.Parameters["@thisId"].Value;
                    if (librarydata["id"] == null)
                        librarydata.Add("id", id);
                    else
                        librarydata["id"] = id;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    m_SqlConnection.Close();
                }
            }
            else
            {
                library.Add("id", librarydata["id"]);
                m_SqlConnection = new SqlConnection(CONNECTION_STRING);
                m_SqlCommand = new SqlCommand(@"
                UPDATE[hvp_libraries]
                   SET[machine_name] = @machine_name
                      ,[title] = @title
                      ,[major_version] = @major_version
                      ,[minor_version] = @minor_version
                      ,[patch_version] = @patch_version
                      ,[runnable] = @runnable
                      ,[fullscreen] = @fullscreen
                      ,[embed_types] = @embed_types
                      ,[preloaded_js] = @preloaded_js
                      ,[preloaded_css] = @preloaded_css
                      ,[drop_library_css] = @drop_library_css
                      ,[semantics] = @semantics
                      ,[restricted] = @restricted
                      ,[tutorial_url] = @tutorial_url
                      ,[has_icon] = @has_icon
                 WHERE id = @id", m_SqlConnection);
                m_SqlCommand.CommandType = CommandType.Text;
                m_SqlCommand.Parameters.AddWithValue("@machine_name", library["machine_name"]);
                m_SqlCommand.Parameters.AddWithValue("@title", library["title"]);
                m_SqlCommand.Parameters.AddWithValue("@major_version", library["major_version"]);
                m_SqlCommand.Parameters.AddWithValue("@minor_version", library["minor_version"]);
                m_SqlCommand.Parameters.AddWithValue("@patch_version", library["patch_version"]);
                m_SqlCommand.Parameters.AddWithValue("@runnable", library["runnable"]);
                m_SqlCommand.Parameters.AddWithValue("@fullscreen", library["fullscreen"]);
                m_SqlCommand.Parameters.AddWithValue("@embed_types", library["embed_types"]);
                m_SqlCommand.Parameters.AddWithValue("@preloaded_js", library["preloaded_js"]);
                m_SqlCommand.Parameters.AddWithValue("@preloaded_css", library["preloaded_css"]);
                m_SqlCommand.Parameters.AddWithValue("@drop_library_css", library["drop_library_css"]);
                m_SqlCommand.Parameters.AddWithValue("@semantics", library["semantics"]);
                m_SqlCommand.Parameters.AddWithValue("@has_icon", library["has_icon"]);
                m_SqlCommand.Parameters.AddWithValue("@id", library["id"]);

                try
                {
                    m_SqlCommand.ExecuteScalar();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    m_SqlConnection.Close();
                }

                this.deleteLibraryDependencies(librarydata["libraryId"]);
            }

            // Log library successfully installed/upgraded.
            //new \mod_hvp\event (
            //'library', ($new ? 'create' : 'update'),
            //null, null,
            //$library->machine_name, $library->major_version. '.' . $library->minor_version
            //);
            m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            m_SqlCommand = new SqlCommand(@"DELETE FROM hvp_libraries_languages WHERE library_id = @library_id");
            m_SqlCommand.Parameters.AddWithValue("@library_id", library["id"]);
            try
            {
                m_SqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                m_SqlConnection.Close();
            }

            if (librarydata["language"] != null)
            {
                m_SqlConnection = new SqlConnection(CONNECTION_STRING);
                //languagecode => $languagejson
                foreach (Dictionary<string, dynamic> language in librarydata["language"])
                {
                    string languagecode = language["languagecode"];
                    string languagejson = language["languagejson"];
                    m_SqlCommand = new SqlCommand(@"INSERT INTO hvp_libraries_languages (library_Id, language_code, language_json) VALUES (@library_Id, @language_code, @language_json)");
                    m_SqlCommand.Parameters.AddWithValue("@library_id", librarydata["libraryId"]);
                    m_SqlCommand.Parameters.AddWithValue("@language_code", library["id"]);
                    m_SqlCommand.Parameters.AddWithValue("@language_json", library["id"]);
                    try
                    {
                        m_SqlCommand.ExecuteScalar();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        m_SqlConnection.Close();
                    }
                }
            }
        }

        public void saveLibraryDependencies(int libraryId, Dictionary<string, dynamic> dependencies, int dependency_type)
        {
            //global $DB;
            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand;
            foreach (Dictionary<string, dynamic> dependency in dependencies.Values)
            {
                // Find dependency library.
                int dependencyId = 0;
                m_SqlConnection = new SqlConnection(CONNECTION_STRING);
                m_SqlCommand = new SqlCommand(@"SELECT *
                                                            FROM hvp_libraries
                                                            WHERE
                                                            machine_name = @machine_name AND
                                                            major_version = @major_version AND
                                                            minor_version = @minor_version", m_SqlConnection);
                m_SqlCommand.Parameters.AddWithValue("@machine_name", dependency["machineName"]);
                m_SqlCommand.Parameters.AddWithValue("@majorVersion", dependency["majorVersion"]);
                m_SqlCommand.Parameters.AddWithValue("@minorVersion", dependency["minorVersion"]);
                try
                {
                    SqlDataReader m_SqlDataReader = m_SqlCommand.ExecuteReader();
                    // Get 1st Row - true if record found -------------
                    if (m_SqlDataReader.Read())
                    {
                        dependencyId = Convert.ToInt32(m_SqlDataReader["id"].ToString());
                    }
                    m_SqlDataReader.Close();
                } // end try
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    m_SqlConnection.Close();
                }

                // Create relation.
                //$DB->insert_record('hvp_libraries_libraries', array(
                //    'library_id' => $libraryid,
                //    'required_library_id' => $dependencylibrary->id,
                //    'dependency_type' => $dependencytype
                //));
                m_SqlConnection = new SqlConnection(CONNECTION_STRING);
                //languagecode => $languagejson
                m_SqlCommand = new SqlCommand(@"INSERT INTO hvp_libraries_libraries (library_Id, required_library_id, dependency_type) VALUES (@library_Id, @required_library_id, @dependency_type)");
                m_SqlCommand.Parameters.AddWithValue("@library_Id", libraryId);
                m_SqlCommand.Parameters.AddWithValue("@required_library_id", dependencyId);
                m_SqlCommand.Parameters.AddWithValue("@dependency_type", dependency_type);
                try
                {
                    m_SqlCommand.ExecuteScalar();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    m_SqlConnection.Close();
                }
            }
        }

        public void saveLibraryUsage(int contentId, Dictionary<string, dynamic> librariesInUse)
        {
            //global $DB;

            string[] droplibrarycsslist = { };
            foreach (Dictionary<string, dynamic> dependency in librariesInUse.Values)
            {
                if (dependency["library"]["dropLibraryCss"] != null)
                {
                    string[] splitCss = dependency["library"]["dropLibraryCss"].ToString().Split(new char[] { ',' });
                    Array.Resize<string>(ref droplibrarycsslist, droplibrarycsslist.Length + splitCss.Length);
                    Array.Copy(splitCss, 0, droplibrarycsslist, droplibrarycsslist.Length, splitCss.Length);
                }
            }
            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand = null;
            // TODO: Consider moving the above code to core. Same for all impl.
            foreach (Dictionary<string, dynamic> dependency in librariesInUse.Values)
            {
                int dropcss = Array.Exists(droplibrarycsslist, dependency["library"]["'machineName"]) ? 1 : 0;
                //$DB->insert_record('hvp_contents_libraries', array(
                //    'hvp_id' => $contentid,
                //    'library_id' => $dependency['library']['libraryId'],
                //    'dependency_type' => $dependency['type'],
                //    'drop_css' => $dropcss,
                //    'weight' => $dependency['weight']

                m_SqlConnection = new SqlConnection(CONNECTION_STRING);
                m_SqlCommand = new SqlCommand(@"                
INSERT INTO [dbo].[hvp_contents_libraries]
           ([hvp_id]
           ,[library_id]
           ,[dependency_type]
           ,[drop_css]
           ,[weight])
     VALUES
           (@hvp_id
           ,@library_id
           ,@dependency_type
           ,@drop_css
           ,@weight); SELECT @thisId=SCOPE_IDENTITY() FROM hvp_contents_libraries;", m_SqlConnection);
                m_SqlCommand.CommandType = CommandType.Text;
                m_SqlCommand.Parameters.AddWithValue("@hvp_id", contentId);
                m_SqlCommand.Parameters.AddWithValue("@library_id", dependency["library"]["libraryId"]);
                m_SqlCommand.Parameters.AddWithValue("@dependency_type", dependency["type"]);
                m_SqlCommand.Parameters.AddWithValue("@drop_css", dropcss);
                m_SqlCommand.Parameters.AddWithValue("@weight", dependency["weight"]);
                SqlParameter returnParam = m_SqlCommand.Parameters.Add(new SqlParameter("@thisId", SqlDbType.Int));
                returnParam.Direction = ParameterDirection.Output;
                try
                {
                    m_SqlCommand.ExecuteScalar();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    m_SqlConnection.Close();
                }
            }
        }

        public void setErrorMessage(string message, string code = "")
        {
            if (message != "")
            {
                messages("error", message, code);
            }
        }

        public void setInfoMessage(string message)
        {
            if (message != "")
            {
                messages("info", message);
            }
        }

        public void setLibraryTutorialUrl(string machineName, string tutorialUrl)
        {
            //global $DB;
            //DB->execute("UPDATE {hvp_libraries} SET tutorial_url = ? WHERE machine_name = ?", array($url, $libraryname));
            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand = new SqlCommand("UPDATE hv_libraries SET tutorial_url=@tutorial_url WHERE machine_name=@machine_name", m_SqlConnection);
            m_SqlCommand.CommandType = CommandType.Text;
            m_SqlCommand.Parameters.AddWithValue("@tutorial_url", tutorialUrl);
            m_SqlCommand.Parameters.AddWithValue("@machine_name", machineName);
            try
            {
                m_SqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                m_SqlConnection.Close();
            }
        }

        public void setOption(string name, Dictionary<string, dynamic> value)
        {
            //set_config($name, $value, 'mod_hvp');
        }

        public void setOption(string name, string value)
        {
            //set_config($name, $value, 'mod_hvp');
        }

        Dictionary<string, dynamic> translationsmap;

        public string t(string message, Dictionary<string, dynamic> replacements = null)
        {
            if (translationsmap == null)
            {
                // Create mapping.
                // @codingStandardsIgnoreStart
                Dictionary<string, dynamic> translationsmap = new Dictionary<string, dynamic>();
                translationsmap.Add("Your PHP version does not support ZipArchive.", "noziparchive");
                translationsmap.Add("The file you uploaded is not a valid HTML5 Package (It does not have the .h5p file extension)", "noextension");
                translationsmap.Add("The file you uploaded is not a valid HTML5 Package (We are unable to unzip it)", "nounzip");
                translationsmap.Add("Could not parse the main h5p.json file", "noparse");
                translationsmap.Add("The main h5p.json file is not valid", "nojson");
                translationsmap.Add("Invalid content folder", "invalidcontentfolder");
                translationsmap.Add("Could not find or parse the content.json file", "nocontent");
                translationsmap.Add("Library directory name must match machineName or machineName-majorVersion.minorVersion (from library.json). (Directory: %directoryName , machineName: %machineName, majorVersion: %majorVersion, minorVersion: %minorVersion)", "librarydirectoryerror");
                translationsmap.Add("A valid content folder is missing", "missingcontentfolder");
                translationsmap.Add("A valid main h5p.json file is missing", "invalidmainjson");
                translationsmap.Add("Missing required library @library", "missinglibrary");
                translationsmap.Add("Note that the libraries may exist in the file you uploaded, but you're not allowed to upload new libraries. Contact the site administrator about this.", "missinguploadpermissions");
                translationsmap.Add("Invalid library name: %name", "invalidlibraryname");
                translationsmap.Add("Could not find library.json file with valid json format for library %name", "missinglibraryjson");
                translationsmap.Add("Invalid semantics.json file has been included in the library %name", "invalidsemanticsjson");
                translationsmap.Add("Invalid language file %file in library %library", "invalidlanguagefile");
                translationsmap.Add("Invalid language file %languageFile has been included in the library %name", "invalidlanguagefile2");
                translationsmap.Add("The file %file is missing from library: %name", "missinglibraryfile");
                translationsmap.Add("The system was unable to install the <em>%component</em> component from the package, it requires a newer version of the H5P plugin. This site is currently running version %current, whereas the required version is %required or higher. You should consider upgrading and then try again.", "missingcoreversion");
                translationsmap.Add("Invalid data provided for %property in %library. Boolean expected.", "invalidlibrarydataboolean");
                translationsmap.Add("Invalid data provided for %property in %library", "invalidlibrarydata");
                translationsmap.Add("Can't read the property %property in %library", "invalidlibraryproperty");
                translationsmap.Add("The required property %property is missing from %library", "missinglibraryproperty");
                translationsmap.Add("Illegal option %option in %library", "invalidlibraryoption");
                translationsmap.Add("Added %new new H5P library and updated %old old one.", "addedandupdatedss");
                translationsmap.Add("Added %new new H5P library and updated %old old ones.", "addedandupdatedsp");
                translationsmap.Add("Added %new new H5P libraries and updated %old old one.", "addedandupdatedps");
                translationsmap.Add("Added %new new H5P libraries and updated %old old ones.", "addedandupdatedpp");
                translationsmap.Add("Added %new new H5P library.", "addednewlibrary");
                translationsmap.Add("Added %new new H5P libraries.", "addednewlibraries");
                translationsmap.Add("Updated %old H5P library.", "updatedlibrary");
                translationsmap.Add("Updated %old H5P libraries.", "updatedlibraries");
                translationsmap.Add("Missing dependency @dep required by @lib.", "missingdependency");
                translationsmap.Add("Provided string is not valid according to regexp in semantics. (value: \"%value\"); regexp: \"%regexp\")", "invalidstring");
                translationsmap.Add("File %filename not allowed. Only files with the following extensions are allowed: %files-allowed.", "invalidfile");
                translationsmap.Add("Invalid selected option in multi-select.", "invalidmultiselectoption");
                translationsmap.Add("Invalid selected option in select.", "invalidselectoption");
                translationsmap.Add("H5P internal error: unknown content type @type in semantics. Removing content!", "invalidsemanticstype");
                translationsmap.Add("Copyright information", "copyrightinfo");
                translationsmap.Add("Title", "title");
                translationsmap.Add("Author", "author");
                translationsmap.Add("Year(s)", "years");
                translationsmap.Add("Year", "year");
                translationsmap.Add("Source", "source");
                translationsmap.Add("License", "license");
                translationsmap.Add("Undisclosed", "undisclosed");
                translationsmap.Add("Attribution 4.0", "attribution");
                translationsmap.Add("Attribution-ShareAlike 4.0", "attributionsa");
                translationsmap.Add("Attribution-NoDerivs 4.0", "attributionnd");
                translationsmap.Add("Attribution-NonCommercial 4.0", "attributionnc");
                translationsmap.Add("Attribution-NonCommercial-ShareAlike 4.0", "attributionncsa");
                translationsmap.Add("Attribution-NonCommercial-NoDerivs 4.0", "attributionncnd");
                translationsmap.Add("Attribution", "noversionattribution");
                translationsmap.Add("Attribution-ShareAlike", "noversionattributionsa");
                translationsmap.Add("Attribution-NoDerivs", "noversionattributionnd");
                translationsmap.Add("Attribution-NonCommercial", "noversionattributionnc");
                translationsmap.Add("Attribution-NonCommercial-ShareAlike", "noversionattributionncsa");
                translationsmap.Add("Attribution-NonCommercial-NoDerivs", "noversionattributionncnd");
                translationsmap.Add("General Public License v3", "gpl");
                translationsmap.Add("Public Domain", "pd");
                translationsmap.Add("Public Domain Dedication and Licence", "pddl");
                translationsmap.Add("Public Domain Mark", "pdm");
                translationsmap.Add("Copyright", "copyrightstring");
                translationsmap.Add("Unable to create directory.", "unabletocreatedir");
                translationsmap.Add("Unable to get field type.", "unabletogetfieldtype");
                translationsmap.Add("File type isn't allowed.", "filetypenotallowed");
                translationsmap.Add("Invalid field type.", "invalidfieldtype");
                translationsmap.Add("Invalid image file format. Use jpg, png or gif.", "invalidimageformat");
                translationsmap.Add("File is not an image.", "filenotimage");
                translationsmap.Add("Invalid audio file format. Use mp3 or wav.", "invalidaudioformat");
                translationsmap.Add("Invalid video file format. Use mp4 or webm.", "invalidvideoformat");
                translationsmap.Add("Could not save file.", "couldnotsave");
                translationsmap.Add("Could not copy file.", "couldnotcopy");
                translationsmap.Add("The mbstring PHP extension is not loaded. H5P need this to function properly", "missingmbstring");
                translationsmap.Add("The version of the H5P library %machineName used in this content is not valid. Content contains %contentLibrary, but it should be %semanticsLibrary.", "wrongversion");
                translationsmap.Add("The H5P library %library used in the content is not valid", "invalidlibrarynamed");
                translationsmap.Add("Your PHP version is outdated. H5P requires version 5.2 to function properly. Version 5.6 or later is recommended.", "oldphpversion");
                translationsmap.Add("Your PHP max upload size is quite small. With your current setup, you may not upload files larger than %number MB. This might be a problem when trying to upload H5Ps, images and videos. Please consider to increase it to more than 5MB.", "maxuploadsizetoosmall");
                translationsmap.Add("Your PHP max post size is quite small. With your current setup, you may not upload files larger than %number MB. This might be a problem when trying to upload H5Ps, images and videos. Please consider to increase it to more than 5MB", "maxpostsizetoosmall");
                translationsmap.Add("Your server does not have SSL enabled. SSL should be enabled to ensure a secure connection with the H5P hub.", "sslnotenabled");
                translationsmap.Add("H5P hub communication has been disabled because one or more H5P requirements failed.", "hubcommunicationdisabled");
                translationsmap.Add("When you have revised your server setup you may re-enable H5P hub communication in H5P Settings.", "reviseserversetupandretry");
                translationsmap.Add("A problem with the server write access was detected. Please make sure that your server can write to your data folder.", "nowriteaccess");
                translationsmap.Add("Your PHP max upload size is bigger than your max post size. This is known to cause issues in some installations.", "uploadsizelargerthanpostsize");
                translationsmap.Add("Library cache was successfully updated!", "ctcachesuccess");
                translationsmap.Add("No content types were received from the H5P Hub. Please try again later.", "ctcachenolibraries");
                translationsmap.Add("Couldn't communicate with the H5P Hub. Please try again later.", "ctcacheconnectionfailed");
                translationsmap.Add("The hub is disabled. You can re-enable it in the H5P settings.", "hubisdisabled");
                translationsmap.Add("File not found on server. Check file upload settings.", "filenotfoundonserver");
                translationsmap.Add("Invalid security token.", "invalidtoken");
                translationsmap.Add("No content type was specified.", "nocontenttype");
                translationsmap.Add("The chosen content type is invalid.", "invalidcontenttype");
                translationsmap.Add("You do not have permission to install content types. Contact the administrator of your site.", "installdenied");
                translationsmap.Add("You do not have permission to install content types.", "installdenied");
                translationsmap.Add("Validating h5p package failed.", "validatingh5pfailed");
                translationsmap.Add("Failed to download the requested H5P.", "failedtodownloadh5p");
                translationsmap.Add("A post message is required to access the given endpoint", "postmessagerequired");
                translationsmap.Add("Could not get posted H5P.", "invalidh5ppost");
                translationsmap.Add("Site could not be registered with the hub. Please contact your site administrator.", "sitecouldnotberegistered");
                translationsmap.Add("The H5P Hub has been disabled until this problem can be resolved. You may still upload libraries through the H5P Libraries page.", "hubisdisableduploadlibraries");
                translationsmap.Add("Your site was successfully registered with the H5P Hub.", "successfullyregisteredwithhub");
                translationsmap.Add("You have been provided a unique key that identifies you with the Hub when receiving new updates. The key is available for viewing in the H5P Settings page.", "sitekeyregistered");
                translationsmap.Add("Fullscreen", "fullscreen");
                translationsmap.Add("Disable fullscreen", "disablefullscreen");
                translationsmap.Add("Download", "download");
                translationsmap.Add("Rights of use", "copyright");
                translationsmap.Add("Embed", "embed");
                translationsmap.Add("Size", "size");
                translationsmap.Add("Show advanced", "showadvanced");
                translationsmap.Add("Hide advanced", "hideadvanced");
                translationsmap.Add("Include this script on your website if you want dynamic sizing of the embedded content:", "resizescript");
                translationsmap.Add("Close", "close");
                translationsmap.Add("Thumbnail", "thumbnail");
                translationsmap.Add("No copyright information available for this content.", "nocopyright");
                translationsmap.Add("Download this content as a H5P file.", "downloadtitle");
                translationsmap.Add("View copyright information for this content.", "copyrighttitle");
                translationsmap.Add("View the embed code for this content.", "embedtitle");
                translationsmap.Add("Visit H5P.org to check out more cool content.", "h5ptitle");
                translationsmap.Add("This content has changed since you last used it.", "contentchanged");
                translationsmap.Add("You'll be starting over.", "startingover");
                translationsmap.Add("by", "by");
                translationsmap.Add("Show more", "showmore");
                translationsmap.Add("Show less", "showless");
                translationsmap.Add("Sublevel", "sublevel");
                translationsmap.Add("Confirm action", "confirmdialogheader");
                translationsmap.Add("Please confirm that you wish to proceed. This action is not reversible.", "confirmdialogbody");
                translationsmap.Add("Cancel", "cancellabel");
                translationsmap.Add("Confirm", "confirmlabel");
                translationsmap.Add("4.0 International", "licenseCC40");
                translationsmap.Add("3.0 Unported", "licenseCC30");
                translationsmap.Add("2.5 Generic", "licenseCC25");
                translationsmap.Add("2.0 Generic", "licenseCC20");
                translationsmap.Add("1.0 Generic", "licenseCC10");
                translationsmap.Add("General Public License", "licenseGPL");
                translationsmap.Add("Version 3", "licenseV3");
                translationsmap.Add("Version 2", "licenseV2");
                translationsmap.Add("Version 1", "licenseV1");
                translationsmap.Add("CC0 1.0 Universal (CC0 1.0) Public Domain Dedication", "licenseCC010");
                translationsmap.Add("CC0 1.0 Universal", "licenseCC010U");
                translationsmap.Add("License Version", "licenseversion");

                // @codingStandardsIgnoreEnd
            }

            return get_string(translationsmap[message], "hvp", replacements);
        }

        public string get_string(string translation, string module, Dictionary<string, dynamic> replacements)
        {
            return "";
        }

        public void unlockDependencyStorage()
        {
            // Library development mode not supported.
        }

        public int updateContent(Dictionary<string, dynamic> content, int? contentMainId = null)
        {
            //global $DB;
            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand;
            if (content["disable"] != null)
            {
                content["disable"] = H5PCore.DISABLE_NONE;
            }

            Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
            data.Add("name", content["name"]);
            data.Add("course", content["course"]);
            data.Add("intro", content["intro"]);
            data.Add("introformat", content["introformat"]);
            data.Add("json_content", content["params"]);
            data.Add("embed_type", "div");
            data.Add("main_library_id", content["library"]["libraryId"]);
            data.Add("filtered", "");
            data.Add("disable", content["disable"]);
            data.Add("timemodified", DateTime.Now);

            int id;
            string eventtype;
            if (content["id"] != null)
            {
                data.Add("slug", "");
                data.Add("timecreated", data["timemodified"]);
                eventtype = "create";
                //id = $DB->insert_record("hvp", $data);
                m_SqlConnection = new SqlConnection(CONNECTION_STRING);
                m_SqlCommand = new SqlCommand(@"
                INSERT INTO [hvp]
           ([course]
           ,[name]
           ,[intro]
           ,[introformat]
           ,[json_content]
           ,[embed_type]
           ,[disable]
           ,[main_library_id]
           ,[content_type]
           ,[author]
           ,[license]
           ,[meta_keywords]
           ,[meta_description]
           ,[filtered]
           ,[slug]
           ,[timecreated]
           ,[timemodified])
     VALUES
           (@course
           ,@name
           ,@intro
           ,@introformat
           ,@json_content
           ,@embed_type
           ,@disable
           ,@main_library_id
           ,@content_type
           ,@author
           ,@license
           ,@meta_keywords
           ,@meta_description
           ,@filtered
           ,@slug
           ,@timecreated
           ,@timemodified; SELECT @thisId=SCOPE_IDENTITY() FROM hvp;", m_SqlConnection);
                m_SqlCommand.CommandType = CommandType.Text;
                m_SqlCommand.Parameters.AddWithValue("@course", data["course"]);
                m_SqlCommand.Parameters.AddWithValue("@name", data["name"]);
                m_SqlCommand.Parameters.AddWithValue("@intro", data["intro"]);
                m_SqlCommand.Parameters.AddWithValue("@introformat", data["introformat"]);
                m_SqlCommand.Parameters.AddWithValue("@json_content", data["json_content"]);
                m_SqlCommand.Parameters.AddWithValue("@embed_type", data["embed_type"]);
                m_SqlCommand.Parameters.AddWithValue("@disable", data["disable"]);
                m_SqlCommand.Parameters.AddWithValue("@main_library_id", data["main_library_id"]);
                m_SqlCommand.Parameters.AddWithValue("@content_type", data["content_type"]);
                m_SqlCommand.Parameters.AddWithValue("@author", data["author"]);
                m_SqlCommand.Parameters.AddWithValue("@license", data["license"]);
                m_SqlCommand.Parameters.AddWithValue("@meta_keywords", data["meta_keywords"]);
                m_SqlCommand.Parameters.AddWithValue("@meta_description", data["meta_description"]);
                m_SqlCommand.Parameters.AddWithValue("@filtered", data["filtered"]);
                m_SqlCommand.Parameters.AddWithValue("@slug", data["slug"]);
                m_SqlCommand.Parameters.AddWithValue("@timecreated", data["timecreated"]);
                m_SqlCommand.Parameters.AddWithValue("@timemodified", data["timemodified"]);
                SqlParameter returnParam = m_SqlCommand.Parameters.Add(new SqlParameter("@thisId", SqlDbType.Int));
                returnParam.Direction = ParameterDirection.Output;

                try
                {
                    m_SqlCommand.ExecuteScalar();
                    id = (int)m_SqlCommand.Parameters["@thisId"].Value;
                    if (data["id"] == null)
                        data.Add("id", id);
                    else
                        data["id"] = id;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    m_SqlConnection.Close();
                }
            }
            else
            {
                id = data["id"] = content["id"];
                m_SqlConnection = new SqlConnection(CONNECTION_STRING);
                m_SqlCommand = new SqlCommand(@"
                UPDATE[dbo].[hvp]
                   SET[course] = @course
                      ,[name] = @name
                      ,[intro] = @intro
                      ,[introformat] = @introformat
                      ,[json_content] = @json_content
                      ,[embed_type] = @embed_type
                      ,[disable] = @disable
                      ,[main_library_id] = @main_library_id
                      ,[content_type] = @content_type
                      ,[author] = @author
                      ,[license] = @license
                      ,[meta_keywords] = @meta_keywords
                      ,[meta_description] = @meta_description
                      ,[filtered] = @filtered
                      ,[slug] = @slug
                      ,[timecreated] = @timecreated
                      ,[timemodified] = @timemodified WHERE id=@id");
                m_SqlCommand.CommandType = CommandType.Text;
                m_SqlCommand.Parameters.AddWithValue("@course", data["course"]);
                m_SqlCommand.Parameters.AddWithValue("@name", data["name"]);
                m_SqlCommand.Parameters.AddWithValue("@intro", data["intro"]);
                m_SqlCommand.Parameters.AddWithValue("@introformat", data["introformat"]);
                m_SqlCommand.Parameters.AddWithValue("@json_content", data["json_content"]);
                m_SqlCommand.Parameters.AddWithValue("@embed_type", data["embed_type"]);
                m_SqlCommand.Parameters.AddWithValue("@disable", data["disable"]);
                m_SqlCommand.Parameters.AddWithValue("@main_library_id", data["main_library_id"]);
                m_SqlCommand.Parameters.AddWithValue("@content_type", data["content_type"]);
                m_SqlCommand.Parameters.AddWithValue("@author", data["author"]);
                m_SqlCommand.Parameters.AddWithValue("@license", data["license"]);
                m_SqlCommand.Parameters.AddWithValue("@meta_keywords", data["meta_keywords"]);
                m_SqlCommand.Parameters.AddWithValue("@meta_description", data["meta_description"]);
                m_SqlCommand.Parameters.AddWithValue("@filtered", data["filtered"]);
                m_SqlCommand.Parameters.AddWithValue("@slug", data["slug"]);
                m_SqlCommand.Parameters.AddWithValue("@timecreated", data["timecreated"]);
                m_SqlCommand.Parameters.AddWithValue("@timemodified", data["timemodified"]);
                m_SqlCommand.Parameters.AddWithValue("@id", data["id"]);
                try
                {
                    m_SqlCommand.ExecuteScalar();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    m_SqlConnection.Close();
                }
                eventtype = "update";
            }

            // Log content create/update/upload.
            if (!String.IsNullOrEmpty(content["uploaded"]))
            {
                eventtype += " upload";
            }

            var result = new Dictionary<string, dynamic>{
                { "content",eventtype}
                ,{ "id",content[""]["name"]}
                ,{ content["library"],"machineName"}
                ,{ "",content["library"]["majorVersion"]+"."+content ["library"]["minorVersion"]}
            };
            //    new \mod_hvp\event (
            //            "content", $eventtype,
            //        $id, $content ["name"],
            //        $content ["library"],["machineName"],
            //$content ["library"]["majorVersion"] . "." . $content ["library"]
            //["minorVersion"]
            //);

            return id;
        }

        public void updateContentFields(int id, Dictionary<string, dynamic> fields)
        {
            //global $DB;
            //$content = new \stdClass();
            //$content->id = $id;
            //foreach ($fields as $name => $value) {
            //$content->$name = $value;
            //}
            //$DB->update_record('hvp', $content);       
            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            String sUpdateSQL = string.Empty;
            sUpdateSQL = "UPDATE hvp SET ";
            foreach (var key in fields.Keys)
            {
                sUpdateSQL += key + "='" + fields[key] + "',";
            }
            sUpdateSQL = sUpdateSQL.Substring(0, sUpdateSQL.Length - 1);
            sUpdateSQL += " WHERE id=" + id;
            SqlCommand m_SqlCommand = new SqlCommand(sUpdateSQL);

            try
            {
                m_SqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                m_SqlConnection.Close();
            }
        }
    }
}