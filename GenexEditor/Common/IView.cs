using System;
using System.Collections.Generic;

namespace GenexEditor
{
    interface IView
    {
        // Windows

        void ShowLauncherWindow();

        void ShowMainWindow();

        // Dialogs

        /// <summary>
        /// Shows the new project dialog.
        /// </summary>
        /// <returns>Dialog result, directory path, file name.</returns>
        Tuple<bool, string, string> ShowNewProjectDialog();

        /// <summary>
        /// Shows the open project dialog.
        /// </summary>
        /// <returns>Directory result, file path.</returns>
        Tuple<bool, string> ShowOpenProjectDialog();

        // General

        void ReloadRecentList(List<string> filePaths);
    }
}
