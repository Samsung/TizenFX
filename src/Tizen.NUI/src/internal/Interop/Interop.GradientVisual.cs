using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class NDalicGradientVisual
        {
            static NDalicGradientVisual()
            {
                Tizen.Log.Error("NUI", "GradientVisual");
            }



            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_START_POSITION_get")]
            public static extern int GRADIENT_VISUAL_START_POSITION_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_END_POSITION_get")]
            public static extern int GRADIENT_VISUAL_END_POSITION_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_CENTER_get")]
            public static extern int GRADIENT_VISUAL_CENTER_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_RADIUS_get")]
            public static extern int GRADIENT_VISUAL_RADIUS_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_STOP_OFFSET_get")]
            public static extern int GRADIENT_VISUAL_STOP_OFFSET_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_STOP_COLOR_get")]
            public static extern int GRADIENT_VISUAL_STOP_COLOR_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_UNITS_get")]
            public static extern int GRADIENT_VISUAL_UNITS_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GRADIENT_VISUAL_SPREAD_METHOD_get")]
            public static extern int GRADIENT_VISUAL_SPREAD_METHOD_get();

        }
    }
}
