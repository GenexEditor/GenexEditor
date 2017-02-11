using Eto.Forms;
using Eto;
using GenexEditor.Core;

namespace GenexEditor
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            CurrentPlatform.IsLinux = true;
            CurrentPlatform.IsUnix = true;

            var app = new Application(Platform.Detect);
            var view = new GenexView();

            Controller.Attach(view);
            app.Run();
        }
    }
}
