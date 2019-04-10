using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class NDalicColor
        {
            static NDalicColor()
            {
                Tizen.Log.Error("NUI", "NDalicColor");
            }

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_BLACK_get")]
            public static extern global::System.IntPtr BLACK_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WHITE_get")]
            public static extern global::System.IntPtr WHITE_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_RED_get")]
            public static extern global::System.IntPtr RED_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GREEN_get")]
            public static extern global::System.IntPtr GREEN_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_BLUE_get")]
            public static extern global::System.IntPtr BLUE_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_YELLOW_get")]
            public static extern global::System.IntPtr YELLOW_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_MAGENTA_get")]
            public static extern global::System.IntPtr MAGENTA_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_CYAN_get")]
            public static extern global::System.IntPtr CYAN_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_TRANSPARENT_get")]
            public static extern global::System.IntPtr TRANSPARENT_get();

        }
    }
}
