using Eto.Forms;
using GenexEditor.Core;

namespace GenexEditor
{
    partial class MainWindow : Form
    {
        private ButtonMenuItem _menuRecent;
        private Command _cmdNewProject, _cmdNewFile, _cmdOpen, _cmdSave, _cmdSaveAs, _cmdSaveAll, _cmdCloseProject, _cmdCloseTab, _cmdQuit;
        private Command _cmdUndo, _cmdRedo, _cmdPreferences;
        private Command _cmdViewHelp, _cmdAbout;

        private void InitializeComponent()
        {
            Title = "Genex Editor";
            Width = 1024;
            Height = 768;

            InitalizeCommands();
            InitalizeMenus();
        }

        private void InitalizeCommands()
        {
            // File Menu

            _cmdNewProject = new Command();
            _cmdNewProject.MenuText = "New Project...";
            _cmdNewProject.Shortcut = Keys.Control | Keys.Shift | Keys.N;
            _cmdNewProject.Executed += (sender, e) => Controller.NewProject();

            _cmdNewFile = new Command();
            _cmdNewFile.MenuText = "New File...";
            _cmdNewFile.Shortcut = Keys.Control | Keys.N;

            _cmdOpen = new Command();
            _cmdOpen.MenuText = "Open...";
            _cmdOpen.Shortcut = Keys.Control | Keys.O;
            _cmdOpen.Executed += (sender, e) => Controller.OpenProject();

            _cmdSave = new Command();
            _cmdSave.MenuText = "Save";
            _cmdSave.Shortcut = Keys.Control | Keys.S;
            _cmdSave.Executed += (sender, e) => Controller.Save(false);

            _cmdSaveAs = new Command();
            _cmdSaveAs.MenuText = "Save As...";
            _cmdSaveAs.Shortcut = Keys.Control | Keys.Shift | Keys.S;

            _cmdSaveAll = new Command();
            _cmdSaveAll.MenuText = "Save All";
            _cmdSaveAll.Executed += (sender, e) => Controller.Save(true);

            _cmdCloseProject = new Command();
            _cmdCloseProject.MenuText = "Close Project";
            _cmdCloseProject.Shortcut = Keys.Control | Keys.Alt | Keys.W;
            _cmdCloseProject.Executed += (sender, e) => Controller.CloseProject();

            _cmdCloseTab = new Command();
            _cmdCloseTab.MenuText = "Close";
            _cmdCloseTab.Shortcut = Keys.Control | Keys.W;

            _cmdQuit = new Command();
            _cmdQuit.MenuText = CurrentPlatform.IsUnix ? "Quit" : "Exit";
            _cmdQuit.Shortcut = Keys.Control | Keys.Q;
            _cmdQuit.Executed += (sender, e) => Close();

            // Edit Menu

            _cmdUndo = new Command();
            _cmdUndo.MenuText = "Undo";
            _cmdUndo.Shortcut = Keys.Control | Keys.Z;

            _cmdRedo = new Command();
            _cmdRedo.MenuText = "Redo";
            _cmdRedo.Shortcut = Keys.Control | Keys.Shift | Keys.Z;

            _cmdPreferences = new Command();
            _cmdPreferences.MenuText = "Preferences...";

            // Help Menu

            _cmdViewHelp = new Command();
            _cmdViewHelp.MenuText = "View Help";
            _cmdViewHelp.Shortcut = Keys.F1;

            _cmdAbout = new Command();
            _cmdAbout.MenuText = "About";
            _cmdAbout.Executed += (sender, e) => Controller.Modify();
        }

        private void InitalizeMenus()
        {
            Menu = new MenuBar();

            _menuRecent = new ButtonMenuItem();
            _menuRecent.Text = "Recent Projects";

            Menu.Items.Add(new ButtonMenuItem
            {
                Text = "File",
                Items =
                {
                    _cmdNewProject,
                    _cmdNewFile,
                    new SeparatorMenuItem(),
                    _cmdOpen,
                    new SeparatorMenuItem(),
                    _menuRecent,
                    new SeparatorMenuItem(),
                    _cmdSave,
                    _cmdSaveAs,
                    _cmdSaveAll,
                    new SeparatorMenuItem(),
                    _cmdCloseProject,
                    _cmdCloseTab
                }
            });

            Menu.Items.Add(new ButtonMenuItem
            {
                Text = "Edit",
                Items =
                {
                    _cmdUndo,
                    _cmdRedo,
                    new SeparatorMenuItem(),
                    _cmdPreferences
                }
            });

            Menu.Items.Add(new ButtonMenuItem
            {
                Text = "Help",
                Items =
                {
                    _cmdViewHelp
                }
            });

            Menu.QuitItem = _cmdQuit;
            Menu.AboutItem = _cmdAbout;
        }
    }
}
