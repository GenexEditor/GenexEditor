using System.IO;

namespace GenexEditor
{
    static class Controller
    {
        private static Settings _settings;
        private static IView _view;

        public static void Attach(IView view)
        {
            _settings = Settings.Load();

            _view = view;
            _view.ReloadRecentList(_settings.RecentList);
            _view.ShowLauncherWindow();
        }

        public static void NewProject()
        {
            var ret = _view.ShowNewProjectDialog();

            if (ret.Item1)
            {
                var path = Path.Combine(ret.Item2, ret.Item3 + ".gex");

                if (!Directory.Exists(ret.Item2))
                    Directory.CreateDirectory(ret.Item2);

                File.WriteAllLines(path, new string[0]);
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
            if (!_settings.RecentList.Contains(filePath))
            {
                _settings.RecentList.Insert(0, filePath);
                _settings.Save();

                _view.ReloadRecentList(_settings.RecentList);
            }

            _view.ShowMainWindow();
        }
    }
}
