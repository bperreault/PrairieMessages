using System;
using System.Collections.Generic;
using System.Linq;

namespace PrairieMessages
{
    class MessagesModel
    {
        public string errorMessage { get; set; }
           public string MessageTitle { set; get; }
           public DateTime DateCreated { set; get; }
           //public string DateCreated {
           //    set {
           //        DateTime dt = DateTime.Now;
           //        DateTime.TryParse(value, out dt);
           //        DateFormatDateCreated = dt;
           //    }
           //    get { 
           //        return DateFormatDateCreated.ToShortDateString();
           //    } }
           public string MessageDescription { set; get; }
           public string MessageAuthor { set; get; }
           public string MessageHardCopy { set; get; }
           public string Series { set; get; }
           public string VideoFile { set; get; }
           public string mp3File { set; get; }
           public int UID { set; get; }
           public string messageClass { get; set; }

    }
}
