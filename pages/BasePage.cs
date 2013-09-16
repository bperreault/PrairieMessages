using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace PrairieMessages
{
    class BasePage
    {
        protected string GetResource(string resourcename)
        {
            foreach (string resource in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                if (resource.EndsWith(resourcename))
                {
                    Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);
                    byte[] buff = new byte[s.Length];
                    s.Read(buff, 0, buff.Length);

                    return Encoding.UTF8.GetString(buff);
                }
            }
            return string.Empty;
        }
    }
}
