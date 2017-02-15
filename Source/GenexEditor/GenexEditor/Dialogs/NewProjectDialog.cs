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
            ReloadCreate(this, EventArgs.Empty);
        }

        private void ReloadCreate(object sender, EventArgs e)
        {
            var enabled = true;
            enabled &= !string.IsNullOrEmpty(_entryName.Text);
            enabled &= Directory.Exists(_fileLocation.FilePath);

            _buttonCreate.Enabled = enabled;
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
