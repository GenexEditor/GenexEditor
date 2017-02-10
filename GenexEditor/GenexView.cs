using System;
using Eto.Forms;

namespace GenexEditor
{
    class GenexView : IView
    {
        MainWindow _mainWindow;

        public GenexView()
        {
            _mainWindow = new MainWindow();
        }

        public void ShowMainWindow()
        {
            _mainWindow.Show();
        }
    }
}
