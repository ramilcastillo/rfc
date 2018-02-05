using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5P.Editor
{
    public class H5PEditorAjax: H5PEditorEndpoints
    {
        public H5PFrameworkInterface h5pF;
        private H5P.H5PCore core;
        private H5peditor editor;
        private H5peditorStorage storage;
        public H5peditorFile file;
        private H5PEditorAjax(H5P.H5PCore H5PCore, H5peditor H5PEditor, H5peditorStorage H5PEditorStorage)
        {
            this.core = H5PCore;
            this.editor = H5PEditor;
            this.storage = H5PEditorStorage;
            
        }
        public void action(string endpoint)
        {
            var token = new string[1];
            var uploadPath = new string[2];
            var contentId = new string[3];
            switch (endpoint)
            {
                case H5PEditorEndpoints.LIBRARIES:
                    H5PCore.ajaxSuccess(this.editor.getLibraries(), true);
                    break;
                case H5PEditorEndpoints.SINGLE_LIBRARY:
                    //$args = func_get_args();
                    //array_shift($args);
                    //$library = call_user_func_array(
                    //array($this->editor, 'getLibraryData'), $args
                    //);
                    Dictionary<string,dynamic> library = null; //Temporary declaration
                    H5PCore.ajaxSuccess(library, true);
                  
                    break;
                case H5PEditorEndpoints.CONTENT_TYPE_CACHE:
                    if (!this.isHubOn()) return;
                    H5PCore.ajaxSuccess(this.getContentTypeCache(!this.isContentTypeCacheUpdated()),true);
                    break;
                case H5PEditorEndpoints.LIBRARY_INSTALL:
                    if (!this.isPostRequest()) return;

                    if (!this.isValidEditorToken(token)) return;

                    var machineName = new string[2];
                    this.libraryInstall(machineName);
                    break;
                case H5PEditorEndpoints.LIBRARY_UPLOAD:
                    if (!this.isPostRequest()) return;

                    token = new string[1];
                    uploadPath = new string[2];
                    contentId = new string[3];
                    if (!this.isValidEditorToken(token)) return;

                    this.libraryUpload(uploadPath,contentId);
                    break;
                case H5PEditorEndpoints.FILES:
                    token = new string[1];
                    contentId = new string[2];
                    this.libraryUpload(uploadPath, contentId);
                    break;
                
            }

        }

        public bool callHubEndpoint(string endpoint)
        {
            var path = this.core.getUploadedH5pPath();
            var response = this.core.fetchExternalData(H5PHubEndpoints.createURL(endpoint), null, true, string.IsNullOrEmpty(path) ? null : path);

            if (!response)
            {
                H5PCore.ajaxError(this.core.t("Failed to download the requested H5P"),"DOWNLOAD_FAILED",null, this.core.getMessages("error"));
                return false;
            }
            return true;
        }
        public void fileUpload(int contentId = 0)
        {
            file = new H5peditorFile(this.core.h5pF);
            if (!file.isLoaded())
            {
                H5PCore.ajaxError(this.core.t("File not found on server. Check file upload settings."));
                return;
            }

            if (file.validate())
            {
                var file_id = this.core.saveFile(file,0);
                this.storage.markFileForCleanup(file_id);
            }

            file.printResult();
        }

        public void libraryUpload(string[] uploadFilePath, string[] contentId)
        {
            if (uploadFilePath != null)
            {
                H5PCore.ajaxError(this.core.t("Could not get posted H5P."), "NO_CONTENT_TYPE", 0);
                return;
            }

            var file = this.saveFileTemporarily(uploadFilePath, true);

            if (!file)
                return;

            if (!this.isValidPackage()) return;

            var storage = new H5PStorage(h5pF,core);
            storage.savePackage(null, null, true);

            var content = this.core.moveContentDirectory(this.getUploadedH5pFolderPath(),contentId);

            this.storage.removeTemporarilySavedFiles(this.core.getUploadedH5pFolderPath());

            Dictionary<string,dynamic> ht = new Dictionary<string,dynamic>();
            ht.Add("h5p", content.h5pJson());
            ht.Add("content", content.contentJson());
            ht.Add("contentTypes", this.getContentTypeCache());
            H5PCore.ajaxSuccess(ht);
        }

        public string[] getUploadedH5pFolderPath()
        {
            string[] result = new string[2];

            return result; 
        }
        public bool isValidPackage(bool skipContent = false)
        {
            var validator = new H5PValidator(this.h5pF,this.core);
            if (!validator.isValidPackage(skipContent, false))
            {
                this.storage.removeTemporarilySavedFiles(this.core.getUploadedH5pPath());

                H5PCore.ajaxError(this.core.t("Validating h5p package failed."),"VALIDATION_FAILED", null, this.core.getMessages("Error"));
                return false;
            }
            return true;
        }
        public bool saveFileTemporarily(string[] data, bool move_file = false)
        {
            var file = this.storage.saveFileTemporarily(data, move_file);

            if (!file)
            {
                H5PCore.ajaxError(this.core.t("Failed to download the requested H5P."),"DOWNLOAD_FAILED",0);
                return false;

            }
            return file;
        }
        public void libraryInstall(string[] machineName)
        {
            if (machineName != null)
            {
                H5PCore.ajaxError(this.core.t("No content type was specified."),"NO_CONTENT_TYPE",0);
                return;
            }
        }

        public bool isValidToken;

        public bool isValidEditorToken(string[] token)
        {
            isValidToken = this.editor.validateEditorToken(token[0]);

            if(!isValidToken)
            {
                H5PCore.ajaxError(this.core.t("Invalid security token"),"INVALID_TOKEN",0);
                return false;
            }
            return true;
        }
        public bool isHubOn()
        {
            if (!this.core.getOption("hub_is_enabled", true))
            {
                H5PCore.ajaxError(this.core.t("The hub is disabled. You can enable it in the H5P settings"), "HUB_DISABLED", 403);
                return false;
            }
            return true;
        }

        public bool isPostRequest()
        {
            var _SERVER = new Dictionary<string,dynamic>();
            _SERVER.Add("REQUEST_METHOD", "POST");
            if (_SERVER["REQUEST_METHOD"] != "POST")
            {
                H5PCore.ajaxError(this.core.t("A post message is required to access the given endpoint"), "REQUIRES_POST", 405);
                return false;
            }
            return true;

        }
        public Dictionary<string,dynamic> getContentTypeCache(bool cacheOutdated = false)
        {
            var canUpdateOrInstall = this.core.hasPermission(H5PPermission.INSTALL_RECOMMENDED == 0 ? 0 : -1) || this.core.hasPermission(H5PPermission.UPDATE_LIBRARIES);
            Dictionary<string,dynamic> ht = new Dictionary<string,dynamic>();
            ht.Add("outdated", cacheOutdated && canUpdateOrInstall);
            ht.Add("libraries", this.editor.getLatestGlobalLibrariesData());
            ht.Add("recentlyUsed", this.editor.getAuthorsRecentlyUsedLibraries());
            ht.Add("apiVersion", "");
            ht.Add("details",this.core.getMessages("info"));

            //var result = new ContentTypeCache {
            //    outdated = cacheOutdated && canUpdateOrInstall,
            //    libraries = this.editor.getLatestGlobalLibrariesData(),
            //    recentlyUsed = this.editor.getAuthorsRecentlyUsedLibraries(),
            //    apiVersion = new H5PCore { major = "", minor = "" },
            //    details = this.core.getMessages("info")
            //};

            return ht;
           
        }

        public bool isContentTypeCacheUpdated()
        {
            var ct_cache_last_update = this.core.getOption("content_type_cache_updated_at", false);
            var outdated_cache = (60 * 60 * 24 * 7);  //+ ct_cache_last_update 1 week

            if (DateTime.Now.Minute > outdated_cache)
            {
                var success = this.core.updateContentTypeCache();
                if (!success)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
