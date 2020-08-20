using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW7.Models;

namespace HW7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*string uri = "/api/user";
            string token = System.Web.Configuration.WebConfigurationManager.AppSettings["GitHubToken"];
            string data = SendRequest(uri, token, "lawlouis");
            User user = JsonConvert.DeserializeObject<User>(data);*/
            return View();
        }

        public JsonResult User()
        {
            string uri = "https://api.github.com/user";
            Debug.WriteLine(uri);
            string token = System.Web.Configuration.WebConfigurationManager.AppSettings["GitHubToken"];
            string data = SendRequest(uri, token, "lawlouis");
            JObject obj = JObject.Parse(data);
            var jsonData = new
            { 
                Name = (string)obj["name"], 
                Username = (string)obj["login"], 
                Email = (string)obj["email"], 
                Company = (string)obj["company"], 
                Location = (string)obj["location"], 
                AvatarURL = (string)obj["avatar_url"],
                URL = (string)obj["html_url"]
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Repo()
        {
            string uri = "https://api.github.com/user/repos";
            Debug.WriteLine(uri);
            string token = System.Web.Configuration.WebConfigurationManager.AppSettings["GitHubToken"];
            string data = SendRequest(uri, token, "lawlouis");
            JArray arr = JArray.Parse(data);
            List<object> repos = new List<object>();
            for (int i = 0; i < arr.Count(); ++i)
            {
                repos.Add(new
                {
                    Name = (string)arr[i]["name"],
                    Owner = (string)arr[i]["owner"]["login"],
                    URL = (string)arr[i]["html_url"],
                    AvatarUrl = (string)arr[i]["owner"]["avatar_url"],
                    LastUpdated = (DateTime.Now - (DateTime)arr[i]["updated_at"]).Days
                });
            }
            return Json(repos, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Commit(string user, string repo)
        {
            string uri = "https://api.github.com/repos/" + user + "/" + repo + "/" + "commits";
            Debug.WriteLine(uri);
            string token = System.Web.Configuration.WebConfigurationManager.AppSettings["GitHubToken"];
            string data = SendRequest(uri, token, "lawlouis");
            JArray arr = JArray.Parse(data);
            List<object> commits = new List<object>();
            for (int i = 0; i < arr.Count(); ++i)
            {
                commits.Add(new
                {
                    Sha = (string)arr[i]["sha"],
                    Commiter = (string)arr[i]["commit"]["committer"]["name"],
                    WhenCommited = ((DateTime)arr[i]["commit"]["committer"]["date"]).ToString(),
                    CommitMessage = (string)arr[i]["commit"]["message"],
                    HtmlUrl = (string)arr[i]["html_url"]
                });
            }
            return Json(commits, JsonRequestBehavior.AllowGet);
        }

        private string SendRequest(string uri, string credentials, string username)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Headers.Add("Authorization", "token " + credentials);
            request.UserAgent = username;       // Required, see: https://developer.github.com/v3/#user-agent-required
            request.Accept = "application/json";

            string jsonString = null;
            // TODO: You should handle exceptions here
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    Stream stream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(stream);
                    jsonString = reader.ReadToEnd();
                    reader.Close();
                    stream.Close();
                }
            }
            catch(System.Net.WebException exception)
            {
                Debug.WriteLine(exception);
            }
            
            return jsonString;
        }
    }
}