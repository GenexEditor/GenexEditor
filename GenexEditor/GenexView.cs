using System;
using System.Collections.Generic;
using Eto.Forms;

namespace GenexEditor
{
    class GenexView : IView
    {
        private Form _currentWindow;
        private LauncherWindow _launcherWindow;
        private MainWindow _mainWindow;
        private FileFilter _allFileFilter, _gexFileFilter;

        public GenexView()
        {
            _launcherWindow = new LauncherWindow();
            _mainWindow = new MainWindow();

            _allFileFilter = new FileFilter("All Files (*.*)", new[] { ".*" });
            _gexFileFilter = new FileFilter("Genex Editor Project Files (*.gex)", new[] { ".gex" });
        }

        // Windows

        public void ShowLauncherWindow()
        {
            _launcherWindow.Show();
            if (_currentWindow != null)
                _currentWindow.Close();
            _currentWindow = _launcherWindow;
        }

        public void ShowMainWindow()
        {
            _mainWindow.Show();
            if (_currentWindow != null)
                _currentWindow.Close();
            _currentWindow = _mainWindow;
        }

        // Dialogs

        public Tuple<bool, string, string> ShowNewProjectDialog()
        {
            // TODO: Implement new project dialog

            return Tuple.Create(false, "", "");
        }

        public Tuple<bool, string> ShowOpenProjectDialog()
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Select Genex Editor Project File";
            dialog.Filters.Add(_gexFileFilter);
            dialog.Filters.Add(_allFileFilter);
            dialog.CurrentFilter = _gexFileFilter;

            var result = dialog.ShowDialog(_currentWindow) == DialogResult.Ok;
            return Tuple.Create(result, result ? dialog.FileName : "");
        }

        // General

        public void ReloadRecentList(List<string> filePaths)
        {
            _launcherWindow.ReloadRecentList(filePaths);
        }
    }
}
