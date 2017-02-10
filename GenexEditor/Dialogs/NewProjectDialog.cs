using System;
using System.IO;
using Eto.Forms;

namespace GenexEditor
{
    partial class NewProjectDialog : Dialog<Tuple<bool, string, string>>
    {
        public NewProjectDialog()
        {
            InitializeComponent();
            Result = Tuple.Create(false, "", "");
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            var location = _fileLocation.FilePath;
            if ((bool)_checkSubFolder.Checked)
                location = Path.Combine(location, _entryName.Text);

            Result = Tuple.Create(true, location, _entryName.Text);
            Close();
        }
    }
}
