using System;
using Eto.Forms;
using Eto.Drawing;

namespace GenexEditor
{
    partial class LauncherWindow : Form
    {
        private Button _buttonNew, _buttonOpen;
        private Scrollable _scollable1;
        private DynamicLayout _stackLayout;

        private void InitializeComponent()
        {
            // Layout
            Title = "Genex Editor";
            Width = 800;
            Height = 440;

            var layout1 = new DynamicLayout();
            layout1.DefaultPadding = new Padding(10);
            layout1.DefaultSpacing = new Size(10, 10);
            {
                var layout2 = new DynamicLayout();
                layout2.DefaultSpacing = new Size(4, 4);
                layout2.BeginHorizontal();
                {
                    _buttonNew = new Button();
                    _buttonNew.Text = "New";
                    layout2.Add(_buttonNew);

                    _buttonOpen = new Button();
                    _buttonOpen.Text = "Open";
                    layout2.Add(_buttonOpen);

                    layout2.Add(null, true, true);
                }
                layout1.Add(layout2);

                _scollable1 = new Scrollable();
                _scollable1.ExpandContentWidth = true;
                _scollable1.ExpandContentHeight = false;
                _scollable1.BackgroundColor = SystemColors.ControlBackground;
                {
                    _stackLayout = new DynamicLayout();
                    _scollable1.Content = _stackLayout;
                }
                layout1.Add(_scollable1, true, true);
            }
            Content = layout1;

            // Events
            _buttonNew.Click += ButtonNew_Click;
            _buttonOpen.Click += ButtonOpen_Click;
        }
    }
}
