using Eto.Forms;
using Eto;

namespace GenexEditor
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var app = new Application(Platform.Detect);
            var view = new GenexView();

            Controller.Attach(view);
            app.Run();
        }
    }
}
