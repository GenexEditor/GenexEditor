using System;
using Eto.Forms;

namespace GenexEditor
{
    class ExtraSpacing : DynamicLayout
    {
        public ExtraSpacing(Control control, bool vertical = true)
        {
            if (!vertical)
                BeginVertical();
            else
                BeginHorizontal();

            Add(null, true, true);
            Add(control);
            Add(null, true, true);
        }
    }
}
