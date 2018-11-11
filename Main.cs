using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using Microsoft.Win32;
using Wox.Infrastructure;
using Wox.Infrastructure.Storage;

namespace Wox.Plugin.Doc
{
    public class Main : IPlugin, ISettingProvider, ISavable
    {
        private static DocSet docSet = new DocSet();
        private Settings _settings;
        private PluginJsonStorage<Settings> _storage;

        public Main()
        {
            _storage = new PluginJsonStorage<Settings>();
            _settings = _storage.Load();
        }


        public List<Result> Query(Query query)
        {
            // TODO get rid of warning by using query.(First|Second|Third)Search
            if (string.IsNullOrEmpty(query.GetAllRemainingParameter().Trim()))
            {
                return new List<Result>();
            }

            return docSet.Query(query.GetAllRemainingParameter());
        }

        public void Init(PluginInitContext context)
        {
            docSet.Load(context.CurrentPluginMetadata.PluginDirectory, _settings);
        }

        public System.Windows.Controls.Control CreateSettingPanel()
        {
            return new SettingPanel(_settings);
        }

        public void Save()
        {
            _storage.Save();
        }
    }
}
