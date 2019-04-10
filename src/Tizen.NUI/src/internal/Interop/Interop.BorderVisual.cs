using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class NDalicBorderVisual
        {
            static NDalicBorderVisual()
            {
                Tizen.Log.Error("NUI", "BorderVisual");
            }


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_BORDER_VISUAL_COLOR_get")]
            public static extern int BORDER_VISUAL_COLOR_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_BORDER_VISUAL_SIZE_get")]
            public static extern int BORDER_VISUAL_SIZE_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_BORDER_VISUAL_ANTI_ALIASING_get")]
            public static extern int BORDER_VISUAL_ANTI_ALIASING_get();

        }
    }
}
