using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Reflection;
using System.IO;

namespace PrairieMessages
{
    public class MessagesController 
    {
        public string GetContent()
        {
            string html = GetHtmlFromResources();
            var data = GetListsOfMessagesFromDB();
            string scripts = GetScripts();
            string content = html.Replace("[data]", data).Replace("[script]", scripts);
            
            return content;
        }

        string GetHtmlFromResources() {
            foreach (string resource in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                if (resource.EndsWith("messages.html"))
                {
                    Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);
                    byte[] buff = new byte[s.Length];
                    s.Read(buff, 0, buff.Length);

                    return Encoding.UTF8.GetString(buff);
                }
            }
            return string.Empty;
        }
        string GetListsOfMessagesFromDB() {
            List<MessagesModel> msgs = new MessagesRepository().GetListOfMessages();
            string returnjson = new JavaScriptSerializer().Serialize(msgs);
            return returnjson;
        }
        string GetScripts() {
            return "scripts";
        }
    }
}
