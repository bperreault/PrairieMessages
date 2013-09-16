using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrairieMessages
{
    interface IPage
    {
        string GetContent();
        string GetHtmlFromResources();
        string GetScripts();
        string GetCssfromResources();
    }
}
