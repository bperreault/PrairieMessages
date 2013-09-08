using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using PrairiePluginLib;
using System.Reflection;

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
        
    }
}
