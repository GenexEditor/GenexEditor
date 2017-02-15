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
                _currentWindow.Visible = false;
            _currentWindow = _launcherWindow;
            _currentWindow.BringToFront();
        }

        public void ShowMainWindow()
        {
            _mainWindow.Show();

            if (_currentWindow != null)
                _currentWindow.Visible = false;
            _currentWindow = _mainWindow;
            _currentWindow.BringToFront();
        }

        // Dialogs

        public Tuple<bool, string, string> ShowNewProjectDialog()
        {
            var dialog = new NewProjectDialog();
            return dialog.ShowModal(_currentWindow);
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

        public bool ShowYesNoDialog(string title, string message)
        {
            var result = MessageBox.Show(_currentWindow, message, title, MessageBoxButtons.YesNo);
            return result == DialogResult.Yes;
        }

        public Response ShowYesNoCancelDialog(string title, string message)
        {
            var result = MessageBox.Show(_currentWindow, message, title, MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
                return Response.Yes;

            if (result == DialogResult.No)
                return Response.No;

            return Response.Cancel;
        }

        // General

        public void ReloadRecentList(List<RecentItem> filePaths)
        {
            _launcherWindow.ReloadRecentList(filePaths);
            _mainWindow.ReloadRecentList(filePaths);
        }
    }
}
