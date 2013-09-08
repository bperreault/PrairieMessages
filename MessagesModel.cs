using System;
using System.Collections.Generic;
using System.Linq;

namespace PrairieMessages
{
    class MessagesModel
    {
        
           public string MessageTitle { set; get; }
           public DateTime DateCreated { set; get; }
           public string MessageDescription { set; get; }
           public string MessageAuthor { set; get; }
           public string MessageHardCopy { set; get; }
           public string Series { set; get; }
           public string VideoFile { set; get; }
           public string mp3File { set; get; }

           public string GetJson()
           {
               return "property in messagesmodel";
           }

    }
}
