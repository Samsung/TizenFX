using System;

namespace ElmSharp
{
    public class Conformant : Widget
    {
        public Conformant(Window parent) : base(parent)
        {
            Interop.Evas.evas_object_size_hint_weight_set(Handle, 1.0, 1.0);
            Interop.Elementary.elm_win_conformant_set(parent.Handle, true);
            parent.AddResizeObject(this);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_conformant_add(parent.Handle);
        }
    }
}
