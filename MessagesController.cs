using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace PrairieMessages
{
    public class MessagesController 
    {
        
        public string GetContent()
        {
            MessagesPage mp = new MessagesPage();
            string content = mp.GetContent();
            return content;
        }

        public string GetAdminPages()
        {
            AdminPage ap = new AdminPage();
            string content = ap.GetContent();
            return content;
        }

        /// <summary>
        /// method name is the last parameter 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        public string GetBridgeData(string method, string json)
        {
            switch (method)
            {

                case "getRSSFeed":
                    return getRSSFeed();
                case "saveMessage":
                    return saveMessage(json);
                default:
                    return "No bridge data found for: " + method;
            }
        }

       

        public string saveMessage(string json)
        {

            JObject jobject = JObject.Parse(json);
            JToken form = jobject["message"];

            DateTime dt = DateTime.Now;
            DateTime.TryParse( form["DateCreated"].ToString(), out dt);
            int uid = -1;
            int.TryParse(form["UID"].ToString(), out uid);
            MessagesModel mm = new MessagesModel()
            {
                MessageTitle = form["MessageTitle"].ToString(),
                DateCreated = dt,
                MessageDescription = form["MessageDescription"].ToString(),
                MessageAuthor = form["MessageAuthor"].ToString(),
                MessageHardCopy = form["MessageHardCopy"].ToString(),
                Series = form["Series"].ToString(),
                VideoFile = form["VideoFile"].ToString(),
                mp3File = form["mp3File"].ToString(),
                UID = uid
            };

            MessagesModel mm2 = new MessagesRepository().SaveMessage(mm);
            string returnjson = new JavaScriptSerializer().Serialize(mm2);
            return returnjson;
        }
        public string getRSSFeed(){
            return "getrssfeed";
        }

        string GetMessagesInSeriesFromDB( string seriesName )
         {
            List<MessagesModel> msgs = new MessagesRepository().GetMessagesInSeries( seriesName);
            string returnjson = new JavaScriptSerializer().Serialize(msgs);
            return returnjson;
        }

 
    }
}
