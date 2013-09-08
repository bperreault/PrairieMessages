using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrairieMessages
{
    class MessagesRepository
    {
        public List<MessagesModel> GetListOfMessages()
        {
            List<MessagesModel> msgs = null;
            using (MessagesContainer cr = new MessagesContainer())
            {

                msgs = (from c in cr.messages
                                            select new MessagesModel()
                                            {
                                                 MessageTitle = c.MessageTitle,
                                                 DateCreated = c.DateCreated,
                                                 MessageDescription = c.MessageDescription,
                                                 MessageAuthor = c.MessageAuthor,
                                                 MessageHardCopy = c.MessageHardCopy,
                                                 Series = c.Series,
                                                 VideoFile = c.VideoFile,
                                                 mp3File = c.mp3File
                                            }).ToList();

            }
            return msgs;
        }
    }
}
