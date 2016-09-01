using System;

namespace ElmSharp
{
    public class Background : Layout
    {
        public Background(EvasObject parent) : base(parent)
        {
        }

        public override Color Color
        {
            get
            {
                int r;
                int g;
                int b;
                Interop.Elementary.elm_bg_color_get(Handle, out r, out g, out b);
                Color value = base.Color;
                return new Color(r, g, b, value.A);
            }
            set
            {
                base.Color = value;
                Interop.Elementary.elm_bg_color_set(Handle, value.R, value.G, value.B);
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
