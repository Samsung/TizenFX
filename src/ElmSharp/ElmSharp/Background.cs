using System;

namespace ElmSharp
{
    public class Background : Layout
    {
        public Background(EvasObject parent) : base(parent)
        {
            Style = "transparent";
        }

        public override Color Color
        {
            get
            {
                int r = 0;
                int g = 0;
                int b = 0;
                int a = 0;
                var swallowContent = GetPartContent("elm.swallow.rectangle");
                if (swallowContent != IntPtr.Zero)
                {
                    Interop.Evas.evas_object_color_get(swallowContent, out r, out g, out b, out a);
                }
                return new Color(r, g, b, a);
            }
            set
            {
                var swallowContent = GetPartContent("elm.swallow.rectangle");
                if(swallowContent == IntPtr.Zero)
                {
                    Interop.Elementary.elm_bg_color_set(Handle, value.R, value.G, value.B);
                    swallowContent = GetPartContent("elm.swallow.rectangle");
                }
                Interop.Evas.evas_object_color_set(swallowContent, value.R, value.G, value.B, value.A);
            }
        }

        public string File
        {
            get
            {
                return Interop.Elementary.BackgroundFileGet(Handle);
            }
            set
            {
                Interop.Elementary.elm_bg_file_set(Handle, value, IntPtr.Zero);
            }
        }

        public BackgroundOptions BackgroundOption
        {
            get
            {
                return (BackgroundOptions) Interop.Elementary.elm_bg_option_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_bg_option_set(Handle, (Interop.Elementary.BackgroundOptions) value);
            }
        }

        internal override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_bg_add(parent.Handle);
        }
    }

    public enum BackgroundOptions
    {
        Center,
        Scale,
        Stretch,
        Tile
    }
}
