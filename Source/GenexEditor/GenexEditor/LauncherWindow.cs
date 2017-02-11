using System;
using System.IO;
using System.Linq;
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

        public void ReloadRecentList(List<string> filePaths)
        {
            var children = _stackLayout.Children.ToArray();
            foreach (var child in children)
                _stackLayout.Remove(child);

            foreach (var filePath in filePaths)
            {
                _stackLayout.Add(new RecentProjectControl(Path.GetFileName(filePath), filePath));
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

        private void Drawable1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;


        }
    }
}
