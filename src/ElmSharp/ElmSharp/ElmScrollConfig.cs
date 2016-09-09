using System;

namespace ElmSharp
{
    public static class ElmScrollConfig
    {
        public static double BringInScrollFriction
        {
            get
            {
                return Interop.Elementary.elm_config_scroll_bring_in_scroll_friction_get();
            }
            set
            {
                Interop.Elementary.elm_config_scroll_bring_in_scroll_friction_set(value);
            }
        }
    }
}
