using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5P
{
    public abstract class H5P_Event_Base
    {
        const int LOG_NONE = 0;
        const int LOG_ALL = 1;
        const int LOG_ACTIONS = 2;
        public static string log_level = "";
        public static string log_time = ""; // 30 Days
        protected string id, type, sub_type, content_id, content_title, library_name, library_version, time;
        abstract protected void save();
        abstract protected void saveStats();

        public void _construct(string type, string sub_type = null, string content_id = null, string content_title = null, string library_name = null, string library_version = null)
        {
            this.type = type;
            this.sub_type = sub_type;
            this.content_id = content_id;
            this.content_title = content_title;
            this.library_name = library_name;
            this.library_version = library_version;
            this.time = DateTime.Now.ToShortTimeString();

            if (validLogLevel(type, sub_type))
            {
                this.save();
            }
            if (validStats(type, sub_type))
            {

            }
        }

        public bool validStats(string type, string sub_type)
        {
            if ((type == "content" && sub_type == "shortcode insert") ||
                (type == "library" && sub_type == null) ||
                (type == "results" && sub_type == "content"))
            {
                return true;
            }
            else if (isAction(type, sub_type)) { // Count all actions
                return true;
            }
            else
                return false;
        }

        public bool in_array(string sub_type, string[] array)
        {
            return true;
        }
        public bool isAction(string type, string sub_type)
        {
            string[] array1 = { "create", "create upload", "update", "update upload", "upgrade", "delete" };
            string[] array2 = { "create", "update" };
            if ((type == "content" && in_array(sub_type, array1)) ||
            (type == "library" && in_array(sub_type, array2)))
            {
                return true;
            }
            return false;
        }
        public bool validLogLevel(string type, string sub_type)
        {

            switch (log_level)
            {
                case "LOG_NONE":
                    return false;
                    break;
                case "LOG_ALL":
                    return true;
                    break;
                case "LOG_ACTIONS":
                    if (isAction(type, sub_type))
                    { return true; }
                    else
                    {
                        return false;
                    }
            }
            return false;
        }

        public Dictionary<string,dynamic> getDataArray()
        {
            Dictionary<string,dynamic> ht = new Dictionary<string,dynamic>();
            ht.Add("created_at", String.IsNullOrEmpty(this.time) ? String.Empty : this.time);
            ht.Add("type", String.IsNullOrEmpty(this.type) ? String.Empty : this.type);
            ht.Add("sub_type", String.IsNullOrEmpty(this.sub_type) ? String.Empty : this.sub_type);
            ht.Add("content_id", String.IsNullOrEmpty(this.content_id) ? String.Empty : this.content_id);
            ht.Add("content_title", String.IsNullOrEmpty(this.content_title) ? String.Empty : content_title);
            ht.Add("library_name", String.IsNullOrEmpty(this.library_name) ? String.Empty : this.library_name);
            ht.Add("library_version", String.IsNullOrEmpty(this.library_version) ? String.Empty : this.library_version);
            //var result = new DataArray {
            //    created_at = String.IsNullOrEmpty(this.time) ? String.Empty : this.time,
            //    type = String.IsNullOrEmpty(this.type) ? String.Empty : this.type,
            //    sub_type = String.IsNullOrEmpty(this.sub_type) ? String.Empty : this.sub_type,
            //    content_id = String.IsNullOrEmpty(this.content_id) ? String.Empty : this.content_id,
            //    content_title = String.IsNullOrEmpty(this.content_title) ? String.Empty : content_title,
            //    library_name = String.IsNullOrEmpty(this.library_name) ? String.Empty : this.library_name,
            //    library_version = String.IsNullOrEmpty(this.library_version) ? String.Empty : this.library_version
            //};
            //return result;
            return ht;
        }

        public string[] getFormatArray()
        {
            string[] result = {  "%d",
                            "%s",
                            "%s",
                            "%d",
                            "%s",
                            "%s",
                            "%s"};
            return result;
        }
    }
}




