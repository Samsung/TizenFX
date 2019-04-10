using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class NDalicColorVisual
        {
            static NDalicColorVisual()
            {
                Tizen.Log.Error("NUI", "NDalicColorVisual");
            }

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_COLOR_VISUAL_MIX_COLOR_get")]
            public static extern int COLOR_VISUAL_MIX_COLOR_get();
        }
    }
}
