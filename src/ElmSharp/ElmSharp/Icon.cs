using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmSharp
{
    public enum IconLookupOrder
    {
        FreeDesktopFirst = 0,
        ThemeFirst,
        FreeDesktopOnly,
        ThemeOnly
    }
    public class Icon : Image
    {
        public Icon(EvasObject parent) : base(parent)
        {
        }

        public string StandardIconName
        {
            get
            {
                return Interop.Elementary.elm_icon_standard_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_icon_standard_set(Handle, value);
            }
        }

        public IconLookupOrder IconLookupOrder
        {
            get
            {
                return (IconLookupOrder)Interop.Elementary.elm_icon_order_lookup_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_icon_order_lookup_set(Handle, (int)value);
            }
        }

        public void SetThumb(string file, string group)
        {
            Interop.Elementary.elm_icon_thumb_set(Handle, file, group);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_icon_add(parent);
        }
    }
}
