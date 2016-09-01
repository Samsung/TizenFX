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
    }
}
