using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Infrastructure;

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
                                                 mp3File = c.mp3File,
                                                 UID = c.UID
                                            })
                                            .OrderByDescending(m => m.DateCreated)
                                            .ToList();

            }
            return msgs;
        }

        public List<MessagesModel> GetMessagesInSeries( string seriesName )
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
                                                 mp3File = c.mp3File,
                                                 UID = c.UID
                                            })
                                            .Where( m => m.Series.Equals(seriesName))
                                            .OrderByDescending(m => m.DateCreated)
                                            .ToList();

            }
            return msgs;
        }

        public MessagesModel SaveMessage(MessagesModel mm)
        {
             using (MessagesContainer cr = new MessagesContainer())
            {
                message msg = null;
                if (mm.UID > 0)
                {                    
                    msg = cr.messages.Where(m => m.UID == mm.UID).FirstOrDefault();
                }
                if (msg == null)
                {
                    msg = new message();
                    cr.Entry(msg).State = System.Data.EntityState.Added;
                }
                
                msg.MessageTitle = mm.MessageTitle;
                msg.DateCreated = mm.DateCreated;
                msg.MessageDescription = mm.MessageDescription;
                msg.MessageAuthor = mm.MessageAuthor;
                msg.MessageHardCopy = mm.MessageHardCopy;
                msg.Series = mm.Series;
                msg.VideoFile = mm.VideoFile;
                msg.mp3File = mm.mp3File;
                try
                {
                    cr.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException DbEx)
                {
                    mm.errorMessage = DbEx.ToString();
                }
                finally
                {
                    mm.UID = msg.UID;
                    ((IObjectContextAdapter)cr).ObjectContext.Detach(msg);
                }

            }
             return mm;
        }
    }
}
