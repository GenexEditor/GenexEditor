using Eto.Forms;
using Eto.Drawing;

namespace GenexEditor
{
    partial class RecentProjectControl : DynamicLayout
    {
        private Button _buttonOpen;

        private void InitializeComponent()
        {
            // Layout
            DefaultPadding = new Padding(10, 5);
            BeginHorizontal();

            var layout1 = new DynamicLayout();
            {
                var label = new Label();
                label.Font = new Font(label.Font.Family, label.Font.Size * 1.5f, FontStyle.Bold);
                label.Text = _title;
                layout1.Add(label);

                var label2 = new Label();
                label2.Font = new Font(label2.Font.Family, label2.Font.Size * 0.90f);
                label2.Text = _filePath;
                layout1.Add(label2);
            }
            Add(layout1);
            Add(null, true, true);

            _buttonOpen = new Button();
            _buttonOpen.Text = "Open";
            Add(new ExtraSpacing(_buttonOpen, false));

            // Events
            _buttonOpen.Click += ButtonOpen_Click;
        }
    }
}
