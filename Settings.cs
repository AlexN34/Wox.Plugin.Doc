using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Wox.Infrastructure.Storage;

namespace Wox.Plugin.Doc
{

    public class Settings
    {
        public string CustomBrowserPath { get; set; }
        public string BrowserLocationMethod { get; set; }
    }
}
