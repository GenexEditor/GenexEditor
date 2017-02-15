using System;
using System.Collections.Generic;
using Eto.Forms;

namespace GenexEditor
{
    partial class LauncherWindow : Form
    {
        public LauncherWindow()
        {
            InitializeComponent();
        }

        public void ReloadRecentList(List<RecentItem> items)
        {
            _stackLayout.RemoveAll();
            _stackLayout.Clear();

            foreach (var item in items)
            {
                _stackLayout.Add(new RecentProjectControl(item.Title, item.FilePath));
                _stackLayout.Add(new Splitter { Orientation = Orientation.Vertical, Enabled = false });
            }

            _stackLayout.Create();
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            Controller.NewProject();
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            Controller.OpenProject();
        }
    }
}
