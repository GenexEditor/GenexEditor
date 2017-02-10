using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;

namespace GenexEditor
{
    public class Settings
    {
        private const string SettingsPath = "Settings.xml";

        private static IsolatedStorageFile _storage;
        private static bool _storageInit;

        public List<string> RecentList;

        private Settings()
        {
            RecentList = new List<string>();
        }

        public static Settings Load()
        {
            try
            {
                _storage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
                _storageInit = true;
            }
            catch { }

            var ret = new Settings();

            if (_storageInit && _storage.FileExists(SettingsPath))
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
            if (!_storageInit)
                return;

            try
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
            catch { }
        }
    }
}
