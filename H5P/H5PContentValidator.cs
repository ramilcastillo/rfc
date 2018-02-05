using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static H5P.H5PExport;

namespace H5P
{
    /**
* voids for validating basic types from H5P library semantics.
* @property bool allowedStyles
*/
    public class H5PContentValidator
    {
        public H5PFrameworkInterface h5pF;
        public H5PCore h5pC;
        private object nextWeight;
        Dictionary<string, dynamic> typeMap, libraries, dependencies, library;
        public string value = String.Empty;
        public object ENT_QUOTES = null;
        bool allowedStyles;

        private static string[] allowed_styleable_tags = new string[] { "span", "p", "div", "h1", "h2", "h3", "td" };
        /**
         * Constructor for the H5PContentValidator
         *
         * @param object H5PFramework
         *  The frameworks implementation of the H5PFrameworkInterface
         * @param object H5PCore
         *  The main H5PCore instance
         */
        public H5PContentValidator(H5PFrameworkInterface H5PFramework, H5PCore _H5PCore)
        {
            this.h5pF = H5PFramework;
            this.h5pC = _H5PCore;
            var tm = new Dictionary<string, dynamic>();
            tm.Add("text", "validateText");
            tm.Add("number", "validateNumber");
            tm.Add("boolean", "validateBoolean");
            tm.Add("list", "validateList");
            tm.Add("group", "validateGroup");
            tm.Add("file", "validateFile");
            tm.Add("image", "validateImage");
            tm.Add("video", "validateVideo");
            tm.Add("audio", "validateAudio");
            tm.Add("select", "validateSelect");
            tm.Add("library", "validateLibrary");
            this.typeMap = tm;

            this.nextWeight = 1;
            // Keep track of the libraries we load to avoid loading it multiple times.
            this.libraries = new Dictionary<string, dynamic>();
            // Keep track of all dependencies for the given content.
            this.dependencies = new Dictionary<string, dynamic>();
        }
        /**
         * Get the flat dependency tree.
         *
         * @return array
         */
        public Dictionary<string, dynamic> getDependencies()
        {

            return this.dependencies;
        }
        /**
         * Validate given text value against text semantics.
         * @param text
         * @param semantics
         */
        public void validateText(ref string text, Dictionary<string, Dictionary<string, dynamic>> semantics)
        {
            semantics["tags"] = new Dictionary<string, dynamic>();
            if (String.IsNullOrEmpty(text))
            {
                text = "";
            }
            if (semantics["tags"] != null)
            {
                // Not testing for empty array allows us to use the 4 defaults without
                // specifying them in semantics.
                string[] tags = new string[] { "div", "span", "p", "br" };

                tags.Concat((IEnumerable<string>)semantics["tags"]).ToArray();
                // Add related tags for table etc.
                if (tags.Contains("table"))
                {
                    tags = tags.Concat(new string[] { "tr", "td", "th", "colgroup", "thead", "tbody", "tfoot" }).ToArray();
                }
                if (tags.Contains("b") && !tags.Contains("strong"))
                {
                    tags.Concat(new string[] { "strong" }).ToArray();
                }
                if (tags.Contains("i") && !tags.Contains("em"))
                {
                    tags.Concat(new string[] { "em" });
                }
                if (tags.Contains("ul") || tags.Contains("ol") && !tags.Contains("li"))
                {
                    tags.Concat(new string[] { "li" });
                }
                if (tags.Contains("del") || tags.Contains("strike") && !tags.Contains("s"))
                {
                    tags.Concat(new string[] { "s" });
                }
                // Determine allowed style tags
                //string[] stylePatterns;
                Regex stylePatterns;
                // All styles must be start to end patterns (^...)
                if (semantics["font"] != null)
                {
                    if (semantics["font"] != null)//if (semantics["font"]!=null) {
                    {
                        stylePatterns = new Regex(@"/^font-size: *[0-9.]+(em|px|%) *;?/i");//stylePatterns = new string[] { "/^font-size: *[0-9.]+(em|px|%) *;?/i" };

                    }//}
                    if (semantics["font"]["family"] != null)//if (semantics["font"]["family"]) && semantics.font.family) {
                    {
                        stylePatterns = new Regex(@"/^font-family: *[-a-z0-9,'']+;?/ i");//stylePatterns = new string[] {@"/^font-family: *[-a-z0-9," ]+;?/ i"};
                    }//}
                    if (semantics["font"]["color"] != null)//if (isset(semantics.font.color) && semantics.font.color) {
                    {
                        stylePatterns = new Regex(@"/^color: *(#[a-f0-9]{3}[a-f0-9]{3}?|rgba?\([0-9, ]+\)) *;?/i");//stylePatterns[] = "/^color: *(#[a-f0-9]{3}[a-f0-9]{3}?|rgba?\([0-9, ]+\)) *;?/i";
                    }//}
                    if (semantics["font"]["background"] != null)//if (isset(semantics.font.background) && semantics.font.background) {
                    {
                        stylePatterns = new Regex(@"/^background-color: *(#[a-f0-9]{3}[a-f0-9]{3}?|rgba?\([0-9, ]+\)) *;?/i");//stylePatterns[] = "/^background-color: *(#[a-f0-9]{3}[a-f0-9]{3}?|rgba?\([0-9, ]+\)) *;?/i";
                    }//}

                    if (semantics["font"]["spacing"] != null) //if (isset(semantics.font.spacing) && semantics.font.spacing) {
                    {
                        stylePatterns = new Regex(@"/^letter-spacing: *[0-9.]+(em|px|%) *;?/i");//stylePatterns[] = "/^letter-spacing: *[0-9.]+(em|px|%) *;?/i";
                    } //}

                    if (semantics["font"]["height"] != null)//if (isset(semantics.font.height) && semantics.font.height) {
                    {
                        stylePatterns = new Regex(@"/^line-height: *[0-9.]+(em|px|%|) *;?/i");//stylePatterns[] = "/^line-height: *[0-9.]+(em|px|%|) *;?/i";
                    }//}

                }//}

                //// Alignment is allowed for all wysiwyg texts
                stylePatterns = new Regex(@"/^text-align: *(center|left|right);?/i");//stylePatterns[] = "/^text-align: *(center|left|right);?/i";
                                                                                     //// Strip invalid HTML tags.
                text = this.filter_xss(text, tags, stylePatterns);//text = this.filter_xss(text, tags, stylePatterns);
            }//}
            else                                         //else
            {                        //{
                                     //// Filter text to plain text.
                                     //text = htmlspecialchars(text, ENT_QUOTES, "UTF-8", false);
            } //}
              //// Check if string is within allowed length
            if (!(semantics["maxLength"] != null))                                                                   //if (isset(semantics.maxLength))
            {                                //{
                if (!(extension_loaded("mbstring")))                                                                        //if (!extension_loaded("mbstring"))
                {                                                  //{
                    this.h5pF.setErrorMessage(this.h5pF.t("The mbstring PHP extension is not loaded. H5P need this to void properly"), "mbstring-unsupported");                                 //this.h5pF.setErrorMessage(this.h5pF.t("The mbstring PHP extension is not loaded. H5P need this to void properly"), "mbstring-unsupported");
                }                                                           //}
                else          //else
                {    //{
                    text = text.Substring(0, (semantics["maxLength"]).ToString().Length);//text = mb_substr(text, 0, semantics.maxLength);
                }                                                         //}
            }                                      //}
                                                   //// Check if string is according to optional regexp in semantics
            if (!(text == "" && (semantics["optional"] != null) && string.IsNullOrEmpty(semantics["optional"].ToString())) && (semantics["regexp"] != null))
            {  //if (!(text === "" && isset(semantics.optional) && semantics.optional) && isset(semantics.regexp)) {
               //// Escaping "/" found in patterns, so that it does not break regexp fencing.
                var pattern = semantics["regexp.pattern"].ToString().Replace("/", "\\/");//pattern = "/".str_replace("/", "\\/", semantics.regexp.pattern). "/";
                pattern += (semantics["regexp.modifiers"] != null ? semantics["regexp.modifiers"].ToString() : String.Empty);// //pattern.= isset(semantics.regexp.modifiers) ? semantics.regexp.modifiers : "";
                if (preg_match(new Regex(pattern), new Dictionary<string, dynamic> { { "", text } }) == true)//if (preg_match(pattern, text) === 0)
                {//{
                 //// Note: explicitly ignore return value false, to avoid removing text
                 //// if regexp is invalid...
                    this.h5pF.setErrorMessage(this.h5pF.t("Provided string is not valid according to regexp in semantics. (value: " + "%value" + ", regexp: " + "%regexp), array(" + "%value => text, " + "%regexp => pattern))"));//this.h5pF.setErrorMessage(this.h5pF.t("Provided string is not valid according to regexp in semantics. (value: " % value", regexp: " % regexp")", array("%value" => text, "%regexp" => pattern)), "semantics-invalid-according-regexp");
                                                                                                                                                                                                                                   //text = "";
                }
            }                                                            //}


        }
        public string filter_xss(string input1, string[] input2, Regex regex)
        {
            return "";
        }
        /**
         * Validates content files
         *
         * @param string contentPath
         *  The path containing content files to validate.
         * @param bool isLibrary
         * @return bool TRUE if all files are valid
         * TRUE if all files are valid
         * false if one or more files fail validation. Error message should be set accordingly by validator.
         */

        public bool validateContentFiles(string contentPath, bool isLibrary = false)
        {
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
        }
        /**
         * Validate given value against number semantics
         * @param number
         * @param semantics
         */
        public bool extension_loaded(string input)
        {
            return true;
        }
        public bool preg_match(Regex pattern, Dictionary<string,dynamic> subject)
        {
            return true;
        }
        public bool preg_match(Regex pattern, Dictionary<string,dynamic> subject, string[] matches)
        {
            return true;
        }
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
        /**
         * Validate given value against boolean semantics
         * @param bool
         * @return bool
         */
        bool validateBoolean(object _bool)
        {
            return Convert.ToBoolean(_bool);
        }
        /**
         * Validate select values
         * @param select
         * @param semantics
         */
        void validateSelect(ref string[] select, Dictionary<string, dynamic> semantics)
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
        /**
         * Validate given list value against list semantics.
         * Will recurse into validating each item in the list according to the type.
         * @param list
         * @param semantics
         */
        public string htmlspecialchars(string input, object flags, string character_set, bool double_encode)
        {
            return "";
        }
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
        /**
         * Validate a file like object, such as video, image, audio and file.
         * @param file
         * @param semantics
         * @param array int? typeValidKeys
         */
        public Dictionary<string, dynamic> array_merge(Dictionary<string, dynamic> array1, Dictionary<string,dynamic> array2)
        {

            return null;
        }
        private void _validateFilelike(Dictionary<string, dynamic> file, Dictionary<string, dynamic> semantics, Dictionary<string,dynamic> typeValidKeys)
        {
            //// Do not allow to use files from other content folders.
            string[] matches = null;//matches = array();

            if (preg_match(this.h5pC.relativePathRegExp, file, matches))//if (preg_match(this.h5pC.relativePathRegExp, file.path, matches))
            {// {
                file["path"] = matches[5];//  file.path = matches[5];
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
                    this.filterParams(file["quality"], new string[] { "level", "label" });//    this.filterParams(file.quality, array("level", "label"));
                    file["quality.level"] = Convert.ToInt32(file["quantity.level"]);//    file.quality.level = intval(file.quality.level);
                    file["quality.label"] = htmlspecialchars(file["quality.label"], ENT_QUOTES, "UTF-8", false);//    file.quality.label = htmlspecialchars(file.quality.label, ENT_QUOTES, "UTF-8", false);
                }//  }
            }//}
            if (file["copyright"])//if (isset(file.copyright))
            { // {
                this.validateGroup(file["copyright"], this.getCopyrightSemantics(), false); //  this.validateGroup(file.copyright, this.getCopyrightSemantics());
            }
        }//}

        /**
         * Validate given file data
         * @param file
         * @param semantics
         */
        public void filterParams(Dictionary<string, dynamic> input1, string[] input2)
        {

        }
        public void validateFile(Dictionary<string, dynamic> file, Dictionary<string, dynamic> semantics)
        {
            this._validateFilelike(file, semantics, null);
        }
        /**
         * Validate given image data
         * @param image
         * @param semantics
         */
        public void validateImage(Dictionary<string, dynamic> image, Dictionary<string, dynamic> semantics)
        {
            this._validateFilelike(image, semantics, new Dictionary<string, dynamic>{ { "0", "width" }, { "1", "height" }, { "2", "originalImage" } });
        }
        /**
         * Validate given video data
         * @param video
         * @param semantics
         */
        public void validateVideo(object video, Dictionary<string, dynamic> semantics)
        {
            foreach (Dictionary<string, dynamic> v in (List<object>)video)
            {
                this._validateFilelike(v, semantics, new Dictionary<string, dynamic>{ { "0", "width" }, { "1", "height" }, { "2", "codecs" }, { "3", "quality" } });
            }
        }
        /**
         * Validate given audio data
         * @param audio
         * @param semantics
         */
        public void validateAudio(object audio, Dictionary<string, dynamic> semantics)
        {
            foreach (Dictionary<string, dynamic> a in (List<object>)audio)
            {
                this._validateFilelike(a, semantics, null);
            }
        }
        /**
         * Validate given group value against group semantics.
         * Will recurse into validating each group member.
         * @param group
         * @param semantics
         * @param bool flatten
         */
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

        /**
         * Validate given library value against library semantics.
         * Check if provided library is within allowed options.
         *
         * Will recurse into validating the library"s semantics too.
         * @param value
         * @param semantics
         */
        public bool property_exists(Dictionary<string, dynamic> input1, string input2)
        {
            return true;
        }
        public bool in_array(string input1, Dictionary<string, dynamic> input2)
        {
            return true;
        }
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

        /**
         * Check params for a whitelist of allowed properties
         *
         * @param array/object params
         * @param array whitelist
         */
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
        private string filter_xss(Dictionary<string, dynamic> allowed_tags, bool allowedStyles) //private void filter_xss(string, allowed_tags = array("a", "em", "strong", "cite", "blockquote", "code", "ul", "ol", "li", "dl", "dt", "dd"), allowedStyles = false) {
        {
            string _string = null;
            if (_string.Length == 0)//  if (strlen(string) == 0) {
            {
                return _string;//    return string;
            }//  }
            //  // Only operate on valid UTF-8 strings. This is necessary to prevent cross
            //  // site scripting issues on Internet Explorer 6. (Line copied from
            //  // drupal_validate_utf8)
            if (preg_match(new Regex(@"/^./us"), new Dictionary<string, dynamic> { { "", _string } }) != true)//  if (preg_match(, string) != 1) {
            {
                return "";//    return "";
            }//  }
            this.allowedStyles = allowedStyles;//  this.allowedStyles = allowedStyles;
            //  // Store the text format.
            this._filter_xss_split(allowed_tags, true);//  this._filter_xss_split(allowed_tags, TRUE);
            //  // Remove null characters (ignored by some browsers).
            _string = Regex.Replace("","char(0)",_string);//  string = str_replace(chr(0), "", string);
            //  // Remove Netscape 4 JS entities.
            _string = Regex.Replace("", @"%&\s*\{[^}]*(\}\s*;?|)%",_string);//  string = preg_replace("%&\s*\{[^}]*(\}\s*;?|)%", "", string);
            //  // Defuse all HTML entities.
            _string = Regex.Replace("&amp","&",_string);//  string = str_replace("&", "&amp;", string);
            //  // Change back only well-formed entities in our whitelist:
            //  // Decimal numeric entities.
            _string = Regex.Replace(@"&#\1", @"/&amp;#([0-9]+;)/",_string);//  string = preg_replace("/&amp;#([0-9]+;)/", "&#\1", string);
            //  // Hexadecimal numeric entities.
            _string = Regex.Replace(@"&#x\1", "/&amp;#[Xx]0*((?:[0-9A-Fa-f]{2})+;)/",_string);//  string = preg_replace("/&amp;#[Xx]0*((?:[0-9A-Fa-f]{2})+;)/", "&#x\1", string);
            //  // Named entities.
            _string = Regex.Replace(@"&\1", "/&amp;([A-Za-z][A-Za-z0-9]*;)/", _string);//  string = preg_replace("/&amp;([A-Za-z][A-Za-z0-9]*;)/", "&\1", string);
            return preg_replace_callback(new Dictionary<string, dynamic> { {"", "_filter_xss_split" } },//  return preg_replace_callback(array(this, "_filter_xss_split")
                "%" +//"%
                "("+//    (
                "<(?=[^a-zA-Z!/]) " +//    <(?=[^a-zA-Z!/])  # a lone <
                "|"+//    |                 # or
                "<!--.*?-." +//    <!--.*?-.        # a comment
                "|"+//    |                 # or
                "<[^>]*(>|)" +//    <[^>]*(>|)       # a string that starts with a <, up until the > or the end of the string
                "|" +//    |                 # or
                ">"+//    >                 # just a >
                ")%x"//    )%x"
                , _string);//, string);

        }    //}

        public string preg_replace_callback(Dictionary<string,dynamic> input1, string input2, string input3)
        {
            return "";
        }
        /**
         * Processes an HTML tag.
         *
         * @param m
         *   An array with various meaning depending on the value of store.
         *   If store is TRUE then the array contains the allowed tags.
         *   If store is false then the array has one element, the HTML tag to process.
         * @param bool store
         *   Whether to store m.
         * @return string If the element isn"t allowed, an empty string. Otherwise, the cleaned up
         * If the element isn"t allowed, an empty string. Otherwise, the cleaned up
         * version of the HTML element.
         */
        public Dictionary<string, dynamic> _filter_xss_split(Dictionary<string, dynamic> m, bool store = false)//private void _filter_xss_split(m, store = false) 
        {//{
            string[] matches = new string[5];
            Dictionary<string, dynamic> allowed_html = null;//  static allowed_html;
            if (store)//  if (store) 
            {// {  
                allowed_html = array_flip(m);//allowed_html = array_flip(m);
                return allowed_html;//    return allowed_html;
            }//  }
            string _string = m["1"];//  string = m[1];
            if (_string.Substring(0, 1) != "<")//  if (substr(string, 0, 1) != "<") {
            {//    // We matched a lone ">" character.
                return new Dictionary<string, dynamic> { { "", "&gt;" } }; //    return "&gt;";
            }//  }
            else if (_string.Length == 1)//  elseif (strlen(string) == 1) {
            {//    // We matched a lone "<" character.
                return new Dictionary<string, dynamic> { { "", "&lt;" } };//    return "&lt;";
            }//  }

            if (!(preg_match(new Regex(@"%^<\s*(/\s*)?([a-zA-Z0-9\-]+)([^>]*)>?|(<!--.*?-.)%"),new Dictionary<string, dynamic> { { "", _string } } , matches)))//  if (!preg_match("%^<\s*(/\s*)?([a-zA-Z0-9\-]+)([^>]*)>?|(<!--.*?-.)%", string, matches)) {
            {//    // Seriously malformed.
                return new Dictionary<string, dynamic> { { "", "" } };//    return "";
            }//  }
            var slash = matches[1].Trim();//  slash = trim(matches[1]);
            var elem = matches[2];//  elem = &matches[2];
            var attrList = matches[3];//  attrList = &matches[3];
            var comment = matches[3];//  comment = &matches[4];
            if (comment != null)//  if (comment) {
            {//    elem = "!--";
                elem = "!--";
            }//  }
            if (!(allowed_html[elem.ToLower()] != null))//  if (!isset(allowed_html[strtolower(elem)])) {
            {                                          //    // Disallowed HTML element.
                return new Dictionary<string, dynamic> { {"", ""} };                                //    return "";
            }                              //  }
            if(comment!=null) {//  if (comment) {
                return new Dictionary<string, dynamic> { { "", comment } }; //    return comment;
            }//  }
            if (slash != String.Empty)                             //  if (slash != "") {
            {
             return new Dictionary<string, dynamic> { { "", "</elem>" } };   //    return "</elem>";
            }                                        //  }
                                                     //  // Is there a closing XHTML slash at the end of the attributes?
                                                     //  attrList = preg_replace("%(\s?)/\s*%", "\1", attrList, -1, count);
                                                     //  xhtml_slash = count ? " /" : "";
                                                     //  // Clean up attributes.
            string attr2 = null;
            //  attr2 = implode(" ", this._filter_xss_attributes(attrList, (in_array(elem, self::allowed_styleable_tags) ? this.allowedStyles : false)));
            attr2 = Regex.Replace("", "/[<>]/", attr2);                                         //  attr2 = preg_replace("/[<>]/", "", attr2);
            attr2 = attr2.Length > 0 ? " " + attr2 : "";                                                                             //  attr2 = strlen(attr2) ? " " . attr2 : "";
            return new Dictionary<string, dynamic> { { "0", "<elemattr2xhtml_slash>" } };//  return "<elemattr2xhtml_slash>";
        }//}
         /**
          * Processes a string of HTML attributes.
          *
          * @param attr
          * @param array|bool|object allowedStyles
          * @return array Cleaned up version of the HTML attributes.
          * Cleaned up version of the HTML attributes.
          */
        public Dictionary<string,dynamic> _filter_xss_attributes(string attr, bool allowedStyles = false)//private void _filter_xss_attributes(attr, allowedStyles = false)
        {// {
            var attrArr = new Dictionary<string, dynamic>();//  attrArr = array();
            int mode = 0;//  mode = 0;
            string attrName = "";//  attrName = "";
            bool skip = false;//  skip = false;
            var match = new string[1];
            while (attr.Length != 0)//  while (strlen(attr) != 0) {
            {//    // Was the last operation successful?
                int working = 0;//    working = 0;
                switch (mode)//    switch (mode) {
                {
                    case 0://      case 0:
                           //        // Attribute name, href for instance.
                        if (preg_match(new Regex(@"/^([-a-zA-Z]+)/"), new Dictionary<string, dynamic> { { "", attr } }, match))//        if (preg_match("/^([-a-zA-Z]+)/", attr, match)) {
                        {
                            attrName = match[1].ToLower();//          attrName = strtolower(match[1]);
                            skip = attrName == "style" || attrName.Substring(0, 2) == "on";//          skip = (attrName == "style" || substr(attrName, 0, 2) == "on");
                            working = 1;//          working = mode = 1;
                            attr = Regex.Replace("", @"/^[-a-zA-Z]+/", attr);//          attr = preg_replace("/^[-a-zA-Z]+/", "", attr);
                        }//        }
                        break;//        break;
                    case 1://      case 1:
                           //        // Equals sign or valueless ("selected").
                        if (preg_match(new Regex(@"/^\s*=\s*/"), new Dictionary<string, dynamic> { { "", attr } }))//        if (preg_match("/^\s*=\s*/", attr)) {
                        {
                            working = 1;
                            mode = 2;//          working = 1; mode = 2;
                            attr = Regex.Replace("", @"/^\s*=\s*/", attr);//          attr = preg_replace("/^\s*=\s*/", "", attr);
                                                                          //          break;
                        }//        }
                        if (preg_match(new Regex(@"/^\s+/"), new Dictionary<string, dynamic> { { "", attr } }))//        if (preg_match("/^\s+/", attr)) {
                        {
                            working = 1;
                            mode = 2;//          working = 1; mode = 0;
                            if (!skip)//          if (!skip) {
                            {
                                attrArr[""] = attrName;//            attrArr[] = attrName;

                            } //          }
                            attr = Regex.Replace("", @"/^\s+/", attr);//          attr = preg_replace("/^\s+/", "", attr);
                        }//        }
                        break; //        break;
                    case 2://      case 2:
                           //        // Attribute value, a URL after href= for instance.
                        if (preg_match(new Regex(@"/^''([^ '']*''(\s +|) / "), new Dictionary<string, dynamic> { { "", attr } }, match))//        if (preg_match(" /^"([^"]*)"(\s+|)/", attr, match)) {
                        {
                            if (allowedStyles && attrName == "style")//          if (allowedStyles && attrName === "style") {
                            {//            // Allow certain styles
                                string[] _allowedStyles = new string[5];
                                foreach (string pattern in _allowedStyles)//            foreach (allowedStyles as pattern) {
                                {
                                    if (preg_match(new Regex(pattern), new Dictionary<string, dynamic> { { "", match[1] } }))//              if (preg_match(pattern, match[1])) 
                                    { // {               // All patterns are start to end patterns, and CKEditor adds one span per style
                                        attrArr[""] = "styles" + match[1] + ""; //                attrArr[] = "style="" . match[1] . """;
                                        break;//                break;
                                    }//              }
                                }//            }
                                break;//            break;
                            }//          }
                            this.filter_xss_bad_protocol(match[1]);//          thisVal = this.filter_xss_bad_protocol(match[1]);
                            if (!skip)//          if (!skip) {
                            {
                                attrArr[""] = "attrName=\"thisVal\"";//            attrArr[] = "attrName=\"thisVal\"";

                            }//          }
                            working = 1;//          working = 1;
                            mode = 0;//          mode = 0;
                            attr = Regex.Replace("", @"/''[^ '']*''(\s +|) / ", attr);//          attr = preg_replace(" /^"[^"]*"(\s+|)/", "", attr);
                            break;//          break;
                        }//        }
                        if (preg_match(new Regex(@"/^''([^ '']*)''(\s +|) / "), new Dictionary<string, dynamic> { { "", attr } }, match)) //        if (preg_match(" /^"([^"]*)"(\s+|)/", attr, match)) {
                        {
                            this.filter_xss_bad_protocol(match[1]);//          thisVal = this.filter_xss_bad_protocol(match[1]);
                            if (!skip) //          if (!skip) {
                            {
                                //            attrArr[] = "attrName="thisVal"";
                            }//          }
                            working = 1;
                            mode = 0;//          working = 1; mode = 0;
                            attr = Regex.Replace("", @"/^''[^ '']*''(\s +|) /", attr);//          attr = preg_replace(" /^"[^"]*"(\s+|)/", "", attr);
                            break;//          break;
                        }//        }
                        if (preg_match(new Regex(@"%^([^\s\""]+)(\s+|)%"), new Dictionary<string, dynamic> { { "", attr } }, match)) //        if (preg_match("%^([^\s\""]+)(\s+|)%", attr, match)) {
                        {
                            this.filter_xss_bad_protocol(match[1]);//          thisVal = this.filter_xss_bad_protocol(match[1]);
                            if (!skip)//          if (!skip) {
                            {

                                attrArr[""] = @"attrName=\''thisVal\''";//            attrArr[] = "attrName=\"thisVal\"";
                            }//          }
                            working = 1;
                            mode = 0;//          working = 1; mode = 0;
                            attr = Regex.Replace("", @"%^[^\s\""]+(\s+|)%", attr);//          attr = preg_replace("%^[^\s\""]+(\s+|)%", "", attr);
                        }//        }
                        break;//        break;
                }//    }
                if (working == 0)//    if (working == 0) {
                {//      // Not well formed; remove and try again.
                    attr = Regex.Replace("",//      attr = preg_replace("/
                       "/^(" +          //        ^          //        (
                       "[^'']* (''|)" + //        "[^"]*("|)     # - a string that starts with a double quote, up until the next double quote or the end of the string
                       "|" +  //        |               # or
                       "\"[^\"]*(\"|)|" + //        \"[^\"]*(\"|)| # - a string that starts with a quote, up until the next quote or the end of the string
                          "|" +  //        |               # or
                          @"\S" +//        \S              # - a non-whitespace character
                          ")*" +//        )*              # any number of the above three
                          @"\s*" +//        \s*             # any number of whitespaces
                          "/x''" //        /x", 
                       , attr);//, attr);

                    mode = 0; //      mode = 0;
                }//    }
            }//  }
             //  // The attribute list ends with a valueless attribute like "selected".
            if (mode == 1 && !skip)//  if (mode == 1 && !skip) {
            {
                attrArr[""] = attrName; //    attrArr[] = attrName;
            }     //  }
            return attrArr;//  return attrArr;
        }//}
                 // TODO: Remove Drupal related stuff in docs.
                 /**
                  * Processes an HTML attribute value and strips dangerous protocols from URLs.
                  *
                  * @param string
                  *   The string with the attribute value.
                  * @param bool decode
                  *   (deprecated) Whether to decode entities in the string. Set to false if the
                  *   string is in plain text, TRUE otherwise. Defaults to TRUE. This parameter
                  *   is deprecated and will be removed in Drupal 8. To process a plain-text URI,
                  *   call _strip_dangerous_protocols() or check_url() instead.
                  * @return string Cleaned up and HTML-escaped version of string.
                  * Cleaned up and HTML-escaped version of string.
                  */

        public string html_entity_decode(string _input, object input2, string input3)
        {
            return "";
        }

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
         ///**
        // * Strips dangerous protocols (e.g. "javascript:") from a URI.
        // *
        // * This void must be called for all URIs within user-entered input prior
        // * to being output to an HTML attribute value. It is often called as part of
        // * check_url() or filter_xss(), but those voids return an HTML-encoded
        // * string, so this void can be called independently when the output needs to
        // * be a plain-text string for passing to t(), l(), drupal_attributes(), or
        // * another void that will call check_plain() separately.
        // *
        // * @param uri
        // *   A plain-text URI that might contain dangerous protocols.
        // * @return string A plain-text URI stripped of dangerous protocols. As with all plain-text
        // * A plain-text URI stripped of dangerous protocols. As with all plain-text
        // * strings, this return value must not be output to an HTML page without
        // * check_plain() being called on it. However, it can be passed to voids
        // * expecting plain-text strings.
        // * @see check_url()
        // */
        public Dictionary<string,dynamic> array_flip(Dictionary<string,dynamic> array)
        {
            return null;
        }
        public string _strip_dangerous_protocols(string uri)//private void _strip_dangerous_protocols(uri)
        { //{
            var allowed_protocols = new Dictionary<string,dynamic>();//  static allowed_protocols;
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
        public Dictionary<string,dynamic> getCopyrightSemantics()
        {
            var semantics = new Dictionary<string, dynamic>();
            var cc_versions = new Dictionary<string, dynamic>();
            semantics = null;//  static semantics;
            if (semantics == null)
            {//  if (semantics === null) {
                cc_versions = new Dictionary<string, dynamic>() { //      (object) array(
                    { "value", "4.0" }, { "label", this.h5pF.t("4.0 International") }, //        "value" => "4.0", //        "label" => this.h5pF.t("4.0 International")
                    { "value", "3.0" }, { "label", this.h5pF.t("3.0 Unported") },   //        "value" => "3.0", //        "label" => this.h5pF.t("3.0 Unported")
                    { "value", "2.5" }, { "label", this.h5pF.t("2.5 Generic") },//        "value" => "2.5", //        "label" => this.h5pF.t("2.5 Generic")
                    { "value", "2.0" }, { "label", this.h5pF.t("2.0 Generic") },  //        "value" => "2.0", //        "label" => this.h5pF.t("2.0 Generic")
                    { "value", "1.0" }, { "label", this.h5pF.t("1.0 Generic") }//        "value" => "1.0",//        "label" => this.h5pF.t("1.0 Generic")
                };
                semantics = new Dictionary<string, dynamic> {
                          
                    //    semantics = (object) array(
                    //      "name" => "copyright",
                    //      "type" => "group",
                    //      "label" => this.h5pF.t("Copyright information"),
                    //      "fields" => array(
                    //        (object) array(
                    //          "name" => "title",
                    //          "type" => "text",
                    //          "label" => this.h5pF.t("Title"),
                    //          "placeholder" => "La Gioconda",
                    //          "optional" => TRUE
                    //        ),
                    { "name","copyright"},
                    { "type","group"},
                    { "label",this.h5pF.t("Copyright information")},
                    { "fields" ,new Dictionary<string,dynamic>
                    {
                            { "",new Dictionary<string,dynamic>
                            {

                                { "name","title"},
                                { "type","text"},
                                { "label",this.h5pF.t("Title")},
                                { "placeholder","La Gioconda"},
                                { "optional",true}
                            }
                            },
                            
                    //        (object) array(
                    //          "name" => "author",
                    //          "type" => "text",
                    //          "label" => this.h5pF.t("Author"),
                    //          "placeholder" => "Leonardo da Vinci",
                    //          "optional" => TRUE
                    //        ),
                            { "",new Dictionary<string,dynamic>
                            {

                                { "name","author"},
                                { "type","text"},
                                { "label",this.h5pF.t("Author")},
                                { "placeholder","Leonardo da Vinci"},
                                { "optional",true}
                            }
                            },
                    //        (object) array(
                    //          "name" => "year",
                    //          "type" => "text",
                    //          "label" => this.h5pF.t("Year(s)"),
                    //          "placeholder" => "1503 - 1517",
                    //          "optional" => TRUE
                    //        ),
                            { "",new Dictionary<string,dynamic>
                            {

                                { "name","year"},
                                { "type","text"},
                                { "label",this.h5pF.t("Year(s)")},
                                { "placeholder","1503 - 1517"},
                                { "optional",true}
                            }
                            },
                    //        (object) array(
                    //          "name" => "source",
                    //          "type" => "text",
                    //          "label" => this.h5pF.t("Source"),
                    //          "placeholder" => "http://en.wikipedia.org/wiki/Mona_Lisa",
                    //          "optional" => true,
                    //          "regexp" => (object) array(
                    //            "pattern" => "^http[s]?://.+",
                    //            "modifiers" => "i"
                    //          )
                    //        ),
                            { "",new Dictionary<string,dynamic>
                            {

                                { "name","source"},
                                { "type","text"},
                                { "label",this.h5pF.t("Source")},
                                { "placeholder",@"http://en.wikipedia.org/wiki/Mona_Lisa"},
                                { "optional",true},
                                { "regex", new Dictionary<string, dynamic>
                                {
                                    { "pattern","^http[s]?://.+"},
                                    { "modifiers", "i"}
                                }
                                }
                            }
                            },
                    //        (object) array(
                    //          "name" => "license",
                    //          "type" => "select",
                    //          "label" => this.h5pF.t("License"),
                    //          "default" => "U",
                    //          "options" => array(
                    //            (object) array(
                    //              "value" => "U",
                    //              "label" => this.h5pF.t("Undisclosed")
                    //            ),
                            { "",new Dictionary<string,dynamic>
                            {

                                { "name","license"},
                                { "type","select"},
                                { "label",this.h5pF.t("License")},
                                { "default","U" },
                                { "options", new Dictionary<string, dynamic>
                                {
                                    { "value","U"},
                                    { "label", this.h5pF.t("Undisclosed")}
                                }
                                }
                            }
                            },
                    //            (object) array(
                    //              "value" => "CC BY",
                    //              "label" => this.h5pF.t("Attribution"),
                    //              "versions" => cc_versions
                    //            ),
                            { "",new Dictionary<string,dynamic>
                            {

                                { "value","CC BY"},
                                { "label",this.h5pF.t("Attribution")},
                                { "versions",cc_versions },
                            }
                            },
                    //            (object) array(
                    //              "value" => "CC BY-SA",
                    //              "label" => this.h5pF.t("Attribution-ShareAlike"),
                    //              "versions" => cc_versions
                    //            ),
                            { "",new Dictionary<string,dynamic>
                            {

                                { "value","CC BY-SA"},
                                { "label",this.h5pF.t("Attribution-ShareAlike")},
                                { "versions",cc_versions },
                            }
                            },
                    //            (object) array(
                    //              "value" => "CC BY-ND",
                    //              "label" => this.h5pF.t("Attribution-NoDerivs"),
                    //              "versions" => cc_versions
                    //            ),
                            { "",new Dictionary<string,dynamic>
                            {

                                { "value","CC BY-ND"},
                                { "label",this.h5pF.t("Attribution-NoDerivs")},
                                { "versions",cc_versions },
                            }
                            },

                    //            (object) array(
                    //              "value" => "CC BY-NC",
                    //              "label" => this.h5pF.t("Attribution-NonCommercial"),
                    //              "versions" => cc_versions
                    //            ),
                            { "",new Dictionary<string,dynamic>
                            {

                                { "value","CC BY-NC"},
                                { "label",this.h5pF.t("Attribution-NonCommercial")},
                                { "versions",cc_versions },
                            }
                            },
                    //            (object) array(
                    //              "value" => "CC BY-NC-SA",
                    //              "label" => this.h5pF.t("Attribution-NonCommercial-ShareAlike"),
                    //              "versions" => cc_versions
                    //            ),
                            { "",new Dictionary<string,dynamic>
                            {

                                { "value","CC BY-NC-SA"},
                                { "label",this.h5pF.t("Attribution-NonCommercial-ShareAlike")},
                                { "versions",cc_versions },
                            }
                            },
                    //            (object) array(
                    //              "value" => "CC BY-NC-ND",
                    //              "label" => this.h5pF.t("Attribution-NonCommercial-NoDerivs"),
                    //              "versions" => cc_versions
                    //            ),
                            { "",new Dictionary<string,dynamic>
                            {

                                { "value","CC BY-NC-ND"},
                                { "label",this.h5pF.t("Attribution-NonCommercial-NoDerivs")},
                                { "versions",cc_versions },
                            }
                            },
                    //            (object) array(
                    //              "value" => "GNU GPL",
                    //              "label" => this.h5pF.t("General Public License"),
                    //              "versions" => array(
                    //                (object) array(
                    //                  "value" => "v3",
                    //                  "label" => this.h5pF.t("Version 3")
                    //                ),
                    //                (object) array(
                    //                  "value" => "v2",
                    //                  "label" => this.h5pF.t("Version 2")
                    //                ),
                    //                (object) array(
                    //                  "value" => "v1",
                    //                  "label" => this.h5pF.t("Version 1")
                    //                )
                    //              )
                    //            ),
                            {
                            "",new Dictionary<string,dynamic>
                            {

                                { "value","GNU GPL"},
                                { "label",this.h5pF.t("General Public License")},
                                { "versions",new Dictionary<string , dynamic>
                                {
                                    {"", new Dictionary<string,dynamic>
                                        {
                                                { "value", "v3"},
                                                { "label", this.h5pF.t("Version 3")}
                                        }
                                    },
                                    {"", new Dictionary<string,dynamic>
                                        {
                                                { "value", "v2"},
                                                { "label", this.h5pF.t("Version 2")}
                                        }
                                    },
                                    {"", new Dictionary<string,dynamic>
                                        {
                                                { "value", "v1"},
                                                { "label", this.h5pF.t("Version 1")}
                                        }
                                    },
                                }
                            }
                            }
                        },
                        //            (object) array(
                        //              "value" => "PD",
                        //              "label" => this.h5pF.t("Public Domain"),
                        //              "versions" => array(
                        //                (object) array(
                        //                  "value" => "-",
                        //                  "label" => "-"
                        //                ),
                        //                (object) array(
                        //                  "value" => "CC0 1.0",
                        //                  "label" => this.h5pF.t("CC0 1.0 Universal")
                        //                ),
                        //                (object) array(
                        //                  "value" => "CC PDM",
                        //                  "label" => this.h5pF.t("Public Domain Mark")
                        //                )
                        //              )
                        //            ),
                        {
                            "",new Dictionary<string,dynamic>
                            {

                                { "value","PD"},
                                { "label",this.h5pF.t("Public Domain")},
                                { "versions",new Dictionary<string , dynamic>
                                {
                                    {"", new Dictionary<string,dynamic>
                                        {
                                                { "value", "-"},
                                                { "label", "-"}
                                        }
                                    },
                                    {"", new Dictionary<string,dynamic>
                                        {
                                                { "value", "CC0 1.0"},
                                                { "label", this.h5pF.t("CC0 1.0 Universal")}
                                        }
                                    },
                                    {"", new Dictionary<string,dynamic>
                                        {
                                                { "value", "CC PDM"},
                                                { "label", this.h5pF.t("Public Domain Mark")}
                                        }
                                    }
                                }
                            }
                            }
                        },
                        //            (object) array(
                        //              "value" => "C",
                        //              "label" => this.h5pF.t("Copyright")
                        //            )
                        //          )
                        //        ),
                         {
                            "",new Dictionary<string,dynamic>
                            {

                                { "value","C"},
                                { "label",this.h5pF.t("Copyright")},                           
                            }
                        },
                        //        (object) array(
                        //          "name" => "version",
                        //          "type" => "select",
                        //          "label" => this.h5pF.t("License Version"),
                        //          "options" => array()
                        //        )
                        //      )
                        //    );
                        {
                            "",new Dictionary<string,dynamic>
                            {

                                { "name","version"},
                                { "type","select"},
                                { "label" , this.h5pF.t("License Version")},
                                { "options", new Dictionary<string,dynamic>()}
                            }
                        },
                    }
                    }
                };
                                                                                                                                                
                                                                                                                                          
            }//  }
             return semantics;//  return semantics;
        }
    }
}
    

