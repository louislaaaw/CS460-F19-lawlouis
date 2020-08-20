using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW7.Models
{
    public class Repo
    {
        public Repo(string name, string owner, string url, string avatarUrl, string lastUpdated)
        {
            Name = name;
            Owner = owner;
            URL = url;
            AvatarUrl = avatarUrl;
            LastUpdated = lastUpdated;
        }

        public string Name { get; set; }
        public string Owner { get; set; }
        public string URL { get; set; }
        public string AvatarUrl { get; set; }
        public string LastUpdated { get; set; }
    }
}