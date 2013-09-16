using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using PrairiePluginLib;
using System.Reflection;
using System.Collections.Specialized;

namespace PrairieMessages
{
    public class PrairieMessagesModule : IModule
        {
            public string Title
            {
                get { return "PrairieMessages"; }
            }
            public string Name
            {
                get { return Assembly.GetAssembly(GetType()).GetName().Name; }
            }
            public Version Version
            {
                get { return new Version(1, 0, 0, 0); }
            }
            public string EntryControllerName
            {
                get { return "PrairieMessages"; }
            }

            public void Install()
            {
               
            }

            public string GetHtml()
            {
                return new MessagesController().GetContent();
            }

        /// <summary>
        /// support dynamic links for ajax requests from scripts.
        /// first section is entryController name
        /// second section is dataController name
        /// third section is specific method requested
        /// anything posted are json encoded parameters to the specific method to be called.
        /// </summary>
        /// <param name="friendlyUrl"></param>
        /// <returns></returns>
            public string GetRequestedContent(string friendlyUrl, string json)
            {
                //(plugin supported public entry)friendlyUrl = "PrairieMessages.MessagesController.getSeriesForView"
                string[ ] parts = friendlyUrl.Split('.');
                if (parts.Length > 2)
                {
                    if (parts[1].Equals("MessagesController"))
                    {
                        return new MessagesController().GetBridgeData(parts[2], json);
                    }
                    
                    return "<h1>content for json request was not found" + friendlyUrl + "</h1>";
                }
                return "<h1>No Content " + friendlyUrl + "</h1>";
            }

        /// <summary>
        /// support the entry of new messages/series
        /// </summary>
        /// <returns></returns>
            public string GetAdminPages()
            {
                return new MessagesController().GetAdminPages();
            }
    }
}
