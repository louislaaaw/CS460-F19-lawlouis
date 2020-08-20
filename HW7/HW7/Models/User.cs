using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW7.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string AvatarURL { get; set; }
        public string URL { get; set; }
        /*public IList<Repo> RepoList { get; set; }*/
    }
}