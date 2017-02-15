using System;
using Eto.Forms;
using Eto.Drawing;
using GenexEditor.Core;

namespace GenexEditor
{
    partial class NewProjectDialog : Dialog<Tuple<bool, string, string>>
    {
        private TextBox _entryName;
        private FilePicker _fileLocation;
        private CheckBox _checkSubFolder;
        private Button _buttonCreate, _buttonCancel;

        private void InitializeComponent()
        {
            // Layouts
            Title = "New Project Dialog";
            Resizable = true;
            MinimumSize = new Size(480, 320);
            Size = new Size(520, 360);

            var layout1 = new DynamicLayout();
            {
                var layout2 = new DynamicLayout();
                layout2.DefaultPadding = new Padding(20, 0);
                layout2.DefaultSpacing = new Size(20, 6);
                {
                    layout2.BeginVertical();

                    layout2.BeginHorizontal();
                    {
                        var label1 = new Label();
                        label1.VerticalAlignment = VerticalAlignment.Center;
                        label1.Text = "Project Name:";
                        layout2.Add(label1);

                        _entryName = new TextBox();
                        layout2.Add(_entryName, true, false);
                    }
                    layout2.EndHorizontal();

                    layout2.BeginHorizontal();
                    {
                        var label2 = new Label();
                        label2.VerticalAlignment = VerticalAlignment.Center;
                        label2.Text = "Location:";
                        layout2.Add(label2);

                        _fileLocation = new FilePicker();
                        _fileLocation.FileAction = Eto.FileAction.SelectFolder;
                        _fileLocation.FilePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + (CurrentPlatform.IsLinux ? "/Documents" : "");
                        layout2.Add(_fileLocation, true, false);
                    }
                    layout2.EndHorizontal();

                    layout2.BeginHorizontal();
                    {
                        layout2.Add(null, false, false);

                        _checkSubFolder = new CheckBox();
                        _checkSubFolder.Text = "Create Subfolder";
                        _checkSubFolder.Checked = true;
                        layout2.Add(_checkSubFolder, true, false);
                    }
                    layout2.EndHorizontal();
                }
                layout1.Add(new ExtraSpacing(layout2, false), true, true);

                var layout3 = new DynamicLayout();
                layout3.DefaultSpacing = new Size(10, 10);
                layout3.DefaultPadding = new Padding(10);
                layout3.BeginHorizontal();
                {
                    _buttonCancel = new Button();
                    _buttonCancel.Text = "Cancel";
                    layout3.Add(_buttonCancel);

                    layout3.Add(null, true, false);

                    _buttonCreate = new Button();
                    _buttonCreate.Text = "Create";
                    layout3.Add(_buttonCreate);
                }

                var extra = new ExtraSpacing(layout3, false);
                extra.BackgroundColor = SystemColors.ControlBackground;
                layout1.Add(extra);
            }

            Content = layout1;

            DefaultButton = _buttonCreate;
            AbortButton = _buttonCancel;

            // Events
            _entryName.TextChanged += ReloadCreate;
            _fileLocation.FilePathChanged += ReloadCreate;
            _buttonCancel.Click += ButtonCancel_Click;
            _buttonCreate.Click += ButtonCreate_Click;
        }
    }
}
