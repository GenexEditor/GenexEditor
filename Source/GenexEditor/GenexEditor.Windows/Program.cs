using System;
using Eto.Forms;
using Eto;
using GenexEditor.Core;

namespace GenexEditor
{
    class MainClass
    {
        [STAThread]
        public static void Main(string[] args)
        {
            CurrentPlatform.IsWindows = true;

            var app = new Application(Platform.Detect);
            var view = new GenexView();

            Controller.Attach(view);
            app.Run();
        }
    }
}
