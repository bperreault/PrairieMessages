using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Reflection;
using System.IO;
using System.Collections.Specialized;

namespace PrairieMessages
{
    class MessagesPage : BasePage, IPage
    {
        public string GetContent()
        {
            string html = GetHtmlFromResources();
            var data =  GetListsOfMessagesFromDB();
            string css =  GetCssfromResources();
            string scripts =  GetScripts();
            string content = html.Replace("[data]", data).Replace("[script]", scripts).Replace("[css]", css);
            return content;
        }

        public string GetHtmlFromResources()
        {
            return GetResource("messages.html");
        }

        public string GetListsOfMessagesFromDB()
        {
            List<MessagesModel> msgs = new MessagesRepository().GetListOfMessages();
            string returnjson = new JavaScriptSerializer().Serialize(msgs);
            return returnjson;
        }

        public string GetScripts()
        {
            return GetResource("messages.js");
        }

        public string GetCssfromResources()
        {
            return GetResource("messages.css");
        }
    }
}
