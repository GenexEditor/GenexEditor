using System;
using System.Collections.Generic;

namespace GenexEditor
{
    enum Response
    {
        Yes,
        No,
        Cancel
    }

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

        bool ShowYesNoDialog(string title, string message);

        Response ShowYesNoCancelDialog(string title, string message);

        // General

        void ReloadRecentList(List<RecentItem> items);
    }
}
