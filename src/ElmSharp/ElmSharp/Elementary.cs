using System;

namespace ElmSharp
{
    public static class Elementary
    {
        public static void Initialize()
        {
            Interop.Elementary.elm_init(0, null);
        }

        public static void Shutdown()
        {
            Interop.Elementary.elm_shutdown();
        }

        public static void Run()
        {
            Interop.Elementary.elm_run();
        }

        public static double GetSystemScrollFriction()
        {
            return Interop.Elementary.elm_config_scroll_bring_in_scroll_friction_get();
        }

        public static void SetSystemScrollFriction(double timeSet)
        {
            Interop.Elementary.elm_config_scroll_bring_in_scroll_friction_set(timeSet);
        }
    }
}
