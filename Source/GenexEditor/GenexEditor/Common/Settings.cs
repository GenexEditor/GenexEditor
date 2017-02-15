using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;

namespace GenexEditor
{
    [Serializable]
    public class RecentItem
    {
        public string Title { get; set; }

        public string FilePath { get; set; }

        public RecentItem()
        {
            
        }

        public RecentItem(string title, string filepath) : this()
        {
            Title = title;
            FilePath = filepath;
        }
    }

    [Serializable]
    public class Settings
    {
        private const string SettingsPath = "Settings.xml";

        private static IsolatedStorageFile _storage;

        public List<RecentItem> RecentList;

        private Settings()
        {
            RecentList = new List<RecentItem>();
        }

        public static Settings Load()
        {
            _storage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            var ret = new Settings();

            if (_storage.FileExists(SettingsPath))
            {
                try
                {
                    using (var isoStream = new IsolatedStorageFileStream(SettingsPath, FileMode.Open, _storage))
                    {
                        using (var reader = new StreamReader(isoStream))
                        {
                            var serializer = new XmlSerializer(typeof(Settings));
                            ret = (Settings)serializer.Deserialize(reader);
                        }
                    }
                }
                catch { }
            }

            return ret;
        }

        public void Save()
        {
            using (var isoStream = new IsolatedStorageFileStream(SettingsPath, FileMode.Create, _storage))
            {
                using (var writer = new StreamWriter(isoStream))
                {
                    var serializer = new XmlSerializer(typeof(Settings));
                    serializer.Serialize(writer, this);
                }
            }
        }
    }
}
