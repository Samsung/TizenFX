using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class NDalicVisual
        {
            static NDalicVisual()
            {
                Tizen.Log.Error("NUI", "NDalicVisual");
            }

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VISUAL_PROPERTY_TYPE_get")]
            public static extern int VISUAL_PROPERTY_TYPE_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VISUAL_PROPERTY_SHADER_get")]
            public static extern int VISUAL_PROPERTY_SHADER_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VISUAL_SHADER_VERTEX_get")]
            public static extern int VISUAL_SHADER_VERTEX_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VISUAL_SHADER_FRAGMENT_get")]
            public static extern int VISUAL_SHADER_FRAGMENT_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VISUAL_SHADER_SUBDIVIDE_GRID_X_get")]
            public static extern int VISUAL_SHADER_SUBDIVIDE_GRID_X_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VISUAL_SHADER_SUBDIVIDE_GRID_Y_get")]
            public static extern int VISUAL_SHADER_SUBDIVIDE_GRID_Y_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VISUAL_SHADER_HINTS_get")]
            public static extern int VISUAL_SHADER_HINTS_get();

        }
    }
}
