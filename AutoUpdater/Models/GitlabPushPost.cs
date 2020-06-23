using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AutoUpdater.Models
{

    public class GitlabPushPost
    {
        public string object_kind { get; set; }
        public string event_name { get; set; }
        public string before { get; set; }
        public string after { get; set; }
        public string _ref { get; set; }
        public string checkout_sha { get; set; }
        public object message { get; set; }
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_username { get; set; }
        public string user_email { get; set; }
        public string user_avatar { get; set; }
        public int project_id { get; set; }
        public Project project { get; set; }
        public Commit[] commits { get; set; }
        public int total_commits_count { get; set; }
        public Push_Options push_options { get; set; }
        public Repository repository { get; set; }
    }

    public class Project
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string web_url { get; set; }
        public object avatar_url { get; set; }
        public string git_ssh_url { get; set; }
        public string git_http_url { get; set; }
        public string _namespace { get; set; }
        public int visibility_level { get; set; }
        public string path_with_namespace { get; set; }
        public string default_branch { get; set; }
        public object ci_config_path { get; set; }
        public string homepage { get; set; }
        public string url { get; set; }
        public string ssh_url { get; set; }
        public string http_url { get; set; }
    }

    public class Push_Options
    {
    }

    public class Repository
    {
        public string name { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public string homepage { get; set; }
        public string git_http_url { get; set; }
        public string git_ssh_url { get; set; }
        public int visibility_level { get; set; }
    }

    public class Commit
    {
        public string id { get; set; }
        public string message { get; set; }
        public DateTime timestamp { get; set; }
        public string url { get; set; }
        public Author author { get; set; }
        public string[] added { get; set; }
        public string[] modified { get; set; }
        public object[] removed { get; set; }
    }

    public class Author
    {
        public string name { get; set; }
        public string email { get; set; }
    }


}
