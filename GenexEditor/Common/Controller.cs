using System;

namespace GenexEditor
{
    static class Controller
    {
        private static IView _view;

        public static void Attach(IView view)
        {
            _view = view;
            _view.ShowMainWindow();
        }
    }
}
