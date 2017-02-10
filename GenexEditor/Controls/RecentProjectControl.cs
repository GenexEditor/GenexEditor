using System;
using Eto.Forms;

namespace GenexEditor
{
    partial class RecentProjectControl : DynamicLayout
    {
        private string _title, _filePath;

        public RecentProjectControl(string title, string filePath)
        {
            _title = title;
            _filePath = filePath;

            InitializeComponent();
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            Controller.OpenProject(_filePath);
        }
    }
}
