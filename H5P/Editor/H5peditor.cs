using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace H5P.Editor
{
    public class H5peditor : H5PEditorAjaxInterface
    {
        public const string CONNECTION_STRING = "User ID=sa;password=P@ssword;Initial Catalog=h5p;Data Source=(local);Packet Size=4096;TimeOut=0;";
        public object getLatestGlobalLibrariesData()
        {
            return null;
        }
        public void keepFile(int fileid) ////    public function keepFile($fileid)
        {////    {
         ////        global $DB;

            ////        // Remove from tmpfiles
            delete_records("hvp_tmpfiles", new Dictionary<string, dynamic> {
                { "id",fileid}
            }); ////        $DB->delete_records('hvp_tmpfiles', array(
            ////            'id' => $fileid
            ////        ));
        }////    }
        public void delete_records(string input1, Dictionary<string, dynamic> input2)
        {
            
        }

        public string has_capability(string input1, int input2)
        {
            return "";
        }
        public Dictionary<string,dynamic> getLibraries(Dictionary<string, dynamic> libraries = null)////    public function getLibraries($libraries = null)
        {////    {
         ////        global $DB;

            var context_id = required_param("contextId", PARAM_INT);////        $context_id = required_param('contextId', PARAM_RAW);
            var super_user = has_capability("mod/hvp:userestrictedlibraries", int.Parse(context.instance_by_id(context_id)));////        $super_user = has_capability('mod/hvp:userestrictedlibraries',
                                                                                                                  ////            \context::instance_by_id($context_id));

            if (libraries != null) ////        if ($libraries !== null) {
            {////            // Get details for the specified libraries only.

                var librarieswithdetails = new Dictionary<string, dynamic>(); ////            $librarieswithdetails = array();

                foreach (KeyValuePair<string, dynamic> library in libraries)////            foreach ($libraries as $library) {
                {////                // Look for library
                    var details = DB.get_record_sql(@" SELECT title,
                    runnable,
                    restricted,
                    tutorial_url
                    FROM { hvp_libraries}
                    WHERE machine_name = ?
                    AND major_version = ?
                    AND minor_version = ?
                    AND semantics IS NOT NULL
                    ", new Dictionary<string, dynamic> {
                        { library.Value, "name"},
                        { library.Value, "majorVersion" },
                        { library.Value, "minorVersion" }
                    });

                    ////                $details = $DB->get_record_sql(
                    ////                        "SELECT title,
                    ////                                runnable,
                    ////                                restricted,
                    ////                                tutorial_url
                    ////                           FROM { hvp_libraries}
                    ////                WHERE machine_name = ?
                    ////                  AND major_version = ?
                    ////                  AND minor_version = ?
                    ////                  AND semantics IS NOT NULL
                    ////                        ", array(
                    ////                            $library->name,
                    ////                            $library->majorVersion,
                    ////                            $library->minorVersion
                    ////                        )
                    ////                );
                    if (details != null)////                if ($details) {
                    {
                        ////                    // Library found, add details to list
                        library.Value["tutorialUrl"] = details["tutorialUrl"];////                    $library->tutorialUrl = $details->tutorial_url;
                        library.Value["title"] = details["title"];////                    $library->title = $details->title;
                        library.Value["runnable"] = details["runnable"];////                    $library->runnable = $details->runnable;
                        library.Value["restricted"] = super_user != null ? false : (details["restricted"] == "1" ? true : false);////$library->restricted = $super_user ? false : ($details->restricted === '1' ? true : false);
                                                                 ////                    $librarieswithdetails[] = $library;
                    }////                }
                }////            }

                ////            // Done, return list with library details
                ////            return $librarieswithdetails;
            } ////        }

            ////        // Load all libraries
            libraries = new Dictionary<string, dynamic>();////        $libraries = array();
            var librariesresult = DB.get_record_sql(@"SELECT id,
                                            machine_name AS name,
                                            title,
                                            major_version,
                                            minor_version,
                                            tutorial_url,
                                            restricted
                                       FROM { hvp_libraries}
            WHERE runnable = 1
                                        AND semantics IS NOT NULL
                                   ORDER BY title");////        $librariesresult = $DB->get_records_sql(
            ////                "SELECT id,
            ////                        machine_name AS name,
            ////                        title,
            ////                        major_version,
            ////                        minor_version,
            ////                        tutorial_url,
            ////                        restricted
            ////                   FROM { hvp_libraries}
            ////        WHERE runnable = 1
            ////                    AND semantics IS NOT NULL
            ////               ORDER BY title"
            ////        );
           foreach(KeyValuePair<string,dynamic> library in librariesresult) ////        foreach ($librariesresult as $library) {
            { ////            // Remove unique index
                library.Value["id"] = null;////            unset($library->id);

            ////            // Convert snakes to camels
            library.Value["majorVersion"] = (int) library.Value["major_version"];////            $library->majorVersion = (int) $library->major_version;
                library.Value["majorVersion"] = null;                                                             ////            unset($library->major_version);
                library.Value["minorVersion"] = (int)library.Value["minor_version"];                                                             ////            $library->minorVersion = (int) $library->minor_version;
                library.Value["minor_version"] = null;////            unset($library->minor_version);
                if (!((string)library.Value["tutorial_url"] == string.Empty))                                     ////            if (!empty($library->tutorial_url))
                {                                                                                                                                ////            {
                    library.Value["tutorialUrl"] = library.Value["tutorial_url"];////              $library->tutorialUrl = $library->tutorial_url;
                }                                                                                                                                 ////            }
                library.Value["tutorial_url"] = null;////            unset($library->tutorial_url);

                ////            // Make sure we only display the newest version of a library.
                foreach (KeyValuePair<string, dynamic> existinglibrary in libraries)////            foreach ($libraries as $key => $existinglibrary) {
                {
                    if (library.Value["name"] == existinglibrary.Value["name"])////                if ($library->name === $existinglibrary->name) {
                    { ////                    // Found library with same name, check versions
                        if ((library.Value["majorVersion"] == existinglibrary.Value["majorVersion"] && library.Value["minorVersion"] > existinglibrary.Value["minorVersion"]) || (library.Value["majorVersion"] > existinglibrary.Value["majorVersion"]))///                    if (( $library->majorVersion === $existinglibrary->majorVersion &&
                        {  ////                           $library->minorVersion > $existinglibrary->minorVersion ) ||
                            ////                         ( $library->majorVersion > $existinglibrary->majorVersion ) ) {
                            ////                        // This is a newer version
                            existinglibrary.Value["isOld"] = true;


                            ////                        $existinglibrary->isOld = true;
                        }////                    }
                        else////                    else {
                        {////                        // This is an older version
                            library.Value["isOld"] = true; ////                        $library->isOld = true;
                        }////                    }
                    } ////                }
                }////            }

                ////            // Check to see if content type should be restricted
                ////            $library->restricted = $super_user ? false : ($library->restricted === '1' ? true : false);

                ////            // Add new library
                ////            $libraries[] = $library;
            }////        }
                return libraries;////        return $libraries;
        } ////    }

        ////    /**
        ////     * Allow for other plugins to decide which styles and scripts are attached.
        ////     * This is useful for adding and/or modifing the functionality and look of
        ////     * the content types.
        ////     *
        ////     * @param array $files
        ////     *  List of files as objects with path and version as properties
        ////     * @param array $libraries
        ////     *  List of libraries indexed by machineName with objects as values. The objects
        ////     *  have majorVersion and minorVersion as properties.
        ////     */
        public string PAGE = null;
        public const int PARAM_INT = 0;
        public void alterLibraryFiles(string files, Dictionary<string,dynamic> libraries)////    public function alterLibraryFiles(&$files, $libraries)
        {////    {
         ////        global $PAGE;

            ////      // Refactor dependency list
           var libraryList = new Dictionary<string, dynamic> ();////      $libraryList = array();

            foreach (KeyValuePair<string, dynamic> dependency in libraries)////        foreach ($libraries as $dependency) {
            {
                libraryList[dependency.Value["machineName"]] = new Dictionary<string, dynamic> {
                    {"majorVersion", dependency.Value["majorVersion"] },
                    { "minorVersion", dependency.Value["minorVersion"]}
                };////        $libraryList[$dependency['machineName']] = array(
             ////          'majorVersion' => $dependency['majorVersion'],
             ////          'minorVersion' => $dependency['minorVersion']
             ////        );
            } ////        }

            var contextId = required_param("contextId", PARAM_INT);////      $contextId = required_param('contextId', PARAM_INT);
            context.instance_by_id(contextId);////      $context = \context::instance_by_id($contextId);

            ////      $PAGE->set_context($context);
            ////      $renderer = $PAGE->get_renderer('mod_hvp');

            ////      $embedType = 'editor';
            ////      $renderer->hvp_alter_scripts($files['scripts'], $libraryList, $embedType);
            ////      $renderer->hvp_alter_styles($files['styles'], $libraryList, $embedType);
        }////    }
        public int required_param(string inputId, int param)
        {
            return 0;
        }
        ////    /**
        ////     * Saves a file or moves it temporarily. This is often necessary in order to
        ////     * validate and store uploaded or fetched H5Ps.
        ////     *
        ////     * @param string $data Uri of data that should be saved as a temporary file
        ////     * @param boolean $move_file Can be set to TRUE to move the data instead of saving it
        ////     *
        ////     * @return bool|object Returns false if saving failed or an object with path
        ////     * of the directory and file that is temporarily saved
        ////     */
        public static void move_uploaded_file(string input1, string input2)
        {

        }
        public static void file_put_contents(string input1, string input2)
        {

        }
        public const string DIRECTORY_SEPARATOR = "";
        public static Dictionary<string,dynamic> saveFileTemporarily(string data, bool move_file = false)////    public static function saveFileTemporarily($data, $move_file = FALSE)
        {////    {
         ////        global $CFG;
        
            ////        // Generate local tmp file path
            var unique_h5p_id = Guid.NewGuid();  ////        $unique_h5p_id = uniqid('hvp-');
            var file_name = unique_h5p_id + ".h5p";////        $file_name = $unique_h5p_id. '.h5p';
            var directory = CFG.tempdir + DIRECTORY_SEPARATOR + unique_h5p_id;////        $directory = $CFG->tempdir.DIRECTORY_SEPARATOR. $unique_h5p_id;
            var file_path = directory + DIRECTORY_SEPARATOR + file_name;////        $file_path = $directory.DIRECTORY_SEPARATOR. $file_name;

            if (!(File.Exists(directory)))////        if (!is_dir($directory))
            {////        {
                File.Create(directory,0777,FileOptions.WriteThrough);////            mkdir($directory, 0777, true);
            }           ////        }

            ////        // Move file or save data to new file so core can validate H5P
            if (move_file)
            {////        if ($move_file) {
                move_uploaded_file(data, file_path);////            move_uploaded_file($data, $file_path);
            }////        }
            else
            {////        else {
                file_put_contents(file_path, data); ////            file_put_contents($file_path, $data);
            }////        }

            ////        // Add folder and file paths to H5P Core
            ////        $interface = framework::instance('interface');
            ////        $interface->getUploadedH5pFolderPath($directory);
            ////        $interface->getUploadedH5pPath($directory.DIRECTORY_SEPARATOR. $file_name);

            return new Dictionary<string, dynamic> {
                { "dir",directory},
                { "fileName",file_name}
            };////        return (object) array(
            ////            'dir' => $directory,
            ////            'fileName' => $file_name
            ////        );
        } ////    }

        ////    /**
        ////     * Marks a file for later cleanup, useful when files are not instantly cleaned
        ////     * up. E.g. for files that are uploaded through the editor.
        ////     *
        ////     * @param int $file Id of file that should be cleaned up
        ////     * @param int|null $content_id Content id of file
        ////     */
        public static void markFileForCleanup(string file, int content_id = 0)////    public static function markFileForCleanup($file, $content_id = null)
        { ////    {
          ////        global $DB;

            ////        // Let H5P Core clean up
            if (content_id == 0)   ////        if ($content_id) {
            {
                return;////            return;
            }////        }

            ////        // Track temporary files for later cleanup
            insert_record_raw("hvp_tmpfiles", new Dictionary<string, dynamic> { { "id", file} },false,false,true);////        $DB->insert_record_raw('hvp_tmpfiles', array(
            ////            'id' => $file
            ////        ), false, false, true);
        }////    }
        public static void insert_record_raw(string input1, Dictionary<string, dynamic> input2,bool input3, bool input4, bool input5)
        {

        }
        ////    /**
        ////     * Clean up temporary files
        ////     *
        ////     * @param string $filePath Path to file or directory
        ////     */
        public static void removeTemporarilySavedFiles(string filePath)////    public static function removeTemporarilySavedFiles($filePath)
        {////    {
            if (File.Exists(filePath))////        if (is_dir($filePath))
            {////        {
                H5PCore.deleteFileTree(filePath);////            \H5PCore::deleteFileTree($filePath);
            }////        }
            else////        else
            {////        {
               unlink(filePath);////            @unlink($filePath);
            }////        }
        }////    }
        ////}
        public static bool unlink(string filePath)
        {
            return true;
        }

        public string[] getAuthorsRecentlyUsedLibraries()
        {
            throw new System.NotImplementedException();
        }

        public string getContentTypeCache(string machineName = null)
        {
            throw new System.NotImplementedException();
        }

        public string[] getLatestLibraryVersions()
        {
            throw new System.NotImplementedException();
        }


        public bool validateEditorToken(string token)
        {
            throw new System.NotImplementedException();
        }

        public string getLanguage(string name, string major, string minor, string lang)////    public function getLanguage($name, $major, $minor, $lang)
        { ////    {
          ////        global $DB;

            ////        // Load translation field from DB

            //        var result  = DB.get_field_sql(@"SELECT hlt.language_json
            //                       FROM { hvp_libraries_languages}
            //        hlt
            //JOIN { hvp_libraries}
            //        hl ON hl.id = hlt.library_id
            //                      WHERE hl.machine_name = ?
            //                        AND hl.major_version = ?
            //                        AND hl.minor_version = ?
            //                        AND hlt.language_code = ?
            //                    ", new Dictionary<string, dynamic> {
            //                            { "", "name"}
            //                            ,{ "","major"}
            //                            ,{ "","minor"}
            //                            ,{ "","lang"}

            //        });
            //return result;
            SqlConnection m_SqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand m_SqlCommand = new SqlCommand();
            string result = string.Empty;
            try
            {
                var dict = new Dictionary<string, dynamic> {
                    { "name", "name"}
                    ,{ "major","major"}
                    ,{ "minor","minor"}
                    ,{ "lang","lang"}
                };
                foreach (KeyValuePair<string, dynamic> s in dict)
                {
                    m_SqlCommand.CommandText = @"select * from hvp_libraries_languages hlt " +
                                                "left join hvp_libraries hl on hl.id = hlt.library_id "
                                                + "WHERE hl.machine_name = " + s.Value["name"]
                                    + "AND hl.major_version = " + s.Value["major"]
                                    + "AND hl.minor_version = " + s.Value["minor"]
                                    + "AND hlt.language_code = " + s.Value["lang"];
                }
                SqlDataReader m_SqlDataReader = m_SqlCommand.ExecuteReader();
                // Get 1st Row - true if record found -------------
                if (m_SqlDataReader.Read())
                {
                     result =  (string)m_SqlDataReader["lang"];
                }
                else
                {
                    return string.Empty;
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

            return result;

            ////        return $DB->get_field_sql(
            ////            "SELECT hlt.language_json
            ////               FROM { hvp_libraries_languages}
            ////        hlt
            ////JOIN { hvp_libraries}
            ////        hl ON hl.id = hlt.library_id
            ////              WHERE hl.machine_name = ?
            ////                AND hl.major_version = ?
            ////                AND hl.minor_version = ?
            ////                AND hlt.language_code = ?
            ////            ", array(
            ////                $name,
            ////                $major,
            ////                $minor,
            ////                $lang
            ////            )
            ////        );
        }////    }




       
    }
}