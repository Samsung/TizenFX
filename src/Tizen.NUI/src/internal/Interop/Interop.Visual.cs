using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Visual
        {

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Visual_Property_TRANSFORM_get")]
            public static extern int Visual_Property_TRANSFORM_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Visual_Property_PREMULTIPLIED_ALPHA_get")]
            public static extern int Visual_Property_PREMULTIPLIED_ALPHA_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Visual_Property_MIX_COLOR_get")]
            public static extern int Visual_Property_MIX_COLOR_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Image_Visual_BORDER_get")]
            public static extern int Image_Visual_BORDER_get();

        }
    }
}
