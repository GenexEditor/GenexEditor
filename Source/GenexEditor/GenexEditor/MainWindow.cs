using System.Collections.Generic;
using System.ComponentModel;
using Eto.Forms;

namespace GenexEditor
{
    partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = !Controller.Quit();
        }

        public void ReloadRecentList(List<RecentItem> items)
        {
            _menuRecent.Items.Clear();

            foreach (var item in items)
            {
                var menuitem = new ButtonMenuItem();
                menuitem.Text = item.Title;
                menuitem.Click += (sender, e) => Controller.OpenProject(item.FilePath);
                _menuRecent.Items.Add(menuitem);
            }

            _menuRecent.Items.Add(new SeparatorMenuItem());

            var clearitem = new ButtonMenuItem();
            clearitem.Text = "Clear";
            clearitem.Click += (sender, e) => Controller.ClearRecentItems();
            _menuRecent.Items.Add(clearitem);
        }
    }
}
