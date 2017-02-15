using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace GenexEditor
{
    static class Controller
    {
        private static GenexProject _project;
        private static Settings _settings;
        private static IView _view;

        public static void Attach(IView view)
        {
            _settings = Settings.Load();

            _view = view;
            _view.ReloadRecentList(_settings.RecentList);
            _view.ShowLauncherWindow();
        }

        public static void ClearRecentItems()
        {
            _settings.RecentList.Clear();
            _settings.Save();

            _view.ReloadRecentList(_settings.RecentList);
        }

        public static void CloseProject()
        {
            if (!TrySave())
                return;

            _project = null;
            _view.ShowLauncherWindow();
        }

        public static void NewProject()
        {
            var ret = _view.ShowNewProjectDialog();

            if (ret.Item1)
            {
                var path = Path.Combine(ret.Item2, "Main.gex");

                if (!Directory.Exists(ret.Item2))
                    Directory.CreateDirectory(ret.Item2);

                using (var writer = new StreamWriter(path))
                {
                    var serializer = new XmlSerializer(typeof(GenexProject));
                    serializer.Serialize(writer, new GenexProject { Title = ret.Item3 });
                }

                OpenProject(path);
            }
        }

        public static void OpenProject()
        {
            var ret = _view.ShowOpenProjectDialog();

            if (ret.Item1)
                OpenProject(ret.Item2);
        }

        public static void OpenProject(string filePath)
        {
            var index = _settings.RecentList.FindIndex((obj) => obj.FilePath == filePath);

            if (!File.Exists(filePath))
            {
                if (index != -1)
                {
                    var result = _view.ShowYesNoDialog(
                        "Project Not Found",
                        "Project \"" + Path.GetFileName(filePath) + "\" was not found, do you want to remove it from the recent projects list?"
                    );

                    if (result)
                    {
                        _settings.RecentList.RemoveAt(index);
                        _settings.Save();

                        _view.ReloadRecentList(_settings.RecentList);
                    }
                }

                return;
            }

            _project = GenexProject.Load(filePath);

            if (index == -1)
            {
                _settings.RecentList.Insert(0, new RecentItem(_project.Title, filePath));
                _settings.Save();

                _view.ReloadRecentList(_settings.RecentList);
            }

            _view.ShowMainWindow();
        }

        public static bool Quit()
        {
            return TrySave();
        }

        public static void Save(bool all)
        {
            _project.Save();
        }

        public static void Modify()
        {
            _project.Dirty = true;
        }

        private static bool TrySave()
        {
            if (_project.Dirty)
            {
                var result = _view.ShowYesNoCancelDialog("Save Project", "The project is dirty, do you wish to save the project before continuing?");

                if (result == Response.Yes)
                    Save(true);

                return result != Response.Cancel;
            }

            return true;
        }
    }
}
